using System;

namespace Assignment3
{
    public class BeforePrint : EventArgs
    {
        public BeforePrint(string msg)
        {
            Message = "BeforePrintEvent fires from Print" + msg;

        }

        public BeforePrint()
        {
            Message = "BeforPrintEventHandler: PrintHelper is going to print a value";
        }

        public string Message { get; }
    }
    class Number
    {
        public Number(int val)
        {
            _value = val;
        }

        private int _value;
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public void NumberInfo(object sender, BeforePrint e)
        {
            Console.WriteLine(_value + " " + e.Message);
        }
    }

    public class PrintHelper
    {

        public event EventHandler<BeforePrint> NewNumberInfo;

        public void NewHelper(int val, string msg)
        {
            NewNumberInfo?.Invoke(this, new BeforePrint(msg));
            PrintMoney(val);
        }

        public void NewHelper(int val)
        {
            NewNumberInfo?.Invoke(this, new BeforePrint());
            PrintNumber(val);
        }
        public void PrintNumber(int num)
        {
            Console.WriteLine("Number: {0,-12:N0}", num);
        }
        public void PrintMoney(int money)
        {
            Console.WriteLine("Money: {0:C}", money);
        }

    }

    class Program
    {
        static void Main()
        {
            var printHelper = new PrintHelper();
            var Number = new Number(10000);
            printHelper.NewNumberInfo += Number.NumberInfo;
            printHelper.NewHelper(Number.Value, "Money");
            //printHelper.NewNumberInfo -= Money.NumberInfo;

            //var Number = new Number(10000);
            //printHelper.NewNumberInfo += Number.NumberInfo;
            printHelper.NewHelper(Number.Value);


        }
    }
}