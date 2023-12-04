using Common;
using Timer = System.Windows.Forms.Timer;

namespace FireworkWinFormsApp
{
    public class FireworkBall : MoveRandomBall
    {
        private int currentLiveTime = 0;
        private int timeToLive = 1000;
        private int minDiameter = 5;
        private int maxDiameter = 10;
        private int colorAlpha = 255;
        private int colorAlphaStep = 10;
        private int speedFactor = 10;
        private float g = 0.2f;
        private Timer liveTimer = new Timer();
        private Timer explodingTimer = new Timer();
        public Color Color { get; set; }
        public bool IsDisappear = false;

        public FireworkBall(Color color, float centerX, float centerY, int borderX, int borderY) : base(borderX, borderY)
        {
            diameter = random.Next(minDiameter, maxDiameter);

            var angle = random.Next(360);

            var vx = random.NextDouble() * speedFactor * GetRandomDirection() * Math.Cos(angle);
            var vy = random.NextDouble() * speedFactor * Math.Sin(angle);

            speed.VX = (float)vx;
            speed.VY = -(float)vy;

            centerPoint.X = centerX;
            centerPoint.Y = centerY;

            this.color = color;
            Color = color;

            liveTimer.Tick += LiveTimer_Tick;
            liveTimer.Interval = 100;
            liveTimer.Start();

            explodingTimer.Tick += ExplodingTime_Tick;
            explodingTimer.Interval = 100;
        }

        private void LiveTimer_Tick(object? sender, EventArgs e)
        {
            currentLiveTime += 100;
        }

        private void ExplodingTime_Tick(object? sender, EventArgs e)
        {
            if (colorAlpha >= colorAlphaStep)
            {
                colorAlpha -= colorAlphaStep;
            }
            else
            {
                explodingTimer.Stop();
                IsDisappear = true;
            }
        }

        public override void Move()
        {
            base.Move();

            speed.VY += g;
        }

        public void DrawExploding(Graphics graphics)
        {
            color = Color.FromArgb(colorAlpha, color.R, color.G, color.B);

            var brush = new Pen(color, 2);
            var radius = diameter / 2;
            var rectangle = new RectangleF(centerPoint.X - radius, centerPoint.Y - radius, diameter, diameter);

            graphics.DrawEllipse(brush, rectangle);
        }

        public bool IsExploding()
        {
            var isExpoding = currentLiveTime >= timeToLive;

            if (isExpoding)
            {
                explodingTimer.Start();
                liveTimer.Stop();
            }

            return isExpoding;
        }
    }
}
