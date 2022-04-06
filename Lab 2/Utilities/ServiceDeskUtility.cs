﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryFor2ndLab;

namespace Lab_2.Utilities
{
    class ServiceDeskUtility
    {
        public static ServiceDesk GetRandomServiceDeskModel(int ordersCount, Random random)
        {
            string[] serviceDeskName = new string[] {"Services", "Services Fx", "Legends Services", "Services Brain", "Services Lifetime",
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

            List <Order> orders = new();

            for (int i = 0; i < ordersCount; i++)
            {
                orders.Add(OrderUtility.GetRandomOrderModel(random));
            }

            return new(serviceDeskName[random.Next(0,serviceDeskName.Length)], orders);
        }
    }
}