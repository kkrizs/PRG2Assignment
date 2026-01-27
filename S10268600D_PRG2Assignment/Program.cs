
using S10268600D_PRG2Assignment;
List<Restaurant> restaurantList = new List<Restaurant>();

LoadRestaurants();
LoadFoodItems();

WelcomeMessage();

while (true)
{
    MainMenu();
    Console.Write("Enter your choice: ");
    int choice = Convert.ToInt32(Console.ReadLine());

    if (choice == 2)
    {
        ListAllOrders();
    }

    else if (choice == 4)
    {

    }

    else if (choice == 6)
    {

    }

    else if (choice == 0)
    {
        Console.WriteLine("Exiting the program...");
        break;
    }

    else
    {
        Console.WriteLine("Invalid choice. Please try again.");
    }
}

void WelcomeMessage()
{
    Console.WriteLine("Welcome to the Gruberoo Food Delivery System");
    Console.WriteLine("{0} restaurants loaded!", restaurantList.Count);
    Console.WriteLine("{0} food items loaded!", CountFoodItems());
    Console.WriteLine("20 customers loaded!");
    Console.WriteLine("35 orders loaded!");
}

void MainMenu()
{
    Console.WriteLine();
    Console.WriteLine("===== Gruberoo Food Delivery System =====");
    Console.WriteLine("1. List all restaurants and menu items");
    Console.WriteLine("2. List all orders");
    Console.WriteLine("3. Create a new order");
    Console.WriteLine("4. Process an order");
    Console.WriteLine("5. Modify an existing order");
    Console.WriteLine("6. Delete an existing order");
    Console.WriteLine("0. Exit");
}

// Basic Feature 1 (Load files - restaurant.csv)
void LoadRestaurants()
{
    restaurantList.Clear();

    string[] lines = File.ReadAllLines("restaurants.csv");

    for (int i = 1; i < lines.Length; i++)
    {
        string[] parts = lines[i].Split(',');

        string id = parts[0];
        string name = parts[1];
        string email = parts[2];

        Restaurant r = new Restaurant(id, name, email);

        // Default menu for storing food items (not shown in output)
        Menu m = new Menu("M1", "Main Menu");
        r.AddMenu(m);

        restaurantList.Add(r);

    }
}

// Basic Feature 1 (Load files - fooditems.csv)
void LoadFoodItems()
{
    string[] lines2 = File.ReadAllLines("fooditems.csv");

    for (int i = 1; i < lines2.Length; i++)
    {
        string[] parts2 = lines2[i].Split(',');

        string restaurantID = parts2[0];
        string itemName = parts2[1];
        string itemDesc = parts2[2];
        double price = Convert.ToDouble(parts2[3]);

        FoodItem fi = new FoodItem(itemName, itemDesc, price, "");

        for (int j = 0; j < restaurantList.Count; j++)
        {
            if (restaurantList[j].RestaurantID == restaurantID)
            {
                restaurantList[j].MenuList[0].AddFoodItem(fi);
                break;
            }
        }
    }
}

// Basic Feature 1 (Count food items)
int CountFoodItems()
{
    int count = 0;

    for (int i = 0; i < restaurantList.Count; i++)
    {
        count = count + restaurantList[i].MenuList[0].ItemList.Count;
    }

    return count;
}

// Basic Feature 4 (List all orders)
void ListAllOrders()
{
    Console.WriteLine();
    Console.WriteLine("All Orders");
    Console.WriteLine("==========");

    if (orderList.Count == 0)
    {
        Console.WriteLine("No orders available.");
        return;
    }

    Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-20} {4,-10} {5,-10}",
                      "Order ID",
                      "Customer",
                      "Restaurant",
                      "Delivery Date/Time",
                      "Amount",
                      "Status");

    Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-20} {4,-10} {5,-10}",
                      "--------",
                      "--------",
                      "----------",
                      "------------------",
                      "------",
                      "------");


    for (int i = 0; i < orderList.Count; i++)
    {
        Order order = orderList[i];

        Console.WriteLine(
            "{0,-10} {1,-15} {2,-15} {3,-20} ${4,-9} {5,-10}",
            order.OrderID,
            order.CustomerName,
            order.RestaurantName,
            order.DeliveryDateTime,
            order.TotalAmount.ToString("F2"),
            order.Status
        );
    }
}

