#region License

// SwoptSharp, a collection of swarm intelligence algorithms for general optimisation purposes
// Copyright (C) 2015  Aleksander Palkowski <http://apalkowski.com>
// 
// This program is free software; you can redistribute it and/or modify it under the terms of the
// GNU General Public License as published by the Free Software Foundation; either version 2 of the
// License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without
// even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
// General Public License for more details.
// 
// You should have received a copy of the GNU General Public License along with this program; if
// not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA
// 02110-1301 USA.

#endregion License

using System;

namespace SwoptSharp
{
    [Serializable]
    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

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
    }
}