using BeosztasTervezo.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.IO;

namespace BeosztasTervezo.MVVM.View
{
    /// <summary>
    /// Interaction logic for UjresztvevoView.xaml
    /// </summary>
    public partial class UjresztvevoView : UserControl
    {
        ObservableCollection<ResztvevoClass> NevLista = new ObservableCollection<ResztvevoClass>();
        public UjresztvevoView()
        {
            InitializeComponent();
            string[] beolvasottAdatok = File.ReadAllLines("Resztvevok.txt");
            for (int i = 0; i < beolvasottAdatok.Length; i++)
            {
                NevLista.Add(new ResztvevoClass(beolvasottAdatok[i]));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NevLista.Add(new ResztvevoClass(String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};{16};{17};{18};{19};{20};{21};{22};{23};{24};{25};{26};{27};{28}",
                NevLista.Count,
                TB_Nev.Text,
                CB_Nem.SelectedIndex + 1,
                int.Parse(TB_Csalad.Text),
                2,
                CB_SZ8.IsChecked,
                CB_SZ9.IsChecked,
                CB_SZ10.IsChecked,
                CB_SZ11.IsChecked,
                CB_SZ14.IsChecked,
                CB_SZ15.IsChecked,
                CB_SZ16.IsChecked,
                CB_SZ17.IsChecked,
                CB_P8.IsChecked,
                CB_P9.IsChecked,
                CB_P10.IsChecked,
                CB_P11.IsChecked,
                CB_P14.IsChecked,
                CB_P15.IsChecked,
                CB_P16.IsChecked,
                CB_P17.IsChecked,
                CB_SZO8.IsChecked,
                CB_SZO9.IsChecked,
                CB_SZO10.IsChecked,
                CB_SZO11.IsChecked,
                0,
                CB_csakCsaladdal.IsChecked,
                true,
                DateTime.Now
                )));

                ResztvevoClass.MentesFajlba(NevLista);
                MessageBoxResult result = MessageBox.Show("Új résztvevő hozzáadása megtörtént!");

                TB_Nev.Text = "";
                CB_Nem.SelectedIndex = 0;
                TB_Csalad.Text = "";
                //CB_Prio.SelectedIndex = 0;
                CB_SZ8.IsChecked = false;
                CB_SZ9.IsChecked = false;
                CB_SZ10.IsChecked = false;
                CB_SZ11.IsChecked = false;
                CB_SZ14.IsChecked = false;
                CB_SZ15.IsChecked = false;
                CB_SZ16.IsChecked = false;
                CB_SZ17.IsChecked = false;
                CB_P8.IsChecked = false;
                CB_P9.IsChecked = false;
                CB_P10.IsChecked = false;
                CB_P11.IsChecked = false;
                CB_P14.IsChecked = false;
                CB_P15.IsChecked = false;
                CB_P16.IsChecked = false;
                CB_P17.IsChecked = false;
                CB_SZO8.IsChecked = false;
                CB_SZO9.IsChecked = false;
                CB_SZO10.IsChecked = false;
                CB_SZO11.IsChecked = false;
                CB_csakCsaladdal.IsChecked = false;
            }
            catch (Exception)
            {
                MessageBoxResult result = MessageBox.Show("Váratlan hiba történt, győződjön meg róla hogy helyes adatokat adott meg és hogy minden mezőt kitöltött!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CB_SZ8.IsChecked = true;
            CB_SZ9.IsChecked = true;
            CB_SZ10.IsChecked = true;
            CB_SZ11.IsChecked = true;
            CB_SZ14.IsChecked = true;
            CB_SZ15.IsChecked = true;
            CB_SZ16.IsChecked = true;
            CB_SZ17.IsChecked = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CB_P8.IsChecked = true;
            CB_P9.IsChecked = true;
            CB_P10.IsChecked = true;
            CB_P11.IsChecked = true;
            CB_P14.IsChecked = true;
            CB_P15.IsChecked = true;
            CB_P16.IsChecked = true;
            CB_P17.IsChecked = true;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CB_SZO8.IsChecked = true;
            CB_SZO9.IsChecked = true;
            CB_SZO10.IsChecked = true;
            CB_SZO11.IsChecked = true;
        }
    }
}
