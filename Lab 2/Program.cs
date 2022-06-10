using Lab_2.Repository;
using Lab_2.Tests;
using Lab_2.Utilities;
using LibraryFor2ndLab;
using LibraryFor2ndLab.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab_2
{
    class Program
    {
        static void Main()
        {
            //CustomTest.UserRepository.Deserialise();
            //CustomTest.CustomerRepository.Deserialise();
            //CustomTest.PerformerRepository.Deserialise();
            //CustomTest.OrderRepository.Deserialise();
            //CustomTest.ServiceDeskRepository.Deserialise();

            RepositoryControler repository = new();
            InputUtil input = new(repository);
            input.ProcessInput();
            input.PrintInfoAboutModelRelatives();

            //CustomTest.UserRepository.Serialise();
            //CustomTest.CustomerRepository.Serialise();
            //CustomTest.PerformerRepository.Serialise();
            //CustomTest.OrderRepository.Serialise();
            //CustomTest.ServiceDeskRepository.Serialise();
        }
    }
}
