using Application.Interfaces;
using Domain.Models;
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
                var stringParts = item.Split(";");
                var firstName = stringParts[0].ToUpper();
                var lastName = stringParts[1].ToUpper();
                var age = int.Parse(stringParts[2]);
                if(!firstName.Any(Char.IsLetter) || !lastName.Any(Char.IsLetter) || age < 0)
                {
                    throw new Exception();
                }
                people.Add(new Person
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age
                });
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
