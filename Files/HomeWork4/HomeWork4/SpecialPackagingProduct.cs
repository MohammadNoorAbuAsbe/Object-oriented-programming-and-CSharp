using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    public class SpecialPackagingProduct : Product
    {
        private double specialPackagingPrice;

        public SpecialPackagingProduct(string name, double price, ProductCategory category, double specialPackagingPrice, int productSerialNumber, Seller seller)
            : base(name, price, category, productSerialNumber, seller)
        {
            SpecialPackagingPrice = specialPackagingPrice;
        }

        public SpecialPackagingProduct(SpecialPackagingProduct other) : this(other.Name, other.Price, other.Category, other.specialPackagingPrice, other.SerialNumber, other.Seller) { }


        public double SpecialPackagingPrice
        {
            get { return specialPackagingPrice; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Special packaging price cannot be negative.");
                }
                specialPackagingPrice = value;
            }
        }

        public override double GetFinalPrice()
        {
            return base.GetFinalPrice() + SpecialPackagingPrice;
        }

        public override string ToString()
        {
            return base.ToString() +
                    $"special Packaging Price: {SpecialPackagingPrice}\n" +
                    $"Final Price: {GetFinalPrice()}\n";
        }

        public override bool Equals(object other)
        {
            if (other is SpecialPackagingProduct otherSpecialPackagingProduct)
            {
                return this.specialPackagingPrice == otherSpecialPackagingProduct.specialPackagingPrice &&
                       base.Equals(otherSpecialPackagingProduct);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + specialPackagingPrice.GetHashCode();
        }
    }
}