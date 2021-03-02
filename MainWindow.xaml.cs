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
            DBHelper.FillCombo(combo_findFilter, new string[] { "Прiзвище", "Iм'я", "По батьковi", "Пiдроздiл", "Посада" });
            combo_findFilter.SelectedIndex = 0;
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
            text_currentCount.Text = grid_employeers.Items.Count.ToString();
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
            if (grid_employeers.SelectedItem == null)
            {
                MessageBox.Show("Виберiть сотрудника для редагування", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string IID = GetIID();
            NewEmployeeWindow newEmployeeWindow = new NewEmployeeWindow(EWindowMode.Edit, IID);
            newEmployeeWindow.ShowDialog();
        }


        private void UpdateAll()
        {
            grid_employeers.Items.Clear();
            if (connection.State != ConnectionState.Closed) connection.Close();
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select Surname,Name,Lastname,Department,Position,DateOfCompletion from [table]";
            cmd.Connection = connection;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Employee employee = new Employee(
                        DBHelper.Normalize(reader["Name"].ToString()),
                        DBHelper.Normalize(reader["Surname"].ToString()),
                        DBHelper.Normalize(reader["Lastname"].ToString()),
                        DBHelper.Normalize(reader["Department"].ToString()),
                        DBHelper.Normalize(reader["Position"].ToString()),
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
            stack_find.Visibility = Visibility.Collapsed;
        }
        private void check_ageSort_Unchecked(object sender, RoutedEventArgs e)
        {
            stack_sort.IsEnabled = false;
            text_from.Foreground = Brushes.Gray;
            text_to.Foreground = Brushes.Gray;
            text_found.Visibility = Visibility.Collapsed;
            stack_find.Visibility = Visibility.Visible;
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

        private void button_delete_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = grid_employeers.SelectedItem as Employee;
            if (employee != null)
            {
                if (MessageBox.Show($"Видалити {DBHelper.Normalize(employee.surname)} {DBHelper.Normalize(employee.name)} з бази данних?", "Ви впевненi?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    string IID = GetIID();
                    DBHelper.ClearTable(connection, "[Table]", IID);
                    DBHelper.ClearTable(connection, "[Appointment]", IID);
                    DBHelper.ClearTable(connection, "[Diploma]", IID);
                    DBHelper.ClearTable(connection, "[Educations]", IID);
                    DBHelper.ClearTable(connection, "[Family]", IID);
                    DBHelper.ClearTable(connection, "[Military]", IID);
                    DBHelper.ClearTable(connection, "[Profession]", IID);
                    DBHelper.ClearTable(connection, "[Vacation]", IID);
                    UpdateMainGrid();

                }
            }
        }
        private string GetIID()
        {
            string IID = "-1";
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
            return IID;
        }

        private void btn_findSur_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textB_surSort.Text))
            {
                UpdateMainGrid();
                return;
            }
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            switch (combo_findFilter.SelectedIndex)
            {
                //new string[] { "Прiзвище", "Iм'я", "По батьковi", "Пiдроздiл", "Посада" }
                case 0:
                    cmd.CommandText = "select Surname,Name,Lastname,Department,Position,DateOfCompletion from [table] where Surname = @sur";
                    cmd.Parameters.AddWithValue("@sur", textB_surSort.Text);
                    break;
                case 1:
                    cmd.CommandText = "select Surname,Name,Lastname,Department,Position,DateOfCompletion from [table] where Name = @Name";
                    cmd.Parameters.AddWithValue("@Name", textB_surSort.Text);
                    break;
                case 2:
                    cmd.CommandText = "select Surname,Name,Lastname,Department,Position,DateOfCompletion from [table] where Lastname = @Lastname";
                    cmd.Parameters.AddWithValue("@Lastname", textB_surSort.Text);
                    break;
                case 3:
                    cmd.CommandText = "select Surname,Name,Lastname,Department,Position,DateOfCompletion from [table] where Department = @Department";
                    cmd.Parameters.AddWithValue("@Department", textB_surSort.Text);
                    break;
                case 4:
                    cmd.CommandText = "select Surname,Name,Lastname,Department,Position,DateOfCompletion from [table] where Position = @Position";
                    cmd.Parameters.AddWithValue("@Position", textB_surSort.Text);
                    break;
                default:
                    cmd.CommandText = "select Surname,Name,Lastname,Department,Position,DateOfCompletion from [table] where Surname = @sur";
                    cmd.Parameters.AddWithValue("@sur", textB_surSort.Text);
                    break;
            }
            cmd.Connection = connection;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                grid_employeers.Items.Clear();
                while (reader.Read())
                {
                    Employee employee = new Employee(
                            DBHelper.Normalize(reader["Name"].ToString()),
                            DBHelper.Normalize(reader["Surname"].ToString()),
                            DBHelper.Normalize(reader["Lastname"].ToString()),
                            DBHelper.Normalize(reader["Department"].ToString()),
                            DBHelper.Normalize(reader["Position"].ToString()),
                            DateTime.Parse(reader["DateOfCompletion"].ToString()).ToShortDateString());
                    grid_employeers.Items.Add(employee);
                }
                MessageBox.Show($"Знайдено {grid_employeers.Items.Count}", "Iнформацiя", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Нiчого не знайдено", "Iнформацiя", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateMainGrid();
                return;
            }
            textB_surSort.Text = string.Empty;
            text_currentCount.Text = grid_employeers.Items.Count.ToString();
            connection.Close();
        }
    }
}
