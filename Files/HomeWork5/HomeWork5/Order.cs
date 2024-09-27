using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork5
{
    public class Order
    {
        private List<Product> products;
        private double totalPrice;
        private Buyer buyerAccount;

        public Order(Buyer buyerAccount, double totalPrice, List<Product> products)
        {
            BuyerAccount = buyerAccount;
            TotalPrice = totalPrice;
            Products = products;
        }

        public Order(Order other) : this(other.buyerAccount, other.totalPrice, other.products) { }

        public List<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentException("Products list cannot be null or empty.");
                }
                products = value;
            }
        }

        public double TotalPrice
        {
            get { return totalPrice; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Total price cannot be negative.");
                }
                totalPrice = value;
            }
        }

        public Buyer BuyerAccount
        {
            get { return buyerAccount; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Buyer account cannot be null.");
                }
                buyerAccount = value;
            }
        }

        public override string ToString()
        {
            string productDetails = "";
            int productNumber = 1;
            foreach (var product in products)
            {
                if (productDetails != "") productDetails += "\n\n";
                productDetails += $"\t{productNumber}. " + product.ToString();
                productNumber++;
            }

            string orderDetails = $"Order Details:\nTotal Price: ${totalPrice}\nProducts:\n{productDetails}";
            return orderDetails;
        }

        public bool ProductsEqualityCompare(List<Product> otherProducts)
        {
            return EqualityUtils.ProductsEqualityCompare(products, otherProducts);
        }

        public override bool Equals(object other)
        {
            if (other is Order otherOrder)
            {
                return this.totalPrice == otherOrder.totalPrice &&
                       this.buyerAccount.Equals(otherOrder.buyerAccount) &&
                       ProductsEqualityCompare(otherOrder.products);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}