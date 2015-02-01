using System;

namespace SwoptSharp
{
    [Serializable]
    public struct Point
    {
        #region Public Fields

        public int X;
        public int Y;

        #endregion Public Fields

        #region Public Constructors

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        #endregion Public Constructors

        #region Public Methods

        public static Point Add(Point point1, Point point2)
        {
            return new Point(point1.X + point2.X, point1.Y + point2.Y);
        }

        public static Point Add(Point point, int valueToAdd)
        {
            return new Point(point.X + valueToAdd, point.Y + valueToAdd);
        }

        public static Point Divide(Point point, int factor)
        {
            return new Point(point.X / factor, point.Y / factor);
        }

        public static Point Multiply(Point point, int factor)
        {
            return new Point(point.X * factor, point.Y * factor);
        }

        public static Point operator -(Point point1, Point point2)
        {
            return new Point(point1.X - point2.X, point1.Y - point2.Y);
        }

        public static Point operator -(Point point, int valueToSubtract)
        {
            return new Point(point.X - valueToSubtract, point.Y - valueToSubtract);
        }

        public static bool operator !=(Point point1, Point point2)
        {
            return ((point1.X != point2.X) || (point1.Y != point2.Y));
        }

        public static Point operator *(Point point, int factor)
        {
            return new Point(point.X * factor, point.Y * factor);
        }

        public static Point operator /(Point point, int factor)
        {
            return new Point(point.X / factor, point.Y / factor);
        }

        public static Point operator +(Point point1, Point point2)
        {
            return new Point(point1.X + point2.X, point1.Y + point2.Y);
        }

        public static Point operator +(Point point, int valueToAdd)
        {
            return new Point(point.X + valueToAdd, point.Y + valueToAdd);
        }

        public static bool operator ==(Point point1, Point point2)
        {
            return ((point1.X == point2.X) && (point1.Y == point2.Y));
        }

        public static Point Subtract(Point point1, Point point2)
        {
            return new Point(point1.X - point2.X, point1.Y - point2.Y);
        }

        public static Point Subtract(Point point, int valueToSubtract)
        {
            return new Point(point.X - valueToSubtract, point.Y - valueToSubtract);
        }

        public double DistanceTo(Point anotherPoint)
        {
            int dx = X - anotherPoint.X;
            int dy = Y - anotherPoint.Y;

            return System.Math.Sqrt(dx * dx + dy * dy);
        }

        public override bool Equals(object obj)
        {
            return (obj is Point) ? (this == (Point)obj) : false;
        }

        public double EuclideanNorm()
        {
            return System.Math.Sqrt(X * X + Y * Y);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }

        public double SquaredDistanceTo(Point anotherPoint)
        {
            double dx = X - anotherPoint.X;
            double dy = Y - anotherPoint.Y;

            return dx * dx + dy * dy;
        }

        #endregion Public Methods
    }
}