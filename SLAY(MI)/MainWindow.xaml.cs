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

namespace SLAY_MI_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            List<List<double>> Value = new();
            List<double> Y = new() { Double.Parse(Y1.Text), Double.Parse(Y2.Text) , Double.Parse(Y3.Text), Double.Parse(Y4.Text) , Double.Parse(Y5.Text)};
            Value.Add(new() { Double.Parse(C0.Text), Double.Parse(B0.Text) });
            Value.Add(new() {Double.Parse(A1.Text), Double.Parse(C1.Text), Double.Parse(B1.Text) });
            Value.Add(new() {Double.Parse(A2.Text), Double.Parse(C2.Text), Double.Parse(B2.Text) });
            Value.Add(new() {Double.Parse(A3.Text), Double.Parse(C3.Text), Double.Parse(B3.Text) });
            Value.Add(new() {Double.Parse(A4.Text), Double.Parse(C4.Text) });

            Equation equation = new Equation();
            equation.Y = Y;
            equation.X = Value;
            equation.Presicion = Math.Pow(10, Double.Parse(textBox1.Text));
            var l = equation.Calculate();
            int counter = 1;
            textBox.Clear();
            l.ForEach(x => { textBox.Text += String.Format("X{1} = {0:F2}\n", x,counter); counter++; });
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
