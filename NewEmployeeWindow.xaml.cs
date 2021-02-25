using Human_Resources_Department.Properties;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для NewEmployeeWindow.xaml
    /// </summary>
    public partial class NewEmployeeWindow : Window
    {
        SqlConnection connection = new SqlConnection(new Settings().BDConnectionString);
        public NewEmployeeWindow()
        {
            InitializeComponent();
        }
        private string[] Genders = new string[] { "Жiноча", "Чоловiча" };
        private string[] WorkTypes = new string[] { "За сумiсництвом", "Основна" };
        private string[] FamilyStatuses = new string[] { "Одружений", "Неодружений", "Замiжня", "Незамiжня", "Розлучений", "Розлучена", "Вдова", "Вдiвець" };

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Combo_gender.SelectedIndex = 0;
            Combo_workType.SelectedIndex = 0;
            Combo_FamilyStatus.SelectedIndex = 0;
            foreach (var item in Genders)
                Combo_gender.Items.Add(item);
            foreach (var item in WorkTypes)
                Combo_workType.Items.Add(item);
            foreach (var item in FamilyStatuses)
                Combo_FamilyStatus.Items.Add(item);
        }

        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            //if (!Check(text_iid, "Введiть корректний IIД")) return;
            //if (!Check(text_surname, "Введiть корректне прiзвище")) return;
            //if (!Check(text_name, "Введiть корректне iм'я")) return;
            //if (!Check(text_lastname, "Введiть корректне по батьковi")) return;
            //if (!Check(text_department, "Введiть корректний пiдроздiл")) return;
            //if (!Check(text_position, "Введiть корректну посаду")) return;
            //if (!Check(text_phone, "Введiть корректну телефон")) return;
            //if (!Check(text_citizenship, "Введiть корректне громадянство")) return;
            //if (!Check(text_lastWorkPosition, "Введiть корректне останню посаду")) return;
            //if (!Check(text_lastWorkPlace, "Введiть корректне останнє мiсце роботи")) return;
            //if (!Check(text_DismissalReason, "Введiть корректну причину звiльнення")) return;
            //if (!Check(text_expD, "Введiть кiлькiсть днiв стажу")) return;
            //if (!Check(text_expM, "Введiть кiлькiсть мiсяцiв стажу")) return;
            //if (!Check(text_expY, "Введiть кiлькiсть рокiв стажу")) return;
            //if (!Check(text_Pension, "Введiть вiдомостi про отримання пенсiї")) return;
            //if (!Check(DatePicker_Birthday, "Введiть дату дня народження")) return;
            //if (!Check(DatePicker_Dismissal, "Введiть дату звiльнення")) return;
            //if (!Check(DatePicker_Completion, "Введiть дату заполнення")) return;

            try
            {
                Add();
                this.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if(connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();
            }
        }

        private void Add()
        {

            //Get last id from id
            int newId = GetLastId();
            //Insert
            connection.Open();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connection;
            cmd2.CommandText = "Insert Into [Table] (Id,DateOfCompletion,IsMale,IsMainWork,Department,Position,Surname,Name,Lastname,Birthday,Citizenship,Education,LastWorkPlace,LastWorkPosition,ExperienceD,ExperienceM,ExperienceY,DateOfDismissal,DismissalReason,Pension,FamilyStatus,PassportAdress,RealAdress,PassportSerial,PassportNumber,IssuingAuthority,IID,TelephoneNumber,PassportDate)  Values (@Id,@DateOfCompletion,@Male,@IsMainWork,@Department,@Position,@Surname,@Name,@Lastname,@Birthday,@Citizenship,@Education,@LastWorkPlace,@LastWorkPosition,@ExperienceD,@ExperienceM,@ExperienceY,@DateOfDismissal,@DismissalReason,@Pension,@FamilyStatus,@PassportAdress,@RealAdress,@PassportSerial,@PassportNumber,@IssuingAuthority,@IID,@TelephoneNumber,@PassportDate) ";           
            //Data
            Dictionary<string, string> dS = new Dictionary<string, string>()
            {
                {"@Department",text_department.Text },
                {"@Position",text_position.Text },
                {"@Surname", text_surname.Text },
                {"@Lastname", text_lastname.Text },
                {"@Name",text_name.Text },
                {"@Citizenship",text_citizenship.Text },
                {"@Education","Temp Education" },
                {"@LastWorkPlace", text_lastWorkPlace.Text },
                {"@LastWorkPosition", text_lastWorkPosition.Text },
                {"@DismissalReason",text_DismissalReason.Text },
                {"@Pension", text_Pension.Text },
                {"@FamilyStatus", Combo_FamilyStatus.SelectedItem.ToString() },
                {"@PassportAdress", "Temp passport adress" },
                {"@RealAdress", "Temp real adress" },
                {"@IssuingAuthority", "Temp authority"},
                {"@PassportSerial", "-" },
                {"@PassportNumber", "-" },
                {"@IID", text_iid.Text },
                {"@TelephoneNumber", text_phone.Text },
            };
            Dictionary<string, bool> dB = new Dictionary<string, bool>()
            {
                { "@Male", Convert.ToBoolean( Combo_gender.SelectedIndex) },
                { "@IsMainWork",  Convert.ToBoolean(Combo_workType.SelectedIndex) }
            };
            Dictionary<string, int> dI = new Dictionary<string, int>()
            {
                { "@Id", newId},
                { "@ExperienceD", int.Parse(text_expD.Text)},
                { "@ExperienceM", int.Parse(text_expM.Text)},
                { "@ExperienceY", int.Parse(text_expY.Text)}
            };
            Dictionary<string, DateTime> dD = new Dictionary<string, DateTime>()
            {
                {"@DateOfCompletion", Convert.ToDateTime(DatePicker_Completion.SelectedDate)},
                {"@Birthday", Convert.ToDateTime(DatePicker_Birthday.SelectedDate)},
                {"@DateOfDismissal", Convert.ToDateTime(DatePicker_Dismissal.SelectedDate)},
                {"@PassportDate",DateTime.Now }
            };
            //Add to parametrs
            foreach (var item in dS)
                cmd2.Parameters.AddWithValue(item.Key, item.Value);
            foreach (var item in dI)
                cmd2.Parameters.AddWithValue(item.Key, item.Value);
            foreach (var item in dB)
                cmd2.Parameters.AddWithValue(item.Key, item.Value);
            foreach (var item in dD)
                cmd2.Parameters.AddWithValue(item.Key, item.Value);
            //Execute
            cmd2.ExecuteNonQuery();
            //MessageBox.Show(newId.ToString());


            connection.Close();

        }
        private int GetLastId()
        {
            int newId = 0;
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM [Table] WHERE ID = (SELECT MAX(ID) FROM[Table])";

            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
                newId = (int)(sqlDataReader["ID"]) + 1;
            sqlDataReader.Close();

            connection.Close();
            return newId;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult resuult = MessageBox.Show("Ви хочете завершити створення сотрудника?", "Вийти?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            e.Cancel = resuult == MessageBoxResult.No;
        }
        private bool Check(TextBox textBox, string error)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show(error, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private bool Check(DatePicker datePicker, string error)
        {
            if (string.IsNullOrWhiteSpace(datePicker.SelectedDate.ToString()))
            {
                MessageBox.Show(error, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
