using Lab6.Data.Repositories.APIs;
using LibraryFor2ndLab.Models;
using System.Collections.ObjectModel;

namespace Lab6.Data.Repositories
{
    class RepositoryControler
    {
        public DataBase DataBase { get; private set; }

        public UserRepository UserRepository { get; private set; }
        public CustomerRepository CustomerRepository { get; private set; }
        public PerformerRepository PerformerRepository { get; private set; }
        public OrderRepository OrderRepository { get; private set; }
        public ServiceDeskRepository ServiceDeskRepository { get; private set; }

        public RepositoryControler()
        {
            DataBase = new DataBase();

            UserRepository = new UserRepository(DataBase);
            CustomerRepository = new CustomerRepository(DataBase);
            PerformerRepository = new PerformerRepository(DataBase);
            OrderRepository = new OrderRepository(DataBase);
            ServiceDeskRepository = new ServiceDeskRepository(DataBase);
        }

        public ObservableCollection<ServiceDesk> GetServiceDesk()
        {
            return DataBase.ServiceDesks;
        }
    }
}
