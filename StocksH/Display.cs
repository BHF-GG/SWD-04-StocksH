using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksH
{
    class Display : IDisplay
    {
        public void OutPutInformation(List<OwnedStock> ownedStocks)
        {
            foreach (var stock in ownedStocks)
            {
                Console.WriteLine($"Stock: {stock.Name} - Price: {stock.Price}");
            }
            Console.WriteLine("--------------------------------\n");
        }
    }
}
