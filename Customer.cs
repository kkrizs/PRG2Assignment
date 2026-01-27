
//==========================================================
// Student Number : S10272060J
// Student Name : Miridhu D/O Ellapparaja
// Partner Name : Kristine Keok Jia Xuan
//========================================================== 

using System;
using System.Collections.Generic;

namespace S10272060J_PRG2Assignment
{
    public class Customer
    {
        public string EmailAddress { get; set; }
        public string CustomerName { get; set; }

        public List<Order> Orders { get; private set; }

        public Customer(string name, string email)
        {
            CustomerName = name;
            EmailAddress = email;
            Orders = new List<Order>();
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        public bool RemoveOrder(Order order)
        {
            return Orders.Remove(order);
        }

        public void DisplayAllOrders()
        {
            if (Orders.Count == 0)
            {
                Console.WriteLine("No orders found.");
                return;
            }

            foreach (var order in Orders)
            {
                Console.WriteLine(order.ToString());
            }
        }

        public override string ToString()
        {
            return $"{CustomerName} ({EmailAddress})";
        }
    }
}
