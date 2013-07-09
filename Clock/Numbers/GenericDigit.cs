using System.Text;

namespace Clock.Numbers
{
    internal class GenericDigit : ClockDigit
    {
        private readonly QuadrantMap quadrantMap;

        public GenericDigit(QuadrantMap quadrantMap)
        {
            this.quadrantMap = quadrantMap;
        }

        public override AsciiNumber GetAscii()
        {
            var sb = new StringBuilder();
            for (var y = 0; y < quadrantMap.GetHeight(); y++)
            {
                foreach (var quadrant in quadrantMap.GetQuadrantsInRow(y))
                {
                    sb.Append(quadrant.GetCharacter());
                }
                sb.Append("\r\n");
            }

            return new AsciiNumber(sb.ToString());
        }
    }
}