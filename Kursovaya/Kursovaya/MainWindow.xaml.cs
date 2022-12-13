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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kursovaya
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text.Trim() != "" && password.Password.ToString() != "" && password2.Password.ToString() != "")
            {
                if (password.Password.ToString() == password2.Password.ToString())
                {
                    string passwdd = password.Password.ToString();
                    //passwdd = Encrypt(passwdd, "qwerty");

                    string ConnectBD = "Data Source = LAPTOP-HV0RLJLE;Initial Catalog = Buro; Integrated Security = True;";
                    SqlConnection conn = new SqlConnection(ConnectBD);
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM [Client] WHERE [Login] = '" + login.Text + "' AND [Password] = '" + passwdd + "'", conn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            conn.Close();
                            SqlConnection conn2 = new SqlConnection(ConnectBD);
                            conn2.Open();
                            SqlCommand command1 = new SqlCommand("SELECT * FROM [Employee] WHERE [Login] = '" + login.Text + "' AND [Password] = '" + passwdd + "'", conn2);
                            using (SqlDataReader reader1 = command1.ExecuteReader())
                            {
                                if (!reader1.HasRows)
                                {
                                    MessageBox.Show("Пользователь с таким логином и паролем не найден!. Удостоверьтесь в корректности введенных данных.", "Оповещение системы");
                                }
                                else
                                {
                                    while (reader1.Read())
                                    {
                                        if (reader1["Post"].ToString() == "Турагент")
                                        {
                                            MenuTuragent fm = new MenuTuragent(login.Text);
                                            fm.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                                            fm.Show();
                                            this.Hide();
                                        }
                                        if (reader1["Post"].ToString() == "Бухгалтер")
                                        {
                                            MenuBuhgalter fm = new MenuBuhgalter(login.Text);
                                            fm.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                                            fm.Show();
                                            this.Hide();
                                        }
                                        if (reader1["Post"].ToString() == "Администратор")
                                        {
                                            MenuAdministrator fm = new MenuAdministrator();
                                            fm.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                                            fm.Show();
                                            this.Hide();
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            while (reader.Read())
                            {                                                  
                                    ClientMenu fm = new ClientMenu(login.Text);
                                    fm.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                                    fm.Show();
                                    this.Hide();                           
                            }
                        }
                    }
                }
                else MessageBox.Show("Пароли не совпадают!");
              
            }
            else MessageBox.Show("Пожалуйста, заполните все поля!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            registration.Show();
            this.Hide();
        }
    }
}
