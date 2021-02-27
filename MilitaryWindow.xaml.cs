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

namespace Human_Resources_Department.windows
{
    /// <summary>
    /// Логика взаимодействия для MilitaryWindow.xaml
    /// </summary>
    public partial class MilitaryWindow : Window
    {
        public MilitaryData Data = null;
        public MilitaryWindow(MilitaryData data)
        {
            InitializeComponent();
            this.Data = data;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillText(this.Data);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            FillData();
        }
        private void FillText(MilitaryData data)
        {
            if (data != null)
            {
                text_group.Text = data.Group;
                text_category.Text = data.Category;
                text_staff.Text = data.Staff;
                text_rank.Text = data.Rank;
                text_number.Text = data.Number;
                text_suitability.Text = data.Suitability;
                text_officePassport.Text = Data.OfficePassport;
                text_officeReal.Text = Data.OfficeReal;
            }
        }
        private void FillData()
        {
            this.Data.Group = text_group.Text;
            this.Data.Category = text_category.Text;
            this.Data.Staff = text_staff.Text;
            this.Data.Rank = text_rank.Text;
            this.Data.Number = text_number.Text;
            this.Data.Suitability = text_suitability.Text;
            this.Data.OfficePassport = text_officePassport.Text;
            this.Data.OfficeReal = text_officeReal.Text;
        }
    }
}
