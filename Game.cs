using System;
using System.Drawing;

namespace Snake
{
    public class Game
    {
        private readonly int braden;
        private readonly int langden;
        private readonly Snake ormen;
        private readonly Piece maten;
        private readonly Random ingevetvilken;

        public Game(int width, int height)
        {
            braden = width;
            langden = height;
            ormen = new Snake(Brushes.Red);
            ingevetvilken = new Random();
            maten = new Piece(0, 0, Brushes.Navy);
            Restart();
        }

        public void Restart()
        {
            ormen.Clear();
            GenerateFood();
        }

        public void Draw(Graphics g)
        {
            ormen.Draw(g);
            maten.Draw(g);
        }

        public int GetScore()
        {
           return ormen.ScoreLength;
        }

        public bool SnakeHasGrown()
        {
            switch (ormen.Direction)
            {
                case Direction.Down:
                    return TryEat(0, 1);
                case Direction.Up:
                    return TryEat(0, -1);
                case Direction.Right:
                    return TryEat(1, 0);
                case Direction.Left:
                    return TryEat(-1, 0);
            }
            return false;
        }

        public bool Lost()
        {
            return ormen.HeadX > braden || ormen.HeadX < 0 || ormen.HeadY > langden || ormen.HeadY < 0 || ormen.EatsItself();
        }

        public void ChangeSnakeDIrection(Direction direction)
        {
            ormen.Direction = direction;
        }

        private bool TryEat(int a, int b)
        {
            if (ormen.CanEat(a, b, maten))
            {
                ormen.Eat(maten);
                GenerateFood();
                return true;
            }
            ormen.MoveTo(a, b);
            return false;
        }

        private void GenerateFood()
        {
            var a = ingevetvilken.Next(0, braden);
            var b = ingevetvilken.Next(0, langden);
            if (ormen.Contains(a, b))
            {
                GenerateFood();
            }
            maten.X = a;
            maten.Y = b;
        }
    }
}
