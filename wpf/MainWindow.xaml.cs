using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StrandWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Furdo> furdok = new List<Furdo>();
        public MainWindow()
        {
            InitializeComponent();
            var sorok = File.ReadAllLines("strandadatok.txt").Skip(1);

            foreach (var sor in sorok)
            {
                furdok.Add(new Furdo(sor));
            }
            datagrid.ItemsSource = furdok;
        }

        private void kivalasztott(object sender, SelectionChangedEventArgs e)
        {
            nevinput.Text = ((Furdo)datagrid.SelectedItem).Nev;
            ciminput.Text = ((Furdo)datagrid.SelectedItem).Cim;
            arinput.Text = ((Furdo)datagrid.SelectedItem).Ar.ToString();
            hofokinput.Text = ((Furdo)datagrid.SelectedItem).Vizhofok.ToString();
            progress.Value = ((Furdo)datagrid.SelectedItem).Vizhofok;
        }

        private void ment(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItem is not null)
            {
                SaveFileDialog parbeszed = new SaveFileDialog();
                parbeszed.Filter = "Szöveges fájl | *.txt";
                parbeszed.FileName = nevinput.Text + ".txt";
                parbeszed.ShowDialog();

                if (parbeszed.ShowDialog() == true)
                {
                    string tartalom = $"{nevinput.Text}\nCím:{ciminput.Text}\nÁr:{arinput.Text}\nVízhőfok:{hofokinput.Text}\n";
                    File.WriteAllText(parbeszed.FileName, tartalom);
                }
            }
            else
            {
                MessageBox.Show("Nem menthető, amíg nincs kiválasztva semmi!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}