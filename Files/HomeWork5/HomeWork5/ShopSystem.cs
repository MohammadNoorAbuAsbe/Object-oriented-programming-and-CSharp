using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    public class ShopSystem
    {
        private string systemName;
        private List<User> buyers = new List<User>();
        private List<User> sellers = new List<User>();

        public ShopSystem(string name)
        {
            SystemName = name;
        }

        public static ShopSystem operator +(ShopSystem shopSystem, User user)
        {
            shopSystem.AddUser(user);
            return shopSystem;
        }


        public void AddUser(string username, string password, string streetName, int buildingNumber, string city, string country, UserType userType)
        {
            if (UserExists(username))
            {
                throw new Exception("User already exists.");
            }

            Address address = new Address(streetName, buildingNumber, city, country);

            if (userType == UserType.Buyer)
            {
                buyers.Add(new Buyer(username, password, address));
            }
            else
            {
                sellers.Add(new Seller(username, password, address));
            }
        }

        public void AddUser(User user)
        {
            if (UserExists(user.Username))
            {
                throw new Exception("User already exists.");
            }

            if (user is Buyer)
            {
                buyers.Add(user);
            }
            else if (user is Seller)
            {
                sellers.Add(user);
            }
        }


        public void AddProductToSeller(Seller selectedUser, string name, double price, double specialPackagingPrice, ProductCategory category)
        {
            if (FindUserByUsername(sellers, selectedUser.Username) is Seller seller)
            {
                Product newProduct;
                if (specialPackagingPrice > 0)
                {
                    newProduct = new SpecialPackagingProduct(name, price, category, specialPackagingPrice, -1, seller);
                }
                else
                {
                    newProduct = new Product(name, price, category, -1, seller);
                }
                try
                {
                    seller.AddProduct(newProduct);
                }
                catch (InvalidOperationException ex)
                {
                    Product.ReduceSerialNumber();
                    throw ex;
                }

            }
            else
            {
                throw new Exception("Seller not found.");
            }
        }

        public void AddProductToBuyerCart(Buyer selectedUser, Product product)
        {
            if (FindUserByUsername(buyers, selectedUser.Username) is Buyer buyer)
            {
                Product newProduct;
                if (product is SpecialPackagingProduct specialPackagingProduct)
                {
                    newProduct = new SpecialPackagingProduct(specialPackagingProduct);
                }
                else
                {
                    newProduct = new Product(product);
                }
                buyer.AddProduct(newProduct);
            }
            else
            {
                throw new Exception("Buyer not found.");
            }
        }

        private User FindUserByUsername(List<User> users, string username)
        {
            foreach (var user in users)
            {
                if (user.Username == username)
                {
                    return user;
                }
            }
            return null;
        }

        public void ProcessOrder(Buyer selectedUser)
        {
            if (FindUserByUsername(buyers, selectedUser.Username) is Buyer buyer)
            {
                buyer.PlaceOrder();
            }
            else
            {
                throw new Exception("Buyer not found.");
            }
        }

        public List<User> GetAllBuyers()
        {
            return buyers;
        }

        public List<User> GetAllSellers()
        {
            return sellers;
        }

        public List<User> GetAllSellersSorted()
        {
            List<Seller> sellers = new List<Seller>();
            foreach (User user in GetAllSellers())
            {
                if (user is Seller seller)
                {
                    sellers.Add(seller);
                }
            }

            sellers.Sort();

            List<User> sortedUsers = new List<User>();
            foreach (Seller seller in sellers)
            {
                sortedUsers.Add(seller);
            }

            return sortedUsers;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> allProducts = new List<Product>();
            foreach (Seller seller in sellers)
            {
                if (seller != null)
                {
                    allProducts.AddRange(seller.Products);
                }
            }
            return allProducts;
        }

        private bool UserExists(string username)
        {
            return FindUserByUsername(buyers, username) != null || FindUserByUsername(sellers, username) != null;
        }

        public string SystemName
        {
            get
            {
                return systemName;
            }
            set
            {
                if (systemName != null)
                {
                    throw new Exception("System name is already set.");
                }

                systemName = value;
            }
        }

        public void UpdateProductsSerialNumber(int value)
        {
            Product.SetGlobalSerialNumber(value);
        }

        public void CreateCartFromHistory(Buyer selectedUser, int orderIndex)
        {
            if (FindUserByUsername(buyers, selectedUser.Username) is Buyer)
            {
                selectedUser.CreateCartFromHistory(orderIndex);
            }
            else
            {
                throw new Exception("Buyer not found in the system.");
            }
        }
    }
}
