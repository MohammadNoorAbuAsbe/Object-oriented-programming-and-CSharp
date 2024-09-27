using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShopSystem shopSystem = new ShopSystem("Ebay");
            bool running = true;
            while (running)
            {
                int choice = ShowMenuAndGetChoice();
                Console.ForegroundColor = ConsoleColor.DarkCyan;

                switch (choice)
                {
                    case 1:
                        AddBuyer(shopSystem);
                        break;
                    case 2:
                        AddSeller(shopSystem);
                        break;
                    case 3:
                        AddProductToSeller(shopSystem);
                        break;
                    case 4:
                        AddProductToBuyerCart(shopSystem);
                        break;
                    case 5:
                        ProcessOrderForBuyer(shopSystem);
                        break;
                    case 6:
                        ShowBuyers(shopSystem);
                        break;
                    case 7:
                        ShowSellers(shopSystem);
                        break;
                    case 8:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }
        }

        static int ShowMenuAndGetChoice()
        {
            Console.WriteLine("-----------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Add Buyer");
            Console.WriteLine("2. Add Seller");
            Console.WriteLine("3. Add Product to Seller");
            Console.WriteLine("4. Add Product to Buyer's Cart");
            Console.WriteLine("5. Process Order for Buyer");
            Console.WriteLine("6. Show Buyers");
            Console.WriteLine("7. Show Sellers");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your choice (1-8): ");
            return int.Parse(Console.ReadLine());
        }


        static void AddUser(ShopSystem shopSystem, bool isBuyer)
        {
            string username = GetUserInput("\nEnter username: ");
            string password = GetUserInput("Enter password: ");
            string streetName = GetUserInput("Enter street name: ");
            int buildingNumber = int.Parse(GetUserInput("Enter building number: "));
            string city = GetUserInput("Enter city: ");
            string country = GetUserInput("Enter country: ");

            bool success;
            if (isBuyer)
            {
                success = shopSystem.AddBuyer(username, password, streetName, buildingNumber, city, country);
            }
            else
            {
                success = shopSystem.AddSeller(username, password, streetName, buildingNumber, city, country);
            }

            string userType = isBuyer ? "Buyer" : "Seller";
            if (success)
            {
                PrintMessage($"{userType} added successfully.",true);
            }
            else
            {
                PrintMessage("User already exists. please enter a diffrent Username", false);
            }
        }

        static string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static void AddBuyer(ShopSystem shopSystem)
        {
            AddUser(shopSystem,true);
        }

        static void AddSeller(ShopSystem shopSystem)
        {
            AddUser(shopSystem, false);
        }

        static void AddProductToSeller(ShopSystem shopSystem)
        {
            Seller[] sellers = shopSystem.GetAllSellers();
            if (sellers.Length == 0)
            {
                PrintMessage("No sellers available.", false);
                return;
            }

            Console.WriteLine("\nSelect a seller from the list:");
            for (int i = 0; i < sellers.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {sellers[i].GetUsername()}");
            }

            int choice = int.Parse(GetUserInput("\nEnter your choice: ")) - 1;

            if (choice < 0 || choice >= sellers.Length)
            {
                PrintMessage("Invalid choice.", false);
                return;
            }

            string username = sellers[choice].GetUsername();

            string name = GetUserInput("Enter product name: ");
            double price = double.Parse(GetUserInput("Enter product price: "));

            bool success = shopSystem.AddProductToSeller(username, name, price);
            if (success)
            {
                PrintMessage("Product added successfully to seller.",true);
            }
            else
            {
                PrintMessage("Failed to add product to seller, Prouduct with a similar name already exists. ", false);
            }
        }

        static void AddProductToBuyerCart(ShopSystem shopSystem)
        {
            Buyer[] buyers = shopSystem.GetAllBuyers();
            if (buyers.Length == 0)
            {
                PrintMessage("No buyers available.", false);
                return;
            }

            Console.WriteLine("\nSelect a buyer from the list:");
            for (int i = 0; i < buyers.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {buyers[i].GetUsername()}");
            }

            int buyerChoice = int.Parse(GetUserInput("\nEnter your choice: ")) - 1;

            if (buyerChoice < 0 || buyerChoice >= buyers.Length)
            {
                PrintMessage("Invalid choice.", false);
                return;
            }

            string username = buyers[buyerChoice].GetUsername();

            Product[] products = shopSystem.GetAllProducts();
            if (products.Length == 0)
            {
                PrintMessage("No products available.", false);
                return;
            }

            Console.WriteLine("\nSelect a product from the list:");
            for (int j = 0; j < products.Length; j++)
            {
                Console.WriteLine($"{j + 1}. {products[j].GetName()} -Price: ${products[j].GetPrice()} -Sold by: {products[j].GetSeller().GetUsername()}");
            }

            int productChoice = int.Parse(GetUserInput("\nEnter your choice: ")) - 1;

            if (productChoice < 0 || productChoice >= products.Length)
            {
                PrintMessage("Invalid choice.", false);
                return;
            }

            string productName = products[productChoice].GetName();
            double productPrice = products[productChoice].GetPrice();
            Seller seller = products[productChoice].GetSeller();

            bool success = shopSystem.AddProductToBuyerCart(username, productName, productPrice, seller);
            if (success)
            {
                PrintMessage("Product added successfully to buyer's cart.",true);
            }
            else
            {
                PrintMessage("Failed to add product to buyer's cart.", false);
            }
        }

        static void ProcessOrderForBuyer(ShopSystem shopSystem)
        {
            Buyer[] buyers = shopSystem.GetAllBuyers();
            if (buyers.Length == 0)
            {
                PrintMessage("No buyers available.", false);
                return;
            }

            Console.WriteLine("\nSelect a buyer from the list:");
            for (int i = 0; i < buyers.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {buyers[i].GetUsername()}");
            }

            int buyerChoice = int.Parse(GetUserInput("\nEnter your choice: ")) - 1;

            if (buyerChoice < 0 || buyerChoice >= buyers.Length)
            {
                PrintMessage("Invalid choice.", false);
                return;
            }

            string username = buyers[buyerChoice].GetUsername();

            if (shopSystem.ProcessOrder(username))
            {
                PrintMessage("Order processed successfully.",true);
            }
            else
            {
                PrintMessage("there is no order to be processed for this buyer.", false);
            }
        }

        static void ShowBuyers(ShopSystem shopSystem)
        {
            Buyer[] buyers = shopSystem.GetAllBuyers();
            if (buyers.Length == 0)
            {
                PrintMessage("No buyers available.",false);
            }
            else
            {
                for (int i = 0; i < buyers.Length; i++)
                {
                    PrintMessage("\n-----------------------------------------------\n" + $"Buyer {i + 1}:\n" + buyers[i].Print(),true);
                }
            }
        }

        static void ShowSellers(ShopSystem shopSystem)
        {
            Seller[] sellers = shopSystem.GetAllSellers();
            if (sellers.Length == 0)
            {
                PrintMessage("No sellers available.",false);
            }
            else
            {
                foreach (Seller seller in sellers)
                {
                    PrintMessage(seller.Print(),true);
                }
            }
        }

        static void PrintMessage(string message, bool isSuccess)
        {
            Console.ForegroundColor = isSuccess ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine("\n" + message);
            Console.ResetColor();
        }
    }
}
