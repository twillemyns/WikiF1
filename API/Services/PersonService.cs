using WikiF1.API.Models;

namespace WikiF1.API.Services;

public static class PersonService
{
    private static List<Person> Persons { get;  }

    private static int nextId = 3;
    
    static PersonService()
    {
        Persons = new List<Person>
        {
            new Person
            {
                Id = 1, LastName = "Verstappen", FirstName = "Max", PictureUrl = "",
                BirthDate = new DateTime(1997, 09, 30),IsDriver = true, TeamId = 1, RecordId = 1
            },
            new Person
            {
                Id = 2, LastName = "Pérez", FirstName = "Sergio", PictureUrl = "",
                BirthDate = new DateTime(1990, 01, 26),IsDriver = true , TeamId = 1, RecordId = 2
            },
            new Person
            {
                Id = 3, LastName = "Horner", FirstName = "Christian", PictureUrl = "",
                BirthDate = new DateTime(1973, 11, 16),IsDriver = false , TeamId = 1, RecordId = 3
            },
        };
    }

    public static List<Person> GetAll() => Persons;
    
    public static List<Person> GetDrivers() => Persons.FindAll(p => p.IsDriver == true);
    public static List<Person> GetTeamPrincipals() => Persons.FindAll(p => p.IsDriver == false);

    public static Person? Get(int id) => Persons.FirstOrDefault(p => p.Id == id);

    public static void Add(Person person)
    {
        person.Id = nextId++;
        Persons.Add(person);
    }

    public static void Delete(int id)
    {
        var person = Get(id);
        if (person is null)
        {
            return;
        }
        Persons.Remove(person);
    }

    public static void Update(Person person)
    {
        var index = Persons.FindIndex(p => p.Id == person.Id);
        if (index == -1)
        {
            return;
        }

        Persons[index] = person;
    }
}