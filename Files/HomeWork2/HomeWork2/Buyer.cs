using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    public class Buyer
    {
        private string username;
        private string password;
        private Address address;
        private Product[] shoppingCart;
        private Order[] orderHistory;
        private int cartSize = 0;
        private int orderHistorySize = 0;
        private int cartCapacity = 4;
        private int orderHistoryCapacity = 4;

        public Buyer(string username, string password, Address address)
        {
            shoppingCart = new Product[cartCapacity];
            orderHistory = new Order[orderHistoryCapacity];
            SetUsername(username);
            SetPassword(password);
            SetAddress(address);
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

        public Product[] GetShoppingCart()
        {
            return shoppingCart;
        }

        public bool SetShoppingCart(Product[] cart)
        {
            if (cart != null)
            {
                shoppingCart = cart;
                return true;
            }
            return false;

        }

        public Order[] GetOrderHistory()
        {
            return orderHistory;
        }

        public bool SetOrderHistory(Order[] history)
        {
            if (history != null)
            {
                orderHistory = history;
                return true;
            }
            return false;
        }

        public int GetCartSize()
        {
            return cartSize;
        }

        private bool SetCartSize(int value)
        {
            if (value >= 0 && value <= cartCapacity)
            {
                cartSize = value;
                return true;
            }
            return false;
        }

        public int GetOrderHistorySize()
        {
            return orderHistorySize;
        }

        private bool SetOrderHistorySize(int value)
        {
            if (value >= 0 && value <= orderHistoryCapacity)
            {
                orderHistorySize = value;
                return true;
            }
            return false;
        }

        public void AddToCart(Product product)
        {
            if (product != null)
            {
                if (cartSize >= cartCapacity)
                {
                    SetCartCapacity(cartCapacity * 2);
                }
                shoppingCart[cartSize++] = product;
            }
        }

        public void PlaceOrder()
        {
            if (cartSize > 0)
            {
                Product[] cartProducts = new Product[cartSize];
                Array.Copy(shoppingCart, cartProducts, cartSize);

                double totalPrice = 0;
                foreach (Product product in cartProducts)
                {
                    if (product != null)
                    {
                        totalPrice += product.GetPrice();
                    }
                }

                Order newOrder = new Order(this, totalPrice, cartProducts);

                if (orderHistorySize >= orderHistoryCapacity)
                {
                    SetOrderHistoryCapacity(orderHistoryCapacity * 2);
                }

                orderHistory[orderHistorySize++] = newOrder;
                Array.Clear(shoppingCart, 0, cartSize);
                cartSize = 0;
            }
        }

        public bool SetCartCapacity(int newCapacity)
        {
            if (newCapacity > 0 && newCapacity >= cartSize)
            {
                Product[] newCart = new Product[newCapacity];
                Array.Copy(shoppingCart, newCart, cartSize);
                shoppingCart = newCart;
                cartCapacity = newCapacity;
                return true;
            }
            return false;
        }

        private bool SetOrderHistoryCapacity(int newCapacity)
        {
            if (newCapacity >= orderHistorySize)
            {
                Order[] newHistory = new Order[newCapacity];
                Array.Copy(orderHistory, newHistory, orderHistorySize);
                orderHistory = newHistory;
                orderHistoryCapacity = newCapacity;
                return true;
            }
            return false;
        }


        public string Print()
        {
            string details = "----- Buyer Details -----\n";
            details += $"Username: {username}\n";
            details += $"Password: {password}\n";
            details += $"Address: {address.Print(1)}\n";
            details += $"Items in Cart: {cartSize}\n";
            details += $"Orders in History: {orderHistorySize}\n";

            if (cartSize > 0)
            {
                details += "----- Shopping Cart Items -----\n";
                int productCount = 0;
                foreach (Product product in shoppingCart)
                {
                    if (product != null)
                    {
                        productCount++;
                        details += $"{productCount}. {product.Print(1)}\n\n";
                    }
                }
            }
            else
            {
                details += "Shopping Cart is empty.\n";
            }

            if (orderHistorySize > 0)
            {
                details += "----- Order History -----\n";
                int orderCount = 0;
                foreach (Order order in orderHistory)
                {
                    if (order != null)
                    {
                        orderCount++;
                        details += $"{orderCount}. {order.Print(1)}\n\n";
                    }
                }
            }
            else
            {
                details += "Order History is empty.\n";
            }

            return details;
        }
    }
}