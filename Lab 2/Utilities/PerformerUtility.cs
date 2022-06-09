using LibraryFor2ndLab;
using LibraryFor2ndLab.DTO;
using System;

namespace Lab_2.Utilities
{
    class PerformerUtility
    {
        private static readonly string[] names = new string[] {"Adrianna", "Diggory", "Kathi", "Ruben", "Myra",
                 "Heorhiy", "Lyudmyla", "Vasylyna", "Sofron", "Trokhym",
                 "Lionors", "Andriy", "Tyberiy", "Nemo", "Ivan",
                 "Guiomar", "Nina", "Natali", "Yeva", "Arwen",
                 "Amadis", "Vitold", "Markiyan", "Calafia", "Medrod",
                 "Marharyta", "Anatoli", "Caspian", "Malvolio", "Cordelia",
                 "Isolda", "Gandalf", "Candide", "Polikarp", "Figaro",
                 "Tariel", "Anton", "Lukyan", "Denys", "Jorah"};

        private static readonly string[] surnames = new string[] { "Kohlberg", "Schoenbach", "Schiano", "Emory", "Urdang-brown",
                "Miranda", "Lipponen", "Luntz", "Haines", "Kester",
                "Knell", "Bloomfield", "Viggiani", "Beyer", "Dohrman",
                "Endres", "Darlington", "Rando", "Nocella", "Maron",
                "Lad", "Marquardt", "Neushul", "Pels", "Bogosian",
                "Reinagle", "Glick", "De veyra", "Ling", "Cvek",
                "Hemingway", "Mclaughlin", "Continolo", "Genest", "Novio",
                "Chaput", "Gerraughty", "Blackmar", "Iriye", "Spurr",
                "Devney", "Romaine", "Demarinis", "Merrithew", "Marzke",};

        public static Performer GetRandomPerformerModel(Random random)
        {
            int year = random.Next(1950, 2003);
            int month = random.Next(1, 13);
            int day = random.Next(1, 28);

            User user = UserUtility.GetRandomUserModel(random);

            return new(names[random.Next(0, names.Length)],
                surnames[random.Next(0, surnames.Length)],
                new DateTime(year, month, day), user);
        }
    }
}