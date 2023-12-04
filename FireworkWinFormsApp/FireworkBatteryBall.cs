using Common;

namespace FireworkWinFormsApp
{
    public class FireworkBatteryBall : MoveRandomBall
    {
        private int speedVY = 5;
        private int ballDiameter = 15;
        private int explodingHeightIndentation = 100;
        private int fireforkBatteryStartXIndentation = 50;
        private float explodingHeight;
        private float explodingHeightBorder = 0.6f;
        public Color Color { get; set; }

        public FireworkBatteryBall(Color color, int borderX, int borderY) : base(borderX, borderY)
        {
            var vx = 0;
            var vy = ballDiameter;

            diameter = ballDiameter;
            speed.VX = vx;
            speed.VY = vy;
            centerPoint.X = random.Next(fireforkBatteryStartXIndentation, borderX - fireforkBatteryStartXIndentation);
            centerPoint.Y = borderY;
            this.color = color;
            Color = color;

            explodingHeight = borderY - borderY * explodingHeightBorder;
            explodingHeight = random.Next(explodingHeightIndentation, (int)explodingHeight);
        }

        public override void Move()
        {
            base.Move();

            if (IsExploding())
            {
                speed.VY = 0;
            } else
            {
                speed.VY -= speedVY;
            }
        }

        public bool IsExploding()
        {
            return centerPoint.Y < explodingHeight;
        }

        public PointF GetCenterPoint()
        {
            return centerPoint;
        }
    }
}
