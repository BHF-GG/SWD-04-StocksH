using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksH
{
    public interface IDisplay
    {
        void OutPutInformation(List<OwnedStock> ownedStocks);
    }
}
