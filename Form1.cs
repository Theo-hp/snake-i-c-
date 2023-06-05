using System;
using System.Drawing;
using System.Windows.Forms;

namespace snake
{
    public partial class Form1 : Form
    {
        private const int langden = 16;
        private const int hajden = 12;
        private const string poangmang = "score: {0}";
        private readonly Color fargpabagrund = Color.AntiqueWhite;
        private readonly thagmae speletskalv;
        private readonly Bitmap daralltgors;
        private readonly Graphics grafiken;

        public Form1()
        {
            InitializeComponent();
            daralltgors = new Bitmap(langden * delarna.sida, hajden * delarna.sida);
            grafiken = Graphics.FromImage(daralltgors); grafiken.PageUnit = GraphicsUnit.Pixel;
            ClientSize = new Size(daralltgors.Width, daralltgors.Height + button2.Height);
            speletskalv = new thagmae(langden, hajden);
            timer1.Start();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    speletskalv.vilkerhol(hol.Left);
                    break;
                case Keys.Right:
                    speletskalv.vilkerhol(hol.Right);
                    break;
                case Keys.Up:
                    speletskalv.vilkerhol(hol.Up);
                    break;
                case Keys.Down:
                    speletskalv.vilkerhol(hol.Down);
                    break;
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            grafiken.Clear(fargpabagrund);
            speletskalv.Mala(grafiken);
            e.Graphics.DrawImage(daralltgors, 0, button2.Height);
        }

        private void Onbutton2Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            speletskalv.startaom();
            nypoang();
            timer1.Start();
        }

        private void Ontimer1Tick(object sender, EventArgs e)
        {
            if (speletskalv.langre())
            {
                nypoang();
            }
            if (speletskalv.forsvinen())
            {
                timer1.Stop();
                button2.Enabled = true;
            }
            Invalidate();
        }

        private void nypoang()
        {
            label1.Text = string.Format(poangmang, speletskalv.poangar());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lable1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}