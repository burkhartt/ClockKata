using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using Clock.Numbers;

namespace Clock
{
    internal class StringDeterminer
    {
        private Bitmap DrawText(String text) {
            var img = new Bitmap(1, 1);
            var drawing = Graphics.FromImage(img);

            var font = new Font("Courier", 14);
            var textSize = drawing.MeasureString(text, font);

            img.Dispose();
            drawing.Dispose();

            img = new Bitmap((int)textSize.Width, (int)textSize.Height);            
            drawing = Graphics.FromImage(img);
            drawing.Clear(Color.White);

            var textBrush = new SolidBrush(Color.Black);
            drawing.DrawString(text, font, textBrush, 0, 0);
            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();
            return img;
        }

        public AsciiNumberRows GetAscii(string letters)
        {
            var list = new AsciiNumberRows();
            foreach (var letter in letters)
            {
                var image = DrawText(letter.ToString());
                var quadrantMap = new QuadrantMap(image.Width, image.Height);                

                for (var x = 0; x < image.Width; x++)
                {
                    for (var y = 0; y < image.Height; y++)
                    {                        
                        quadrantMap.Add(new Quadrant(image, x, y));
                    }
                }

                list.Add(new GenericDigit(quadrantMap).GetAscii());
            }

            return list;
        }
    }

    internal class AsciiNumberRows : IEnumerable<AsciiNumber>
    {
        private List<AsciiNumber> list;

        public AsciiNumberRows()
        {
            list = new List<AsciiNumber>();
        }

        public AsciiNumberRows(IEnumerable<AsciiNumber> asciiNumbers)
        {
            list = asciiNumbers.ToList();
        }

        public int Rows
        {
            get { return list.First().GetRows(); }
        }

        public void Add(AsciiNumber asciiNumber)
        {
            list.Add(asciiNumber);
        }

        public IEnumerator<AsciiNumber> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class QuadrantMap
    {
        private readonly int horizontalQuadrants;
        private readonly int verticalQuadrants;
        private readonly Quadrant[,] quadrants;

        public QuadrantMap(int horizontalQuadrants, int verticalQuadrants)
        {
            this.horizontalQuadrants = horizontalQuadrants;
            this.verticalQuadrants = verticalQuadrants;
            quadrants = new Quadrant[horizontalQuadrants,verticalQuadrants];
        }

        public void Add(Quadrant quadrant)
        {
            quadrants[quadrant.X, quadrant.Y] = quadrant;
        }

        public IEnumerable<Quadrant> GetQuadrantsInRow(int row)
        {
            var list = new List<Quadrant>();
            for (var i = 0; i < horizontalQuadrants; i++)
            {
                list.Add(quadrants[i, row]);
            }
            return list;
        }

        public int GetHeight()
        {
            return verticalQuadrants;
        }
    }

    internal class Quadrant
    {
        private readonly Bitmap image;
        public int X { get; private set; }
        public int Y { get; private set; }

        public Quadrant(Bitmap image, int x, int y)
        {
            this.image = image;
            X = x;
            Y = y;            
        }

        public string GetCharacter()
        {
            var pixel = image.GetPixel(X, Y);
            if (pixel.R != 255 || pixel.G != 255 || pixel.B != 255)
            {
                return "#";
            }
            return " ";
        }
    }
}