using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    public static class EqualityUtils
    {
        public static bool ProductsEqualityCompare(Product[] products, Product[] otherProducts, int capacity, int actualSize, int otherCapacity, int otherActualSize)
        {
            if (capacity == otherCapacity && actualSize == otherActualSize && otherProducts.Length == products.Length)
            {
                for (int i = 0; i < actualSize; i++)
                {
                    if (!products[i].Equals(otherProducts[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
