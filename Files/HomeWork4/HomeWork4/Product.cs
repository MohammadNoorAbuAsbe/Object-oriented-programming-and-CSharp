
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
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
            Name = name;
            Price = price;
            Category = category;
            Seller = seller;
            SerialNumber = productSerialNumber;
        }

        public Product(Product other) : this(other.name, other.price, other.category, other.productSerialNumber, other.seller) { }

        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Name cannot be null.");
                }

                name = value;
            }
        }

        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative.");
                }
                price = value;
            }
        }

        public ProductCategory Category
        {
            get { return category; }
            set { category = value; }
        }

        public int SerialNumber
        {
            get { return productSerialNumber; }
            set
            {
                if (value == -1)
                {
                    productSerialNumber = serialNumber++;
                }
                else
                {
                    productSerialNumber = value;
                }
            }
        }

        public Seller Seller
        {
            get { return seller; }
            set { seller = value; }
        }

        public virtual double GetFinalPrice()
        {
            return price;
        }

        public static void ReduceSerialNumber()
        {
            serialNumber--;
        }

        public override string ToString()
        {
            return $"Product Details:\nSerial Number: {productSerialNumber}\n" +
                    $"Name: {name}\n" +
                    $"Category: {category}\n" +
                    $"Seller: {seller.Username}\n" +
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