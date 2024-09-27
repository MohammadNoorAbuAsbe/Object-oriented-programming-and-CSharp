using System;

namespace HomeWork3
{
    public class Seller : User
    {
        private Product[] products;
        private int actualSize = 0;
        private int capacity = Constants.DefaultCapacity;

        public Seller(string username, string password, Address address) : base(username, password, address)
        {
            products = new Product[capacity];
        }

        public Seller(Seller other) : this(other.username, other.password, other.address) { }

        public Product[] GetProducts()
        {
            Product[] activeProducts = new Product[actualSize];
            Array.Copy(products, activeProducts, actualSize);
            return activeProducts;
        }

        public bool SetProducts(Product[] products)
        {
            if (products != null)
            {
                this.products = products;
                return true;
            }
            return false;
        }

        public int GetActualSize()
        {
            return actualSize;
        }

        private bool SetActualSize(int value)
        {
            if (value >= 0 && value <= capacity)
            {
                actualSize = value;
                return true;
            }
            return false;
        }

        public int GetCapacity()
        {
            return capacity;
        }

        public bool SetCapacity(int value)
        {
            if (value > 0 && value >= actualSize)
            {
                capacity = value;
                Product[] newProducts = new Product[capacity];
                Array.Copy(products, newProducts, actualSize);
                products = newProducts;
                return true;
            }
            return false;
        }

        public bool AddProduct(Product product)
        {
            for (int i = 0; i < actualSize; i++)
            {
                if (products[i] != null && products[i].GetName() == product.GetName())
                {
                    return false;
                }
            }

            if (actualSize == capacity)
            {
                if (!IncreaseCapacity())
                {
                    return false;
                }
            }

            products[actualSize] = product;
            if (!SetActualSize(actualSize + 1))
            {
                return false;
            }
            return true;
        }

        private bool IncreaseCapacity()
        {
            return SetCapacity(capacity * 2);
        }

        public override string ToString()
        {
            string details = "----- Seller Details -----\n";
            details += base.ToString();
            details += $"Products:\n";

            if (actualSize == 0)
            {
                details += $"No products available.\n";
            }
            else
            {
                for (int i = 0; i < actualSize; i++)
                {
                    details += $"Product {i + 1}: {products[i]}\n";
                }
            }
            return details;
        }

        public bool ProductsEqualityCompare(Product[] otherProducts, int otherCapacity, int otherActualSize)
        {
            return EqualityUtils.ProductsEqualityCompare(products, otherProducts, capacity, actualSize, otherCapacity, otherActualSize);
        }

        public override bool Equals(object other)
        {
            if (other is Seller otherSeller)
            {
                return base.Equals(otherSeller) &&
                       ProductsEqualityCompare(otherSeller.products, otherSeller.capacity, otherSeller.actualSize);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}