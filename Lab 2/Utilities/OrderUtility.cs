using LibraryFor2ndLab;
using LibraryFor2ndLab.DTO;
using System;

namespace Lab_2.Utilities
{
    class OrderUtility
    {
        public static Order GetRandomOrderModel(Random random)
        {
            return new(PerformerUtility.GetRandomPerformerModel(random),
                CustomerUtility.GetRandomCustomerModel(random),
                DateTime.Today,
                random.Next(20, 1000));
        }
    }
}
