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

namespace WpfApp1
{

    public partial class MainWindow : Window
    {
        List<City> cities = new List<City>();

        public MainWindow()
        {
            InitializeComponent();

            using (var sr = new StreamReader("../../../src/cities.txt"))
            {
                _ = sr.ReadLine();
                while (!sr.EndOfStream) cities.Add(new City(sr.ReadLine()));
            }

            foreach (var item in cities) lbx_adat.Items.Add(item.Name);
        }

        private void btnFelvesz_Click(object sender, RoutedEventArgs e)
        {
            var temp = new City(txbNev.Text.ToString(),Convert.ToDouble(txbHo.Text),Convert.ToInt32(txbPara.Text),Convert.ToDouble(txbSzel.Text));
            txbNev.Text = "";
            txbHo.Text = "";
            txbPara.Text = "";
            txbSzel.Text = "";

            if (lbx_adat.Items.Contains(temp.Name))
            {
                MessageBox.Show("Ez a város már fel van véve.");
            }
            cities.Add(temp);

            lbx_adat.Items.Clear();
            foreach (var item in cities) lbx_adat.Items.Add(item.Name);
        }

        private void lbx_adat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbx_adat.SelectedIndex != -1)
            {
                int index = lbx_adat.SelectedIndex;
                var select = cities[index];
                txbNev.Text = select.Name;
                txbHo.Text = select.Temperature.ToString();
                txbPara.Text = select.Humidity.ToString();
                txbSzel.Text = select.Windspeed.ToString();
            }
            else
            {
                txbNev.Text = "";
                txbHo.Text = "";
                txbPara.Text = "";
                txbSzel.Text = "";
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (lbx_adat.SelectedIndex != -1)
            {
                int index = lbx_adat.SelectedIndex;
                cities.RemoveAt(index);
                lbx_adat.Items.Clear();
                foreach (var item in cities) lbx_adat.Items.Add(item.Name);

                if (index < lbx_adat.Items.Count)
                {
                    lbx_adat.SelectedIndex = index;
                }
                else if (lbx_adat.Items.Count > 0)
                {
                    lbx_adat.SelectedIndex = lbx_adat.Items.Count - 1;
                }
                else
                {
                    txbNev.Text = "";
                    txbHo.Text = "";
                    txbPara.Text = "";
                    txbSzel.Text = "";
                }
            }
        }
    }
}