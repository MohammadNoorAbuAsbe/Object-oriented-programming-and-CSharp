using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    public class SpecialPackagingProduct : Product
    {
        private double specialPackagingPrice;

        public SpecialPackagingProduct(string name, double price, ProductCategory category, double specialPackagingPrice, int productSerialNumber, Seller seller)
            : base(name, price, category, productSerialNumber, seller)
        {
            SetSpecialPackagingPrice(specialPackagingPrice);
        }

        public SpecialPackagingProduct(SpecialPackagingProduct other) : this(other.GetName(), other.GetPrice(), other.GetCategory(), other.specialPackagingPrice, other.GetSerialNumber(), other.GetSeller()) { }


        public double GetSpecialPackagingPrice()
        {
            return specialPackagingPrice;
        }

        public bool SetSpecialPackagingPrice(double price)
        {
            if (price >= 0)
            {
                specialPackagingPrice = price;
                return true;
            }
            return false;
        }

        public override double GetFinalPrice()
        {
            return base.GetFinalPrice() + GetSpecialPackagingPrice();
        }

        public override string ToString()
        {
            return base.ToString() +
                    $"special Packaging Price: {GetSpecialPackagingPrice()}\n" +
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