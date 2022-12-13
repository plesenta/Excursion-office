using Kursovaya.BuroDataSetTableAdapters;
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

namespace Kursovaya
{
    /// <summary>
    /// Логика взаимодействия для MenuBuhgalter.xaml
    /// </summary>
    /// 

    public partial class MenuBuhgalter : Window
    {
        public string log;
        string idi;
        string post;
        public MenuBuhgalter(string log)
        {
            this.log = log;
            InitializeComponent();

            string ConnectBD = "Data Source = LAPTOP-HV0RLJLE;Initial Catalog = Buro; Integrated Security = True;";
            SqlConnection conn = new SqlConnection(ConnectBD);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM [Employee] WHERE [Login] = '" + log + "'", conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    idi = reader["ID_Employee"].ToString();
                    fam_sotr.Text = reader["Surname"].ToString();
                    im_sotr.Text = reader["Name"].ToString();
                    otch_sotr.Text = reader["Patronym"].ToString();
                    date_sotr.Text = reader["Date_of_birth"].ToString();
                    post = reader["Post"].ToString();
                    passwd_sotr.Password = reader["Password"].ToString();
                    mail_sotr.Text = reader["Email"].ToString();
                    tel_sotr.Text = reader["Telephon"].ToString();
                    log_sotr.Text = log;
                }
            }

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
        private void PackIcon_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            mainWindow.Show();
            this.Hide();
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            try
            {

                new EmployeeTableAdapter().UpdateQuery(fam_sotr.Text, im_sotr.Text, otch_sotr.Text, date_sotr.Text, post, log_sotr.Text, passwd_sotr.Password, mail_sotr.Text, tel_sotr.Text, Convert.ToInt32(idi));
                MessageBox.Show("Данные были изменены!");

            }
            catch { }
        }
    }
}
