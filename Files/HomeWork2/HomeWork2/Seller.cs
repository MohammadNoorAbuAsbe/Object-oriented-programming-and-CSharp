using System;

namespace HomeWork2
{
    public class Seller
    {
        private string username;
        private string password;
        private Address address;
        private Product[] products;
        private int actualSize = 0;
        private int capacity = 4;

        public Seller(string username, string password, Address address)
        {
            SetPassword(password);
            SetAddress(address);
            SetUsername(username);
            products = new Product[capacity];
        }

        public string GetUsername()
        {
            return username;
        }

        public bool SetUsername(string username)
        {
            if (username != null)
            {
                this.username = username;
                return true;
            }
            return false;
        }

        public string GetPassword()
        {
            return password;
        }

        public bool SetPassword(string password)
        {
            if (password != null)
            {
                this.password = password;
                return true;
            }
            return false;
        }

        public Address GetAddress()
        {
            return address;
        }

        public bool SetAddress(Address address)
        {
            if (address != null)
            {
                this.address = address;
                return true;
            }
            return false;
        }

        public Product[] GetProducts()
        {
            Product[] activeProducts = new Product[actualSize];
            Array.Copy(products, activeProducts, actualSize);
            return activeProducts;
        }

        public bool SetProducts(Product[] products)
        {
            if (products != null)
            {
                this.products = products;
                return true;
            }
            return false;
        }

        public int GetActualSize()
        {
            return actualSize;
        }

        private bool SetActualSize(int value)
        {
            if (value >= 0 && value <= capacity)
            {
                actualSize = value;
                return true;
            }
            return false;
        }

        public int GetCapacity()
        {
            return capacity;
        }

        public bool SetCapacity(int value)
        {
            if (value > 0 && value >= actualSize)
            {
                capacity = value;
                Product[] newProducts = new Product[capacity];
                Array.Copy(products, newProducts, actualSize);
                products = newProducts;
                return true;
            }
            return false;
        }

        public bool AddProduct(Product product)
        {
            for (int i = 0; i < actualSize; i++)
            {
                if (products[i] != null && products[i].GetName() == product.GetName())
                {
                    return false;
                }
            }

            if (actualSize == capacity)
            {
                if (!IncreaseCapacity())
                {
                    return false;
                }
            }

            products[actualSize] = product;
            if (!SetActualSize(actualSize + 1))
            {
                return false;
            }
            return true;
        }

        private bool IncreaseCapacity()
        {
            return SetCapacity(capacity * 2);
        }

        public string Print()
        {
            string details = "----- Seller Details -----\n";
            details += $"Username: {username}\n";
            details += $"Password: {password}\n";
            details += $"Address: {address.Print(1)}\n";
            details += $"Products:\n";

            if (actualSize == 0)
            {
                details += $"\tNo products available.\n";
            }
            else
            {
                for (int i = 0; i < actualSize; i++)
                {
                    details += $"\tProduct {i + 1}: {products[i].Print(2)}\n";
                }
            }
            return details;
        }
    }
}