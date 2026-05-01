using Application.Interfaces;
using Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.PeopleData;

public sealed class PeopleWriter(ILogger<PeopleWriter> logger) : IFileWriter<string>
{
    public async Task WriteAsync(IEnumerable<string> people, string outputFilePath, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Started write data");
        await File.WriteAllLinesAsync(outputFilePath, people, cancellationToken);
        logger.LogInformation("Writing complete");
    }
}
