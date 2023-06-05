using System;
using System.Drawing;

namespace snake
{
    internal class thagmae
    {
        private readonly Random ingenvet;
        private readonly delarna mat;
        private readonly ormen orm;
        private readonly int hojden;
        private readonly int langden;

        public thagmae(int langd, int hojd)
        {
            hojden = hojd;
            langden = langd;
            orm = new ormen(Brushes.OrangeRed);
            ingenvet = new Random();
            mat = new delarna(Brushes.Aqua, 0, 0);
            startaom();
        }

        public void Mala (Graphics mol)
        {
            orm.Mala(mol);
            mat.Mala(mol);
        }

        public void startaom()
        {
            orm.clear();
            gormat();
        }

        private void gormat()
        {
            var a = ingenvet.Next(0, langden);
            var b = ingenvet.Next(0, hojden);
            if ( orm.inehaler(a, b) )
            {
                gormat();
            }
            mat.X = a;
            mat.Y = b;
        }

        private bool forsokata(int a, int b)
        {
            if ( orm.kanata(a, b, mat))
            {
                orm.ata(mat);
                gormat();
                return true;
            }
            orm.rorasig(a, b); 
            return false;
        }

        public bool forsvinen()
        {
            return orm.headx > langden || orm.headx < 0 || orm.heady > hojden || orm.heady < 0 || orm.atasig();
        }

        public bool langre()
        {
            switch (orm.hol)
            {
                case hol.Down:
                    return forsokata(0, 1);
                case hol.Up:
                    return forsokata(0, -1);
                case hol.Right:
                    return forsokata(1, 0);
                case hol.Left:
                    return forsokata(-1, 0);
            }
            return false;
        }

        public void vilkerhol(hol hol)
        {
            orm.hol = hol;
        }

        public int poangar()
        {
            return orm.poang;
        }
    }
}
