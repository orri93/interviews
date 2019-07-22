using System;
using System.IO;
using System.Text;

namespace Calculator
{
    interface Scanner { bool ReadNext<T>(ref T t) where T : IConvertible; }
    interface Calculator { int power(int n, int p); }

    class TextScanner : Scanner
    {
        private TextReader reader;
        public TextScanner(TextReader reader)
        {
            this.reader = reader;
        }
        public bool ReadNext<T>(ref T t) where T : IConvertible
        {
            int i;
            StringBuilder sb = new StringBuilder();
            for (i = 0; !char.IsDigit((char)i) && i >= 0; i = this.reader.Read()) ;
            while(char.IsDigit((char)i) && i >= 0)
            {
                sb.Append((char)i);
            }
            if(sb.Length > 0)
            {
                t  = (T)(((IConvertible)sb.ToString()).ToType(
                    typeof(T),
                    System.Globalization.CultureInfo.InvariantCulture));
                return true;
            } else
            {
                return false;
            }
        }
    }

    class MyCalculator : Calculator
    {
        public int power(int n, int p)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        private static readonly Calculator calculator = new MyCalculator();
        private static readonly Scanner scanner = new TextScanner(Console.In);
        static void Main(string[] args)
        {
            int n = 0, p = 0;
            while(scanner.ReadNext(ref n) && scanner.ReadNext(ref p))
            {
                try
                {
                    Console.Out.WriteLine(calculator.power(n, p));
                }
                catch(Exception e)
                {
                    Console.Error.WriteLine(e.Message);
                }
            }
        }
    }
}
