using LibraryFor2ndLab.DTO;
using System;
using System.Collections.Generic;

namespace Lab_2.Utilities
{
    class ServiceDeskUtility
    {
        private static readonly string[] serviceDeskNames = new string[] {"Services", "Services Fx", "Legends Services", "Services Brain", "Services Lifetime",
                "Scorpio Services", "Services Program", "BlueFire Services", "Homeland Services", "Services Bay",
                "Services Hand", "Align Services", "Global Services", "Embassy Services", "Raw Services",
                "Smart Services", "Services Platinum", "Graphic Services", "Ventura Services", "Services Runners",
                "Services Links", "Dimension Services", "List Services", "Services Arena", "Jackpot Services",
                "Core Services", "Brighter Services", "Services Look", "Lambda Services", "Inspire Services",
                "Services Game", "Access Services", "Sienna Services", "Variety Services", "Concrete Services",
                "Instant Services", "Cowgirl Services", "Titan Services", "Services Bargain", "Mega Services",
                "Finest Services", "Leopard Services", "RedDog Services", "Clockwork Services", "Services Core",
                "Last Services", "Linked Services", "Colossal Services", "Services Avatar", "Blackwell Services",
                "New Services", "Pearl Services", "WhiteHat Services", "WallStreet Services", "Services Keys",
                "Keystone Services", "Riddle Services", "Hexagon Services", "BlackOps Services", "Services Professional"};

        public static ServiceDesk GetRandomServiceDeskModel(int ordersCount, Random random)
        {
            List<Order> orders = new();

            for (int i = 0; i < ordersCount; i++)
            {
                orders.Add(OrderUtility.GetRandomOrderModel(random));
            }

            ServiceDesk serviceDesk = new(serviceDeskNames[random.Next(0, serviceDeskNames.Length)]);

            foreach (Order order in orders)
            {
                serviceDesk.AddNewOrder(order);
            }

            return serviceDesk;
        }

        public static ServiceDesk GetRandomServiceDeskModel(Random random, params Order[] orders)
        {
            ServiceDesk serviceDesk = new(serviceDeskNames[random.Next(0, serviceDeskNames.Length)]);

            foreach (Order order in orders)
            {
                serviceDesk.AddNewOrder(order);
            }

            return serviceDesk;
        }
    }
}
