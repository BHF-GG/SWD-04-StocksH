using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksH
{
    public class Portfolio : IObserver
    {
        private List<OwnedStock> _stocks;
        private IDisplay _display;
        private OwnedStock _ownedStock;

        public Portfolio()
        {
            _stocks = new List<OwnedStock>();
            _display = new Display();
        }

        public void AddStock(Stock stock)
        {
            stock.Register(this);
            _stocks.Add(new OwnedStock(stock.Name, stock.Price));
        }

        public void RemoveStock(Stock stock)
        {
            
            string name = stock.Name;
            foreach (var ownedStock in _stocks)
            {
                if (ownedStock.Name == name)
                {
                    _stocks.Remove(ownedStock);
                    break;
                }
            }
            stock.UnRegister(this);
        }

        public void Update(Stock stock)
        {
            foreach (var ownedStock in _stocks)
            {
                if (ownedStock.Name == stock.Name)
                {
                    ownedStock.SetPrice(stock.Price);
                }
            }
            _display.OutPutInformation(_stocks);
        }
    }
}
