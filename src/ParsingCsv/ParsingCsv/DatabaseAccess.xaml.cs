using Microsoft.EntityFrameworkCore;
using ParsingCsv.Data;
using System.Linq;
using System.Windows;

namespace ParsingCsv
{
    /// <summary>
    /// Interakční logika pro DatabaseAccess.xaml
    /// </summary>
    public partial class DatabaseAccess : Window
    {
        private ApplicationDbContext dbContext;

        public DatabaseAccess()
        {
            InitializeComponent();
        }

        private async void ConnectToDbAsync(object sender, RoutedEventArgs e)
        {
            var connectionString = ConnectionString.Text; // Vytažení přístupového řetězce
            dbContext = new ApplicationDbContext(connectionString); // Vytvoření přístupu do databáze
            Read.IsEnabled = true;
            Disconnect.IsEnabled = true;
        }

        private async void DisconnectFromDbAsync(object sender, RoutedEventArgs e)
        {
            await dbContext.DisposeAsync();
            CustomersGrid.ItemsSource = null;
            Disconnect.IsEnabled = false;
            Read.IsEnabled = false;
        }
        private async void ReadFromDatabaseAsync(object sender, RoutedEventArgs e)
        {
            CustomersGrid.ItemsSource = await dbContext.Customer.Select(c => c).ToListAsync(); // Vytažení dat z tabulky Customer
        }
    }
}
