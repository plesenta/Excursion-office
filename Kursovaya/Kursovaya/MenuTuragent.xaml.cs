using Kursovaya.BuroDataSetTableAdapters;
using Microsoft.Win32;
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

namespace Kursovaya
{
    /// <summary>
    /// Логика взаимодействия для MenuTuragent.xaml
    /// </summary>
    public partial class MenuTuragent : Window
    {
        public string log;
        string idi;
        string post;
        public MenuTuragent(string log)
        {
            this.log = log;
            InitializeComponent();

            TransportTableAdapter adapter = new TransportTableAdapter();
            BuroDataSet.TransportDataTable table = new BuroDataSet.TransportDataTable();
            adapter.Fill(table);
            transport.ItemsSource = table;

            GuideTableAdapter adapter1 = new GuideTableAdapter();
            BuroDataSet.GuideDataTable table1 = new BuroDataSet.GuideDataTable();
            adapter1.Fill(table1);
            gid.ItemsSource = table1;

            AttractionTableAdapter adapter2 = new AttractionTableAdapter();
            BuroDataSet.AttractionDataTable table2 = new BuroDataSet.AttractionDataTable();
            adapter2.Fill(table2);
            dostoprimechatelnost.ItemsSource = table2;

            PlaceTableAdapter adapter3 = new PlaceTableAdapter();
            BuroDataSet.PlaceDataTable table3 = new BuroDataSet.PlaceDataTable();
            adapter3.Fill(table3);
            places.ItemsSource = table3;

            AttractionTableAdapter adapt = new AttractionTableAdapter();
            BuroDataSet.AttractionDataTable tabl = new BuroDataSet.AttractionDataTable();
            adapt.Fill(tabl);
            dostp.ItemsSource = tabl;
            dostp.DisplayMemberPath = "Наименование";
            dostp.SelectedValuePath = "№ Достопримечательности";

            RequestTableAdapter adapter4 = new RequestTableAdapter();
            BuroDataSet.RequestDataTable table4 = new BuroDataSet.RequestDataTable();
            adapter4.Fill(table4);
            zayavka.ItemsSource = table4;

            ClientTableAdapter adaptt = new ClientTableAdapter();
            BuroDataSet.ClientDataTable tabll = new BuroDataSet.ClientDataTable();
            adaptt.Fill(tabll);
            client.ItemsSource = tabll;
            client.DisplayMemberPath = "Фамилия";
            client.SelectedValuePath = "№ Клиента";

            StatusTableAdapter adapttt = new StatusTableAdapter();
            BuroDataSet.StatusDataTable tablll = new BuroDataSet.StatusDataTable();
            adapttt.Fill(tablll);
            status.ItemsSource = tablll;
            status.DisplayMemberPath = "Наименование статуса";
            status.SelectedValuePath = "№ Статуса";

            EmployeeTableAdapter adapterempl = new EmployeeTableAdapter();
            BuroDataSet.EmployeeDataTable tableempl = new BuroDataSet.EmployeeDataTable();
            adapterempl.Fill(tableempl);
            sotr.ItemsSource = tableempl;
            sotr.DisplayMemberPath = "Фамилия";
            sotr.SelectedValuePath = "№ Сотрудника";

            TourTableAdapter adaptertur = new TourTableAdapter();
            BuroDataSet.TourDataTable tabletur = new BuroDataSet.TourDataTable();
            adaptertur.Fill(tabletur);
            tur.ItemsSource = tabletur;
            tur.DisplayMemberPath = "Наименование";
            tur.SelectedValuePath = "№ Тура";

            TourTableAdapter adapter1tur = new TourTableAdapter();
            BuroDataSet.TourDataTable table5 = new BuroDataSet.TourDataTable();
            adapter1tur.Fill(table5);
            tuur.ItemsSource = table5;

            PlaceTableAdapter placeadapt = new PlaceTableAdapter();
            BuroDataSet.PlaceDataTable placetable = new BuroDataSet.PlaceDataTable();
            placeadapt.Fill(placetable);
            mesto.ItemsSource = placetable;
            mesto.DisplayMemberPath = "Название достопримечательности";
            mesto.SelectedValuePath = "№ Места";

            TransportTableAdapter transportadapt = new TransportTableAdapter();
            BuroDataSet.TransportDataTable transporttable = new BuroDataSet.TransportDataTable();
            transportadapt.Fill(transporttable);
            trnspt.ItemsSource = transporttable;
            trnspt.DisplayMemberPath = "Наименование";
            trnspt.SelectedValuePath = "№ Транспорта";

            GuideTableAdapter didadapt = new GuideTableAdapter();
            BuroDataSet.GuideDataTable guidetable = new BuroDataSet.GuideDataTable();
            didadapt.Fill(guidetable);
            gid_id.ItemsSource = guidetable;
            gid_id.DisplayMemberPath = "Фамилия";
            gid_id.SelectedValuePath = "№ Гида";

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

        private void transport_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (transport.SelectedItem as DataRowView != null)
            {
                idi = (transport.SelectedItem as DataRowView).Row.ItemArray[0].ToString();
                naim.Text = (transport.SelectedItem as DataRowView).Row.ItemArray[1].ToString();
                nomer.Text = (transport.SelectedItem as DataRowView).Row.ItemArray[2].ToString();
                timer.Text = (transport.SelectedItem as DataRowView).Row.ItemArray[3].ToString();
              

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                    new TransportTableAdapter().InsertQuery(naim.Text, Convert.ToInt32(nomer.Text), timer.Text);
                    TransportTableAdapter adapter = new TransportTableAdapter();
                    BuroDataSet.TransportDataTable table = new BuroDataSet.TransportDataTable();
                    adapter.Fill(table);
                    transport.ItemsSource = table;
                    MessageBox.Show("Данные были успешно добавлены!");
     
            }
            catch {  }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (transport.SelectedItem as DataRowView != null)
                {
                    new TransportTableAdapter().UpdateQuery(naim.Text, Convert.ToInt32(nomer.Text), timer.Text, Convert.ToInt32(idi));
                    TransportTableAdapter adapter = new TransportTableAdapter();
                    BuroDataSet.TransportDataTable table = new BuroDataSet.TransportDataTable();
                    adapter.Fill(table);
                    transport.ItemsSource = table;
                }
                else MessageBox.Show("Выберите запись!");
            }
            catch {  } 
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (transport.SelectedItem as DataRowView != null)
                {
                    new TransportTableAdapter().DeleteQuery(Convert.ToInt32(idi));
                    TransportTableAdapter adapter = new TransportTableAdapter();
                    BuroDataSet.TransportDataTable table = new BuroDataSet.TransportDataTable();
                    adapter.Fill(table);
                    transport.ItemsSource = table;
                    MessageBox.Show("Запись была удалена!");
                }
                else MessageBox.Show("Выберите запись!");
            }
            catch { MessageBox.Show("Данную запись удалить нельзя, так как она используется!"); }
        }

        private void gid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (gid.SelectedItem as DataRowView != null)
            {
                idi = (gid.SelectedItem as DataRowView).Row.ItemArray[0].ToString();
                fam.Text = (gid.SelectedItem as DataRowView).Row.ItemArray[1].ToString();
                imya.Text = (gid.SelectedItem as DataRowView).Row.ItemArray[2].ToString();
                otche.Text = (gid.SelectedItem as DataRowView).Row.ItemArray[3].ToString();
                lang.Text = (gid.SelectedItem as DataRowView).Row.ItemArray[4].ToString();
                city.Text = (gid.SelectedItem as DataRowView).Row.ItemArray[5].ToString();

            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {

                    new GuideTableAdapter().InsertQuery(fam.Text, imya.Text, otche.Text, lang.Text, city.Text);
                    GuideTableAdapter adapter1 = new GuideTableAdapter();
                    BuroDataSet.GuideDataTable table1 = new BuroDataSet.GuideDataTable();
                    adapter1.Fill(table1);
                    gid.ItemsSource = table1;
                    MessageBox.Show("Данные были успешно добавлены!");

            }
            catch { }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                if (gid.SelectedItem as DataRowView != null)
                {
                    new GuideTableAdapter().UpdateQuery(fam.Text, imya.Text, otche.Text, lang.Text, city.Text, Convert.ToInt32(idi));
                    GuideTableAdapter adapter1 = new GuideTableAdapter();
                    BuroDataSet.GuideDataTable table1 = new BuroDataSet.GuideDataTable();
                    adapter1.Fill(table1);
                    gid.ItemsSource = table1;
                }
                else MessageBox.Show("Выберите запись!");
            }
            catch { }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                if (gid.SelectedItem as DataRowView != null)
                {
                    new GuideTableAdapter().DeleteQuery(Convert.ToInt32(idi));
                    GuideTableAdapter adapter1 = new GuideTableAdapter();
                    BuroDataSet.GuideDataTable table1 = new BuroDataSet.GuideDataTable();
                    adapter1.Fill(table1);
                    gid.ItemsSource = table1;
                    MessageBox.Show("Запись была удалена!");
                }
                else MessageBox.Show("Выберите запись!");
            }
            catch { MessageBox.Show("Данную запись удалить нельзя, так как она используется!"); }
        }

        private void dostoprimechatelnost_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (dostoprimechatelnost.SelectedItem as DataRowView != null)
            {
                idi = (dostoprimechatelnost.SelectedItem as DataRowView).Row.ItemArray[0].ToString();
                naimenovanie.Text = (dostoprimechatelnost.SelectedItem as DataRowView).Row.ItemArray[1].ToString();
                yearbuild.Text = (dostoprimechatelnost.SelectedItem as DataRowView).Row.ItemArray[2].ToString();
                description.Text = (dostoprimechatelnost.SelectedItem as DataRowView).Row.ItemArray[3].ToString();
 
            }
          
        }

        private void add_dostoprimechatelnost(object sender, RoutedEventArgs e)
        {
            try
            {

                    new AttractionTableAdapter().InsertQuery(naimenovanie.Text, yearbuild.Text, description.Text);
                    AttractionTableAdapter adapter2 = new AttractionTableAdapter();
                    BuroDataSet.AttractionDataTable table2 = new BuroDataSet.AttractionDataTable();
                    adapter2.Fill(table2);
                    dostoprimechatelnost.ItemsSource = table2;
                    MessageBox.Show("Данные были успешно добавлены!");

            }
            catch { }
        }

        private void readd_dostoprimechatelnost(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dostoprimechatelnost.SelectedItem as DataRowView != null)
                {
                    new AttractionTableAdapter().UpdateQuery(naimenovanie.Text, yearbuild.Text, description.Text, Convert.ToInt32(idi));
                    AttractionTableAdapter adapter2 = new AttractionTableAdapter();
                    BuroDataSet.AttractionDataTable table2 = new BuroDataSet.AttractionDataTable();
                    adapter2.Fill(table2);
                    dostoprimechatelnost.ItemsSource = table2;
                }
                else MessageBox.Show("Выберите запись!");
            }
            catch { }
        }

        private void remove_dostoprimechatelnost(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dostoprimechatelnost.SelectedItem as DataRowView != null)
                {
                    new AttractionTableAdapter().DeleteQuery(Convert.ToInt32(idi));
                    AttractionTableAdapter adapter1 = new AttractionTableAdapter();
                    BuroDataSet.AttractionDataTable table1 = new BuroDataSet.AttractionDataTable();
                    adapter1.Fill(table1);
                    dostoprimechatelnost.ItemsSource = table1;
                    MessageBox.Show("Запись была удалена!");
                }
                else MessageBox.Show("Выберите запись!");
            }
            catch { MessageBox.Show("Данную запись удалить нельзя, так как она используется!"); }
        }

        private void places_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (places.SelectedItem as DataRowView != null)
            {
                idi = (places.SelectedItem as DataRowView).Row.ItemArray[0].ToString();
                mestopoloshzh.Text = (places.SelectedItem as DataRowView).Row.ItemArray[1].ToString();
                klimat.Text = (places.SelectedItem as DataRowView).Row.ItemArray[2].ToString();
                yslovie.Text = (places.SelectedItem as DataRowView).Row.ItemArray[3].ToString();
                dostp.Text = (places.SelectedItem as DataRowView).Row.ItemArray[4].ToString();
             
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            try
            {

                new PlaceTableAdapter().InsertQuery(mestopoloshzh.Text, klimat.Text, yslovie.Text, Convert.ToInt32(dostp.SelectedValue));
                PlaceTableAdapter adapter2 = new PlaceTableAdapter();
                BuroDataSet.PlaceDataTable table2 = new BuroDataSet.PlaceDataTable();
                adapter2.Fill(table2);
                places.ItemsSource = table2;
                MessageBox.Show("Данные были успешно добавлены!");

            }
            catch { }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            try
            {
                if (places.SelectedItem as DataRowView != null)
                {
                    new PlaceTableAdapter().UpdateQuery(mestopoloshzh.Text, klimat.Text, yslovie.Text, Convert.ToInt32(dostp.SelectedValue), Convert.ToInt32(idi));
                    PlaceTableAdapter adapter2 = new PlaceTableAdapter();
                    BuroDataSet.PlaceDataTable table2 = new BuroDataSet.PlaceDataTable();
                    adapter2.Fill(table2);
                    places.ItemsSource = table2;
                }
                else MessageBox.Show("Выберите запись!");
            }
            catch { }

        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            try
            {
                if (places.SelectedItem as DataRowView != null)
                {
                    new PlaceTableAdapter().DeleteQuery(Convert.ToInt32(idi));
                    PlaceTableAdapter adapter1 = new PlaceTableAdapter();
                    BuroDataSet.PlaceDataTable table1 = new BuroDataSet.PlaceDataTable();
                    adapter1.Fill(table1);
                    places.ItemsSource = table1;
                    MessageBox.Show("Запись была удалена!");
                }
                else MessageBox.Show("Выберите запись!");
            }
            catch { MessageBox.Show("Данную запись удалить нельзя, так как она используется!"); }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            try
            {
                if (zayavka.SelectedItem as DataRowView != null)
                {
                    new RequestTableAdapter().UpdateQuery(Convert.ToInt32(client.SelectedValue), Convert.ToInt32(status.SelectedValue), Convert.ToInt32(sotr.SelectedValue), Convert.ToInt32(tur.SelectedValue), oform.Text, otpr.Text, pribit.Text, Convert.ToInt32(kolvo.Text), fio.Text, Convert.ToInt32(itog.Text), Convert.ToInt32(idi));
                    RequestTableAdapter adapter2 = new RequestTableAdapter();
                    BuroDataSet.RequestDataTable table2 = new BuroDataSet.RequestDataTable();
                    adapter2.Fill(table2);
                    zayavka.ItemsSource = table2;
                }
                else MessageBox.Show("Выберите запись!");
            }
            catch { }
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            try
            {
                if (zayavka.SelectedItem as DataRowView != null)
                {
                    new RequestTableAdapter().DeleteQuery(Convert.ToInt32(idi));
                    RequestTableAdapter adapter1 = new RequestTableAdapter();
                    BuroDataSet.RequestDataTable table1 = new BuroDataSet.RequestDataTable();
                    adapter1.Fill(table1);
                    zayavka.ItemsSource = table1;
                    MessageBox.Show("Запись была удалена!");
                }
                else MessageBox.Show("Выберите запись!");
            }
            catch { MessageBox.Show("Данную запись удалить нельзя, так как она используется!"); }
        }
         
        private void zayavka_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (zayavka.SelectedItem as DataRowView != null)
            {
                idi = (zayavka.SelectedItem as DataRowView).Row.ItemArray[0].ToString();
                client.Text = (zayavka.SelectedItem as DataRowView).Row.ItemArray[1].ToString();
                status.Text = (zayavka.SelectedItem as DataRowView).Row.ItemArray[2].ToString();
                sotr.Text = (zayavka.SelectedItem as DataRowView).Row.ItemArray[3].ToString();
                tur.Text = (zayavka.SelectedItem as DataRowView).Row.ItemArray[4].ToString();
                oform.Text = (zayavka.SelectedItem as DataRowView).Row.ItemArray[5].ToString();
                otpr.Text = (zayavka.SelectedItem as DataRowView).Row.ItemArray[6].ToString();
                pribit.Text = (zayavka.SelectedItem as DataRowView).Row.ItemArray[7].ToString();
                kolvo.Text = (zayavka.SelectedItem as DataRowView).Row.ItemArray[8].ToString();
                fio.Text = (zayavka.SelectedItem as DataRowView).Row.ItemArray[9].ToString();
                itog.Text = (zayavka.SelectedItem as DataRowView).Row.ItemArray[10].ToString();
            }
        }
        Uri uriImageSource;
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg;*.*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                pich.Text = openFileDialog.FileName; 
            uriImageSource = new Uri(pich.Text, UriKind.RelativeOrAbsolute);
            pp.Source = new BitmapImage(uriImageSource);
        }

        private void tuur_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (tuur.SelectedItem as DataRowView != null)
            {
                idi = (tuur.SelectedItem as DataRowView).Row.ItemArray[0].ToString();
                naimen.Text = (tuur.SelectedItem as DataRowView).Row.ItemArray[1].ToString();
                cost.Text = (tuur.SelectedItem as DataRowView).Row.ItemArray[2].ToString();
                kol.Text = (tuur.SelectedItem as DataRowView).Row.ItemArray[3].ToString();
                mesto.Text = (tuur.SelectedItem as DataRowView).Row.ItemArray[4].ToString();
                trnspt.Text = (tuur.SelectedItem as DataRowView).Row.ItemArray[5].ToString();
                gid_id.Text = (tuur.SelectedItem as DataRowView).Row.ItemArray[6].ToString();
                pich.Text = (tuur.SelectedItem as DataRowView).Row.ItemArray[7].ToString();
                opis.Text = (tuur.SelectedItem as DataRowView).Row.ItemArray[8].ToString();
                dur.Text = (tuur.SelectedItem as DataRowView).Row.ItemArray[9].ToString();
                pp.Source = new BitmapImage(new Uri(pich.Text, UriKind.Relative)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };

            }
             

        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            try
            {

                new TourTableAdapter().InsertQuery(naimen.Text, Convert.ToInt32(cost.Text), Convert.ToInt32(kol.Text), Convert.ToInt32(mesto.SelectedValue), Convert.ToInt32(trnspt.SelectedValue), Convert.ToInt32(gid_id.SelectedValue), pich.Text, opis.Text, dur.Text);
                TourTableAdapter adapter = new TourTableAdapter();
                BuroDataSet.TourDataTable table = new BuroDataSet.TourDataTable();
                adapter.Fill(table);
                tuur.ItemsSource = table;
                MessageBox.Show("Данные были успешно добавлены!");

            }
            catch { }
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            try
            {

                new TourTableAdapter().UpdateQuery(naimen.Text, Convert.ToInt32(cost.Text), Convert.ToInt32(kol.Text), Convert.ToInt32(mesto.SelectedValue), Convert.ToInt32(trnspt.SelectedValue), Convert.ToInt32(gid_id.SelectedValue), pich.Text, opis.Text, dur.Text, Convert.ToInt32(idi));
                TourTableAdapter adapter = new TourTableAdapter();
                BuroDataSet.TourDataTable table = new BuroDataSet.TourDataTable();
                adapter.Fill(table);
                tuur.ItemsSource = table;
                MessageBox.Show("Данные были успешно добавлены!");

            }
            catch { }
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tuur.SelectedItem as DataRowView != null)
                {
                    new TourTableAdapter().DeleteQuery(Convert.ToInt32(idi));
                    TourTableAdapter adapter = new TourTableAdapter();
                    BuroDataSet.TourDataTable table = new BuroDataSet.TourDataTable();
                    adapter.Fill(table);
                    tuur.ItemsSource = table;
                    MessageBox.Show("Данные были удалены!");
                }
                else MessageBox.Show("Выберите запись!");

            }
            catch { MessageBox.Show("Данную запись удалить нельзя, так как она используется!"); }
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
