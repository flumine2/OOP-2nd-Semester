using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryFor2ndLab;

namespace Lab_2.Utilities
{
    class PerformerUtility
    {
        public static Performer GetRandomPerformerModel(Random random)
        {
            string[] name = new string[] {"Adrianna", "Diggory", "Kathi", "Ruben", "Myra",
                 "Heorhiy", "Lyudmyla", "Vasylyna", "Sofron", "Trokhym",
                 "Lionors", "Andriy", "Tyberiy", "Nemo", "Ivan",
                 "Guiomar", "Nina", "Natali", "Yeva", "Arwen",
                 "Amadis", "Vitold", "Markiyan", "Calafia", "Medrod",
                 "Marharyta", "Anatoli", "Caspian", "Malvolio", "Cordelia",
                 "Isolda", "Gandalf", "Candide", "Polikarp", "Figaro",
                 "Tariel", "Anton", "Lukyan", "Denys", "Jorah"};

            string[] surname = new string[] { "Kohlberg", "Schoenbach", "Schiano", "Emory", "Urdang-brown",
                "Miranda", "Lipponen", "Luntz", "Haines", "Kester",
                "Knell", "Bloomfield", "Viggiani", "Beyer", "Dohrman",
                "Endres", "Darlington", "Rando", "Nocella", "Maron",
                "Lad", "Marquardt", "Neushul", "Pels", "Bogosian",
                "Reinagle", "Glick", "De veyra", "Ling", "Cvek",
                "Hemingway", "Mclaughlin", "Continolo", "Genest", "Novio",
                "Chaput", "Gerraughty", "Blackmar", "Iriye", "Spurr",
                "Devney", "Romaine", "Demarinis", "Merrithew", "Marzke",};

            int year = random.Next(1950, 2003);
            int month = random.Next(1, 13);
            int day = random.Next(1, 28);

            return new(name[random.Next(0, name.Length)],
                surname[random.Next(0, surname.Length)],
                new DateTime(year, month, day));
        }
    }
}