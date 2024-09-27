using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork3
{
    public class Order
    {
        private Product[] products;
        private double totalPrice;
        private Buyer buyerAccount;

        public Order(Buyer buyerAccount, double totalPrice, Product[] products)
        {
            SetBuyerAccount(buyerAccount);
            SetTotalPrice(totalPrice);
            SetProducts(products);
        }

        public Order(Order other) : this(other.buyerAccount, other.totalPrice, other.products) { }

        public Product[] GetProducts()
        {
            return products;
        }

        public bool SetProducts(Product[] value)
        {
            if (value != null && value.Length > 0)
            {
                products = value;
                return true;
            }
            return false;
        }

        public double GetTotalPrice()
        {
            return totalPrice;
        }

        public bool SetTotalPrice(double value)
        {
            if (value >= 0)
            {
                totalPrice = value;
                return true;
            }
            return false;
        }

        public Buyer GetBuyerAccount()
        {
            return buyerAccount;
        }

        public bool SetBuyerAccount(Buyer value)
        {
            if (value != null)
            {
                buyerAccount = value;
                return true;
            }
            return false;
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

        public bool ProductsEqualityCompare(Product[] otherProducts)
        {
            return EqualityUtils.ProductsEqualityCompare(products, otherProducts, products.Length, products.Length, otherProducts.Length, otherProducts.Length);
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