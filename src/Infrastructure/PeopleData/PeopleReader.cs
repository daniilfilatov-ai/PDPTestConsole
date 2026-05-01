using Application.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.PeopleData;

public sealed class PeopleReader(ILogger<PeopleReader> logger) : IFileReader<string>
{
    public async Task<IEnumerable<string>> ReadAsync(string inputFilePath, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Started read file");
        var rawData = await File.ReadAllLinesAsync(inputFilePath, cancellationToken);
        logger.LogInformation("Reading complete");
        return rawData;
    }
}
