using Application.Interfaces;
using Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.PeopleData;

public sealed class PeopleMapper(ILogger<PeopleMapper> logger) : IDataMapper<string, string>
{
    public IEnumerable<string> DataMapper(IEnumerable<string> rawData)
    {
        logger.LogInformation("Started mapping data");
        var people = new List<string>();
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
                var personData = $"{firstName} {lastName} ({age})";
                people.Add(personData);
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
