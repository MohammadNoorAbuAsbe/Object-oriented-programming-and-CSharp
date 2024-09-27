using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    public class Buyer : User
    {
        private Product[] shoppingCart;
        private Order[] orderHistory;
        private int cartSize = 0;
        private int orderHistorySize = 0;
        private int cartCapacity = Constants.DefaultCapacity;
        private int orderHistoryCapacity = Constants.DefaultCapacity;

        public Buyer(string username, string password, Address address) : base(username, password, address)
        {
            shoppingCart = new Product[cartCapacity];
            orderHistory = new Order[orderHistoryCapacity];
        }

        public Buyer(Buyer other) : this(other.username, other.password, other.address) { }

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
            Order[] copyOfOrderHistory = new Order[orderHistorySize];
            Array.Copy(orderHistory, copyOfOrderHistory, orderHistorySize);
            return copyOfOrderHistory;
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


        public int GetOrderHistorySize()
        {
            return orderHistorySize;
        }

        public bool AddToCart(Product product)
        {
            if (product != null)
            {
                if (cartSize >= cartCapacity)
                {
                    SetCartCapacity(cartCapacity * 2);
                }
                shoppingCart[cartSize++] = product;
                return true;
            }
            return false;
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
                        totalPrice += product.GetFinalPrice();
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


        public override string ToString()
        {
            string details = "----- Buyer Details -----\n";
            details += base.ToString();
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
                        details += $"{productCount}. {product}\n\n";
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
                        details += $"{orderCount}. {order}\n\n";
                    }
                }
            }
            else
            {
                details += "Order History is empty.\n";
            }

            return details;
        }

        public bool OrderHistoryEqualityCompare(Order[] otherOrderHistory, int otherOrderHistoryCapacity, int otherOrderHistorySize)
        {
            if (orderHistoryCapacity == otherOrderHistoryCapacity && orderHistorySize == otherOrderHistorySize && otherOrderHistory.Length == orderHistory.Length)
            {
                for (int i = 0; i < orderHistorySize; i++)
                {
                    if (!orderHistory[i].Equals(otherOrderHistory[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public bool ProductsEqualityCompare(Product[] otherProducts, int otherCartCapacity, int otherCartSize)
        {
            return EqualityUtils.ProductsEqualityCompare(shoppingCart, otherProducts, cartCapacity, cartSize, otherCartCapacity, otherCartSize);
        }

        public override bool Equals(object other)
        {
            if (other is Buyer otherBuyer)
            {
                return base.Equals(otherBuyer) &&
                       ProductsEqualityCompare(otherBuyer.shoppingCart, otherBuyer.cartCapacity, otherBuyer.cartSize) &&
                       OrderHistoryEqualityCompare(otherBuyer.orderHistory, otherBuyer.orderHistoryCapacity, otherBuyer.orderHistorySize);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}