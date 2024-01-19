using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace PR7_Drachev
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool coordinates = false;

        public double xAbsoluteCenter;
        public double yAbsoluteCenter;


        public MainWindow()
        {
            InitializeComponent();
        }



        public void CoordinatePlane_Click(object sender, RoutedEventArgs e)
        {
            if (!coordinates)
            {
                Line horizontalLine = new Line();
                horizontalLine.X1 = 0;
                horizontalLine.X2 = canvas.ActualWidth;
                horizontalLine.Y1 = canvas.ActualHeight / 2.0;
                horizontalLine.Y2 = canvas.ActualHeight / 2.0;
                horizontalLine.StrokeThickness = 1;
                horizontalLine.Stroke = Brushes.Black;
                canvas.Children.Add(horizontalLine);

                Line verticalLine = new Line();
                verticalLine.X1 = canvas.ActualWidth / 2.0;
                verticalLine.X2 = canvas.ActualWidth / 2.0;
                verticalLine.Y1 = 0;
                verticalLine.Y2 = canvas.ActualHeight;
                verticalLine.StrokeThickness = 1;
                verticalLine.Stroke = Brushes.Black;
                canvas.Children.Add(verticalLine);

                coordinates = true;
            }
        }

        private void AddCircle_Click(object sender, RoutedEventArgs e)
        {
            if (xAxisAdd.Text == "" || yAxisAdd.Text == "")
            {
                if (xAxisAdd.Text == "")
                {
                    xAxisAdd.Text = "0";
                }
                if (yAxisAdd.Text == "")
                {
                    yAxisAdd.Text = "0";
                }
            }
            if (!(double.TryParse(xAxisAdd.Text, out double xFigureCenter) & double.TryParse(yAxisAdd.Text, out double yFigureCenter)))
            {
                MessageBox.Show("Некорректный ввод координат центра");
                return;
            }
            xFigureCenter += canvas.ActualWidth / 2;
            yFigureCenter += canvas.ActualHeight / 2;
            Classes.Circle triangle = new Classes.Circle(xFigureCenter, yFigureCenter, 25);
            triangle.DrowCircle(canvas);
        }

        private void AddTiangle_Click(object sender, RoutedEventArgs e)
        {
            if (xAxisAdd.Text == "" || yAxisAdd.Text == "")
            {
                if (xAxisAdd.Text == "")
                {
                    xAxisAdd.Text = "0";
                }
                if (yAxisAdd.Text == "")
                {
                    yAxisAdd.Text = "0";
                }
            }
            if (!(double.TryParse(xAxisAdd.Text, out double xFigureCenter) & double.TryParse(yAxisAdd.Text, out double yFigureCenter)))
            {
                MessageBox.Show("Некорректный ввод координат центра");
                return;
            }
            xFigureCenter += canvas.ActualWidth / 2;
            yFigureCenter += canvas.ActualHeight / 2;
            Classes.Triangle triangle = new Classes.Triangle(xFigureCenter, yFigureCenter);
            triangle.DrowTriangle(canvas);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            coordinates = false;
        }
    }
}
