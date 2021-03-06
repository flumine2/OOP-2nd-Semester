using Lab_2.Repository;
using LibraryFor2ndLab.Models;
using LibraryFor2ndLab.Models.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab_2
{
    class InputUtil
    {
        private RepositoryControler _repository;

        public InputUtil(RepositoryControler repository)
        {
            _repository = repository;
        }

        public void ProcessInput()
        {
            Console.WriteLine("To sign up user - input '/create_user' and press Enter, otherwise press Enter only");
            string input = Console.ReadLine();
            if (input is "/create_user")
            {
                CreateUser();
                while (true)
                {
                    Console.WriteLine("To sign up user as customer - input '/create_customer' and press Enter." + "\n" +
                        "To sign up user as performer - input '/create_performer' and press Enter." + "\n" +
                        "To sign up another user - input '/create_user' and press Enter." + "\n" +
                        "Otherwise press Enter only");
                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "/create_customer":
                            CreateCustomer();
                            continue;
                        case "/create_performer":
                            CreatePerformer();
                            continue;
                        case "/create_user":
                            CreateUser();
                            continue;
                        default:
                            break;
                    }
                    break;
                }
            }


            if (_repository.CustomerRepository.Count == 0)
            {
                Console.WriteLine("Cannot create order objects without customers!");
                return;
            }
            if (_repository.PerformerRepository.Count == 0)
            {
                Console.WriteLine("Cannot create order objects without performers!");
                return;
            }

            Console.WriteLine("To create order - input '/create_order' and press Enter, otherwise press Enter only");
            input = Console.ReadLine();
            while (input is "/create_order")
            {
                CreateOrder();
                Console.WriteLine("To create another order - input '/create_order' and press Enter, otherwise press Enter only");
                input = Console.ReadLine();
            }

            Console.WriteLine("To create service desk - input '/create_desk' and press Enter, otherwise press Enter only");
            input = Console.ReadLine();
            while (input is "/create_desk")
            {
                CreateDesk();
                Console.WriteLine("To create another service desk - input '/create_desk' and press Enter, otherwise press Enter only");
                input = Console.ReadLine();
            }
        }

        public void PrintInfoAboutModelRelatives()
        {
            Console.WriteLine("Enter 'User', 'Customer', 'Performer', 'Order' or press Enter to exit:");
            string input = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(input))
            {
                switch (input)
                {
                    case "User":
                        PrintUserRelatives();
                        break;
                    case "Customer":
                        PrintCustomerRelatives();
                        break;
                    case "Performer":
                        PrintPerformerRelatives();
                        break;
                    case "Order":
                        PrintOrderRelatives();
                        break;
                    default: break;
                }
                Console.WriteLine("Enter 'User', 'Customer', 'Performer', 'Order' or press Enter to exit:");
                input = Console.ReadLine();
            }
        }

        private void CreateDesk()
        {
            try
            {
                Console.WriteLine("Input service desk name:");
                string serviceDeskName = Console.ReadLine();

                ServiceDesk serviceDesk = new(serviceDeskName);

                List<ValidationResult> validations = new();
                if (!Validator.TryValidateObject(serviceDesk, new ValidationContext(serviceDesk), validations, true))
                {
                    throw new Exception(string.Join(", ", validations));
                };

                Console.WriteLine("To add order to desk - input '/add_order' and press Enter, otherwise press Enter only");
                string input = Console.ReadLine();
                while (input is "/add_order")
                {
                    AddOrderToDesk(serviceDesk);
                    Console.WriteLine("To add another order to desk - input '/add_order' and press Enter, otherwise press Enter only");
                    input = Console.ReadLine();
                }

                _repository.ServiceDeskRepository.Add(serviceDesk);
                Console.WriteLine($"Service desk(id: {serviceDesk.Id}) successfully created.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong with exception: " + e.Message);
            }
        }

        private void AddOrderToDesk(ServiceDesk serviceDesk)
        {
            try
            {
                Console.WriteLine("Input adding order id:");
                long orderId = long.Parse(Console.ReadLine());
                Order order = _repository.OrderRepository.GetById(orderId);

                serviceDesk.AddNewOrder(order);

                Console.WriteLine($"Order(id: {order.Id}) successfully added to service desk(id: {serviceDesk.Id}).");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong with exception: " + e.Message);
            }
        }

        private void CreateOrder()
        {
            try
            {
                Console.WriteLine("Input customer id:");
                long customerId = long.Parse(Console.ReadLine());
                Customer customer = _repository.CustomerRepository.GetById(customerId);
                if (customer is null)
                {
                    throw new Exception("There is no customer with this id.");
                }

                Console.WriteLine("Input performer id:");
                long performerId = long.Parse(Console.ReadLine());
                Performer performer = _repository.PerformerRepository.GetById(performerId);
                if (performer is null)
                {
                    throw new Exception("There is no performer with this id.");
                }

                Console.WriteLine("Input creating date and time:");
                DateTime creationDateTime = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Input order price:");
                int price = int.Parse(Console.ReadLine());

                Order order = new(performer, customer, creationDateTime, price);

                List<ValidationResult> validations = new();
                if (!Validator.TryValidateObject(order, new ValidationContext(order), validations, true))
                {
                    throw new Exception(string.Join(", ", validations));
                };

                _repository.OrderRepository.Add(order);
                Console.WriteLine($"Order(id: {order.Id}) successfully created.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong with exception: " + e.Message);
            }
        }

        private void CreateUser()
        {
            try
            {
                Console.WriteLine("Input username:");
                string username = Console.ReadLine();
                Console.WriteLine("Input email:");
                string email = Console.ReadLine();
                Console.WriteLine("Input phone:");
                string phone = Console.ReadLine();
                Console.WriteLine("Input password:");
                string password = Console.ReadLine();
                User user = new(username, email, phone, password);

                List<ValidationResult> validations = new();
                if (!Validator.TryValidateObject(user, new ValidationContext(user), validations, true))
                {
                    throw new Exception(string.Join(", ", validations));
                };

                _repository.UserRepository.Add(user);
                Console.WriteLine($"User(id: {user.Id}) successfully sign up.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong with exception: " + e.Message);
            }
        }

        private void CreateCustomer()
        {
            try
            {
                Console.WriteLine("\"Child Care\" - 0;" + "\n" +
                    "\"Cleaning\" - 1;" + "\n" +
                    "\"Minor Repairs\" - 2;" + "\n" +
                    "\"Mixed\" - 3;" + "\n" +
                    "\"Window Cleaning\" - 4." + "\n" +
                    "Input service:");
                int.TryParse(Console.ReadLine(), out int serviceNum);
                Service service = (Service)serviceNum;

                Console.WriteLine("Input adress:");
                string adress = Console.ReadLine();

                Console.WriteLine("Input User Id:");
                long userId = long.Parse(Console.ReadLine());
                User user = _repository.UserRepository.GetById(userId);
                if (user is null)
                {
                    throw new Exception("There is no user with this id.");
                }

                Customer customer = new(service, adress, user);

                List<ValidationResult> validations = new();
                if (!Validator.TryValidateObject(customer, new ValidationContext(customer), validations, true))
                {
                    throw new Exception(string.Join(", ", validations));
                };

                _repository.CustomerRepository.Add(customer);
                Console.WriteLine($"User(id: {user.Id}) successfully sign up as the customer(id: {customer.Id}).");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong with exception: " + e.Message);
            }
        }

        private void CreatePerformer()
        {
            try
            {
                Console.WriteLine("Input name:");
                string name = Console.ReadLine();

                Console.WriteLine("Input surname:");
                string surname = Console.ReadLine();

                Console.WriteLine("Input birth date:");
                DateTime birthdate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Input User Id:");
                long userId = long.Parse(Console.ReadLine());
                User user = _repository.UserRepository.GetById(userId);
                if (user is null)
                {
                    throw new Exception("There is no user with this id.");
                }

                Performer performer = new(name, surname, birthdate, user);

                List<ValidationResult> validations = new();
                if (!Validator.TryValidateObject(performer, new ValidationContext(performer), validations, true))
                {
                    throw new Exception(string.Join(", ", validations));
                };

                _repository.PerformerRepository.Add(performer);
                Console.WriteLine($"User(id: {user.Id}) successfully sign up as the performer(id: {performer.Id}).");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong with exception: " + e.Message);
            }
        }

        private void PrintUserRelatives()
        {
            Console.WriteLine("Input User Id:");
            try
            {
                long userId = long.Parse(Console.ReadLine());
                User user = _repository.UserRepository.GetById(userId);
                if (user is null)
                {
                    throw new Exception("User not found.");
                }

                Console.WriteLine("Model:");
                Console.WriteLine(user);

                Console.WriteLine("Relatives:");

                Customer customer = _repository.CustomerRepository.FindByUserId(userId);
                if (customer is null)
                {
                    Performer performer = _repository.PerformerRepository.FindByUserId(userId);
                    if (performer is null)
                    {
                        Console.WriteLine("There is no related customer or performer.");
                    }
                    else
                    {
                        Console.WriteLine($"Performer: {performer}");
                    }
                }
                else
                {
                    Console.WriteLine($"Customer: {customer}");
                }

                List<Order> orders = _repository.OrderRepository.FindAllByUserId(userId);
                if (orders.Count == 0)
                {
                    Console.WriteLine("There is no this user related orders.");
                }
                foreach (Order order in orders)
                {
                    Console.WriteLine(order);
                }

                List<ServiceDesk> serviceDesks = _repository.ServiceDeskRepository.FindAllByUserId(userId);
                if (serviceDesks.Count == 0)
                {
                    Console.WriteLine("There is no this user related service desks.");
                }
                foreach (ServiceDesk serviceDesk in serviceDesks)
                {
                    Console.WriteLine(serviceDesk);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong: " + e.Message);
            }
        }

        private void PrintCustomerRelatives()
        {
            Console.WriteLine("Input Customer Id:");
            try
            {
                long customerId = long.Parse(Console.ReadLine());
                Customer customer = _repository.CustomerRepository.GetById(customerId);
                if (customer is null)
                {
                    throw new Exception("Customer not found.");
                }

                Console.WriteLine("Model:");
                Console.WriteLine(customer);

                Console.WriteLine("Relatives:");

                List<Order> orders = _repository.OrderRepository.FindAllByCustomerId(customerId);
                if (orders.Count == 0)
                {
                    Console.WriteLine("There is no this customer related orders.");
                }
                foreach (Order order in orders)
                {
                    Console.WriteLine(order);
                }

                List<ServiceDesk> serviceDesks = _repository.ServiceDeskRepository.FindAllByCustomerId(customerId);
                if (serviceDesks.Count == 0)
                {
                    Console.WriteLine("There is no this customer related service desks.");
                }
                foreach (ServiceDesk serviceDesk in serviceDesks)
                {
                    Console.WriteLine(serviceDesk);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong: " + e.Message);
            }
        }

        private void PrintPerformerRelatives()
        {
            Console.WriteLine("Input Performer Id:");
            try
            {
                long performerId = long.Parse(Console.ReadLine());
                Performer performer = _repository.PerformerRepository.GetById(performerId);
                if (performer is null)
                {
                    throw new Exception("Performer not found.");
                }

                Console.WriteLine("Model:");
                Console.WriteLine(performer);

                Console.WriteLine("Relatives:");

                List<Order> orders = _repository.OrderRepository.FindAllByPerformerId(performerId);
                if (orders.Count == 0)
                {
                    Console.WriteLine("There is no this performer related orders.");
                }
                foreach (Order order in orders)
                {
                    Console.WriteLine(order);
                }

                List<ServiceDesk> serviceDesks = _repository.ServiceDeskRepository.FindAllByPerformerId(performerId);
                if (serviceDesks.Count == 0)
                {
                    Console.WriteLine("There is no this performer related service desks.");
                }
                foreach (ServiceDesk serviceDesk in serviceDesks)
                {
                    Console.WriteLine(serviceDesk);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong: " + e.Message);
            }
        }

        private void PrintOrderRelatives()
        {
            Console.WriteLine("Enter Order Id:");
            try
            {
                long orderId = long.Parse(Console.ReadLine());
                Order order = _repository.OrderRepository.GetById(orderId);
                if (order is null)
                {
                    throw new Exception("User not found.");
                }

                Console.WriteLine("Model:");
                Console.WriteLine(order);

                Console.WriteLine("Relatives:");

                List<ServiceDesk> serviceDesks = _repository.ServiceDeskRepository.FindAllByOrderId(orderId);
                if (serviceDesks.Count == 0)
                {
                    Console.WriteLine("There is no this order related service desks.");
                }
                foreach (ServiceDesk serviceDesk in serviceDesks)
                {
                    Console.WriteLine(serviceDesk);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong: " + e.Message);
            }
        }
    }
}
