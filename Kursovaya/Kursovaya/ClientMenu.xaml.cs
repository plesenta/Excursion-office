using Kursovaya.BuroDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для ClientMenu.xaml
    /// </summary>
    public partial class ClientMenu : Window
    {
        public string log;
        string idi;
        string id_tur;
        int cost;
        public ClientMenu(string log)
        {
            this.log = log;
            InitializeComponent();
            TourTableAdapter adapter1tur = new TourTableAdapter();
            BuroDataSet.TourDataTable table5 = new BuroDataSet.TourDataTable();
            adapter1tur.Fill(table5);
            tuur.ItemsSource = table5;

            string ConnectBD = "Data Source = LAPTOP-HV0RLJLE;Initial Catalog = Buro; Integrated Security = True;";
            SqlConnection conn = new SqlConnection(ConnectBD);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM [Client] WHERE [Login] = '" + log + "'", conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    idi = reader["ID_Client"].ToString();
                }
            }

            string ConnectBD1 = "Data Source = LAPTOP-HV0RLJLE;Initial Catalog = Buro; Integrated Security = True;";
            SqlConnection conn1 = new SqlConnection(ConnectBD1);
            conn1.Open();
            SqlCommand command1 = new SqlCommand("SELECT * FROM [Client] WHERE [Login] = '" + log + "'", conn1);
            using (SqlDataReader reader1 = command1.ExecuteReader())
            {
                while (reader1.Read())
                {
                    idi = reader1["ID_Client"].ToString();
                    fam.Text = reader1["Surname"].ToString();
                    imya.Text = reader1["Name"].ToString();
                    otchestvo.Text = reader1["Patronym"].ToString();
                    databirth.Text = reader1["Data_of_birth"].ToString();
                    adres.Text = reader1["Adress"].ToString();
                    seria.Text = reader1["Seria_pasporta"].ToString();
                    nomer.Text = reader1["Nomer_pasporta"].ToString();
                    telephon.Text = reader1["Telephon"].ToString();
                    pochta.Text = reader1["Email"].ToString();
                    password.Password = reader1["Password"].ToString();
                    login.Text = log;
                }
            }

            RequestTableAdapter adapter = new RequestTableAdapter();
            BuroDataSet.RequestDataTable table = new BuroDataSet.RequestDataTable();
            adapter.FillBy(table, fam.Text);
            request.ItemsSource = table;
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

        private void tuur_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (tuur.SelectedItem as DataRowView != null)
            {
                id_tur = (tuur.SelectedItem as DataRowView).Row.ItemArray[0].ToString();
                itog.Content = (tuur.SelectedItem as DataRowView).Row.ItemArray[2].ToString(); 
                cost = Convert.ToInt32((tuur.SelectedItem as DataRowView).Row.ItemArray[2].ToString());
               
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(kolvobilet.Text);
            a += 1;
            kolvobilet.Text = Convert.ToString(a);
            itog.Content = Convert.ToInt32(kolvobilet.Text) * cost;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (tuur.SelectedItem as DataRowView != null)
            {
                try
                {
                    if (data_departure.Text != "" && data_arrival.Text != "" && kolvobilet.Text != "")
                    {
                        new RequestTableAdapter().InsertQuery(Convert.ToInt32(idi), 1, 1, Convert.ToInt32(id_tur), Convert.ToString(DateTime.Now), data_departure.Text, data_arrival.Text, Convert.ToInt32(kolvobilet.Text), fio.Text, Convert.ToInt32(itog.Content));
                        RequestTableAdapter adapter = new RequestTableAdapter();
                        BuroDataSet.RequestDataTable table = new BuroDataSet.RequestDataTable();
                        adapter.Fill(table);
                        MessageBox.Show("Заказ был добавлен!");
                    }
                    else MessageBox.Show("Заполните данные!");
 
                }
                catch { }
            }
            else MessageBox.Show("Выберите тур!");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {


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
                   
                                    new ClientTableAdapter().UpdateQuery(fam.Text, imya.Text, otchestvo.Text, databirth.Text, adres.Text, seria.Text, nomer.Text, telephon.Text, pochta.Text, password.Password.ToString(), login.Text, Convert.ToInt32(idi));
                                    ClientTableAdapter adapter = new ClientTableAdapter();
                                    BuroDataSet.ClientDataTable table = new BuroDataSet.ClientDataTable();
                                    adapter.Fill(table);
                                    MessageBox.Show("Данные были изменены!'");


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

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            TourTableAdapter a = new TourTableAdapter();
            BuroDataSet.TourDataTable b = new BuroDataSet.TourDataTable();
            a.Fill(b);
            DataView dv = new DataView(b);
            dv.RowFilter = $@"[Наименование] LIKE '%{search.Text}%' or [Описание]  LIKE '%{search.Text}%' or [Длительность]  LIKE '%{search.Text}%' or [Место]  LIKE '%{search.Text}%' or CONVERT([Стоимость], System.String) LIKE '%{search.Text}%' or [Гид]  LIKE '%{search.Text}%' or [Транспорт]  LIKE '%{search.Text}%'";
            tuur.ItemsSource = dv.ToTable().DefaultView;
        }

        private void request_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (request.SelectedItem as DataRowView != null)
            {
                idi = (request.SelectedItem as DataRowView).Row.ItemArray[0].ToString();
            }
            else MessageBox.Show("Выберите заказ!");
          
        }

        string cl_id, st_id, em_id, dt_oform, tr_id, dt_dep, ph, opis, dur, itog_sym;
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
           
            if (request.SelectedItem as DataRowView != null)
            {
                idi = (request.SelectedItem as DataRowView).Row.ItemArray[0].ToString();

                if ((request.SelectedItem as DataRowView).Row.ItemArray[2].ToString() == "В обработке")
                {
                    string ConnectBD = "Data Source = LAPTOP-HV0RLJLE;Initial Catalog = Buro; Integrated Security = True;";
                    SqlConnection conn = new SqlConnection(ConnectBD);
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM [Request] WHERE [ID_Request] = '" + idi + "'", conn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            idi = reader["ID_Request"].ToString();
                            cl_id = reader["Client_ID"].ToString();
                            st_id = "3";
                            em_id = reader["Employee_ID"].ToString();
                            tr_id = reader["Tour_ID"].ToString();
                            dt_oform = reader["Data_oformleniya"].ToString();
                            dt_dep = reader["Data_departure"].ToString();
                            ph = reader["Data_arrival"].ToString();
                            opis = reader["Number_of_tickets"].ToString();
                            dur = reader["FIO_people"].ToString();
                            itog_sym = reader["Itog_symma"].ToString();
                        }
                    }
                    new RequestTableAdapter().UpdateQuery(Convert.ToInt32(cl_id), Convert.ToInt32(st_id), Convert.ToInt32(em_id), Convert.ToInt32(tr_id), dt_oform, dt_dep, ph, Convert.ToInt32(opis), dur, Convert.ToInt32(itog_sym), Convert.ToInt32(idi));
                    RequestTableAdapter adapter2 = new RequestTableAdapter();
                    BuroDataSet.RequestDataTable table2 = new BuroDataSet.RequestDataTable();
                    adapter2.FillBy(table2, fam.Text);
                    request.ItemsSource = table2;
                }
                else MessageBox.Show("Заказ уже подтвержден!");

            }        
            else MessageBox.Show("Выберите заказ!");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (request.SelectedItem as DataRowView != null)
            {
                idi = (request.SelectedItem as DataRowView).Row.ItemArray[0].ToString();
                if ((request.SelectedItem as DataRowView).Row.ItemArray[2].ToString() != "Оплачено" || (request.SelectedItem as DataRowView).Row.ItemArray[2].ToString() != "Выдача документов")
                {
                    new RequestTableAdapter().DeleteQuery(Convert.ToInt32(idi));
                    RequestTableAdapter adapter1 = new RequestTableAdapter();
                    BuroDataSet.RequestDataTable table1 = new BuroDataSet.RequestDataTable();
                    adapter1.FillBy(table1, fam.Text);
                    request.ItemsSource = table1;
                    MessageBox.Show("Заказ отменён!");
                }
                else MessageBox.Show("Заказ уже подтвержден, его нельзя удалить!");
            }
            else MessageBox.Show("Выберите заказ!");
        }
    }
}
