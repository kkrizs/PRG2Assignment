
//========================================================== 
// Student Number : S10268600D
// Student Name : Kristine Keok Jia Xuan
// Partner Name : Miridhu D/O Ellapparaja
//==========================================================

using System;
using System.Collections.Generic;

namespace S10268600D_PRG2Assignment
{
    class Restaurant
    {
        private string restaurantId;

        private string restaurantName;

        private string restaurantEmail;

        public List<Menu> MenuList { get; set; } 
                          = new List<Menu>();

        public List<SpecialOffer> OfferList { get; set; } 
                                  = new List<SpecialOffer>();

        public List<Order> OrderList { get; set; }
                           = new List<Order>();

        public string RestaurantId
        { 
            get { return restaurantId; } 
            set { restaurantId = value; } 
        }

        public string RestaurantName
        {
            get { return restaurantName; }
            set { restaurantName = value; }
        }

        public string RestaurantEmail
        {
            get { return restaurantEmail; }
            set { restaurantEmail = value; }
        }

        public Restaurant() { }

        public Restaurant(string restaurantId, string restaurantName, string restaurantEmail)
        {
            RestaurantId = restaurantId;
            RestaurantName = restaurantName;
            RestaurantEmail = restaurantEmail;
        }

        public void DisplayOrders()
        {
            if (OrderList.Count == 0)
            {
                Console.WriteLine("No orders available.");
                return;
            }

            for (int i = 0; i < OrderList.Count; i++)
            {
                Console.WriteLine(OrderList[i]);
            }
        }

        public void DisplaySpecialOffers()
        {
            if (OfferList.Count == 0)
            {
                Console.WriteLine("No special offers available.");
                return;
            }

            for (int i = 0; i < OfferList.Count; i++)
            {
                Console.WriteLine(OfferList[i]);
            }
        }

        public void DisplayMenu()
        {
            if (MenuList.Count == 0)
            {
                Console.WriteLine("There are no menus available.");
                return;
            }

            for (int i = 0; i < MenuList.Count; i++)
            {
                Console.WriteLine(MenuList[i]);
                MenuList[i].DisplayFoodItems();
            }
        }

        public void AddMenu(Menu menu)
        {
            if (menu == null)
                return;

            for (int i = 0; i < MenuList.Count; i++)
            {
                if (MenuList[i].MenuId == menu.MenuId)
                    return;
            }

            MenuList.Add(menu);
        }

        public bool RemoveMenu(Menu menu)
        {
            if (menu == null)
                return false;

            for (int i = 0; i < MenuList.Count; i++)
            {
                if (MenuList[i].MenuId == menu.MenuId)
                {
                    MenuList.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return "Restaurant: " + restaurantName + " (" + restaurantId + ")";
        }
    }
}