using System;
using System.Linq;
using System.Net.Mime;
using System.Threading;
using Clock.Numbers;
using Clock.Outputters;

namespace Clock
{
    public delegate void WriterDelegate(string text);

    public class Program
    {
        private static void Main()
        {
            var clockWriter = new ClockWriter(ConsoleWriter);            

            while (true)
            {
                Console.Clear();

                var stringDeterminer = new StringDeterminer();
                var ascii = stringDeterminer.GetAscii(DateTime.Now.ToString("H:mm:ss"));

                clockWriter.Write("#", ascii);
                Thread.Sleep(1000);
            }
        }

        private static void ConsoleWriter(string text)
        {
            Console.WriteLine(text);
        }
    }
}