
//==========================================================
// Student Number : S10272060J
// Student Name : Miridhu D/O Ellapparaja
// Partner Name : Kristine Keok Jia Xuan
//========================================================== 

using System;
using System.Collections.Generic;

namespace S10272060J_PRG2Assignment
{
    class OrderedFoodItem : FoodItem
    {
        private int qtyOrdered;

        private double subTotal;

        public int QtyOrdered
        {
            get { return qtyOrdered; }
            set { qtyOrdered = value; }
        }

        public double SubTotal
        {
            get { return subTotal; }
        }

        public OrderedFoodItem(string itemName, string itemDesc, double itemPrice, string customise, int qtyOrdered)
                              : base(itemName, itemDesc, itemPrice, customise)
        {
            QtyOrdered = qtyOrdered;
            CalculateSubtotal();
        }

        public double CalculateSubtotal()
        {
            subTotal = ItemPrice * QtyOrdered;
            return subTotal;
        }

        public override string ToString()
        {
            string output = ItemName + " x" + QtyOrdered +
                            " - SGD " + subTotal.ToString("F2");

            if (Customise != "")
            {
                output = output + " (Customise: " + Customise + ")";
            }

            return output;
        }
    }
}
