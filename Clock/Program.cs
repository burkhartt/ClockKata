using System;
using Clock.Numbers;
using Clock.Outputters;

namespace Clock
{
    public delegate void WriterDelegate(string text);

    public class Program
    {
        private static void Main()
        {
            var clockNumbers = new ClockNumbers();
            var clockWriter = new ClockWriter(ConsoleWriter);

            var timeAscii = clockNumbers.GetAscii(DateTime.Now.ToString("H:mm:ss.fff tt"));
            clockWriter.Write("#", timeAscii);

            var dateAscii = clockNumbers.GetAscii(DateTime.Now.ToString("M/d/yyyy"));
            clockWriter.Write("#", dateAscii);

            Console.ReadKey();
        }

        private static void ConsoleWriter(string text)
        {
            Console.WriteLine(text);
        }
    }
}