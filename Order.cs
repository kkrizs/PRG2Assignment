
//==========================================================
// Student Number : S10272060J
// Student Name : Miridhu D/O Ellapparaja
// Partner Name : Kristine Keok Jia Xuan
//========================================================== 

using System;
using System.Collections.Generic;

namespace S10272060J_PRG2Assignment
{
    class Order
    {
        private int orderId;

        private DateTime orderDateTime;

        private double orderTotal;

        private string orderStatus;

        private DateTime deliveryDateTime;

        private string deliveryAddress;

        private string orderPaymentMethod;

        private bool orderPaid;

        private List<OrderedFoodItem> orderedItems;

        public const double DeliveryFee = 5.00;

        public const double PlatformFeeRate = 0.30;

        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        public DateTime OrderDateTime
        {
            get { return orderDateTime; }
            set { orderDateTime = value; }
        }

        public double OrderTotal
        {
            get { return orderTotal; }
            set { orderTotal = value; }
        }

        public string OrderStatus
        {
            get { return orderStatus; }
            set { orderStatus = value; }
        }

        public DateTime DeliveryDateTime
        {
            get { return deliveryDateTime; }
            set { deliveryDateTime = value; }
        }

        public string DeliveryAddress
        {
            get { return deliveryAddress; }
            set { deliveryAddress = value; }
        }

        public string OrderPaymentMethod
        {
            get { return orderPaymentMethod; }
            set { orderPaymentMethod = value; }
        }

        public bool OrderPaid
        {
            get { return orderPaid; }
            set { orderPaid = value; }
        }

        public List<OrderedFoodItem> OrderedItems
        {
            get { return orderedItems; }
        }

        public Order(int orderId, DateTime deliveryDateTime, string deliveryAddress)
        {
            OrderId = orderId;
            DeliveryDateTime = deliveryDateTime;
            DeliveryAddress = deliveryAddress;

            OrderDateTime = DateTime.Now;

            OrderStatus = "Pending";
            OrderPaymentMethod = "";
            OrderPaid = false;

            orderedItems = new List<OrderedFoodItem>();
            OrderTotal = 0;
        }

        public void AddOrderedFoodItem(OrderedFoodItem item)
        {
            orderedItems.Add(item);
            CalculateOrderTotal();
        }

        public bool RemoveOrderedFoodItem(OrderedFoodItem item)
        {
            bool removed = orderedItems.Remove(item);
            CalculateOrderTotal();
            return removed;
        }

        public void DisplayOrderedFoodItems()
        {
            if (orderedItems.Count == 0)
            {
                Console.WriteLine("No items in this order.");
                return;
            }

            int count = 1;
            foreach (OrderedFoodItem item in orderedItems)
            {
                Console.WriteLine(count + ". " + item.ToString());
                count++;
            }
        }

        public double CalculateOrderTotal()
        {
            double itemsSubtotal = 0;

            foreach (OrderedFoodItem item in orderedItems)
            {
                itemsSubtotal = itemsSubtotal + item.CalculateSubtotal();
            }

            OrderTotal = itemsSubtotal + DeliveryFee;
            return OrderTotal;
        }

        public override string ToString()
        {
            return "Order " + OrderId +
                   " Delivery: " + DeliveryDateTime.ToString("dd/MM/yyyy HH:mm") +
                   " Amount: $" + OrderTotal.ToString("F2") +
                   " Status: " + OrderStatus;
        }
    }
}