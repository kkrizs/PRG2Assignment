
//==========================================================
// Student Number : S10272060J
// Student Name : Miridhu D/O Ellapparaja
// Partner Name : Kristine Keok Jia Xuan
//========================================================== 

using System;
using System.Collections.Generic;

namespace S10272060J_PRG2Assignment
{
    public enum OrderStatus
    {
        Pending,
        Preparing,
        Delivered,
        Cancelled,
        Rejected,
        Archived
    }

    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDateTime { get; set; }
        public double OrderTotal { get; private set; }
        public OrderStatus OrderStatus { get; private set; }

        public DateTime DeliveryDateTime { get; set; }
        public string DeliveryAddress { get; set; }

        public string OrderPaymentMethod { get; set; }
        public bool OrderPaid { get; private set; }

        public List<OrderedFoodItem> OrderedItems { get; private set; }

        public const double DeliveryFee = 5.00;
        public const double PlatformFeeRate = 0.30; 

        public Order(int orderId, DateTime deliveryDateTime, string deliveryAddress)
        {
            OrderId = orderId;
            DeliveryDateTime = deliveryDateTime;
            DeliveryAddress = deliveryAddress;

            OrderDateTime = DateTime.Now;
            OrderStatus = OrderStatus.Pending;

            OrderPaymentMethod = "";
            OrderPaid = false;

            OrderedItems = new List<OrderedFoodItem>();
            OrderTotal = 0;
        }

        public void AddOrderedFoodItem(OrderedFoodItem item)
        {
            OrderedItems.Add(item);
            CalculateOrderTotal();
        }

        public bool RemoveOrderedFoodItem(OrderedFoodItem item)
        {
            bool removed = OrderedItems.Remove(item);
            if (removed) CalculateOrderTotal();
            return removed;
        }

        public void DisplayOrderedFoodItems()
        {
            if (OrderedItems.Count == 0)
            {
                Console.WriteLine("No items in this order.");
                return;
            }

            foreach (var item in OrderedItems)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public double CalculateOrderTotal()
        {
            double itemsSubtotal = 0;

            foreach (var item in OrderedItems)
            {
                itemsSubtotal += item.CalculateSubtotal();
            }

            double platformFee = itemsSubtotal * PlatformFeeRate;
            OrderTotal = itemsSubtotal + platformFee + DeliveryFee;

            return OrderTotal;
        }

        public void Pay(string paymentMethod)
        {
            OrderPaymentMethod = paymentMethod;
            OrderPaid = true;
        }

        public void Confirm()
        {
            if (!OrderPaid)
                throw new InvalidOperationException("Cannot confirm: order not paid yet.");

            if (OrderStatus != OrderStatus.Pending)
                throw new InvalidOperationException("Can only confirm when status is Pending.");

            OrderStatus = OrderStatus.Preparing;
        }

        public void Reject()
        {
            if (OrderStatus != OrderStatus.Pending)
                throw new InvalidOperationException("Can only reject when status is Pending.");

            OrderStatus = OrderStatus.Rejected;
        }

        public void Cancel()
        {
            if (OrderStatus != OrderStatus.Pending)
                throw new InvalidOperationException("Can only cancel when status is Pending.");

            OrderStatus = OrderStatus.Cancelled;
        }

        public void MarkDelivered()
        {
            if (OrderStatus != OrderStatus.Preparing)
                throw new InvalidOperationException("Can only deliver when status is Preparing.");

            OrderStatus = OrderStatus.Delivered;
        }

        public void Archive()
        {
            OrderStatus = OrderStatus.Archived;
        }

        public override string ToString()
        {
            return $"Order #{OrderId} | {OrderStatus} | Total: ${OrderTotal:0.00} | Delivery: {DeliveryDateTime:dd/MM/yyyy HH:mm}";
        }
    }
}
