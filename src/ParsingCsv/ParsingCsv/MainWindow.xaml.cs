using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace ParsingCsv
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

        private async void btnOK_Click(object sender, RoutedEventArgs e)
        {
            await NewHeavyMethodAsync();
            LoggerTextBlock.Text = "Hello world!";
            LoggerTextBlock.FontSize = 24;
        }

        private static async Task NewHeavyMethodAsync()
        {
            await Task.Run(() => System.Threading.Thread.Sleep(10000));
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            LoggerTextBlock.Text = await GetNewsFrom("https://www.aktualne.cz");
        }

        private static async Task<string> GetNewsFrom(string uri)
        {
            return await Task.Run(async () =>
            {
                var client = new HttpClient();
                return await client.GetStringAsync(uri);
            });
        }
    }
}
