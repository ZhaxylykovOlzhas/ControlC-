using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace FixerSharpWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public string CurrencyConversion(decimal amount, string fromCurrency, string toCurrency)
        {
            string Output = "";
            string fromCurrency1 = comboBox1.Text; // comboBox1.Text;
            string toCurrency1 = comboBox2.Text; // comboBox2.Text;
            decimal amount1 = Convert.ToDecimal(textBox1.Text); // Convert.ToDecimal(textBox1.Text);

            // For other currency symbols see http://finance.yahoo.com/currency-converter/
            // Construct URL to query the Yahoo! Finance API

            const string urlPattern = "http://finance.yahoo.com/d/quotes.csv?s={0}{1}=X&f=l1";
            string url = string.Format(urlPattern, fromCurrency1, toCurrency1);

            // Get response as string
            string response = new WebClient().DownloadString(url);

            // Convert string to number
            decimal exchangeRate = decimal.Parse(response, System.Globalization.CultureInfo.InvariantCulture);

            // Output the result
            Output = (amount1 * exchangeRate).ToString();

            textBox2.Text = Output;
            MessageBox.Show(Output);

            return Output;
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {

            CurrencyConversion(new decimal(123.45), "CAD", "USD");
        }
    }
}
