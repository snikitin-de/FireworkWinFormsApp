using Common;
using System.Media;
using Timer = System.Windows.Forms.Timer;

namespace FireworkWinFormsApp
{
    public partial class MainForm : Form
    {
        private List<FireworkBall> fireworksBalls = new List<FireworkBall>();
        private List<FireworkBatteryBall> fireworksBatteryBalls = new List<FireworkBatteryBall>();
        private Random random = new Random();
        private int renderInterval = 1;
        private int borderX;
        private int borderY;
        private int minBallsCount = 100;
        private int maxBallsCount = 150;

        public MainForm()
        {
            InitializeComponent();

            var renderTimer = new Timer();
            renderTimer.Interval = renderInterval;
            renderTimer.Enabled = true;
            renderTimer.Tick += (s, o) => { renderPictureBox.Refresh(); };
        }

        // Включение двойной буферизации для всех элементов управления
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x00000020;
                return createParams;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            renderPictureBox.BackColor = GameColors.FireworkNightSky;

            borderX = renderPictureBox.Width;
            borderY = renderPictureBox.Height;
        }

        private void renderPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var centerPoint = new PointF(e.X, e.Y);

                DrawFirework(centerPoint);
            }
            else if (e.Button == MouseButtons.Right)
            {
                DrawFireworkBattery();
            }
        }

        private void renderPictureBox_Paint(object sender, PaintEventArgs e)
        {
            for (var i = 0; i < fireworksBatteryBalls.Count; i++)
            {
                var ball = fireworksBatteryBalls[i];

                if (ball.IsExploding())
                {
                    fireworksBatteryBalls.RemoveAt(i);

                    DrawFirework(ball.GetCenterPoint());
                }
                else
                {
                    ball.Draw(e.Graphics);
                }
            }

            foreach (var ball in fireworksBalls)
            {
                if (ball.IsExploding())
                {
                    ball.DrawExploding(e.Graphics);
                }
                else
                {
                    ball.Draw(e.Graphics);
                }
            }
        }

        private void DrawFirework(PointF centerPoint)
        {
            var ballsCount = random.Next(minBallsCount, maxBallsCount);
            var soundFireworkExposionPath = Properties.Resources.fireworkExplosionFizz;

            using (var soundPlayer = new SoundPlayer(soundFireworkExposionPath))
            {
                soundPlayer.Play();
            }

            if (fireworksBalls.Count > 0 && fireworksBalls.Max(x => x.IsDisappear))
            {
                fireworksBalls.Clear();
            }

            for (var j = 0; j < ballsCount; j++)
            {
                var color = GameColors.GetRandomBallColor();
                var ball = new FireworkBall(color, centerPoint.X, centerPoint.Y, borderX, borderY);
                fireworksBalls.Add(ball);
                ball.Start();
            }
        }

        private void DrawFireworkBattery()
        {
            var soundFireworkRocketLaunchPath = Properties.Resources.fireworkRocketLaunch;

            using (var soundPlayer = new SoundPlayer(soundFireworkRocketLaunchPath))
            {
                soundPlayer.Play();
            }

            var borderX = renderPictureBox.Width;
            var borderY = renderPictureBox.Height;
            var color = GameColors.GetRandomBallColor();
            var ball = new FireworkBatteryBall(color, borderX, borderY);
            fireworksBatteryBalls.Add(ball);
            ball.Start();
        }
    }
}