using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace StocksH
{
    public class Stock : ISubject
    {
        public float Price { get; private set; }
        public string Name { get; private set; }

        private Random _random;
        private List<IObserver> _observers;

        private System.Timers.Timer aTimer;
        private Thread _thread;
        private Random rand;

        public Stock(string name, int price)
        {
            Name = name;
            Price = price;
            _observers = new List<IObserver>();

            int priceAsInteger = (int)Price;
            _thread = new Thread(() => AutoUpdate(priceAsInteger / 20));

            _thread.Start();
        }

        public void Register(IObserver observer)
        {
            _observers.Add(observer);
        }
        public void UnRegister(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyAll()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public void ChangePriceUp()
        {
            //Price = Price + 5;
            float percentChange = 1 + GetRandomPercent();
            Price = Price * percentChange;
            Console.WriteLine($"\n{Name} - Price up by factor: {percentChange}\n");
            NotifyAll();
        }

        public void ChangePriceDown()
        {
            //Price = Price - 5;
            float percentChange = 1 - GetRandomPercent();
            Price = Price * percentChange;
            Console.WriteLine($"\n{Name} - Price down by factor: {percentChange}\n");
            NotifyAll();
        }

        private float GetRandomPercent()
        {
            _random = new Random();
            float number = _random.Next(1, 6);

            return number / 100;
        }

        public void AutoUpdate(int waitTime)
        {
            aTimer = new Timer(waitTime*500);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

            
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            rand = new Random();

            if (rand.Next(1, 3) == 1)
                ChangePriceUp();
            else
                ChangePriceDown();
        }
    }
}
