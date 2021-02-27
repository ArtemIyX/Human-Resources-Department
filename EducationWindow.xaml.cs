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
    /// Логика взаимодействия для EducationWindow.xaml
    /// </summary>
    public partial class EducationWindow : Window
    {
        public List<EducationData> EducationList = null;
        public List<ProfessionData> ProfessionList = null;
        public EducationWindow(List<EducationData> educationsDatas, List<ProfessionData> professionDatas)
        {
            InitializeComponent();
            this.EducationList = educationsDatas;
            this.ProfessionList = professionDatas;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            combo_studyForm.Items.Add("Денна");
            combo_studyForm.Items.Add("Заочна");
            combo_studyForm.SelectedIndex = 0;
            RefreshGridA();
            RefreshGridB();
        }
        private void EducationGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            EducationData obj = (EducationData)(EducationGrid.SelectedItem);
            if (obj == null) ResetA();
            else
            {
                text_dName.Text = obj.DiplomaName;
                text_year.Text = obj.Year.ToString();
                text_uName.Text = obj.UniversityName;
            }
        }
        private void btn_addA_Click(object sender, RoutedEventArgs e)
        {
            if (CheckA())
            {
                EducationList.Add(new EducationData(text_uName.Text, text_dName.Text, int.Parse(text_year.Text)));
                RefreshGridA();
                ResetA();
            }
        }
        private void btn_editA_Click(object sender, RoutedEventArgs e)
        {
            if (EducationGrid.SelectedItem == null)
            {
                MessageBox.Show("Спочатку оберiть строку для редагування", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            EducationData obj = (EducationData)(EducationGrid.SelectedItem);
            int id = EducationList.FindIndex(x => x == obj);
            if (id == -1)
            {
                MessageBox.Show("Object: not found", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (CheckA())
            {
                EducationList[id] = new EducationData(text_uName.Text, text_dName.Text, int.Parse(text_year.Text));
                RefreshGridA();
                ResetA();
            }
        }
        private void btn_removeA_Click(object sender, RoutedEventArgs e)
        {
            if (EducationGrid.SelectedItem == null)
            {
                MessageBox.Show("Спочатку оберiть строку для видалення", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            EducationData obj = (EducationData)(EducationGrid.SelectedItem);
            int id = EducationList.FindIndex(x => x == obj);
            if (id == -1)
            {
                MessageBox.Show("Object: not found", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            EducationList.RemoveAt(id);
            RefreshGridA();
            ResetA();
        }

        private void RefreshGridA()
        {
            this.EducationGrid.Items.Clear();
            if (EducationList != null)
            {
                foreach (var item in EducationList)
                {
                    this.EducationGrid.Items.Add(item);
                }
            }
        }
        private bool CheckA()
        {
            if (!DBHelper.Check(text_dName, "Введiть корректнi данi про диплом")) return false;
            if (!DBHelper.Check(text_uName, "Введiть корректну назву освiтнього закладу")) return false;
            if (!DBHelper.Check(text_year, "Введiть корректний рiк закiнчення")) return false;
            if (!DBHelper.CheckIsNumeric(text_year.Text, "Введiть корректний рiк закiнчення")) return false;
            return true;
        }
        private void ResetA()
        {
            text_dName.Text = string.Empty;
            text_year.Text = string.Empty;
            text_uName.Text = string.Empty;
        }

        private void ProfessionGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            ProfessionData obj = (ProfessionData)(ProfessionGrid.SelectedItem);
            if (obj == null) ResetB();
            else
            {
                text_profession.Text = obj.Profession;
                text_qualification.Text = obj.Qualification;
                combo_studyForm.SelectedItem = obj.StudyForm;
            }
        }
        private void btn_addB_Click(object sender, RoutedEventArgs e)
        {
            if (CheckB())
            {
                ProfessionList.Add(new ProfessionData(text_profession.Text, text_qualification.Text, combo_studyForm.SelectedItem.ToString()));
                RefreshGridB();
                ResetB();
            }
        }
        private void btn_editB_Click(object sender, RoutedEventArgs e)
        {
            if (ProfessionGrid.SelectedItem == null)
            {
                MessageBox.Show("Спочатку оберiть строку для редагування", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            ProfessionData obj = (ProfessionData)(ProfessionGrid.SelectedItem);
            int id = ProfessionList.FindIndex(x => x == obj);
            if (id == -1)
            {
                MessageBox.Show("Object: not found", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (CheckB())
            {
                ProfessionList[id] = new ProfessionData(text_profession.Text, text_qualification.Text, combo_studyForm.SelectedItem.ToString());
                RefreshGridB();
                ResetB();
            }
        }
        private void btn_removeB_Click(object sender, RoutedEventArgs e)
        {
            if (ProfessionGrid.SelectedItem == null)
            {
                MessageBox.Show("Спочатку оберiть строку для видалення", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            ProfessionData obj = (ProfessionData)(ProfessionGrid.SelectedItem);
            int id = ProfessionList.FindIndex(x => x == obj);
            if (id == -1)
            {
                MessageBox.Show("Object: not found", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            ProfessionList.RemoveAt(id);
            RefreshGridB();
            ResetB();
        }

        private void RefreshGridB()
        {
            this.ProfessionGrid.Items.Clear();
            if (ProfessionList != null)
            {
                foreach (var item in ProfessionList)
                {
                    this.ProfessionGrid.Items.Add(item);
                }
            }
        }
        private bool CheckB()
        {
            if (!DBHelper.Check(text_profession, "Введiть корректнi данi про диплом")) return false;
            if (!DBHelper.Check(text_qualification, "Введiть корректну назву освiтнього закладу")) return false;
            return true;
        }
        private void ResetB()
        {
            text_profession.Text = string.Empty;
            text_qualification.Text = string.Empty;
            combo_studyForm.SelectedIndex = 0;
        }
    }
}
