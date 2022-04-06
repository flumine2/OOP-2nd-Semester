using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryFor2ndLab;

namespace Lab_2.Utilities
{
    class OrderUtility
    {
        public static Order GetRandomOrderModel(Random random)
        {
            return new(PerformerUtility.GetRandomPerformerModel(random),
                CustomerUtility.GetRandomCustomerModel(random),
                DateTime.Today,
                random.Next(20,1000));
        } 
    }
}
