using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Assignment3Problem2
{
    public class EventData : EventArgs
    {
        public EventData(string n, int val, int change)
        {
            this.name = n;
            this.currentValue = val;
            this.stockChanges = change;
        }

        public string name { get; }
        public int currentValue { get; }
        public int stockChanges { get; }
    }

    public class Stock
    {

        public event EventHandler<EventData> stockEvent;
        string name;
        int InitialValue;
        int currentValue;
        int maxChange;
        int notificationThreshold;
        int changes;
        Thread thread;
        public Stock(string name, int startingValue, int maxchange, int threshold)
        {
            this.name = name;
            this.maxChange = maxchange;
            InitialValue = startingValue;
            currentValue = InitialValue;
            notificationThreshold = threshold;
            thread = new Thread(new ThreadStart(Activate));
            changes = 0;
            thread.Start();

        }

        public void Activate()
        {
            for (; ; )
            {
                if (changes > 50) break;
                Thread.Sleep(500);
                ChangeStockValue();
                changes++;
            }
        }

        public void ChangeStockValue()
        {
            Random rand = new Random();
            currentValue += rand.Next(1, maxChange);
            if ((currentValue - InitialValue) > notificationThreshold)
            {
                stockEvent?.Invoke(this, new EventData(name, currentValue, changes));
            }
        }
    }

    public class StockBroker
    {
        string name;
        List<Stock> stocks;
        static bool needsHeader = true;
        public StockBroker(string name)
        {
            this.name = name;
            this.stocks = new List<Stock>();
        }

        public void AddStock(Stock stock)
        {
            stocks.Add(stock);
            stock.stockEvent += Notify;
        }

        public void Notify(Object sender, EventData e)
        {
            WriteToFile(e.name, e.currentValue, e.stockChanges);
        }

        public async Task WriteToFile(string stockName, int currentValue, int changes)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string path = Path.Combine(docPath, "Stocks.txt");

            if (needsHeader)
            {
                string header = "";
                header += "Broker".PadRight(10, ' ');
                header += "Stock".PadRight(10, ' ');
                header += "Value".PadRight(10, ' ');
                header += "Changes".PadRight(10, ' ');
                header += "Date/Time\n\n".PadRight(10, ' ');
                using (StreamWriter sw = File.AppendText(path)) await sw.WriteAsync(header);
                Console.WriteLine(header);
                needsHeader = false;
            }
            DateTime datetime = DateTime.Now;
            using (StreamWriter outputFile = File.AppendText(path))
            {
                string line = $"{name}".PadRight(10, ' ');
                line += $"{stockName}".PadRight(10, ' ');
                line += $"{currentValue}".PadRight(10, ' ');
                line += $"{changes}".PadRight(10, ' ');
                line += $"{datetime.ToString("MM / dd / yyyy HH: mm:ss")}\n".PadRight(10,' ');
                await outputFile.WriteAsync(line);
                Console.WriteLine(line);
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Stock stock1 = new Stock("Technology", 160, 5, 15);
            Stock stock2 = new Stock("Retail", 30, 2, 6);
            Stock stock3 = new Stock("Banking", 90, 4, 10);
            Stock stock4 = new Stock("Commodity", 500, 20, 50);

            StockBroker b1 = new StockBroker("Broker 1");
            b1.AddStock(stock1);
            b1.AddStock(stock2);

            StockBroker b2 = new StockBroker("Broker 2");
            b2.AddStock(stock1);
            b2.AddStock(stock3);
            b2.AddStock(stock4);

            StockBroker b3 = new StockBroker("Broker 3");
            b3.AddStock(stock1);
            b3.AddStock(stock3);

            StockBroker b4 = new StockBroker("Broker 4");
            b4.AddStock(stock1);
            b4.AddStock(stock2);
            b4.AddStock(stock3);
            b4.AddStock(stock4);
        }
    }
}