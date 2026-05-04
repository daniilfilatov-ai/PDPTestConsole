namespace Domain.Models;

public sealed class Person
{
    required public string FirstName { get; set; }
    required public string LastName { get; set; }
    public int Age { get; set; }
}
