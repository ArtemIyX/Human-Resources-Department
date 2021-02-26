﻿using Human_Resources_Department.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
using static Human_Resources_Department.DBHelper;
namespace Human_Resources_Department
{
    /// <summary>
    /// Логика взаимодействия для NewEmployeeWindow.xaml
    /// </summary>
    public partial class NewEmployeeWindow : Window
    {
        SqlConnection connection = new SqlConnection(new Settings().BDConnectionString);
        List<FamilyMember> list = new List<FamilyMember>();
        //private string[] Genders = new string[] { "Жiноча", "Чоловiча" };
        //private string[] WorkTypes = new string[] { "За сумiсництвом", "Основна" };
        //private string[] FamilyStatuses = new string[] { "Одружений", "Неодружений", "Замiжня", "Незамiжня", "Розлучений", "Розлучена", "Вдова", "Вдiвець" };
        private bool DontShowQuitMessage = false;
        public NewEmployeeWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DatePicker_Completion.SelectedDate = DateTime.Today;
            //employee_image.Source = 

            //Combo_gender.SelectedIndex = 0;
            //Combo_workType.SelectedIndex = 0;
            //Combo_FamilyStatus.SelectedIndex = 0;
            //foreach (var item in Genders)
            //    Combo_gender.Items.Add(item);
            //foreach (var item in WorkTypes)
            //    Combo_workType.Items.Add(item);
            //foreach (var item in FamilyStatuses)
            //    Combo_FamilyStatus.Items.Add(item);
            FillCombo(Combo_gender, new string[] { "Жiноча", "Чоловiча" });
            FillCombo(Combo_workType, new string[] { "За сумiсництвом", "Основна" });
            FillCombo(Combo_FamilyStatus, new string[] { "Одружений", "Неодружений", "Замiжня", "Незамiжня", "Розлучений", "Розлучена", "Вдова", "Вдiвець" });
        }
        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            if (!CannAddThisIID(text_iid.Text)) return;
            if (!Check(text_iid, "Введiть корректний IIД")) return;
            if (!Check(text_surname, "Введiть корректне прiзвище")) return;
            if (!Check(text_name, "Введiть корректне iм'я")) return;
            if (!Check(text_lastname, "Введiть корректне по батьковi")) return;
            if (!Check(text_department, "Введiть корректний пiдроздiл")) return;
            if (!Check(text_position, "Введiть корректну посаду")) return;
            if (!Check(text_phone, "Введiть корректну телефон")) return;
            if (!Check(text_citizenship, "Введiть корректне громадянство")) return;
            if (!Check(text_lastWorkPosition, "Введiть корректне останню посаду")) return;
            if (!Check(text_lastWorkPlace, "Введiть корректне останнє мiсце роботи")) return;
            if (!Check(text_DismissalReason, "Введiть корректну причину звiльнення")) return;
            if (!Check(text_expD, "Введiть кiлькiсть днiв стажу")) return;
            if (!Check(text_expM, "Введiть кiлькiсть мiсяцiв стажу")) return;
            if (!Check(text_expY, "Введiть кiлькiсть рокiв стажу")) return;
            if (!Check(text_Pension, "Введiть вiдомостi про отримання пенсiї")) return;
            if (!Check(DatePicker_Birthday, "Введiть дату дня народження")) return;
            if (!Check(DatePicker_Dismissal, "Введiть дату звiльнення")) return;
            if (!Check(DatePicker_Completion, "Введiть дату заполнення")) return;
            if (!CheckIsNumeric(text_expD.Text, "Дані про досвід введені некоректно")) return;
            if (!CheckIsNumeric(text_expM.Text, "Дані про досвід введені некоректно")) return;
            if (!CheckIsNumeric(text_expY.Text, "Дані про досвід введені некоректно")) return;
            if (!Check(text_realAdress, "Введiть коректне мiсце фактичного проживання")) return;
            if (!Check(text_passport, "Введiть коректне Мiсце проживання за державною реєстрацією")) return;
            if (!Check(text_authority, "Введiть коректне видаництво паспорту")) return;
            if (!Check(text_passportSerial, "Введiть коректну серiю паспорту")) return;
            if (!Check(text_passport, "Введiть коректний номер паспорту")) return;
            if (!Check(DatePicker_PassportDate, "Введiть коректну дату видачi паспорту")) return;
            if (!Check(text_pictureName, "Виберiть фотографiю")) return;
            try
            {
                Add();
                DontShowQuitMessage = true;
                this.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();
            }
        }
        private void btn_selectPicture_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "JPG Files (*.jpg)| *.jpg |All Files (*.*)|*.*";
                dialog.Title = "Вибрати зображення";
                if (Convert.ToBoolean(dialog.ShowDialog()))
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.UriSource = new Uri(dialog.FileName.ToString());
                    image.EndInit();
                    employee_image.Source = image;
                    text_pictureName.Text = dialog.FileName.ToString();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btn_editFamly_Click(object sender, RoutedEventArgs e)
        {
            EditFamilyWindow familyWindow = new EditFamilyWindow(this.list);
            familyWindow.ShowDialog();

            this.list = familyWindow.list;
            FamilyGrid.Items.Clear();
            foreach (var item in list)
                FamilyGrid.Items.Add(item);
        }
        private void Add()
        {
            //Get last id from id
            int newId = DBHelper.GetLastIdFromTable(connection, "[Table]");
            byte[] img = null;
            try
            {
                img = GetImageFromLoc(text_pictureName.Text);
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Insert
            connection.Open();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connection;
            cmd2.CommandText = "Insert Into [Table] (Id,DateOfCompletion,IsMale,IsMainWork,Department,Position,Surname,Name,Lastname,Birthday,Citizenship,Education,LastWorkPlace,LastWorkPosition,ExperienceD,ExperienceM,ExperienceY,DateOfDismissal,DismissalReason,Pension,FamilyStatus,PassportAdress,RealAdress,PassportSerial,PassportNumber,IssuingAuthority,IID,TelephoneNumber,PassportDate,Picture)  Values (@Id,@DateOfCompletion,@Male,@IsMainWork,@Department,@Position,@Surname,@Name,@Lastname,@Birthday,@Citizenship,@Education,@LastWorkPlace,@LastWorkPosition,@ExperienceD,@ExperienceM,@ExperienceY,@DateOfDismissal,@DismissalReason,@Pension,@FamilyStatus,@PassportAdress,@RealAdress,@PassportSerial,@PassportNumber,@IssuingAuthority,@IID,@TelephoneNumber,@PassportDate,@Image) ";
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
                {"@PassportAdress", text_passportAdress.Text },
                {"@RealAdress", text_realAdress.Text },
                {"@IssuingAuthority", text_authority.Text},
                {"@PassportSerial", text_passportSerial.Text },
                {"@PassportNumber", text_passport.Text },
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
                {"@PassportDate",Convert.ToDateTime(DatePicker_PassportDate.SelectedDate) }
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
            cmd2.Parameters.AddWithValue("@Image", img);
            //Execute
            try
            {
                cmd2.ExecuteNonQuery();
                //MessageBox.Show(newId.ToString());
            }
            finally
            {
                connection.Close();
            }
            AddEducations();
            foreach (var item in list)
            {
                AddFamilyMember(item);
            }
        }
        private void AddEducations()
        {
            Dictionary<string, bool> dB = new Dictionary<string, bool>()
            {
                {"@A",Convert.ToBoolean( check_educationA.IsChecked)},
                {"@B",Convert.ToBoolean( check_educationB.IsChecked)},
                {"@C",Convert.ToBoolean( check_educationC.IsChecked)},
                {"@D",Convert.ToBoolean( check_educationD.IsChecked)},
                {"@E",Convert.ToBoolean( check_educationE.IsChecked)},
                {"@F",Convert.ToBoolean( check_educationF.IsChecked)}
            };
            int newId = DBHelper.GetLastIdFromTable(connection, "[Educations]");
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Insert into [Educations] (Id,IID,A,B,C,D,E,F) Values (@Id,@IID,@A,@B,@C,@D,@E,@F)";
            cmd.Parameters.AddWithValue("@IID", text_iid.Text);
            cmd.Parameters.AddWithValue("@Id", newId);
            foreach (var item in dB)
                cmd.Parameters.AddWithValue(item.Key, item.Value);
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
        private void AddFamilyMember(FamilyMember member)
        {
            int id = GetLastIdFromTable(connection, "[Family]");
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Insert Into [Family] (Id,status,pib,year,IID) Values (@Id,@status,@pib,@year,@IID)";
            cmd.Parameters.AddWithValue("@Id",id);
            cmd.Parameters.AddWithValue("@status",member.status);
            cmd.Parameters.AddWithValue("@pib", member.pib);
            cmd.Parameters.AddWithValue("@year", member.year);
            cmd.Parameters.AddWithValue("@IID", text_iid.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!DontShowQuitMessage)
            {
                MessageBoxResult resuult = MessageBox.Show("Ви хочете завершити створення сотрудника?", "Вийти?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                e.Cancel = resuult == MessageBoxResult.No;
            }
        }

        private bool CannAddThisIID(string Iiid)
        {
            if (!DBHelper.CheckIsNumeric(Iiid, "Iндивiдуальний iндефiкацiйний номер повинен складатися тільки з цифр")) return false;
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Select * From [Table] Where IID = @IID";
            cmd.Parameters.AddWithValue("@IID", text_iid.Text);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable data = new DataTable("Table");
            dataAdapter.Fill(data);
            if (data.Rows.Count >= 1)
            {
                MessageBox.Show("Такий Iндивiдуальний iндефiкацiйний номер вже використовується", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                connection.Close();
                return false;
            }
            connection.Close();
            return true;
        }
        private byte[] GetImageFromLoc(string loc)
        {
            byte[] img = null;
            FileStream fs = new FileStream(loc, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);
            return img;
        }


    }
}
