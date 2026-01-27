
//========================================================== 
// Student Number : S10268600D
// Student Name : Kristine Keok Jia Xuan
// Partner Name : Miridhu D/O Ellapparaja
//==========================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10268600D_PRG2Assignment
{
    class FoodItem
    {
        private string itemName;

        private string itemDesc;

        private double itemPrice;

        private string customise;

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        public string ItemDesc
        {
            get { return itemDesc; }
            set { itemDesc = value; }
        }

        public double ItemPrice
        {
            get { return itemPrice; }
            set { itemPrice = value; }
        }

        public string Customise
        {
            get { return customise; }
            set { customise = value; }
        }

        public FoodItem() { }

        public FoodItem(string itemName, string itemDesc, double itemPrice, string customise)
        {
            ItemName = itemName;
            ItemDesc = itemDesc;
            ItemPrice = itemPrice;
            Customise = customise;
        }

        public override string ToString()
        {
            return ItemName + " - " + 
                   ItemDesc + " - SGD " + 
                   ItemPrice.ToString("F2");
        }
    }
}