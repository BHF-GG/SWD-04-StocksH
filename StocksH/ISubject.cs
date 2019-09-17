using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksH
{
    public interface ISubject
    {
        void Register(IObserver observer);

        void UnRegister(IObserver observer);

        void NotifyAll();
    }
}
