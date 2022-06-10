using Lab_2.Repository;
using Lab_2.Utilities;
using LibraryFor2ndLab.Models;
using LibraryFor2ndLab.Models.Person;
using System;

namespace Lab_2.Tests
{
    static class CustomTest
    {
        public static UserRepository UserRepository = new();
        public static CustomerRepository CustomerRepository = new();
        public static PerformerRepository PerformerRepository = new();
        public static OrderRepository OrderRepository = new();
        public static ServiceDeskRepository ServiceDeskRepository = new();

        public static void TestData(Random random)
        {
            #region User Region

            User user1 = UserUtility.GetRandomUserModel(random); // 1
            UserRepository.Add(user1);
            User user2 = UserUtility.GetRandomUserModel(random); // 2
            UserRepository.Add(user2);
            User user3 = UserUtility.GetRandomUserModel(random); // 3
            UserRepository.Add(user3);
            User user4 = UserUtility.GetRandomUserModel(random); // 4
            UserRepository.Add(user4);
            User user5 = UserUtility.GetRandomUserModel(random); // 5
            UserRepository.Add(user5);
            User user6 = UserUtility.GetRandomUserModel(random); // 6
            UserRepository.Add(user6);
            User user7 = UserUtility.GetRandomUserModel(random); // 7
            UserRepository.Add(user7);
            User user8 = UserUtility.GetRandomUserModel(random); // 8
            UserRepository.Add(user8);

            #endregion

            #region Customer Region

            Customer customer1 = CustomerUtility.GetRandomCustomerModel(random, user1, Service.ChildCare);      // 1
            CustomerRepository.Add(customer1);

            //Customer customer1a = CustomerUtility.GetRandomCustomerModel(random, user1, Service.ChildCare);     // user check test

            Customer customer2 = CustomerUtility.GetRandomCustomerModel(random, user2, Service.Cleaning);       // 2
            CustomerRepository.Add(customer2);
            Customer customer3 = CustomerUtility.GetRandomCustomerModel(random, user3, Service.MinorRepairs);   // 3
            CustomerRepository.Add(customer3);
            Customer customer4 = CustomerUtility.GetRandomCustomerModel(random, user4, Service.Mixed);          // 4
            CustomerRepository.Add(customer4);
            Customer customer5 = CustomerUtility.GetRandomCustomerModel(random, user5, Service.WindowCleaning); // 5
            CustomerRepository.Add(customer5);

            #endregion

            #region Performer Region

            //Performer performer1a = PerformerUtility.GetRandomPerformerModel(random, user1);    // user check test

            Performer performer1 = PerformerUtility.GetRandomPerformerModel(random, user6);     // 1
            PerformerRepository.Add(performer1);
            Performer performer2 = PerformerUtility.GetRandomPerformerModel(random, user7);     // 2
            PerformerRepository.Add(performer2);

            #endregion

            #region Order Region

            Order order1 = OrderUtility.GetRandomOrderModel(random, customer1, performer1); // 1
            OrderRepository.Add(order1);
            Order order2 = OrderUtility.GetRandomOrderModel(random, customer2, performer2); // 2
            OrderRepository.Add(order2);
            Order order3 = OrderUtility.GetRandomOrderModel(random, customer3, performer1); // 3
            OrderRepository.Add(order3);
            Order order4 = OrderUtility.GetRandomOrderModel(random, customer4, performer2); // 4
            OrderRepository.Add(order4);
            Order order5 = OrderUtility.GetRandomOrderModel(random, customer5, performer1); // 5
            OrderRepository.Add(order5);
            Order order6 = OrderUtility.GetRandomOrderModel(random, customer5, performer2); // 6
            OrderRepository.Add(order6);

            #endregion

            #region Service Region

            ServiceDesk serviceDesk1 = ServiceDeskUtility.GetRandomServiceDeskModel(random, order1, order2, order3); // 1
            ServiceDeskRepository.Add(serviceDesk1);
            ServiceDesk serviceDesk2 = ServiceDeskUtility.GetRandomServiceDeskModel(random, order4, order5, order6); // 2
            ServiceDeskRepository.Add(serviceDesk2);

            #endregion

            foreach (var item in ServiceDeskRepository.FindAllByUserId(user1.Id))
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("===========================");
            foreach (var item in ServiceDeskRepository.FindAllByUserId(user2.Id))
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("===========================");
            foreach (var item in ServiceDeskRepository.FindAllByUserId(user3.Id))
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("===========================");
            foreach (var item in ServiceDeskRepository.FindAllByUserId(user4.Id))
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("===========================");
            foreach (var item in ServiceDeskRepository.FindAllByUserId(user5.Id))
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("===========================");
            foreach (var item in ServiceDeskRepository.FindAllByUserId(user6.Id))
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("===========================");
            foreach (var item in ServiceDeskRepository.FindAllByUserId(user7.Id))
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("===========================");
            foreach (var item in ServiceDeskRepository.FindAllByUserId(user8.Id))
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("===========================");

            foreach (var item in ServiceDeskRepository.FindAllByCustomerId(customer1.Id))
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("===========================");
            foreach (var item in ServiceDeskRepository.FindAllByCustomerId(customer2.Id))
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("===========================");
            foreach (var item in ServiceDeskRepository.FindAllByCustomerId(customer3.Id))
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("===========================");
            foreach (var item in ServiceDeskRepository.FindAllByCustomerId(customer4.Id))
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("===========================");
            foreach (var item in ServiceDeskRepository.FindAllByCustomerId(customer5.Id))
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("===========================");

            foreach (var item in ServiceDeskRepository.FindAllByPerformerId(performer1.Id))
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("===========================");
            foreach (var item in ServiceDeskRepository.FindAllByPerformerId(performer2.Id))
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("===========================");

            foreach (var item in ServiceDeskRepository.FindAllByOrderId(order1.Id))
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("===========================");
            foreach (var item in ServiceDeskRepository.FindAllByOrderId(order2.Id))
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("===========================");
            foreach (var item in ServiceDeskRepository.FindAllByOrderId(order3.Id))
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("===========================");
            foreach (var item in ServiceDeskRepository.FindAllByOrderId(order4.Id))
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("===========================");
            foreach (var item in ServiceDeskRepository.FindAllByOrderId(order5.Id))
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("===========================");
            foreach (var item in ServiceDeskRepository.FindAllByOrderId(order6.Id))
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("===========================");
        }
    }
}
