using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    public class Buyer : UserBase
    {
        private List<Order> orderHistory;

        public Buyer(string username, string password, Address address) : base(username, password, address)
        {
            orderHistory = new List<Order>();
        }

        public Buyer(Buyer other) : this(other.username, other.password, other.address) { }

        public static bool operator <(Buyer b1, Buyer b2)
        {
            return b1.GetTotalCartAmount() < b2.GetTotalCartAmount();
        }

        public static bool operator >(Buyer b1, Buyer b2)
        {
            return b1.GetTotalCartAmount() > b2.GetTotalCartAmount();
        }

        private double GetTotalCartAmount()
        {
            double totalPrice = 0;
            foreach (Product product in items)
            {
                if (product != null)
                {
                    totalPrice += product.GetFinalPrice();
                }
            }
            return totalPrice;
        }

        public List<Order> OrderHistory
        {
            get
            {
                return new List<Order>(orderHistory);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Order history cannot be null.");
                }
                orderHistory = value;
            }
        }

        public int GetCountOfOrderHistory()
        {
            return orderHistory.Count();
        }



        public void PlaceOrder()
        {
            if (items == null || items.Count < 2)
            {
                throw new InvalidOperationException("Cannot place order with less than two items in the shopping cart.");
            }

            List<Product> cartProducts = new List<Product>(items);
            Order newOrder = new Order(this, GetTotalCartAmount(), cartProducts);

            orderHistory.Add(newOrder);
            items.Clear();
        }

        public void CreateCartFromOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order cannot be null.");
            }

            items.Clear();
            foreach (Product product in order.Products)
            {
                items.Add(new Product(product));
            }
        }

        public void CreateCartFromHistory(int orderIndex)
        {
            if (orderIndex < 0 || orderIndex >= orderHistory.Count)
            {
                throw new ArgumentOutOfRangeException("orderIndex", "Invalid order index.");
            }
            Order selectedOrder = orderHistory[orderIndex];
            CreateCartFromOrder(selectedOrder);
        }




        public override string ToString()
        {
            string details = "----- Buyer Details -----\n";
            details += base.ToString();
            details += $"Items in Cart: {items.Count}\n";
            details += $"Orders in History: {orderHistory.Count}\n";

            if (items.Count > 0)
            {
                details += "----- Shopping Cart Items -----\n";
                int productCount = 0;
                foreach (Product product in items)
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

            if (orderHistory.Count > 0)
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

        public bool IsOrderHistoryEqual(List<Order> otherOrderHistory)
        {
            if (otherOrderHistory.Count == orderHistory.Count)
            {
                for (int i = 0; i < orderHistory.Count; i++)
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

        public override bool Equals(object other)
        {
            if (other is Buyer otherBuyer)
            {
                return base.Equals(otherBuyer) &&
                       IsOrderHistoryEqual(otherBuyer.orderHistory);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}