using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
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

                try
                {
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
                            SelectOrderForNewCart(shopSystem);
                            break;
                        case 9:
                            CompareShoppers(shopSystem);
                            break;
                        case 10:
                            running = false;
                            break;
                        default:
                            PrintColoredMessage("Invalid option, try again.", MessageStatus.Error);
                            break;
                    }

                }
                catch (Exception ex)
                {
                    PrintColoredMessage(ex.Message, MessageStatus.Error);
                }

            }
        }

        //////////////////////// Menu Methods ////////////////////////
        static int ShowMenuAndGetChoice()
        {
            while (true)
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
                Console.WriteLine("8. Create new cart from history");
                Console.WriteLine("9. Compare two shoppers based on cart amount");
                Console.WriteLine("10. Exit");
                int choice = GetValidIntegerInput("Enter your choice (1-10):");

                if (choice >= 1 && choice <= 10)
                {
                    return choice;
                }

                PrintColoredMessage("Invalid choice. Please enter a number between 1 and 10.", MessageStatus.Error);
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

                int categoryChoice = GetValidIntegerInput("Enter the category number: ");

                if (Enum.IsDefined(typeof(ProductCategory), categoryChoice))
                {
                    selectedCategory = (ProductCategory)categoryChoice;
                    break;
                }
                else
                {
                    PrintColoredMessage("Invalid category choice. Please try again.", MessageStatus.Error);
                }
            }

            return selectedCategory;
        }
        ////////////////////////////////////////////////////////////////////////
        //////////////////////// User Input Methods ////////////////////////
        private static int GetValidIntegerInput(string message)
        {
            int input;
            while (true)
            {
                string userInput = GetRequestedUserInput(message);
                try
                {
                    input = int.Parse(userInput);
                    break;
                }
                catch (FormatException)
                {
                    PrintColoredMessage("Invalid input. Please enter a valid integer.", MessageStatus.Error);
                }
            }
            return input;
        }

        private static double GetValidDoubleInput(string message)
        {
            double input;
            while (true)
            {
                string userInput = GetRequestedUserInput(message);
                try
                {
                    input = double.Parse(userInput);
                    break;
                }
                catch (FormatException)
                {
                    PrintColoredMessage("Invalid input. Please enter a valid number.", MessageStatus.Error);
                }
            }
            return input;
        }

        public static string GetRequestedUserInput(string prompt)
        {
            string userInput = null;

            while (userInput == null || userInput.Length == 0)
            {
                Console.Write(prompt);
                userInput = Console.ReadLine();

                if (userInput == null || userInput.Length == 0)
                {
                    PrintColoredMessage("Input cannot be empty. Please enter a valid input.", MessageStatus.Error);
                }
            }

            return userInput;
        }

        ////////////////////////////////////////////////////////////////////////
        //////////////////////// User Management Methods ////////////////////////
        static void AddUser(ShopSystem shopSystem, UserType userType)
        {
            string username = GetRequestedUserInput("\nEnter username: ");
            string password = GetRequestedUserInput("Enter password: ");
            string streetName = GetRequestedUserInput("Enter street name: ");

            int buildingNumber = GetValidIntegerInput("Enter building number: ");

            string city = GetRequestedUserInput("Enter city: ");
            string country = GetRequestedUserInput("Enter country: ");

            shopSystem.AddUser(username, password, streetName, buildingNumber, city, country, userType);
            PrintColoredMessage("User added successfully", MessageStatus.Passed);
        }

        private static User SelectUser(List<User> users, UserType userType)
        {
            Console.WriteLine($"Select the {userType.ToString().ToLower()}:");
            User selectedUser = GetRequestedUserChoice(users, userType);
            return selectedUser;
        }

        public static User GetRequestedUserChoice(List<User> users, UserType userType)
        {
            if (users.Count == 0)
            {
                PrintColoredMessage($"No {userType}s available.", MessageStatus.Error);
                return null;
            }

            while (true)
            {
                Console.WriteLine($"\nSelect a {userType} from the list:");
                for (int i = 0; i < users.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {users[i].Username}");
                }

                int userChoice = GetValidIntegerInput("\nEnter your choice: ") - 1;

                if (userChoice >= 0 && userChoice < users.Count)
                {
                    return users[userChoice];
                }

                PrintColoredMessage("Invalid choice. Please try again.", MessageStatus.Error);
            }
        }
        ////////////////////////////////////////////////////////////////////////
        //////////////////////// Product Management Methods ////////////////////////
        static void AddProductToSeller(ShopSystem shopSystem)
        {
            try
            {
                User selectedUser = GetRequestedUserChoice(shopSystem.GetAllSellers(), UserType.Seller);
                if (selectedUser == null)
                {
                    return;
                }

                string name = GetRequestedUserInput("Enter product name: ");
                double price = GetValidDoubleInput("Enter product price: ");
                double specialPackagingPrice = GetValidDoubleInput("Enter product special packaging price (0 if none): ");
                ProductCategory category = GetProductCategory();

                shopSystem.AddProductToSeller((Seller)selectedUser, name, price, specialPackagingPrice, category);
                PrintColoredMessage("Product added successfully.", MessageStatus.Passed);
            }
            catch (Exception ex)
            {
                PrintColoredMessage($"Error adding product to seller: {ex.Message}", MessageStatus.Error);
            }
        }

        static void AddProductToBuyerCart(ShopSystem shopSystem)
        {
            try
            {
                User selectedUser = GetRequestedUserChoice(shopSystem.GetAllBuyers(), UserType.Buyer);
                if (selectedUser == null)
                {
                    return;
                }

                List<Product> products = shopSystem.GetAllProducts();
                if (products.Count == 0)
                {
                    PrintColoredMessage("No products available.", MessageStatus.Error);
                    return;
                }

                int productChoice;
                while (true)
                {
                    productChoice = DisplayAndSelectProduct(products);

                    if (productChoice >= 0 && productChoice < products.Count)
                    {
                        break;
                    }

                    PrintColoredMessage("Invalid choice. Please try again.", MessageStatus.Error);
                }

                shopSystem.AddProductToBuyerCart((Buyer)selectedUser, products[productChoice]);
                PrintColoredMessage("Product added to the buyer's cart successfully.", MessageStatus.Passed);
            }
            catch (Exception ex)
            {
                PrintColoredMessage($"Error adding product to buyer cart: {ex.Message}", MessageStatus.Error);
            }
        }

        private static int DisplayAndSelectProduct(List<Product> products)
        {
            Console.WriteLine("\nSelect a product from the list:");
            for (int j = 0; j < products.Count; j++)
            {
                Console.WriteLine($"{j + 1}. {products[j]}");
            }

            return GetValidIntegerInput("\nEnter your choice: ") - 1;
        }
        ////////////////////////////////////////////////////////////////////////
        //////////////////////// Order Management Methods ////////////////////////
        static void ProcessOrderForBuyer(ShopSystem shopSystem)
        {
            User selectedUser = GetRequestedUserChoice(shopSystem.GetAllBuyers(), UserType.Buyer);
            if (selectedUser == null)
            {
                return;
            }

            try
            {
                shopSystem.ProcessOrder((Buyer)selectedUser);
                PrintColoredMessage("Order processed successfully.", MessageStatus.Passed);
            }
            catch (Exception ex)
            {
                PrintColoredMessage($"Error processing order: {ex.Message}", MessageStatus.Error);
            }
        }



        static void DisplayOrderHistory(Buyer buyer)
        {
            if (buyer.OrderHistory.Count == 0)
            {
                throw new InvalidOperationException("Order history is empty.");
            }

            for (int i = 1; i <= buyer.OrderHistory.Count; i++)
            {
                Console.WriteLine($"{i}: {buyer.OrderHistory[i - 1]}");
            }
        }

        static void SelectOrderForNewCart(ShopSystem shopSystem)
        {
            User selectedUser = GetRequestedUserChoice(shopSystem.GetAllBuyers(), UserType.Buyer);
            if (selectedUser == null)
            {
                return;
            }
            try
            {
                DisplayOrderHistory((Buyer)selectedUser);
                int orderIndex;
                while (true)
                {
                    orderIndex = GetValidIntegerInput("Enter the index of the order to create a new cart from:") - 1;

                    if (orderIndex >= 0 && orderIndex < ((Buyer)selectedUser).GetCountOfOrderHistory())
                    {
                        break;
                    }

                    PrintColoredMessage("Invalid order index. Please try again.", MessageStatus.Error);
                }

                shopSystem.CreateCartFromHistory((Buyer)selectedUser, orderIndex);
                PrintColoredMessage("New cart created from selected order.", MessageStatus.Passed);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                PrintColoredMessage($"{ex.Message}", MessageStatus.Error);

            }
            catch (FormatException)
            {
                PrintColoredMessage("Invalid input. Please enter a valid order index.", MessageStatus.Error);
            }
            catch (InvalidOperationException ex)
            {
                PrintColoredMessage($"{ex.Message}", MessageStatus.Error);
            }
        }
        ////////////////////////////////////////////////////////////////////////
        //////////////////////// Shop System Methods ////////////////////////
        private static void CompareShoppers(ShopSystem shopSystem)
        {
            List<User> buyers = shopSystem.GetAllBuyers();

            if (buyers.Count < 2)
            {
                Console.WriteLine("There are not enough buyers to compare.");
                return;
            }


            if (!(SelectUser(buyers, UserType.Buyer) is Buyer buyer1) || !(SelectUser(buyers, UserType.Buyer) is Buyer buyer2))
            {
                Console.WriteLine("Invalid selection of buyers.");
                return;
            }

            if (buyer1 < buyer2)
            {
                Console.WriteLine($"{buyer1.Username} has a smaller shopping cart total than {buyer2.Username}.");
            }
            else if (buyer1 > buyer2)
            {
                Console.WriteLine($"{buyer1.Username} has a larger shopping cart total than {buyer2.Username}.");
            }
            else
            {
                Console.WriteLine("Both buyers have the same shopping cart total.");
            }
        }

        public static void ShowUsers(ShopSystem shopSystem, UserType userType)
        {
            List<User> users;
            if (userType == UserType.Buyer)
            {
                users = shopSystem.GetAllBuyers();
            }
            else if (userType == UserType.Seller)
            {
                users = shopSystem.GetAllSellersSorted();
            }
            else
            {
                PrintColoredMessage("Invalid user type.", MessageStatus.Error);
                return;
            }

            if (users.Count == 0)
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
        ////////////////////////////////////////////////////////////////////////
        //////////////////////// Utility Methods ////////////////////////
        public static void PrintColoredMessage(string message, MessageStatus status)
        {
            ConsoleColor currentColor = Console.ForegroundColor;

            Console.ForegroundColor = (ConsoleColor)status;
            Console.WriteLine("\n" + message);

            Console.ForegroundColor = currentColor;
        }
        ////////////////////////////////////////////////////////////////////////
    }
}
