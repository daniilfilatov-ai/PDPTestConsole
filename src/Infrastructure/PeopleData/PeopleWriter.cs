using Application.Interfaces;
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace Infrastructure.PeopleData;

public sealed class PeopleWriter(ILogger<PeopleWriter> logger) : IFileWriter<Person>
{
    public async Task WriteAsync(IEnumerable<Person> people, string outputFilePath, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Started write data");
        var outputPeopleData = new List<string>();
        foreach (var person in people)
        {
            outputPeopleData.Add($"{person.FirstName} {person.LastName} ({person.Age})");
        }
        await File.WriteAllLinesAsync(outputFilePath, outputPeopleData, cancellationToken);
        logger.LogInformation("Writing complete");
    }
}
