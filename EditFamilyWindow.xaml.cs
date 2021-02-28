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
    /// Логика взаимодействия для EditFamilyWindow.xaml
    /// </summary>
    public partial class EditFamilyWindow : Window
    {
        public List<FamilyMember> list = null;
        public EditFamilyWindow(List<FamilyMember> list)
        {
            InitializeComponent();
            this.list = list;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshGrid();
            DBHelper.FillCombo(combo_status, new string[] { "Чоловiк", "Дружина", "Син", "Донька" });
        }


        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            if (Check())
            {
                list.Add(new FamilyMember(combo_status.SelectedItem.ToString(), text_pib.Text, int.Parse(text_year.Text)));
                RefreshGrid();
                Reset();
            }
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            if (FamilyGrid.SelectedItem == null)
            {
                MessageBox.Show("Спочатку оберiть строку для редагування", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            FamilyMember obj = (FamilyMember)(FamilyGrid.SelectedItem);
            int id = list.FindIndex(x => x == obj);
            if (id == -1)
            {
                MessageBox.Show("Object: not found", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Check())
            {
                list[id] = new FamilyMember(combo_status.SelectedItem.ToString(), text_pib.Text, int.Parse(text_year.Text));
                RefreshGrid();
                Reset();
            }
        }

        private void btn_remove_Click(object sender, RoutedEventArgs e)
        {
            if (FamilyGrid.SelectedItem == null)
            {
                MessageBox.Show("Спочатку оберiть строку для видалення", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            FamilyMember obj = (FamilyMember)(FamilyGrid.SelectedItem);
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

        private void FamilyGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            FamilyMember obj = (FamilyMember)(FamilyGrid.SelectedItem);
            if (obj == null) Reset();
            else
            {
                text_pib.Text = obj.pib;
                var id = combo_status.Items.IndexOf(obj.status);
                if (id == -1) combo_status.SelectedIndex = 0;
                else combo_status.SelectedIndex = id;
                text_year.Text = obj.year.ToString();
            }
        }
        private void RefreshGrid()
        {
            this.FamilyGrid.Items.Clear();
            if (list != null)
            {
                foreach (var item in list)
                {
                    this.FamilyGrid.Items.Add(item);
                }
            }
        }
        private bool Check()
        {
            if (!DBHelper.Check(text_pib, "Введiть корректний ПIБ")) return false;
            if (!DBHelper.Check(text_year, "Введiть корректний рiк народження")) return false;
            // if (!DBHelper.CheckIsNumeric(text_year.Text, "Введiть корректний рiк народження")) return false;
            return true;
        }
        private void Reset()
        {
            text_pib.Text = string.Empty;
            text_year.Text = string.Empty;
            combo_status.SelectedIndex = 0;
        }
    }
    
}
