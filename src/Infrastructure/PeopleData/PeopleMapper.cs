using Application.Interfaces;
using Domain.Models;
using Infrastructure.PeopleData.Extensions;
using Microsoft.Extensions.Logging;

namespace Infrastructure.PeopleData;

public sealed class PeopleMapper(ILogger<PeopleMapper> logger) : IDataMapper<string, Person>
{
    public IEnumerable<Person> DataMapper(IEnumerable<string> rawData)
    {
        logger.LogInformation("Started mapping data");
        var people = new List<Person>();
        var invalidData = new List<string>();
        foreach (var item in rawData)
        {
            try
            {
                people.Add(item.ToPerson());
            }
            catch
            {
                invalidData.Add(item);
            }
        }
        logger.LogInformation("Number of processed records: {number}", rawData.Count());
        logger.LogInformation("Number of valid records: {number}", people.Count());
        logger.LogInformation("Number of invalid records: {number}:", invalidData.Count());
        foreach (var invalidItem in invalidData)
        {
            logger.LogInformation(invalidItem);
        }
        return people;
    }
}
