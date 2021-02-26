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
        SqlConnection connection = new SqlConnection(new Settings().BDConnectionString);
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
            DBHelper.LoadTalbe(connection,"[Table]", debug_grid);
            DBHelper.LoadTalbe(connection,"[Educations]", educations_grid);
            DBHelper.LoadTalbe(connection, "[Family]", family_grid);
        }
    }
}
