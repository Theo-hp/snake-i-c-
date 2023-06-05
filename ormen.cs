using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace snake
{
    public enum hol
    {
        Down,
        Up,
        Right,
        Left
    }

    internal class ormen
    {
        public hol hol { get; set; }
        private readonly Queue<delarna> dealr;
        private readonly Brush ferg;
        public int headx => dealr.Last().X;
        public int heady => dealr.Last().Y;
        public int poang => dealr.Count - 2;

        public ormen (Brush color)
        {
            ferg = color;
            dealr = new Queue<delarna> ();
        }

        public void Mala(Graphics mol)
        {
            foreach (var del in dealr)
            {
                del.Mala(mol);
            }
        }

        public void rorasig (int a, int b)
        {
            dealr.Enqueue(new delarna(ferg, headx + a, heady + b));
            dealr.Dequeue();
        }

        public bool kanata (int a, int b, delarna food)
        {
            return food.X == headx + a && food.Y == heady + b;
        }

        public void ata (delarna food)
        {
            dealr.Enqueue(new delarna(ferg, food.X, food.Y));
        }

        public bool inehaler (int a, int b)
        {
            return dealr.Any(del => del.X == a && del.Y == b);
        }

        public void clear()
        {
            dealr.Clear();
            dealr.Enqueue(new delarna(ferg, 0, 0));
            dealr.Enqueue(new delarna(ferg, 1, 0));
            hol = hol.Right;
        }

        public bool atasig()
        {
            var i = 0;
            return dealr.Any(del => i++ != dealr.Count - 1 && heady == del.Y && headx == del.X);
        }
    }
}
