using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PR7_Drachev.Classes
{
    public class Figure
    {
        public double OX { get; set; }
        public double OY { get; set; }
    }

    public class Triangle : Figure
    {
        public Triangle(double OX, double OY)
        {
            this.OX = OX;
            this.OY = OY;
        }

        public void DrowTriangle(System.Windows.Controls.Canvas canvas)
        {
            Polygon polygon = new Polygon();
            System.Windows.Point Point1 = new System.Windows.Point(1, 50);
            System.Windows.Point Point2 = new System.Windows.Point(10, 80);
            System.Windows.Point Point3 = new System.Windows.Point(50, 50);

            polygon.Points.Add(Point1);
            polygon.Points.Add(Point2);
            polygon.Points.Add(Point3);

            this.OX -= (Point1.X + Point2.X + Point3.X) / 3.0;
            this.OY -= (Point1.Y + Point2.Y + Point3.Y) / 9.0;

            Canvas.SetLeft(polygon, OX);
            Canvas.SetBottom(polygon, OY);
            polygon.StrokeThickness = 1;
            polygon.Stroke = Brushes.Yellow;
            polygon.Fill = Brushes.Green;
            canvas.Children.Add(polygon);
        }
    }

    public class Circle : Figure
    {
        public double Radius { get; set; }

        public Circle(double OX, double OY, double R)
        {
            this.OX = OX;
            this.OY = OY;
            this.Radius = R;
        }

        public void DrowCircle(System.Windows.Controls.Canvas canvas)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Width = Radius * 2;
            ellipse.Height = Radius * 2;
            Canvas.SetLeft(ellipse, OX - Radius);
            Canvas.SetBottom(ellipse, OY - Radius);
            ellipse.StrokeThickness = 1;
            ellipse.Stroke = Brushes.Red;
            ellipse.Fill = Brushes.Blue;
            canvas.Children.Add(ellipse);
        }
    }
}
