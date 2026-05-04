using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.PeopleData.Extensions;

public static class PeopleMapperExtensions
{
    public static Person ToPerson(this string rawData)
    {
        var stringParts = rawData.Split(";");
        var firstName = stringParts[0].ToUpper();
        var lastName = stringParts[1].ToUpper();
        var age = int.Parse(stringParts[2]);
        if (!firstName.Any(Char.IsLetter) || !lastName.Any(Char.IsLetter) || age <= 0)
        {
            throw new Exception();
        }
        return new Person
        {
            FirstName = firstName,
            LastName = lastName,
            Age = age
        };
    }
}
