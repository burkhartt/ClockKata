using System.Collections.Generic;
using System.Linq;
using Clock.Numbers;

namespace Clock.Outputters
{
    internal class ClockWriter
    {
        private readonly WriterDelegate writerDelegate;

        public ClockWriter(WriterDelegate writerDelegate)
        {
            this.writerDelegate = writerDelegate;
        }

        public void Write(string character, AsciiNumberRows asciiNumbers)
        {
            for (var i = 0; i < asciiNumbers.Rows; i++)
            {                
                writerDelegate(asciiNumbers.Select(asciiNumber => asciiNumber.GetLine(i).Replace("#", character)).Aggregate("", (current, line) => current + (line + " ")));
            }
            writerDelegate("");
        }
    }
}