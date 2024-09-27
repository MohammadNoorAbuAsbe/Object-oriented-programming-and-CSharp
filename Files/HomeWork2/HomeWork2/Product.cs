
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    public class Product
    {
        public string name;
        public double price;
        public string category;
        private double specialPackagingPrice;
        private Seller seller;

        public Product(string name, double price, string category, double specialPackagingPrice, Seller seller)
        {
            SetName(name);
            SetPrice(price);
            SetCategory(category);
            SetSpecialPackagingPrice(specialPackagingPrice);
            SetSeller(seller);
        }

        public Product(string name, double price, Seller seller) : this(name, price, "none", 0, seller) { }

        public string GetName()
        {
            return name;
        }

        public double GetPrice()
        {
            return price;
        }

        public string GetCategory()
        {
            return category;
        }

        public double GetSpecialPackagingPrice()
        {
            return specialPackagingPrice;
        }

        public bool SetName(string name)
        {
            if (name != null)
            {
                this.name = name;
                return true;
            }
            return false;
        }

        public bool SetPrice(double price)
        {
            if (price >= 0)
            {
                this.price = price;
                return true;
            }
            return false;
        }

        public bool SetCategory(string category)
        {
            if (category != null)
            {
                this.category = category;
                return true;
            }
            return false;
        }

        public bool SetSpecialPackagingPrice(double specialPackagingPrice)
        {
            if (specialPackagingPrice >= 0)
            {
                this.specialPackagingPrice = specialPackagingPrice;
                return true;
            }
            return false;
        }

        public bool SetSeller(Seller seller) {
            this.seller = seller;
            return true;
        }

        public Seller GetSeller() {
            return seller;
        }

        public string Print(int numberOfTabs)
        {
            string tabs = "";
            for (int i = 0; i < numberOfTabs; i++)
            {
                tabs += "\t";
            }
            return $"Product Details:\n{tabs}Name: {name}"
                +$"\n{tabs}Price: {price}"
                +$"\n{tabs}Category: {category}"
                +$"\n{tabs}Special Packaging Price: {specialPackagingPrice}"
                +$"\n{tabs}Seller: {seller.GetUsername()}";
        }
    }
}