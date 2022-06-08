using Lab_2.Converters;
using Lab_2.dto;
using Lab_2.Utilities;
using LibraryFor2ndLab;
using LibraryFor2ndLab.DTO;
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
            Random random = new();
            List<ServiceDesk> desks = GenerateUtility.GetRandomServiceDeskModelsList(10, random);

            string jsonString = JsonConvert.SerializeObject(desks.Select(x => ServiceDeskConverter.ConvertToDTO(x)).ToList());

            File.WriteAllText("SeviceDesks.json", jsonString);

            var deserialisedDesks = JsonConvert.DeserializeObject<List<ServiceDeskDTO>>(File.ReadAllText("SeviceDesks.json"));

            foreach (var item in deserialisedDesks.Select(x => ServiceDeskConverter.ConvertToModel(x)))
            {
                Console.WriteLine();
                Console.WriteLine(item.ToShortString());
            }
        }
    }
}
