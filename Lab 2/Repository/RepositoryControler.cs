using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.Repository
{
    class RepositoryControler
    {
        public UserRepository UserRepository { get; private set; }
        public CustomerRepository CustomerRepository { get; private set; }
        public PerformerRepository PerformerRepository { get; private set; }
        public OrderRepository OrderRepository { get; private set; }
        public ServiceDeskRepository ServiceDeskRepository { get; private set; }

        public RepositoryControler()
        {
            UserRepository = new UserRepository();
            CustomerRepository = new CustomerRepository();
            PerformerRepository = new PerformerRepository();
            OrderRepository = new OrderRepository();
            ServiceDeskRepository = new ServiceDeskRepository();
        }
    }
}
