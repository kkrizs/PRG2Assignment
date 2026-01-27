
//==========================================================
// Student Number : S10272060J
// Student Name : Miridhu D/O Ellapparaja
// Partner Name : Kristine Keok Jia Xuan
//========================================================== 

using System;

namespace S10272060J_PRG2Assignment
{

    public class OrderedFoodItem
    {
        public string ItemName { get; set; }
        public string ItemDesc { get; set; }
        public double ItemPrice { get; set; }
        public string Customise { get; set; }

        public int QtyOrdered { get; set; }
        public double SubTotal { get; private set; }

        public OrderedFoodItem(string itemName, string itemDesc, double itemPrice, int qtyOrdered, string customise = "")
        {
            ItemName = itemName;
            ItemDesc = itemDesc;
            ItemPrice = itemPrice;
            QtyOrdered = qtyOrdered;
            Customise = customise;

            CalculateSubtotal();
        }

        public double CalculateSubtotal()
        {
            SubTotal = ItemPrice * QtyOrdered;
            return SubTotal;
        }

        public override string ToString()
        {
            string customiseText = string.IsNullOrWhiteSpace(Customise) ? "" : $" (Custom: {Customise})";
            return $"{ItemName} x{QtyOrdered} @ ${ItemPrice:0.00} = ${SubTotal:0.00}{customiseText}";
        }
    }
}
