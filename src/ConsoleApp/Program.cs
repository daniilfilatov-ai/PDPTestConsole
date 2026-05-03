using Application.Interfaces;
using Infrastructure.PeopleData;
using Infrastructure.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("Configuration.json", optional: false, reloadOnChange: true);

IConfiguration config = builder.Build();

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

    var inputFilePath = config["InputFilePath"];
    var outputFilePath = config["OutputFilePath"];

    if (string.IsNullOrWhiteSpace(inputFilePath) || string.IsNullOrWhiteSpace(outputFilePath))
    {
        throw new ArgumentNullException("The path to the file must exist");
    }

    using CancellationTokenSource cts = new();
    CancellationToken cancellationToken = cts.Token;

    await processor.ProcessAsync(inputFilePath, outputFilePath, cancellationToken);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred while processing people data");
}
