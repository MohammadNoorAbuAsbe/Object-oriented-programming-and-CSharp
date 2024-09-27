using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    public class ShopSystem
    {
        private string systemName;
        private Buyer[] buyers;
        private Seller[] sellers;
        private int buyersCapacity = Constants.DefaultCapacity;
        private int buyersActualSize = 0;
        private int sellersCapacity = Constants.DefaultCapacity;
        private int sellersActualSize = 0;

        public ShopSystem(string name)
        {
            buyers = new Buyer[buyersCapacity];
            sellers = new Seller[sellersCapacity];
            SetSystemName(name);
        }

        public bool AddUser(string username, string password, string streetName, int buildingNumber, string city, string country, UserType userType)
        {
            if (IsUserExists(username))
            {
                return false;
            }

            Address address = new Address(streetName, buildingNumber, city, country);

            if (userType == UserType.Buyer)
            {
                buyers = AddUserOfType(username, password, address, buyers, ref buyersActualSize, ref buyersCapacity, userType) as Buyer[];
            }
            else if (userType == UserType.Seller)
            {
                sellers = AddUserOfType(username, password, address, sellers, ref sellersActualSize, ref sellersCapacity, userType) as Seller[];
            }

            return true;
        }

        private User[] AddUserOfType(string username, string password, Address address, User[] users, ref int actualSize, ref int capacity, UserType userType)
        {
            users = EnsureCapacity(ref users, actualSize, ref capacity, userType);
            if (userType == UserType.Buyer)
            {
                users[actualSize++] = new Buyer(username, password, address);
            }
            else users[actualSize++] = new Seller(username, password, address);
            return users;
        }

        private User[] EnsureCapacity(ref User[] users, int actualSize, ref int capacity, UserType userType)
        {
            if (actualSize >= capacity)
            {
                capacity *= 2;
                User[] newTypedUsers;
                if (userType == UserType.Buyer)
                {
                    newTypedUsers = new Buyer[capacity];
                }
                else newTypedUsers = new Seller[capacity];
                Array.Copy(users, newTypedUsers, actualSize);
                return newTypedUsers;
            }
            return users;
        }

        public bool AddProductToSeller(string username, string name, double price, double specialPackagingPrice, ProductCategory category)
        {
            if (FindUserByUsername(sellers, sellersActualSize, username) is Seller seller)
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
                return seller.AddProduct(newProduct);
            }
            return false;
        }

        public bool AddProductToBuyerCart(string username, Product product)
        {

            if (FindUserByUsername(buyers, buyersActualSize, username) is Buyer buyer)
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
                return buyer.AddToCart(newProduct);
            }
            return false;
        }

        private User FindUserByUsername(User[] users, int actualSize, string username)
        {
            for (int i = 0; i < actualSize; i++)
            {
                if (users[i].GetUsername() == username)
                {
                    return users[i];
                }
            }
            return null;
        }

        public bool ProcessOrder(string username)
        {
            if (FindUserByUsername(buyers, buyersActualSize, username) is Buyer buyer)
            {
                if (buyer.GetCartSize() != 0)
                {
                    buyer.PlaceOrder();
                    return true;
                }
            }
            return false;
        }

        public Buyer[] GetAllBuyers()
        {
            Buyer[] activeBuyers = new Buyer[buyersActualSize];
            Array.Copy(buyers, activeBuyers, buyersActualSize);
            return activeBuyers;
        }

        public Seller[] GetAllSellers()
        {
            Seller[] activeSellers = new Seller[sellersActualSize];
            Array.Copy(sellers, activeSellers, sellersActualSize);
            return activeSellers;
        }

        public Product[] GetAllProducts()
        {
            int totalProductCount = 0;
            foreach (Seller seller in sellers)
            {
                if (seller != null)
                {
                    totalProductCount += seller.GetProducts().Length;
                }
            }

            Product[] allProducts = new Product[totalProductCount];
            int currentIndex = 0;
            foreach (Seller seller in sellers)
            {
                if (seller != null)
                {
                    Product[] sellerProducts = seller.GetProducts();
                    Array.Copy(sellerProducts, 0, allProducts, currentIndex, sellerProducts.Length);
                    currentIndex += sellerProducts.Length;
                }
            }

            return allProducts;
        }


        public bool SetBuyersCapacity(int newCapacity)
        {
            if (newCapacity > 0 && newCapacity >= buyersActualSize)
            {
                Buyer[] newBuyers = new Buyer[newCapacity];
                Array.Copy(buyers, newBuyers, buyersActualSize);
                buyers = newBuyers;
                return true;
            }
            return false;
        }

        public bool SetSellersCapacity(int newCapacity)
        {
            if (newCapacity > 0 && newCapacity >= sellersActualSize)
            {
                Seller[] newSellers = new Seller[newCapacity];
                Array.Copy(sellers, newSellers, sellersActualSize);
                sellers = newSellers;
                return true;
            }
            return false;
        }


        private bool IsUserExists(string username)
        {
            for (int i = 0; i < buyersActualSize; i++)
            {
                if (buyers[i].GetUsername() == username)
                    return true;
            }
            for (int i = 0; i < sellersActualSize; i++)
            {
                if (sellers[i].GetUsername() == username)
                    return true;
            }
            return false;
        }

        public string GetSystemName()
        {
            return systemName;
        }

        public bool SetSystemName(string name)
        {
            systemName = name;
            return true;
        }
    }
}
