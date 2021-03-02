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
            stack_sort.IsEnabled = false;
            text_from.Foreground = Brushes.Gray;
            text_to.Foreground = Brushes.Gray;
#if DEBUG
            button_debug.Visibility = Visibility.Visible;
#endif
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
            UpdateAll();
            int fm = GetFemaleCount(), m = GetMaleCount();
            text_female.Text = fm.ToString();
            text_male.Text = m.ToString();
            text_total.Text = (fm + m).ToString();
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

        private void button_edit_Click(object sender, RoutedEventArgs e)
        {
            string IID = "-1";
            if (grid_employeers.SelectedItem == null)
            {
                MessageBox.Show("Виберiть сотрудника для редагування", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Employee employee = grid_employeers.SelectedItem as Employee;
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Select IID From [Table] Where Name = @name AND Surname = @sur AND Lastname = @last AND Department = @dep AND Position = @pos";
            Dictionary<string, string> dS = new Dictionary<string, string>()
            {
                {"@name",employee.name},
                {"@sur",employee.surname },
                {"@last",employee.lastname },
                {"@dep",employee.department },
                {"@pos",employee.position }
            };
            foreach (var item in dS)
                cmd.Parameters.AddWithValue(item.Key, item.Value);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                IID = DBHelper.Normalize(dataReader[0].ToString());
            }
            connection.Close();
            NewEmployeeWindow newEmployeeWindow = new NewEmployeeWindow(EWindowMode.Edit, IID);
            newEmployeeWindow.ShowDialog();
        }

        private void UpdateOnlyMale()
        {
            grid_employeers.Items.Clear();
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select Surname,Name,Lastname,Department,Position,DateOfCompletion from [table] where IsMale = '1'";
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
        private void UpdateOnlyFemale()
        {
            grid_employeers.Items.Clear();
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select Surname,Name,Lastname,Department,Position,DateOfCompletion from [table] where IsMale = '0'";
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
        private void UpdateAll()
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

        private List<Employee> GetByOld(int from, int to)
        {
            List<Employee> res = new List<Employee>();
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select Surname,Name,Lastname,Department,Position,DateOfCompletion,Birthday from [table]";
            cmd.Connection = connection;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime birth = Convert.ToDateTime(reader["Birthday"]);
                double age = (DateTime.Today - birth).TotalDays / 365;
                if (age >= from && age <= to)
                {
                    Employee employee = new Employee(
                        DBHelper.Normalize(reader["Name"].ToString()),
                        DBHelper.Normalize(reader["Surname"].ToString()),
                        DBHelper.Normalize(reader["Lastname"].ToString()),
                        DBHelper.Normalize(reader["Department"].ToString()),
                        DBHelper.Normalize(reader["Position"].ToString()),
                        DateTime.Parse(reader["DateOfCompletion"].ToString()).ToShortDateString());
                    res.Add(employee);
                }
            }
            connection.Close();
            return res;
        }

        private int GetMaleCount()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from [Table] where IsMale = '1'";
            cmd.Connection = connection;
            int res = 0;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    res++;
                }
            }
            connection.Close();
            return res;
        }
        private int GetFemaleCount()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from [Table] where IsMale = '0'";
            cmd.Connection = connection;
            int res = 0;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    res++;
                }
            }
            connection.Close();
            return res;
        }

        private void check_ageSort_Checked(object sender, RoutedEventArgs e)
        {
            stack_sort.IsEnabled = true;
            text_from.Foreground = Brushes.Black;
            text_to.Foreground = Brushes.Black;
        }
        private void check_ageSort_Unchecked(object sender, RoutedEventArgs e)
        {
            stack_sort.IsEnabled = false;
            text_from.Foreground = Brushes.Gray;
            text_to.Foreground = Brushes.Gray;
            text_found.Visibility = Visibility.Collapsed;
            UpdateMainGrid();
        }
        private void btn_updSort_Click(object sender, RoutedEventArgs e)
        {
            if (!DBHelper.Check(textB_from, "Спочатку ведiть дiапазон вiку")) return;
            if (!DBHelper.Check(textB_to, "Спочатку ведiть дiапазон вiку")) return;
            int from = 0, to = 0;
            if (!int.TryParse(textB_from.Text, out from))
            {
                MessageBox.Show("Дуже странний діапазон віку", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!int.TryParse(textB_to.Text, out to))
            {
                MessageBox.Show("Дуже странний діапазон віку", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (from > to)
            {
                MessageBox.Show("\"Від\" повинно бути меньше за \"До\"", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var list = GetByOld(from, to);
            grid_employeers.Items.Clear();
            foreach (var item in list)
                grid_employeers.Items.Add(item);
            text_found.Visibility = Visibility.Visible;
            text_found.Text = "Знайдено: " + list.Count.ToString();
        }
    }
}
