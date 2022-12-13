using Kursovaya.BuroDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

  
        private void PackIcon_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            mainWindow.Show();
            this.Hide();
        }

        private void PackIcon_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            
            Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //string str = passwdord.Password.ToString(); //это строка которую мы зашифруем
                //str = Encrypt(str, "qwerty");

                if (fam.Text.Trim() != "" && telephon.Text.Trim() != "" && seria.Text.Trim() != "" && nomer.Text.Trim() != "" && imya.Text.Trim() != "" && login.Text.Trim() != "" && otchestvo.Text.Trim() != "" && password.Password.ToString() != "" && adres.Text.Trim() != "" && databirth.Text.Trim() != "")
                {
                    if (Regex.IsMatch(pochta.Text, @"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$"))
                    {
                        if (Regex.IsMatch(password.Password.ToString(), @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{7,}$"))
                        {
                            if (Regex.IsMatch(login.Text, "^[a-zA-Z0-9]*$"))
                            {
                                if (Regex.IsMatch(fam.Text, @"^[а-яА-Я_]+$"))
                                {
                                    ClientTableAdapter adapter = new ClientTableAdapter();
                                    BuroDataSet.ClientDataTable table = new BuroDataSet.ClientDataTable();
                                    adapter.Fill(table);

                                    new ClientTableAdapter().InsertQuery(fam.Text, imya.Text, otchestvo.Text, databirth.Text, adres.Text, seria.Text, nomer.Text, telephon.Text, pochta.Text, password.Password.ToString(), login.Text);

                                    MessageBox.Show("Вы были успешно зарегистрированы в системе 'Экскурсионное бюро!'");

                                    MainWindow main = new MainWindow();
                                    main.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                                    main.Show();
                                    this.Close();

                                }
                                else MessageBox.Show("Фамилия должна состоять только из русских букв! Допускается символ: -");
                            }
                            else MessageBox.Show("Логин должен состоять только из английских букв и цифр!");
                        }
                        else MessageBox.Show("Пароль должен соответствовать следующим требованиям: минимум 7 символов, 1 прописная буква, минимум 1 цифра, по крайней мере один спец.символ!");
                    }
                    else MessageBox.Show("Введите корректную почту");
                }
                else MessageBox.Show("Заполните пожалуйста все поля!");


            }
            catch { }
        }

        private string GetRepeatKey(string s, int n)
        {
            var r = s;
            while (r.Length < n)
            {
                r += r;
            }

            return r.Substring(0, n);
        }
        //метод шифрования/дешифровки
        private string Cipher(string text, string secretKey)
        {
            var currentKey = GetRepeatKey(secretKey, text.Length);
            var res = string.Empty;
            for (var i = 0; i < text.Length; i++)
            {
                res += ((char)(text[i] ^ currentKey[i])).ToString();
            }

            return res;
        }

        //шифрование текста
        public string Encrypt(string plainText, string password)
            => Cipher(plainText, password);

    }
}
