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
using System.Windows.Shapes;

namespace Human_Resources_Department
{
    /// <summary>
    /// Логика взаимодействия для AppointmentWindow.xaml
    /// </summary>
    public partial class AppointmentWindow : Window
    {
        public List<AppointmentData> list = null;
        public AppointmentWindow(List<AppointmentData> list)
        {
            InitializeComponent();
            this.list = list;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshGrid();
        }
        private void AppointmentGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            AppointmentData obj = (AppointmentData)(AppointmentGrid.SelectedItem);
            if (obj == null) Reset();
            else
            {
                datePicker_date.SelectedDate = Convert.ToDateTime(obj.Date);
                text_department.Text = obj.Department;
                text_position.Text = obj.Position;
                text_code.Text = obj.Code;
                text_salary.Text = Math.Round(obj.Salary, 2).ToString();
                text_reason.Text = obj.Reason;
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            if (Check())
            {
                try
                {
                    list.Add(new AppointmentData(Convert.ToDateTime(datePicker_date.SelectedDate).ToShortDateString(), text_department.Text, text_position.Text, text_code.Text, decimal.Parse(text_salary.Text), text_reason.Text));
                    RefreshGrid();
                    Reset();
                }
                catch(Exception exp)
                {
                    MessageBox.Show(exp.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            if (AppointmentGrid.SelectedItem == null)
            {
                MessageBox.Show("Спочатку оберiть строку для редагування", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            AppointmentData obj = (AppointmentData)(AppointmentGrid.SelectedItem);
            int id = list.FindIndex(x => x == obj);
            if (id == -1)
            {
                MessageBox.Show("Object: not found", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Check())
            {
                try
                {
                    list[id] = new AppointmentData(Convert.ToDateTime(datePicker_date.SelectedDate).ToShortDateString(), text_department.Text, text_position.Text, text_code.Text, decimal.Parse(text_salary.Text), text_reason.Text);
                    RefreshGrid();
                    Reset();
                }
                catch(Exception exp)
                {
                    MessageBox.Show(exp.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btn_remove_Click(object sender, RoutedEventArgs e)
        {

            if (AppointmentGrid.SelectedItem == null)
            {
                MessageBox.Show("Спочатку оберiть строку для видалення", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            AppointmentData obj = (AppointmentData)(AppointmentGrid.SelectedItem);
            int id = list.FindIndex(x => x == obj);
            if (id == -1)
            {
                MessageBox.Show("Object: not found", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            list.RemoveAt(id);
            RefreshGrid();
            Reset();
        }
        private void RefreshGrid()
        {
            this.AppointmentGrid.Items.Clear();
            if (list != null)
            {
                foreach (var item in list)
                {
                    this.AppointmentGrid.Items.Add(item);
                }
            }
        }
        private bool Check()
        {
            if (!DBHelper.Check(datePicker_date, "Введiть корректну дату")) return false;
            if (!DBHelper.Check(text_department, "Введiть корректну назву пiдроздiлу")) return false;
            if (!DBHelper.Check(text_position, "Введiть корректну назву посади")) return false;
            if (!DBHelper.Check(text_code, "Введiть корректний код за КП")) return false;
            if (!DBHelper.Check(text_salary, "Введiть корректний оклад")) return false;
            if (!DBHelper.Check(text_reason, "Введiть корректну пiдставу")) return false;
            return true;
        }
        private void Reset()
        {
            text_department.Text = string.Empty;
            text_position.Text = string.Empty;
            text_code.Text = string.Empty;
            text_salary.Text = string.Empty;
            text_reason.Text = string.Empty;
        }


    }
}
