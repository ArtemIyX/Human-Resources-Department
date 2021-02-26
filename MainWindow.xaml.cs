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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Human_Resources_Department
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmployeeDebugWindow debugWindow = null;
        SqlConnection connection = new SqlConnection(new Settings().BDConnectionString);
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Main_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateMainGrid();
        }

        private void button_debug_Click(object sender, RoutedEventArgs e)
        {
            if (debugWindow == null)
            {
                debugWindow = new EmployeeDebugWindow();
                debugWindow.Show();
                debugWindow.onClosed += ResetDebugWindow;
            }

        }
        private void ResetDebugWindow()
        {
            debugWindow = null;
        }
        private void UpdateMainGrid()
        {
            grid_employeers.Items.Clear();
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select Surname,Name,Lastname,Department,Position,DateOfCompletion from [table]";
            cmd.Connection = connection;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Employee employee = new Employee(
                    reader["Name"].ToString(),
                    reader["Surname"].ToString(),
                    reader["Lastname"].ToString(),
                    reader["Department"].ToString(),
                    reader["Position"].ToString(),
                    DateTime.Parse(reader["DateOfCompletion"].ToString()).ToShortDateString());
                grid_employeers.Items.Add(employee);
            }
            connection.Close();
        }

        private void grid_employeers_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {

        }

        private void button_createNew_Click(object sender, RoutedEventArgs e)
        {
            NewEmployeeWindow newEmployeeWindow = new NewEmployeeWindow();
            newEmployeeWindow.ShowDialog();
            UpdateMainGrid();
        }

        private void Window_Main_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
