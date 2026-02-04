
//========================================================== 
// Student Number : S10268600D
// Student Name : Kristine Keok Jia Xuan
// Partner Name : Miridhu D/O Ellapparaja
//==========================================================

using System;
using System.Collections.Generic;

namespace S10268600D_PRG2Assignment
{
    class Menu
    {
        private string menuId;

        private string menuName;

        public string MenuId
        {
            get { return menuId; }
            set { menuId = value; }
        }

        public string MenuName
        {
            get { return menuName; }
            set { menuName = value; }
        }

        public List<FoodItem> ItemList { get; set; } 
                              = new List<FoodItem>();

        public Menu() { }

        public Menu(string menuId, string menuName)
        {
            MenuId = menuId;
            MenuName = menuName;
        }

        public void AddFoodItem(FoodItem foodItem)
        {
            if (foodItem == null)
                return;


            for (int i = 0; i < ItemList.Count; i++)
            {
                if (ItemList[i].ItemName == foodItem.ItemName)
                    return;
            }

            ItemList.Add(foodItem);

        }

        public bool RemoveFoodItem(FoodItem foodItem)
        {
            if (foodItem == null)
                return false;

            for (int i = 0;i < ItemList.Count;i++)
            {
                if (ItemList[i].ItemName == foodItem.ItemName)
                {
                    ItemList.RemoveAt(i);
                    return true;
                }
            }

            return false;

        }

        public void DisplayFoodItems()
        {
            if (ItemList.Count == 0)
            {
                Console.WriteLine("There are no food items available.");
                return;
            }

            for (int i = 0; i < ItemList.Count;i++)
            {
                FoodItem fi = ItemList[i];
                Console.WriteLine(
                    fi.ItemName + " - " +
                    fi.ItemDesc + " - SGD " +
                    fi.ItemPrice.ToString("F2")
                );
            }
        }

        public override string ToString()
        {
            return "Menu: " + menuName + " (" + menuId + ")";
        }
    }
}