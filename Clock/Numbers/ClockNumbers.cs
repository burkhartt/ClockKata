using System.Collections.Generic;
using System.Linq;

namespace Clock.Numbers
{
    internal class ClockNumbers
    {
        private IDictionary<string, ClockDigit> clockNumbers = new Dictionary<string, ClockDigit>
            {
                { "0", new ClockDigitZero() },
                { "1", new ClockDigitOne() },
                { "2", new ClockDigitTwo() },
                { "3", new ClockDigitThree() },
                { "4", new ClockDigitFour() },
                { "5", new ClockDigitFive() },
                { "6", new ClockDigitSix() },
                { "7", new ClockDigitSeven() },
                { "8", new ClockDigitEight() },
                { "9", new ClockDigitNine() },
                { ":", new ClockDigitColon() },
                { "A", new ClockDigitA() },
                { "M", new ClockDigitM() },
                { "P", new ClockDigitP() },
                { " ", new ClockDigitSpace() },
                { ".", new ClockDigitPeriod() },
                { "/", new ClockDigitForwardSlash() },
                { "(", new ClockDigitOpenParenthesis()},
                { "-", new ClockDigitHyphen()}
            };

        public IEnumerable<AsciiNumber> GetAscii(string numbers)
        {
            return numbers.Select(number => clockNumbers[number.ToString()].GetAscii());
        }
    }
}