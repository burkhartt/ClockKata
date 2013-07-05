﻿using System.Text;

namespace Clock.Numbers
{
    internal class ClockDigitTwo : ClockDigit
    {
        public override AsciiNumber GetAscii()
        {
            var sb = new StringBuilder();
            sb.AppendLine("####");
            sb.AppendLine("   #");
            sb.AppendLine("####");
            sb.AppendLine("#   ");
            sb.AppendLine("####");
            return new AsciiNumber(sb.ToString());
        }
    }
}