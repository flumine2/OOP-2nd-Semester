using LibraryFor2ndLab.Models;
using LibraryFor2ndLab.Models.Person;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Data
{
    class DataBase
    {
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Customer> Customers { get; set; }
        public ObservableCollection<Performer> Performers { get; set; }
        public ObservableCollection<Order> Orders { get; set; }
        public ObservableCollection<ServiceDesk> ServiceDesks { get; set; }

        public DataBase()
        {
            Users = new ObservableCollection<User>();
            Customers = new ObservableCollection<Customer>();
            Performers = new ObservableCollection<Performer>();
            Orders = new ObservableCollection<Order>();
            ServiceDesks = new ObservableCollection<ServiceDesk>();
        }
    }
}
