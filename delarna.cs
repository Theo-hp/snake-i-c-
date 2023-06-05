using System.Drawing;

namespace snake
{
    public class delarna
    {
        private readonly Brush farg;
        public static int sida = 20;
        public int X { get; set; }
        public int Y { get; set; }

        public delarna (Brush color, int x, int y)
        {
            farg = color;
            X = x;
            Y = y;
        }

        public void Mala (Graphics mol)
        {
            mol.FillRectangle(farg, new Rectangle(X * sida, Y * sida, sida, sida));
        }
    }
}
