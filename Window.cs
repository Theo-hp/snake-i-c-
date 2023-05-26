using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    public partial class Window : Form
    {
        private const int bredan = 12;
        private const int hajden = 16;
        private const string poangmang = "score: {0}";
        private readonly Color fargpabagrund = Color.Wheat;
        private readonly Game speletskalv;
        private readonly Bitmap daralltgors;
        private readonly Graphics grafiken;

        public Window()
        {
            InitializeComponent();
            daralltgors = new Bitmap(bredan * Piece.SIDE, hajden * Piece.SIDE);
            grafiken = Graphics.FromImage(daralltgors); grafiken.PageUnit = GraphicsUnit.Pixel;
            ClientSize = new Size(daralltgors.Width, daralltgors.Height + m_RestartBtn.Height);
            speletskalv = new Game(bredan, hajden);
            m_Timer.Start();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    speletskalv.ChangeSnakeDIrection(Direction.Left);
                    break;
                case Keys.Right:
                    speletskalv.ChangeSnakeDIrection(Direction.Right);
                    break;
                case Keys.Up:
                    speletskalv.ChangeSnakeDIrection(Direction.Up);
                    break;
                case Keys.Down:
                    speletskalv.ChangeSnakeDIrection(Direction.Down);
                    break;
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            grafiken.Clear(fargpabagrund);
            speletskalv.Draw(grafiken);
            e.Graphics.DrawImage(daralltgors, 0, m_RestartBtn.Height);
        }

        private void OnRestartBtnClick(object sender, EventArgs e)
        {
            m_RestartBtn.Enabled = false;
            speletskalv.Restart();
            UpdateScore();
            m_Timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (speletskalv.SnakeHasGrown())
            {
                UpdateScore();
            }
            if (speletskalv.Lost())
            {
                m_Timer.Stop();
                m_RestartBtn.Enabled = true;
            }
            Invalidate();
        }

        private void UpdateScore()
        {
            scoreLbl.Text = string.Format(poangmang, speletskalv.GetScore());
        }

        private void Window_Load(object sender, EventArgs e)
        {

        }

        private void scoreLbl_Click(object sender, EventArgs e)
        {

        }
    }
}

