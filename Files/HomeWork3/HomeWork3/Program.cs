using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    public enum MessageStatus
    {
        Error = ConsoleColor.Red,
        Passed = ConsoleColor.Green
    }
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
                        AddUser(shopSystem, UserType.Buyer);
                        break;
                    case 2:
                        AddUser(shopSystem, UserType.Seller);
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
                        ShowUsers(shopSystem, UserType.Buyer);
                        break;
                    case 7:
                        ShowUsers(shopSystem, UserType.Seller);
                        break;
                    case 8:
                        running = false;
                        break;
                    default:
                        PrintColoredMessage("Invalid option, try again.", MessageStatus.Error);
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


        static void AddUser(ShopSystem shopSystem, UserType userType)
        {
            string username = GetRequestedUserInput("\nEnter username: ");
            string password = GetRequestedUserInput("Enter password: ");
            string streetName = GetRequestedUserInput("Enter street name: ");
            int buildingNumber = int.Parse(GetRequestedUserInput("Enter building number: "));
            string city = GetRequestedUserInput("Enter city: ");
            string country = GetRequestedUserInput("Enter country: ");

            bool success = shopSystem.AddUser(username, password, streetName, buildingNumber, city, country, userType);

            DisplayResultMessage(success, $"{userType} added successfully.", "User already exists. Please enter a different Username");
        }

        static string GetRequestedUserNameChoice(User[] users, UserType userType)
        {
            if (users.Length == 0)
            {
                PrintColoredMessage($"No {userType}s available.", MessageStatus.Error);
                return null;
            }

            Console.WriteLine($"\nSelect a {userType} from the list:");
            for (int i = 0; i < users.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {users[i].GetUsername()}");
            }

            int userChoice = int.Parse(GetRequestedUserInput("\nEnter your choice: ")) - 1;

            if (userChoice < 0 || userChoice >= users.Length)
            {
                PrintColoredMessage("Invalid choice.", MessageStatus.Error);
                return null;
            }

            return users[userChoice].GetUsername();
        }

        static void AddProductToSeller(ShopSystem shopSystem)
        {
            string username = GetRequestedUserNameChoice(shopSystem.GetAllSellers(), UserType.Seller);
            if (username == null)
            {
                return;
            }

            string name = GetRequestedUserInput("Enter product name: ");
            double price = double.Parse(GetRequestedUserInput("Enter product price: "));
            double specialPackagingPrice = double.Parse(GetRequestedUserInput("Enter product special packaging price (0 if none): "));
            ProductCategory category = GetProductCategory();

            bool success = shopSystem.AddProductToSeller(username, name, price, specialPackagingPrice, category);
            DisplayResultMessage(success, "Product added successfully to seller.", "Failed to add product to seller, Product with a similar name already exists.");
        }

        static void AddProductToBuyerCart(ShopSystem shopSystem)
        {
            string username = GetRequestedUserNameChoice(shopSystem.GetAllBuyers(), UserType.Buyer);
            if (username == null)
            {
                return;
            }

            Product[] products = shopSystem.GetAllProducts();
            if (products.Length == 0)
            {
                PrintColoredMessage("No products available.", MessageStatus.Error);
                return;
            }

            Console.WriteLine("\nSelect a product from the list:");
            for (int j = 0; j < products.Length; j++)
            {
                Console.WriteLine($"{j + 1}. {products[j]}");
            }

            int productChoice = int.Parse(GetRequestedUserInput("\nEnter your choice: ")) - 1;

            if (productChoice < 0 || productChoice >= products.Length)
            {
                PrintColoredMessage("Invalid choice.", MessageStatus.Error);
                return;
            }

            bool success = shopSystem.AddProductToBuyerCart(username, products[productChoice]);
            DisplayResultMessage(success, "Product added successfully to buyer's cart.", "Failed to add product to buyer's cart.");
        }

        static void ProcessOrderForBuyer(ShopSystem shopSystem)
        {
            string username = GetRequestedUserNameChoice(shopSystem.GetAllBuyers(), UserType.Buyer);
            if (username == null)
            {
                return;
            }

            if (shopSystem.ProcessOrder(username))
            {
                PrintColoredMessage("Order processed successfully.", MessageStatus.Passed);
            }
            else
            {
                PrintColoredMessage("there is no order to be processed for this buyer.", MessageStatus.Error);
            }
        }

        public static void ShowUsers(ShopSystem shopSystem, UserType userType)
        {
            User[] users;
            if (userType == UserType.Buyer)
            {
                users = shopSystem.GetAllBuyers();
            }
            else if (userType == UserType.Seller)
            {
                users = shopSystem.GetAllSellers();
            }
            else
            {
                PrintColoredMessage("Invalid user type.", MessageStatus.Error);
                return;
            }

            if (users.Length == 0)
            {
                PrintColoredMessage($"No {userType}s available.", MessageStatus.Error);
            }
            else
            {
                foreach (User user in users)
                {
                    if (userType == UserType.Buyer)
                    {
                        Buyer buyer = (Buyer)user;
                        PrintColoredMessage(buyer.ToString(), MessageStatus.Passed);
                    }
                    else if (userType == UserType.Seller)
                    {
                        Seller seller = (Seller)user;
                        PrintColoredMessage(seller.ToString(), MessageStatus.Passed);
                    }
                }
            }
        }

        static ProductCategory GetProductCategory()
        {
            ProductCategory selectedCategory;

            while (true)
            {
                Console.WriteLine("Select a category:");
                foreach (ProductCategory category in Enum.GetValues(typeof(ProductCategory)))
                {
                    Console.WriteLine($"{(int)category}. {category}");
                }

                string categoryChoice = GetRequestedUserInput("Enter the category number: ");

                if (Enum.IsDefined(typeof(ProductCategory), int.Parse(categoryChoice)))
                {
                    selectedCategory = (ProductCategory)Enum.Parse(typeof(ProductCategory), categoryChoice);
                    break;
                }
                else
                {
                    PrintColoredMessage("Invalid category choice. Please try again.", MessageStatus.Error);
                }
            }

            return selectedCategory;
        }

        static string GetRequestedUserInput(string request)
        {
            Console.Write(request);
            return Console.ReadLine();
        }

        static void PrintColoredMessage(string message, MessageStatus status)
        {
            Console.ForegroundColor = (ConsoleColor)status;
            Console.WriteLine("\n" + message);
            Console.ResetColor();
        }

        static void DisplayResultMessage(bool success, string successMessage, string errorMessage)
        {
            if (success)
            {
                PrintColoredMessage(successMessage, MessageStatus.Passed);
            }
            else
            {
                PrintColoredMessage(errorMessage, MessageStatus.Error);
            }
        }

    }
}
