using System.Drawing;

namespace Snake
{
    public class Piece
    {
        public static int SIDE = 25;
        private readonly Brush enfinfärg;

        public int X { get; set; }
        public int Y { get; set; }

        public Piece(int a, int b, Brush color)
        {
            X = a;
            Y = b;
            enfinfärg = color;
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(enfinfärg, new Rectangle(X * SIDE, Y * SIDE, SIDE, SIDE));
        }
    }
}
