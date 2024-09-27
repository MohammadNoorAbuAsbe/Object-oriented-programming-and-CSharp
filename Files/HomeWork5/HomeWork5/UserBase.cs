using System;
using System.Collections.Generic;

namespace HomeWork5
{
    public abstract class UserBase : User
    {
        protected List<Product> items;

        protected UserBase(string username, string password, Address address) : base(username, password, address)
        {
            items = new List<Product>();
        }

        public List<Product> Products
        {
            get
            {
                return new List<Product>(items);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Products list cannot be null.");
                }

                items = value;
            }
        }

        public virtual void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("product", "Product cannot be null.");
            }
            items.Add(product);
        }

        public bool ProductsEqualityCompare(List<Product> otherProducts)
        {
            return EqualityUtils.ProductsEqualityCompare(items, otherProducts);
        }

        public override bool Equals(object other)
        {
            if (other is UserBase otherUserBase)
            {
                return base.Equals(otherUserBase) &&
                       ProductsEqualityCompare(otherUserBase.items);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}