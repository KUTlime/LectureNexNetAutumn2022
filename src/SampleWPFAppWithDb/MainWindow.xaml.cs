using Microsoft.EntityFrameworkCore;
using SampleWPFAppWithDb.Data;
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
using System.Windows.Threading;

namespace SampleWPFAppWithDb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationDbContext dbContext;
        private DispatcherTimer timer = new();

        public MainWindow()
        {
            InitializeComponent();
            ConnectToDb();
            timer.Tick += new EventHandler(LoadData_Click);
            timer.Interval = TimeSpan.FromSeconds(double.Parse(PoolingInterval.Text));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default["ConnectionString"] = ConnectionStringTextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void DbConnect_Click(object sender, RoutedEventArgs e) => ConnectToDb();

        private void ConnectToDb()
        {
            ConnectionState.Text = "🟡 Connecting";
            ConnectionState.Foreground = Brushes.Yellow;
            dbContext = new ApplicationDbContext(ConnectionStringTextBox.Text);
            ConnectionState.Text = "✅ Connected";
            ConnectionState.Foreground = Brushes.Green;
        }

        private void LoadData_Click(object sender, EventArgs e)
        {
            Customers.ItemsSource = dbContext.Customer.Select(c => c).ToList(); // Vytažení dat z tabulky Customer
            Orders.ItemsSource = dbContext.Order.Select(c => c).ToList(); // Vytažení dat z tabulky Customer
            LastPooledTimeTag.Text = $"Last pooled time: {DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")}";
        }
        private void PoolData_Click(object sender, RoutedEventArgs e)
        {
            if(timer.IsEnabled)
            {
                timer.Stop();
            }
            else
            {
                timer.Start();
            }
        }
    }
}
