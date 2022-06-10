using LibraryFor2ndLab.DTO;
using LibraryFor2ndLab.Models;
using LibraryFor2ndLab.Models.Person;
using System;

namespace Lab_2.Utilities
{
    class OrderUtility
    {
        public static Order GetRandomOrderModel(Random random)
        {
            return new(
                PerformerUtility.GetRandomPerformerModel(random),
                CustomerUtility.GetRandomCustomerModel(random),
                DateTime.Today,
                random.Next(20, 1000));
        }

        public static Order GetRandomOrderModel(Random random, Customer customer, Performer performer)
        {
            return new(
                performer,
                customer,
                DateTime.Today,
                random.Next(20, 1000));
        }
    }
}
