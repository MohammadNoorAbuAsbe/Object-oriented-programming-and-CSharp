using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork2
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

        public string Print(int numberOfTabs)
        {
            string tabs = "";
            for (int i = 0; i < numberOfTabs; i++)
            {
                tabs += "\t";
            }

            string productDetails = "";
            int productNumber = 1;
            foreach (var product in products)
            {
                if (productDetails != "") productDetails += "\n\n" + tabs;
                productDetails += $"\t{productNumber}. " + product.Print(numberOfTabs + 1);
                productNumber++;
            }

            string orderDetails = $"Order Details:\n{tabs}Total Price: ${totalPrice}\n{tabs}Products:\n{tabs}{productDetails}";
            return orderDetails;
        }
    }
}