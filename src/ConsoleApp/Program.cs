using Application.Interfaces;
using Infrastructure.Service;
using Infrastructure.PeopleData;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var services = new ServiceCollection()
    .AddLogging(builder =>
    {
        builder.AddConsole();
    })
    .AddTransient<IFileReader<string>, PeopleReader>()
    .AddTransient<IDataMapper<string, string>, PeopleMapper>()
    .AddTransient<IFileWriter<string>, PeopleWriter>()
    .AddTransient<IDataService, FileDataService<string, string>>()
    .BuildServiceProvider();

var logger = services.GetRequiredService<ILogger<Program>>();
try
{
    logger.LogInformation("Started processing people data");
    var processor = services.GetRequiredService<IDataService>();

    var inputFilePath = "";
    var outputFilePath = "";

    using CancellationTokenSource cts = new();
    CancellationToken cancellationToken = cts.Token;

    await processor.ProcessAsync(inputFilePath, outputFilePath, cancellationToken);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred while processing people data");
}
