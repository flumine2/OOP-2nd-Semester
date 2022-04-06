using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryFor2ndLab;

namespace Lab_2.dto
{
    class CustomerDTO
    {
        public Service Service;
        public string Adress;

        public CustomerDTO(Service service, string adress)
        {
            Service = service;
            Adress = adress;
        }
    }
}
