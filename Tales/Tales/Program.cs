using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tales.cybermagic.Tales;
using Tales.Persons;

namespace Tales
{
    class Program
    {
        private static string PersonfolderPath = "cybermagic/karty-postaci/";
        private static string TalesFolderPath = "cybermagic/opowiesci/";
        static void Main(string[] args)
        {
            List<Person> Persons = new List<Person>();

            var textParser = new TextParser();

            PersonCreator personCreator = new PersonCreator(textParser);


            FileReader.ReadAllFromDirectory(PersonfolderPath)
                .ForEach(x=> Persons
                    .Add(personCreator.CreatePersonFromFile(x)));

            //TASK 1 save fryderyk komciur to file
            personCreator.SavePersonToFile(Persons.Where(x => x.Name == "Fryderyk Komciur").FirstOrDefault());
            //TASK 2 save sum creation time of all persons and save to file
            string text = "Wszystkie postacie budowane były przez: " +
                          $"{Persons.Sum(x => x.CreationTime)/60} godzin i " +
                          $"{Persons.Sum(x => x.CreationTime) % 60} minuty";
            File.WriteAllText(Environment.CurrentDirectory + "/allPersonsTimeBuild.txt"
                , text);
            //TASK 3
            string PersonsWithoutCreationTime = "";
            foreach (Person person in Persons.Where(x => x.CreationTime <= 0))
            {
                PersonsWithoutCreationTime += person.Name+"\n";
            }

            var AvgCreationTime = Math.Round(Persons.Average(x => x.CreationTime),2);
            string[] tekst = {
                "Postacie, które nie mają podanego czasu to:\n",
                "Średni czas budowania postaci to: {AvgCreationTime} minut.\n",
                PersonsWithoutCreationTime,
                $"Uwzględniając powyższe, postacie do tej pory budowane były najpewniej { (int)AvgCreationTime / 60} godzin { AvgCreationTime % 60} minut."
            };
            File.WriteAllLines(Environment.CurrentDirectory + "/allPersonsTimeBuild.txt",
                tekst);

            //TASK 4
            string Tales = "";
            foreach (var tale in FileReader.ReadAllFromDirectory("cybermagic/opowiesci/"))
            {
                if (File.ReadAllText(tale).Contains("Magda Patiril"))
                {
                    Tales += textParser.ExtractProfileName(File.ReadAllText(tale))+"\n";
                }
            }

            tekst =
                new[]
                {
                    "Magda Patiril występowała w następujących Opowieściach:\n",
                    Tales

                };
            File.WriteAllLines(Environment.CurrentDirectory + "/allPersonsTimeBuild.txt",
                tekst);

            Console.ReadLine();
        }

       
    }
}
