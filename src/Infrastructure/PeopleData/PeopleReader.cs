using Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infrastructure.PeopleData;

public sealed class PeopleReader(ILogger<PeopleReader> logger) : IFileReader<string>
{
    public async Task<IEnumerable<string>> ReadAsync(string inputFilePath, CancellationToken cancellationToken = default)
    {
        if (!File.Exists(inputFilePath))
        {
            throw new FileNotFoundException("Input file not found");
        }
        logger.LogInformation("Started read file");
        var rawData = await File.ReadAllLinesAsync(inputFilePath, cancellationToken);
        logger.LogInformation("Reading complete");
        return rawData;
    }
}
