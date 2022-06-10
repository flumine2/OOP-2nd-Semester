using LibraryFor2ndLab.Models;
using System;
using System.Collections.Generic;

namespace Lab_2.Utilities
{
    class GenerateUtility
    {
        public static List<ServiceDesk> GetRandomServiceDeskModelsList(int modelsCount, Random random)
        {
            List<ServiceDesk> desks = new();
            for (int i = 0; i < modelsCount; i++)
            {
                desks.Add(ServiceDeskUtility.GetRandomServiceDeskModel(random.Next(5, 21), random));
            }
            return desks;
        }
    }
}
