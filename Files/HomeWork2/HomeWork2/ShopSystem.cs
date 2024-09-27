using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    public class ShopSystem
    {
        private string systemName;
        private Buyer[] buyers;
        private Seller[] sellers;
        private int buyersCapacity = 4;
        private int buyersActualSize = 0;
        private int sellersCapacity = 4;
        private int sellersActualSize = 0;

        public ShopSystem(string name)
        {
            buyers = new Buyer[buyersCapacity];
            sellers = new Seller[sellersCapacity];
            SetSystemName(name);
        }

        public bool AddBuyer(string username, string password, string streetName, int buildingNumber, string city, string country)
        {
            if (IsUserExists(username))
            {
                return false;
            }

            Address address = new Address(streetName, buildingNumber, city, country);
            EnsureBuyersCapacity();
            Buyer buyer = new Buyer(username, password, address);
            buyers[buyersActualSize++] = buyer;
            return true;
        }

        public bool AddSeller(string username, string password, string streetName, int buildingNumber, string city, string country)
        {
            if (IsUserExists(username))
            {
                return false;
            }

            Address address = new Address(streetName, buildingNumber, city, country);
            EnsureSellersCapacity();
            Seller seller = new Seller(username, password, address);
            sellers[sellersActualSize++] = seller;
            return true;
        }

        public bool AddProductToSeller(string username, string name, double price)
        {
            Seller seller = null;
            for (int i = 0; i < sellersActualSize; i++)
            {
                if (sellers[i].GetUsername() == username)
                {
                    seller = sellers[i];
                    break;
                }
            }

            if (seller == null)
            {
                return false;
            }

            Product newProduct = new Product(name, price, seller);
            return seller.AddProduct(newProduct);
        }

        public bool AddProductToBuyerCart(string username, string productName, double price, Seller seller)
        {
            Buyer buyer = null;
            for (int i = 0; i < buyersActualSize; i++)
            {
                if (buyers[i].GetUsername() == username)
                {
                    buyer = buyers[i];
                    break;
                }
            }

            if (buyer == null)
            {
                return false;
            }

            Product newProduct = new Product(productName, price, seller);
            buyer.AddToCart(newProduct);
            return true;
        }

        public bool ProcessOrder(string username)
        {
            Buyer buyer = null;
            for (int i = 0; i < buyersActualSize; i++)
            {
                if (buyers[i].GetUsername() == username)
                {
                    buyer = buyers[i];
                    break;
                }
            }

            if (buyer == null|| buyer.GetCartSize() == 0)
            {
                return false;
            }

            buyer.PlaceOrder();
            return true;
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

        private void EnsureBuyersCapacity()
        {
            if (buyersActualSize >= buyersCapacity)
            {
                buyersCapacity *= 2;
                Buyer[] newBuyers = new Buyer[buyersCapacity];
                Array.Copy(buyers, newBuyers, buyersActualSize);
                buyers = newBuyers;
            }
        }

        private void EnsureSellersCapacity()
        {
            if (sellersActualSize >= sellersCapacity)
            {
                sellersCapacity *= 2;
                Seller[] newSellers = new Seller[sellersCapacity];
                Array.Copy(sellers, newSellers, sellersActualSize);
                sellers = newSellers;
            }
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

        public string GetSystemName(){
            return systemName;
        }

        public bool SetSystemName(string name) 
        {
            systemName = name;
            return true;
        }
    }
}
