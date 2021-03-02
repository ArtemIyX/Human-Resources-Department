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

    public partial class HolidayWindow : Window
    {
        private List<VacationData> list = null;
        public HolidayWindow(List<VacationData> list)
        {
            InitializeComponent();
            this.list = list;
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            if (Check())
            {
                try
                {
                    list.Add(new VacationData(
                        text_type.Text,
                        text_period.Text,
                        Convert.ToDateTime( datePicker_begin.SelectedDate).ToShortDateString(),
                        Convert.ToDateTime(datePicker_end.SelectedDate).ToShortDateString(),
                        text_reason.Text));
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
                RefreshGrid();
                Reset();
            }
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            if (HolidayGrid.SelectedItem == null)
            {
                MessageBox.Show("Спочатку оберiть строку для редагування", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            VacationData obj = (VacationData)(HolidayGrid.SelectedItem);
            int id = list.FindIndex(x => x == obj);
            if (id == -1)
            {
                MessageBox.Show("Object: not found", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Check())
            {
                list[id] = new VacationData(
                        text_type.Text,
                        text_period.Text,
                        Convert.ToDateTime(datePicker_begin.SelectedDate).ToShortDateString(),
                        Convert.ToDateTime(datePicker_end.SelectedDate).ToShortDateString(),
                        text_reason.Text);
                RefreshGrid();
                Reset();
            }
        }

        private void btn_remove_Click(object sender, RoutedEventArgs e)
        {
            if (HolidayGrid.SelectedItem == null)
            {
                MessageBox.Show("Спочатку оберiть строку для видалення", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            VacationData obj = (VacationData)(HolidayGrid.SelectedItem);
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

        private void HolidayGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            VacationData obj = (VacationData)(HolidayGrid.SelectedItem);
            if (obj == null) Reset();
            else
            {
                text_period.Text = obj.Period;
                text_reason.Text = obj.Reason;
                text_type.Text = obj.Type;
                datePicker_begin.SelectedDate = DateTime.Parse(obj.Begin);
                datePicker_end.SelectedDate = DateTime.Parse(obj.End);
            }
        }
        private void RefreshGrid()
        {
            this.HolidayGrid.Items.Clear();
            if (list != null)
            {
                foreach (var item in list)
                {
                    this.HolidayGrid.Items.Add(item);
                }
            }
        }
        private bool Check()
        {
            if (!DBHelper.Check(text_type, "Введiть корректний ПIБ")) return false;
            if (!DBHelper.Check(text_period, "Введiть корректний рiк народження")) return false;
            if (!DBHelper.Check(text_reason, "Введiть корректний рiк народження")) return false;
            if (!DBHelper.Check(datePicker_begin, "Введiть корректний рiк народження")) return false;
            if (!DBHelper.Check(datePicker_end, "Введiть корректний рiк народження")) return false;
            // if (!DBHelper.CheckIsNumeric(text_year.Text, "Введiть корректний рiк народження")) return false;
            return true;
        }
        private void Reset()
        {
            text_type.Text = string.Empty;
            text_period.Text = string.Empty;
            text_reason.Text = string.Empty;
            datePicker_begin.SelectedDate = DateTime.Now;
            datePicker_end.SelectedDate = DateTime.Now;
            text_days.Text = "0";
        }


        private void datePicker_end_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datePicker_begin.SelectedDate != null && datePicker_end.SelectedDate != null)
            {
                var a = datePicker_end.SelectedDate - datePicker_begin.SelectedDate;
                text_days.Text = (datePicker_end.SelectedDate - datePicker_begin.SelectedDate).Value.TotalDays.ToString();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshGrid();
        }
    }
}
