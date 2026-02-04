
//==========================================================
// Student Number : S10272060J
// Student Name : Miridhu D/O Ellapparaja
// Partner Name : Kristine Keok Jia Xuan
//========================================================== 

using System;
using System.Collections.Generic;

namespace S10272060J_PRG2Assignment
{
    class Customer
    {
        public string EmailAddress { get; set; }
        public string CustomerName { get; set; }

        public List<Order> OrderList { get; set; }

        public Customer() { }

        public Customer(string name, string email)
        {
            CustomerName = name;
            EmailAddress = email;
            OrderList = new List<Order>();
        }

        public void AddOrder(Order order)
        {
            OrderList.Add(order);
        }

        public bool RemoveOrder(Order order)
        {
            return OrderList.Remove(order);
        }

        public void DisplayAllOrders()
        {
            if (OrderList.Count == 0)
            {
                Console.WriteLine("No orders found.");
                return;
            }

            foreach (var order in OrderList)
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
