using System;
using System.Collections.Generic;
using System.IO;
using Tales;
using Tales.Persons;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CreatePersonFromPersonsCreator()
        {
            List<Person> Persons = new List<Person>();

            var textParser = new TextParser();

            PersonCreator personCreator = new PersonCreator(textParser);

           var person = FileReader.ReadAllFromDirectory("Persons/");

           Assert.IsType<Person>(personCreator.CreatePersonFromFile(person[0]));
            

        }

        [Fact]

        public void SavePersonToFile()
        {
            List<Person> Persons = new List<Person>();

            var textParser = new TextParser();

            PersonCreator personCreator = new PersonCreator(textParser);

            var person = FileReader.ReadAllFromDirectory("Persons/");

            personCreator.SavePersonToFile(personCreator.CreatePersonFromFile(person[0]));
        }
    }
}
