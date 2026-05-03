using Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infrastructure.PeopleData;

public sealed class PeopleWriter(ILogger<PeopleWriter> logger) : IFileWriter<string>
{
    public async Task WriteAsync(IEnumerable<string> people, string outputFilePath, CancellationToken cancellationToken = default)
    {
        if (!File.Exists(outputFilePath))
        {
            throw new FileNotFoundException("Output file not found");
        }
        logger.LogInformation("Started write data");
        await File.WriteAllLinesAsync(outputFilePath, people, cancellationToken);
        logger.LogInformation("Writing complete");
    }
}
