using Microsoft.Data.SqlClient; // régi helyett
using System.Data;
using System.Data.SqlClient;
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

namespace Webshop_wpf_projekt_teszt
{
   
    public partial class MainWindow : Window
    {
        //Ez hozza létre a kapcsolatot az adatbáziahoz
        string connectionString = @"Server=localhost\SQLEXPRESS;Database=Webshop_wpf;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";
        public MainWindow()
        {
            InitializeComponent();
            TestConnection(); //függvényt hívja meg amivel legelsőnek látjuk hogy a kapcsolódás sikeres volt e vagy sem
            LoadProducts(); //Ezzel meg láthatjuk hogy a DataGridben sikeres kapcsolódás után megjelennek az adatok.
        }

        private void TestConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    MessageBox.Show("Kapcsolat sikeres!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kapcsolat sikertelen: " + ex.Message);
            }
        }

        private void LoadProducts()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Termek", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                ProductsDataGrid.ItemsSource = dt.DefaultView;
            }
        }
    }
}