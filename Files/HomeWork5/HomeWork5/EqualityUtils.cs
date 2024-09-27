using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeWork5
{
    public static class EqualityUtils
    {
        public static bool ProductsEqualityCompare(List<Product> products, List<Product> otherProducts)
        {
            if (otherProducts.Count == products.Count)
            {
                for (int i = 0; i < products.Count; i++)
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
