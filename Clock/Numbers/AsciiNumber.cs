using System;

namespace Clock.Numbers
{
    internal class AsciiNumber
    {
        private readonly string textNumber;

        public AsciiNumber(string textNumber)
        {
            this.textNumber = textNumber;
        }

        public string GetLine(int line)
        {
            return textNumber.Split(new [] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)[line];
        }

        public int GetRows()
        {
            return textNumber.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}