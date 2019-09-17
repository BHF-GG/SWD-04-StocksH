using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StocksH
{
    class Program
    {
        static void Main(string[] args)
        {
            Portfolio portfolio = new Portfolio();

            Stock Vestas = new Stock("Vestas", 600);
            Stock Ambu = new Stock("Ambu", 300);
            Stock DB = new Stock("Danske Bank", 100);

            portfolio.AddStock(Vestas);
            portfolio.AddStock(Ambu);
            portfolio.AddStock(DB);


            while (true)
            {
                

            }
        }
    }
}
