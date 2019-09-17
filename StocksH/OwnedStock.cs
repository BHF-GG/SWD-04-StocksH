using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksH
{
    public class OwnedStock
    {
        public float Price { get; private set; }
        public string Name { get; private set; }

        public OwnedStock(string name, float price)
        {
            Name = name;
            SetPrice(price);
        }

        public void SetPrice(float price)
        {
            if (price > 0)
            {
                Price = price;
            }
        }
    }
}
