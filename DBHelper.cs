using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Human_Resources_Department
{
    public static class DBHelper
    {
        public static int GetLastIdFromTable(SqlConnection connection, string tableName)
        {
            int newId = 0;
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = $"SELECT * FROM {tableName} WHERE ID = (SELECT MAX(ID) FROM{tableName})";

            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
                newId = (int)(sqlDataReader["ID"]) + 1;
            sqlDataReader.Close();
            connection.Close();
            return newId;
        }
        public static void LoadTalbe(SqlConnection connection, string tableName, DataGrid gridToFill)
        {

            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from " + tableName;
            cmd.Connection = connection;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable data = new DataTable(tableName);
            dataAdapter.Fill(data);
            gridToFill.ItemsSource = data.DefaultView;
            connection.Close();
        }
        public static bool CheckIsNumeric(string text, string error)
        {
            //int res = 0;
            //if (int.TryParse(text, out res))
            //{
            //    if (res != 0)
            //    {
            //        return true;
            //    }
            //}
            //MessageBox.Show(error, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            //return false;
            return true;
        }
        public static void FillCombo(ComboBox box, string[] data)
        {
            box.SelectedIndex = 0;
            foreach (var item in data)
                box.Items.Add(item);
        }

        public static bool Check(TextBox textBox, string error)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show(error, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public static bool Check(DatePicker datePicker, string error)
        {
            if (string.IsNullOrWhiteSpace(datePicker.SelectedDate.ToString()))
            {
                MessageBox.Show(error, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public static string Normalize(string str)
        {
            var a = str.Last(x => x != ' ');
            var b = str.LastIndexOf(a);
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i <= b; ++i)
            {
                sb.Append(str[i]);
            }
            return sb.ToString();
        }
    }
}
