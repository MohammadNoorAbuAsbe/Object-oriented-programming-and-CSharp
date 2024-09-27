
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    public enum ProductCategory
    {
        Children = 1,
        Electricity = 2,
        Office = 3,
        Clothing = 4
    }

    public class Product
    {
        private static int serialNumber = 1;
        private int productSerialNumber;
        private string name;
        private double price;
        private ProductCategory category;
        private Seller seller;

        public Product(string name, double price, ProductCategory category, int productSerialNumber, Seller seller)
        {
            SetName(name);
            SetPrice(price);
            SetCategory(category);
            SetSeller(seller);
            SetSerialNumber(productSerialNumber);
        }

        public Product(Product other) : this(other.name, other.price, other.category, other.productSerialNumber, other.seller) { }

        public string GetName()
        {
            return name;
        }

        public double GetPrice()
        {
            return price;
        }

        public virtual double GetFinalPrice()
        {
            return price;
        }

        public ProductCategory GetCategory()
        {
            return category;
        }

        public int GetSerialNumber()
        {
            return productSerialNumber;
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

        public bool SetCategory(ProductCategory category)
        {
            this.category = category;
            return true;
        }

        public bool SetSerialNumber(int productSerialNumber)
        {
            if (productSerialNumber == -1)
            {
                this.productSerialNumber = serialNumber++;
            }
            else this.productSerialNumber = productSerialNumber;
            return true;
        }

        public bool SetSeller(Seller seller)
        {
            this.seller = seller;
            return true;
        }

        public Seller GetSeller()
        {
            return seller;
        }

        public override string ToString()
        {
            return $"Product Details:\nSerial Number: {productSerialNumber}\n" +
                    $"Name: {name}\n" +
                    $"Category: {category}\n" +
                    $"Seller: {seller.GetUsername()}\n" +
                    $"Price: {price}\n";
        }

        public override bool Equals(object other)
        {
            if (other is Product otherProduct)
            {
                return this.productSerialNumber == otherProduct.productSerialNumber &&
                       this.name == otherProduct.name &&
                       this.price == otherProduct.price &&
                       this.category == otherProduct.category &&
                       this.seller.Equals(otherProduct.seller);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}