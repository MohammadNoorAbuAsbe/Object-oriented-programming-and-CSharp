using System;
using System.Collections.Generic;

namespace HomeWork5
{
    public class Seller : UserBase, IComparable<Seller>
    {
        public Seller(string username, string password, Address address) : base(username, password, address) { }

        public Seller(Seller other) : this(other.username, other.password, other.address) { }

        public override void AddProduct(Product product)
        {
            foreach (Product p in items)
            {
                if (p.Name == product.Name)
                {
                    throw new InvalidOperationException("Product with the same name already exists.");
                }
            }
            items.Add(product);
        }



        public override string ToString()
        {
            string details = "----- Seller Details -----\n";
            details += base.ToString();
            details += $"Products:\n";

            if (items.Count == 0)
            {
                details += $"No products available.\n";
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    details += $"Product {i + 1}: {items[i]}\n";
                }
            }
            return details;
        }


        public override bool Equals(object other)
        {
            if (other is Seller otherSeller)
            {
                return base.Equals(otherSeller);
            }
            return false;
        }


        public int CompareTo(Seller other)
        {
            if (other == null)
            {
                return 1;
            }

            return items.Count.CompareTo(other.items.Count);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}