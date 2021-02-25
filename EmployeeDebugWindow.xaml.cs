using Human_Resources_Department.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Human_Resources_Department
{
    /// <summary>
    /// Логика взаимодействия для EmployeeDebugWindow.xaml
    /// </summary>
    public partial class EmployeeDebugWindow : Window
    {
        Window org = null;
        public Action onClosed;
        public EmployeeDebugWindow()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            onClosed?.Invoke();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = new Settings().BDConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from [table]";
            cmd.Connection = con;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable data = new DataTable("Users");
            dataAdapter.Fill(data);
            debug_grid.ItemsSource = data.DefaultView;
            con.Close();
        }
    }
}
