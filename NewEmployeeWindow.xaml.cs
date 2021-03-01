using Human_Resources_Department.Properties;
using Human_Resources_Department.windows;
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

    public enum EWindowMode
    {
        CreateNew,
        Edit
    }

    public partial class NewEmployeeWindow : Window
    {

        private EWindowMode WindowMode = EWindowMode.CreateNew;
        private string iid = "-1";
        private byte[] ImageBytes = null;
        private SqlConnection connection = new SqlConnection(new Settings().BDConnectionString);
        private List<FamilyMember> FamilyList = new List<FamilyMember>();
        private List<EducationData> EducationList = new List<EducationData>();
        private List<ProfessionData> Professionlist = new List<ProfessionData>();
        private MilitaryData militaryData = new MilitaryData();
        private List<AppointmentData> AppointmentList = new List<AppointmentData>();

        //private string[] Genders = new string[] { "Жiноча", "Чоловiча" };
        //private string[] WorkTypes = new string[] { "За сумiсництвом", "Основна" };
        //private string[] FamilyStatuses = new string[] { "Одружений", "Неодружений", "Замiжня", "Незамiжня", "Розлучений", "Розлучена", "Вдова", "Вдiвець" };
        private bool DontShowQuitMessage = false;
        public NewEmployeeWindow(EWindowMode mode = EWindowMode.CreateNew, string iid = "-1")
        {
            InitializeComponent();
            this.WindowMode = mode;
            this.iid = iid;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillCombo(Combo_gender, new string[] { "Жiноча", "Чоловiча" });
            FillCombo(Combo_workType, new string[] { "За сумiсництвом", "Основна" });
            FillCombo(Combo_FamilyStatus, new string[] { "Одружений", "Неодружений", "Замiжня", "Незамiжня", "Розлучений", "Розлучена", "Вдова", "Вдiвець" });
            if (this.WindowMode == EWindowMode.CreateNew)
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
            }
            else if (this.WindowMode == EWindowMode.Edit)
            {
                try
                {
                    Load();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    DontShowQuitMessage = true;
                    this.Close();
                }
            }

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!DontShowQuitMessage)
            {
                MessageBoxResult resuult = MessageBox.Show("Ви хочете завершити створення сотрудника?", "Вийти?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                e.Cancel = resuult == MessageBoxResult.No;
            }
        }


        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            //if (!CannAddThisIID(text_iid.Text)) return;
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
            //if (!CheckIsNumeric(text_expD.Text, "Дані про досвід введені некоректно")) return;
            //if (!CheckIsNumeric(text_expM.Text, "Дані про досвід введені некоректно")) return;
            //if (!CheckIsNumeric(text_expY.Text, "Дані про досвід введені некоректно")) return;
            //if (!Check(text_realAdress, "Введiть коректне мiсце фактичного проживання")) return;
            //if (!Check(text_passport, "Введiть коректне мiсце проживання за державною реєстрацією")) return;
            //if (!Check(text_authority, "Введiть коректне видаництво паспорту")) return;
            //if (!Check(text_passportSerial, "Введiть коректну серiю паспорту")) return;
            //if (!Check(text_passport, "Введiть коректний номер паспорту")) return;
            //if (!Check(DatePicker_PassportDate, "Введiть коректну дату видачi паспорту")) return;
            //if (!Check(text_pictureName, "Виберiть фотографiю")) return;
            if (this.WindowMode == EWindowMode.CreateNew)
            {
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
            else if (this.WindowMode == EWindowMode.Edit)
            {
                try
                {
                    Edit();
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
            EditFamilyWindow familyWindow = new EditFamilyWindow(this.FamilyList);
            familyWindow.ShowDialog();

            this.FamilyList = familyWindow.list;
            RefreshFamilyGrid();
        }
        private void btn_military_Click(object sender, RoutedEventArgs e)
        {
            MilitaryWindow window = new MilitaryWindow(militaryData);
            window.ShowDialog();
        }
        private void btn_editEducation_Click(object sender, RoutedEventArgs e)
        {
            EducationWindow window = new EducationWindow(EducationList, Professionlist);
            window.ShowDialog();
        }
        private void btn_appointment_Click(object sender, RoutedEventArgs e)
        {
            AppointmentWindow window = new AppointmentWindow(AppointmentList);
            window.ShowDialog();
        }

        private void RefreshFamilyGrid()
        {
            FamilyGrid.Items.Clear();
            foreach (var item in FamilyList)
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
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Insert
            connection.Open();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connection;
            cmd2.CommandText = "Insert Into [Table] (Id,DateOfCompletion,IsMale,IsMainWork,Department,Position,Surname,Name,Lastname,Birthday,Citizenship,LastWorkPlace,LastWorkPosition,ExperienceD,ExperienceM,ExperienceY,DateOfDismissal,DismissalReason,Pension,FamilyStatus,PassportAdress,RealAdress,PassportSerial,PassportNumber,IssuingAuthority,IID,TelephoneNumber,PassportDate,Picture)  Values (@Id,@DateOfCompletion,@Male,@IsMainWork,@Department,@Position,@Surname,@Name,@Lastname,@Birthday,@Citizenship,@LastWorkPlace,@LastWorkPosition,@ExperienceD,@ExperienceM,@ExperienceY,@DateOfDismissal,@DismissalReason,@Pension,@FamilyStatus,@PassportAdress,@RealAdress,@PassportSerial,@PassportNumber,@IssuingAuthority,@IID,@TelephoneNumber,@PassportDate,@Image) ";
            //Data
            Dictionary<string, string> dS = new Dictionary<string, string>()
            {
                {"@Department",text_department.Text },
                {"@Position",text_position.Text },
                {"@Surname", text_surname.Text },
                {"@Lastname", text_lastname.Text },
                {"@Name",text_name.Text },
                {"@Citizenship",text_citizenship.Text },
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
            AddMilitaryData(militaryData);

            foreach (var item in FamilyList)
                AddFamilyMember(item);
            foreach (var item in EducationList)
                AddDiplomaData(item);
            foreach (var item in Professionlist)
                AddProfessionData(item);
            foreach (var item in AppointmentList)
                AddApointmentData(item);

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
            member.Check();
            int id = GetLastIdFromTable(connection, "[Family]");
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Insert Into [Family] (Id,status,pib,year,IID) Values (@Id,@status,@pib,@year,@IID)";
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@status", member.status);
            cmd.Parameters.AddWithValue("@pib", member.pib);
            cmd.Parameters.AddWithValue("@year", member.year);
            cmd.Parameters.AddWithValue("@IID", text_iid.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        private void AddMilitaryData(MilitaryData data)
        {
            data.Check();
            int id = GetLastIdFromTable(connection, "[Military]");
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Insert Into [Military] (Id,_Group,Category,Staff,_Rank,Number,Suitability,OfficePassport,OfficeReal,IID) Values (@Id,@g,@c,@Staff,@r,@Number,@Suitability,@OfficePassport,@OfficeReal,@IID)";
            Dictionary<string, string> ds = new Dictionary<string, string>()
            {
                {"@g",data.Group},
                {"@c",data.Category },
                {"@Staff",data.Staff },
                {"@r",data.Rank },
                {"@Number",data.Number },
                {"@Suitability",data.Suitability },
                {"@OfficePassport",data.OfficePassport },
                {"@OfficeReal",data.OfficeReal },
                {"@IID",text_iid.Text }
            };
            cmd.Parameters.AddWithValue("@Id", id);
            foreach (var item in ds)
            {
                cmd.Parameters.AddWithValue(item.Key, item.Value);
            }
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        private void AddDiplomaData(EducationData data)
        {
            data.Check();
            int id = GetLastIdFromTable(connection, "[Diploma]");
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Insert Into [Diploma] (Id,UniversityName,DiplomaName,Year,IID) Values (@Id,@UniversityName,@DiplomaName,@Year,@IID)";
            Dictionary<string, string> ds = new Dictionary<string, string>()
            {
                {"@UniversityName",data.UniversityName},
                {"@DiplomaName",data.DiplomaName },
                {"@IID",text_iid.Text }
            };
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Year", data.Year);
            foreach (var item in ds)
                cmd.Parameters.AddWithValue(item.Key, item.Value);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        private void AddProfessionData(ProfessionData data)
        {
            data.Check();
            int id = GetLastIdFromTable(connection, "[Profession]");
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Insert Into [Profession] (Id,Profession,Qualification,StudyForm,IID) Values (@Id,@Profession,@Qualification,@StudyForm,@IID)";
            Dictionary<string, string> ds = new Dictionary<string, string>()
            {
                {"@Profession",data.Profession},
                {"@Qualification",data.Qualification },
                {"@StudyForm",data.StudyForm },
                {"@IID",text_iid.Text }
            };
            cmd.Parameters.AddWithValue("@Id", id);
            foreach (var item in ds)
                cmd.Parameters.AddWithValue(item.Key, item.Value);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        private void AddApointmentData(AppointmentData data)
        {
            data.Check();
            int id = GetLastIdFromTable(connection, "[Appointment]");
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Insert Into [Appointment] (Id,AppointmentDate,Department,Position,Code,Salary,Reason,IID) Values (@Id,@Date,@Department,@Position,@Code,@Salary,@Reason,@IID)";
            Dictionary<string, string> ds = new Dictionary<string, string>()
            {
                {"@Department",data.Department},
                {"@Position",data.Position },
                {"@Code",data.Code },
                {"@Reason",data.Reason },
                {"@IID",text_iid.Text }
            };
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Salary", data.Salary);
            cmd.Parameters.AddWithValue("@Date", DateTime.Parse(data.Date)); //Опасный код
            foreach (var item in ds)
                cmd.Parameters.AddWithValue(item.Key, item.Value);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        private bool CannAddThisIID(string Iiid)
        {
            //if (!DBHelper.CheckIsNumeric(Iiid, "Iндивiдуальний iденфiкацiйний номер повинен складатися тільки з цифр")) return false;
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
                MessageBox.Show("Такий Iндивiдуальний iденфiкацiйний номер вже використовується", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void Load()
        {
            LoadMain();
            LoadEducations();
            LoadFamily();
            LoadMilitary();
            LoadDiploma();
            LoadProfession();
            LoadAppointment();

            text_iid.Text = this.iid;
            text_iid.IsReadOnly = true;
            RefreshFamilyGrid();
        }
        private void LoadMain()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Select * From [Table] Where IID = @IID";
            cmd.Parameters.AddWithValue("@IID", this.iid);
            try
            {
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        try
                        {
                            DatePicker_Completion.SelectedDate = DateTime.Parse(dataReader[1].ToString());
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.Message, "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        Combo_gender.SelectedIndex = Convert.ToInt32(Convert.ToBoolean(dataReader[2]));
                        Combo_workType.SelectedIndex = Convert.ToInt32(Convert.ToBoolean(dataReader[3]));
                        text_department.Text = Normalize(dataReader[4].ToString());
                        text_position.Text = Normalize(dataReader[5].ToString());
                        text_surname.Text = Normalize(dataReader[6].ToString());
                        text_name.Text = Normalize(dataReader[7].ToString());
                        text_lastname.Text = Normalize(dataReader[8].ToString());
                        try
                        {
                            DatePicker_Birthday.SelectedDate = Convert.ToDateTime(dataReader[9]);
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.Message, "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        text_citizenship.Text = Normalize(dataReader[10].ToString());
                        text_lastWorkPlace.Text = Normalize(dataReader[11].ToString());
                        text_lastWorkPosition.Text = Normalize(dataReader[12].ToString());
                        text_expD.Text = Normalize(dataReader[13].ToString());
                        text_expM.Text = Normalize(dataReader[14].ToString());
                        text_expY.Text = Normalize(dataReader[15].ToString());
                        try
                        {
                            DatePicker_Dismissal.SelectedDate = Convert.ToDateTime(dataReader[16]);
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.Message, "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        text_DismissalReason.Text = Normalize(dataReader[17].ToString());
                        text_Pension.Text = Normalize(dataReader[18].ToString());
                        Combo_FamilyStatus.SelectedItem = Normalize(dataReader[19].ToString());
                        text_passportAdress.Text = Normalize(dataReader[20].ToString());
                        text_realAdress.Text = Normalize(dataReader[21].ToString());
                        text_passportSerial.Text = Normalize(dataReader[22].ToString());
                        text_passport.Text = Normalize(dataReader[23].ToString());
                        text_authority.Text = Normalize(dataReader[24].ToString());
                        //iid = dataReader[25].Tostring();
                        text_phone.Text = Normalize(dataReader[26].ToString());
                        try
                        {
                            DatePicker_PassportDate.SelectedDate = Convert.ToDateTime(dataReader[27]);
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.Message, "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        try
                        {
                            byte[] img = (byte[])(dataReader[28]);
                            MemoryStream ms = new MemoryStream(img);
                            employee_image.Source = BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                            ImageBytes = img;
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show("Не знайдено зображення сотрудника", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                connection.Close();
                return;
                //throw new Exception($"Сотрудника з IID {iid} не знайдено");
            }
            connection.Close();
        }
        private void LoadEducations()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Select * From [Educations] Where IID = @IID";
            cmd.Parameters.AddWithValue("@IID", this.iid);
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    //var id = dataReader[0];
                    //var iid = dataReader[1];
                    CheckBox[] checkBoxes = new CheckBox[] { check_educationA, check_educationB, check_educationC, check_educationD, check_educationE, check_educationF };
                    for (int i = 0; i < checkBoxes.Length; ++i)
                    {
                        checkBoxes[i].IsChecked = Convert.ToBoolean(dataReader[i + 2]);
                    }
                }
            }
            connection.Close();
        }
        private void LoadFamily()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Select * From [Family] Where IID = @IID";
            cmd.Parameters.AddWithValue("@IID", this.iid);
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                FamilyList.Clear();
                while (dataReader.Read())
                {
                    FamilyMember member = new FamilyMember();
                    member.status = Normalize(dataReader[1].ToString());
                    member.pib = Normalize(dataReader[2].ToString());
                    member.year = Convert.ToInt32(dataReader[3]);
                    FamilyList.Add(member);
                }
            }
            connection.Close();
        }
        private void LoadMilitary()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Select * From [Military] Where IID = @IID";
            cmd.Parameters.AddWithValue("@IID", this.iid);
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    militaryData.Group = Normalize(dataReader[1].ToString());
                    militaryData.Category = Normalize(dataReader[2].ToString());
                    militaryData.Staff = Normalize(dataReader[3].ToString());
                    militaryData.Rank = Normalize(dataReader[4].ToString());
                    militaryData.Number = Normalize(dataReader[5].ToString());
                    militaryData.Suitability = Normalize(dataReader[6].ToString());
                    militaryData.OfficePassport = Normalize(dataReader[7].ToString());
                    militaryData.OfficeReal = Normalize(dataReader[8].ToString());
                }
            }
            connection.Close();
        }
        private void LoadDiploma()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Select * From [Diploma] Where IID = @IID";
            cmd.Parameters.AddWithValue("@IID", this.iid);
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                EducationList.Clear();
                while (dataReader.Read())
                {
                    EducationData data = new EducationData();
                    data.UniversityName = Normalize(dataReader[1].ToString());
                    data.DiplomaName = Normalize(dataReader[2].ToString());
                    data.Year = Convert.ToInt32(dataReader[3].ToString());
                    EducationList.Add(data);
                }
            }
            connection.Close();
        }
        private void LoadProfession()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Select * From [Profession] Where IID = @IID";
            cmd.Parameters.AddWithValue("@IID", this.iid);
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                Professionlist.Clear();
                while (dataReader.Read())
                {
                    ProfessionData data = new ProfessionData();
                    data.Profession = Normalize(dataReader[1].ToString());
                    data.Qualification = Normalize(dataReader[2].ToString());
                    data.StudyForm = Normalize(dataReader[3].ToString());
                    Professionlist.Add(data);
                }
            }
            connection.Close();
        }
        private void LoadAppointment()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Select * From [Appointment] Where IID = @IID";
            cmd.Parameters.AddWithValue("@IID", this.iid);
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                AppointmentList.Clear();
                while (dataReader.Read())
                {
                    AppointmentData data = new AppointmentData();
                    data.Date = Convert.ToDateTime(dataReader[1]).ToShortDateString();
                    data.Department = Normalize(dataReader[2].ToString());
                    data.Position = Normalize(dataReader[3].ToString());
                    data.Code = Normalize(dataReader[4].ToString());
                    data.Salary = Convert.ToDecimal(dataReader[5]);
                    data.Reason = Normalize(dataReader[6].ToString());
                    AppointmentList.Add(data);
                }
            }
            connection.Close();
        }

        private void Edit()
        {
            EditMain();
            EditMilitary();
            EditFamily();
            EditDiploma();
            EditProfession();
            EditAppointment();
        }
        private void EditMain()
        {
            if (!string.IsNullOrEmpty(text_pictureName.Text))
            {
                ImageBytes = GetImageFromLoc(text_pictureName.Text);
            }
            else if (ImageBytes == null)
            {
                try
                {
                    ImageBytes = GetImageFromLoc(text_pictureName.Text);
                }
                catch (Exception exp)
                {
                    throw new Exception("Виберiть зображення");
                }
            }
            //Update
            connection.Open();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connection;
            cmd2.CommandText = "Update [Table] set DateOfCompletion = @DateOfCompletion ,IsMale = @IsMale,IsMainWork = @IsMainWork,Department = @Department,Position = @Position,Surname = @Surname,Name = @Name,Lastname = @Lastname,Birthday = @Birthday,Citizenship = @Citizenship,LastWorkPlace = @LastWorkPlace,LastWorkPosition = @LastWorkPosition,ExperienceD = @ExperienceD,ExperienceM = @ExperienceM,ExperienceY = @ExperienceY,DateOfDismissal = @DateOfDismissal,DismissalReason = @DismissalReason,Pension = @Pension,FamilyStatus = @FamilyStatus,PassportAdress = @PassportAdress,RealAdress = @RealAdress,PassportSerial = @PassportSerial,PassportNumber = @PassportNumber,IssuingAuthority = @IssuingAuthority,TelephoneNumber = @TelephoneNumber,PassportDate = @PassportDate,Picture = @Image where IID = @IID";
            Dictionary<string, string> dS = new Dictionary<string, string>()
            {
                {"@Department",text_department.Text },
                {"@Position",text_position.Text },
                {"@Surname", text_surname.Text },
                {"@Lastname", text_lastname.Text },
                {"@Name",text_name.Text },
                {"@Citizenship",text_citizenship.Text },
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
                { "@IsMale", Convert.ToBoolean( Combo_gender.SelectedIndex) },
                { "@IsMainWork",  Convert.ToBoolean(Combo_workType.SelectedIndex) }
            };
            Dictionary<string, int> dI = new Dictionary<string, int>()
            {
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
            cmd2.Parameters.AddWithValue("@Image", ImageBytes);
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
        }
        private void EditMilitary()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Update [Military] set _Group = @g,Category = @c,Staff = @Staff, _Rank = @r, Number = @Number, Suitability = @Suit, OfficePassport = @OfficePassport, OfficeReal = @OfficeReal where IID = @IID";
            Dictionary<string, string> ds = new Dictionary<string, string>()
            {
                {"@g",militaryData.Group},
                {"@c",militaryData.Category },
                {"@Staff",militaryData.Staff },
                {"@r",militaryData.Rank },
                {"@Number",militaryData.Number },
                {"@Suit",militaryData.Suitability },
                {"@OfficePassport",militaryData.OfficePassport },
                {"@OfficeReal",militaryData.OfficeReal },
                {"@IID",text_iid.Text }
            };
            foreach (var item in ds)
                cmd.Parameters.AddWithValue(item.Key, item.Value);

            cmd.ExecuteNonQuery();
            connection.Close();
        }
        private void EditFamily()
        {
            ClearTable(connection, "[Family]", iid);
            foreach (var item in FamilyList)
                AddFamilyMember(item);
        }
        private void EditDiploma()
        {
            ClearTable(connection, "[Diploma]", iid);
            foreach (var item in EducationList)
                AddDiplomaData(item);
        }
        private void EditProfession()
        {
            ClearTable(connection, "[Profession]", iid);
            foreach (var item in Professionlist)
                AddProfessionData(item);

        }
        private void EditAppointment()
        {
            ClearTable(connection, "[Appointment]", iid);
            foreach (var item in AppointmentList)
                AddApointmentData(item);
        }
    }
}
