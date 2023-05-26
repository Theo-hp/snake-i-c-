using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Snake
{
    public enum Direction
    {
        Down,
        Up,
        Right,
        Left
    }

    public class Snake
    {
        public int HeadX => piecesonthem.Last().X;
        public int HeadY => piecesonthem.Last().Y;
        public int ScoreLength => piecesonthem.Count - 2;
        public Direction Direction { get; set; }

        private readonly Queue<Piece> piecesonthem;
        private readonly Brush enfinfärg;

        public Snake(Brush color)
        {
            enfinfärg = color;
            piecesonthem = new Queue<Piece>();
        }

        public void Draw(Graphics g)
        {
            foreach (var piece in piecesonthem)
            {
                piece.Draw(g);
            }
        }
        public void Clear()
        {
            piecesonthem.Clear();
            piecesonthem.Enqueue(new Piece(0, 0, enfinfärg));
            piecesonthem.Enqueue(new Piece(0, 1, enfinfärg));
            Direction = Direction.Down;
        }

        public bool CanEat(int a, int b, Piece food)
        {
            return food.X == HeadX + a && food.Y == HeadY + b;
        }

        public bool Contains(int a, int b)
        {
            return piecesonthem.Any(piece => piece.X == a && piece.Y == b);
        }

        public void Eat(Piece food)
        {
            piecesonthem.Enqueue(new Piece(food.X, food.Y, enfinfärg));
        }



        public bool EatsItself()
        {
            var i = 0;
            return piecesonthem.Any(piece => i++ != piecesonthem.Count - 1 && HeadY == piece.Y && HeadX == piece.X);
        }

        public void MoveTo(int a, int b)
        {
            piecesonthem.Enqueue(new Piece(HeadX + a, HeadY + b, enfinfärg));
            piecesonthem.Dequeue();
        }
    }
}
