using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable

namespace NewThings
{
    public class NullableReferenceTypes
    {
        private static readonly string[] FirstNames = { "Allan", "Bill", "Bruce", "Israel", "John", "Matthew", "Miguel" };
        private static readonly string[] Nicknames = { "Big Boy", "Peace", "Smiles", "Tough Guy", "Traitor", "Ziggy" };
        private static readonly string[] LastNames = { "Alfreado", "de Icaza", "Gates", "Leibowitz", "Pead", "Robinson", "Wayne" };

        private List<Person>? people;

        public Person[] GetPeople() => people?.ToArray() ?? new Person[0];

        public void GeneratePeople()
        {
            Random rnd = new Random();

            // generate 10 random people
            people = Enumerable.Range(1, 10)
                .Select(id => GeneratePerson(rnd.Next(100000, 999999)))
                .ToList();

            // the generator
            Person GeneratePerson(int id)
            {
                return new Person(
                    id: id,
                    firstname: FirstNames[rnd.Next(FirstNames.Length)],
                    nickname: rnd.Next(2) == 0 ? null : Nicknames[rnd.Next(Nicknames.Length)],
                    lastname: LastNames[rnd.Next(LastNames.Length)]);
            }
        }

        public void AddPerson(string firstname, string nickname, string lastname)
        {
            Console.WriteLine($"Adding a person with {nickname.Length} characters in their nickname!");

            people?.Add(new Person(Environment.TickCount, firstname, nickname, lastname));
        }
    }

    public class Person
    {
        public Person(int id, string firstname, string? nickname, string lastname)
        {
            Id = id;
            FirstName = firstname;
            Nickname = nickname;
            LastName = lastname;
        }

        public Person(int id, string firstname, string lastname)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string? Nickname { get; set; }

        public string LastName { get; set; }

        public string Initial => FirstName[0].ToString();

        public string ShortName => $"{Initial}. {LastName}";

        public string FullName =>
            Nickname == null
                ? $"{FirstName} {LastName}"
                : $"{FirstName} '{Nickname.ToLower()}' {LastName}";
    }
}
