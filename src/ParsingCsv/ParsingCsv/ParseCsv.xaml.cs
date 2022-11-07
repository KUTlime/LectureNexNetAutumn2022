using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace ParsingCsv
{
    /// <summary>
    /// Interakční logika pro ParseCsv.xaml
    /// </summary>
    public partial class ParseCsv : Window
    {
        public ParseCsv()
        {
            InitializeComponent();
        }

        private async void ValidatePathsAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                await Task.Run(async () =>
                {
                    await Dispatcher.InvokeAsync(() =>
                    {
                        Paths.Text
                        .Split("\n", StringSplitOptions.TrimEntries) // rozdělím na adresáře a ořežu blbosti
                        .Where(path => System.IO.Directory.Exists(path)) // pouštím dál pouze existující adresáře
                        .SelectMany(path => System.IO.Directory.GetFiles(path)) // načítám všechny soubory z každého jednotlivého adresáře
                        .Select(filePath => new FileInfo(filePath)) // měním typ string cesta_k_souboru na typ FileInfo
                        .Where(IsCsv)
                        .ToList() // převádím do listu, abych mohl dělat ForEach na dalším řádku.
                        .ForEach(file => Logger.Text += $"{file}\n");
                    });
                });
            }
            catch (Exception exception)
            {
                Logger.Text = exception.Message;
            }

        }

        private static bool IsCsv(FileInfo file)
        {
            return string.CompareOrdinal(file.Extension.ToLowerInvariant(), ".csv") == 0;
        }
    }
}
