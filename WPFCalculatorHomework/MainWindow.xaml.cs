using System;
using System.Collections.Generic;
using System.Data;
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

namespace WPFCalculatorHomework
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


        private void Button_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        bool option = false;
        double result = 0;
        string checkOperator = "";
         
        private void writeButtonText(object sender, MouseButtonEventArgs e)
        {
            if (textBox.Text == "0" || option)
            {
                textBox.Clear();
            }

            option = false;
            Button button = sender as Button;
            textBox.Text += button.Content.ToString();
        }

        private void writeOperationsText(object sender, MouseButtonEventArgs e)
        {
            Button button = sender as Button;

            string newOperator = button.Content.ToString();

            label.Content += " " + textBox.Text + " " + newOperator;


            double operand = Double.Parse(textBox.Text);

            switch (checkOperator)
            {
                case "+": result += operand; break;
                case "/": result /= operand; break;
                case "*": result *= operand; break;
                case "-": result -= operand; break;
            }

            option = true;
            checkOperator = newOperator;
        }

        private void ceEvent(object sender, MouseButtonEventArgs e)
        {
            textBox.Text = "0";
        }

        private void cEvent(object sender, MouseButtonEventArgs e)
        {
            textBox.Text = "0";
            label.Content = "";
            checkOperator = "";
            result = 0;
            option = false;
        }

        private void equalEvent(object sender, MouseButtonEventArgs e)
        {
            label.Content += textBox.Text;
            option = false;


            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(string), label.Content.ToString());
            DataRow row = table.NewRow();
            table.Rows.Add(row);

            double result1 = double.Parse((string)row["expression"]);
            MessageBox.Show(result1.ToString());

            label.Content = "";
            textBox.Text = result1.ToString();
        }

        private void pointEvent(object sender, MouseButtonEventArgs e)
        {
            if (textBox.Text == "0")
            {
                textBox.Text = "0";
            }
            else if (option)
            {
                textBox.Text = "0";
            }
            if (!textBox.Text.Contains("."))
            {
                textBox.Text += ".";
            }
            option = false;
        }
    }
}
