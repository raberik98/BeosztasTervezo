using BeosztasTervezo.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BeosztasTervezo.MVVM.View
{
    /// <summary>
    /// Interaction logic for ResztvevokView.xaml
    /// </summary>
    public partial class ResztvevokView : UserControl
    {
        ObservableCollection<ResztvevoClass> NevLista = new ObservableCollection<ResztvevoClass>();
        public ResztvevokView()
        {
            InitializeComponent();
            string[] beolvasottAdatok = File.ReadAllLines("Resztvevok.txt");
            for (int i = 0; i < beolvasottAdatok.Length; i++)
            {
                NevLista.Add(new ResztvevoClass(beolvasottAdatok[i]));
            }
            DG_resztvevok.ItemsSource = NevLista;
        }

        //Mentés
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int number;
            bool csaladIdMegfelel = int.TryParse(TB_Csalad.Text, out number);
            if (csaladIdMegfelel)
            {
                NevLista[DG_resztvevok.SelectedIndex].Nev = TB_Nev.Text;
                NevLista[DG_resztvevok.SelectedIndex].Nem = CB_Nem.SelectedIndex + 1;
                NevLista[DG_resztvevok.SelectedIndex].Prio = CB_Prio.SelectedIndex + 1;
                NevLista[DG_resztvevok.SelectedIndex].CsaladId = int.Parse(TB_Csalad.Text);

                NevLista[DG_resztvevok.SelectedIndex].sz8 = CB_SZ8.IsChecked.Value;
                NevLista[DG_resztvevok.SelectedIndex].sz9 = CB_SZ9.IsChecked.Value;
                NevLista[DG_resztvevok.SelectedIndex].sz10 = CB_SZ10.IsChecked.Value;
                NevLista[DG_resztvevok.SelectedIndex].sz11 = CB_SZ11.IsChecked.Value;
                NevLista[DG_resztvevok.SelectedIndex].sz14 = CB_SZ14.IsChecked.Value;
                NevLista[DG_resztvevok.SelectedIndex].sz15 = CB_SZ15.IsChecked.Value;
                NevLista[DG_resztvevok.SelectedIndex].sz16 = CB_SZ16.IsChecked.Value;
                NevLista[DG_resztvevok.SelectedIndex].sz17 = CB_SZ17.IsChecked.Value;

                NevLista[DG_resztvevok.SelectedIndex].p8 = CB_P8.IsChecked.Value;
                NevLista[DG_resztvevok.SelectedIndex].p9 = CB_P9.IsChecked.Value;
                NevLista[DG_resztvevok.SelectedIndex].p10 = CB_P10.IsChecked.Value;
                NevLista[DG_resztvevok.SelectedIndex].p11 = CB_P11.IsChecked.Value;
                NevLista[DG_resztvevok.SelectedIndex].p14 = CB_P14.IsChecked.Value;
                NevLista[DG_resztvevok.SelectedIndex].p15 = CB_P15.IsChecked.Value;
                NevLista[DG_resztvevok.SelectedIndex].p16 = CB_P16.IsChecked.Value;
                NevLista[DG_resztvevok.SelectedIndex].p17 = CB_P17.IsChecked.Value;

                NevLista[DG_resztvevok.SelectedIndex].szo8 = CB_SZO8.IsChecked.Value;
                NevLista[DG_resztvevok.SelectedIndex].szo9 = CB_SZO9.IsChecked.Value;
                NevLista[DG_resztvevok.SelectedIndex].szo10 = CB_SZO10.IsChecked.Value;
                NevLista[DG_resztvevok.SelectedIndex].szo11 = CB_SZO11.IsChecked.Value;

                ResztvevoClass.MentesFajlba(NevLista);
                MessageBoxResult result = MessageBox.Show("A módosítás sikeresen megtörtént!");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Hiba történt, ellenőrizze hogy a CsaládId mezőhöz helyes adatot adott meg.");
            }
            
        }

        private void DG_resztvevok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BTN_Mentes.IsEnabled = true;

            TB_Nev.Text = NevLista[DG_resztvevok.SelectedIndex].Nev;
            CB_Nem.SelectedIndex = NevLista[DG_resztvevok.SelectedIndex].Nem-1;
            CB_Prio.SelectedIndex = NevLista[DG_resztvevok.SelectedIndex].Prio-1;
            TB_Csalad.Text = NevLista[DG_resztvevok.SelectedIndex].CsaladId.ToString();

            CB_SZ8.IsChecked = NevLista[DG_resztvevok.SelectedIndex].sz8;
            CB_SZ9.IsChecked = NevLista[DG_resztvevok.SelectedIndex].sz9;
            CB_SZ10.IsChecked = NevLista[DG_resztvevok.SelectedIndex].sz10;
            CB_SZ11.IsChecked = NevLista[DG_resztvevok.SelectedIndex].sz11;
            CB_SZ14.IsChecked = NevLista[DG_resztvevok.SelectedIndex].sz14;
            CB_SZ15.IsChecked = NevLista[DG_resztvevok.SelectedIndex].sz15;
            CB_SZ16.IsChecked = NevLista[DG_resztvevok.SelectedIndex].sz16;
            CB_SZ17.IsChecked = NevLista[DG_resztvevok.SelectedIndex].sz17;

            CB_P8.IsChecked = NevLista[DG_resztvevok.SelectedIndex].p8;
            CB_P9.IsChecked = NevLista[DG_resztvevok.SelectedIndex].p9;
            CB_P10.IsChecked = NevLista[DG_resztvevok.SelectedIndex].p10;
            CB_P11.IsChecked = NevLista[DG_resztvevok.SelectedIndex].p11;
            CB_P14.IsChecked = NevLista[DG_resztvevok.SelectedIndex].p14;
            CB_P15.IsChecked = NevLista[DG_resztvevok.SelectedIndex].p15;
            CB_P16.IsChecked = NevLista[DG_resztvevok.SelectedIndex].p16;
            CB_P17.IsChecked = NevLista[DG_resztvevok.SelectedIndex].p17;

            CB_SZO8.IsChecked = NevLista[DG_resztvevok.SelectedIndex].szo8;
            CB_SZO9.IsChecked = NevLista[DG_resztvevok.SelectedIndex].szo9;
            CB_SZO10.IsChecked = NevLista[DG_resztvevok.SelectedIndex].szo10;
            CB_SZO11.IsChecked = NevLista[DG_resztvevok.SelectedIndex].szo11;
        }

        //Tervező
        private void BTN_Tervezés_Click(object sender, RoutedEventArgs e)
        {
            //string[] beolvasottAdatok = File.ReadAllLines("Resztvevok.txt");
            //for (int i = 0; i < beolvasottAdatok.Length; i++)
            //{
            //    NevLista.Add(new ResztvevoClass(beolvasottAdatok[i]));
            //}

            //A napok indexei 5-től kezdődnek ami a Szerda 8-9-ig terjedő időpont.
            ObservableCollection<ResztvevoClass> MutableNevLista = new ObservableCollection<ResztvevoClass>();
            for (int i = 0; i < NevLista.Count; i++)
            {
                MutableNevLista.Add(NevLista[i]);
            }
            
            List<int> segedLista = new List<int>();
            List<int> banList = new List<int>();
            using (StreamWriter sw = new StreamWriter("Beosztas.txt"))
            {
                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 6, banList);
                sw.WriteLine("SZERDA CBA");
                sw.WriteLine("9:00-10:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
                vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 7, banList);
                sw.WriteLine("10:00-11:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
                vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);

                

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 8, banList);
                sw.WriteLine("11:00-12:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
               vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);
                 
                

                sw.WriteLine("");

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 9, banList);
                sw.WriteLine("14:00-15:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
               vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);
                 
                

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 10, banList);
                sw.WriteLine("15:00-16:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
               vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);
                 
                 ;

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 11, banList);
                sw.WriteLine("16:00-17:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
               vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);
                 
                

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 12, banList);
                sw.WriteLine("17:00-18:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
               vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);
                 
                

                sw.WriteLine("");

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 5, banList);
                sw.WriteLine("SZERDA VÁSÁRCSARNOK");
                sw.WriteLine("8:00-9:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
               vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);
                 
                

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 6, banList);
                sw.WriteLine("9:00-10:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
               vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);
                 
                

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 7, banList);
                sw.WriteLine("10:00-11:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
               vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);


                //A szerdai időpontok 12-ig vannak, utánna jön a péntek 8:00-tól.
                banList.Clear();
               

                sw.WriteLine("");

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 14, banList);
                sw.WriteLine("PÉNTEK CBA");
                sw.WriteLine("9:00-10:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
               vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);
                 
                

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 15, banList);
                sw.WriteLine("10:00-11:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
               vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);
                 
                

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 16, banList);
                sw.WriteLine("11:00-12:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
               vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);
                 
                

                sw.WriteLine("");

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 17, banList);
                sw.WriteLine("14:00-15:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
               vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);
                 
                

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 18, banList);
                sw.WriteLine("15:00-16:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
               vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);
                 
                

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 19, banList);
                sw.WriteLine("16:00-17:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
               vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);
                 
                

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 20, banList);
                sw.WriteLine("17:00-18:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
               vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);
                 
                

                sw.WriteLine("");

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 13, banList);
                sw.WriteLine("PÉNTEK VÁSÁRCSARNOK");
                sw.WriteLine("8:00-9:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
               vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);
                 
                

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 14, banList);
                sw.WriteLine("9:00-10:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
               vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);
                 
                

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 15, banList);
                sw.WriteLine("10:00-11:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
               vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);


                //A pénteki időpontok 20-ig vannak, utánna jön a szombat 8:00-tól.
                banList.Clear();


                sw.WriteLine("");

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 21, banList);
                sw.WriteLine("SZOMBAT CBA");
                sw.WriteLine("8:00-9:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
               vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);
                 
                

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 22, banList);
                sw.WriteLine("9:00-10:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
               vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);
                 
                

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 23, banList);
                sw.WriteLine("10:00-11:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
               vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);
                 
                

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 24, banList);
                sw.WriteLine("11:00-12:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
               vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);
                 
                

                sw.WriteLine("");

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 21, banList);
                sw.WriteLine("SZOMBAT VÁSÁRCSARNOK");
                sw.WriteLine("8:00-9:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
               vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);
                 
                

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 22, banList);
                sw.WriteLine("9:00-10:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
               vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);
                 
                

                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 23, banList);
                sw.WriteLine("10:00-11:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
                vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);



                segedLista = ResztvevoClass.IdopontVizsgalat(MutableNevLista, 24, banList);
                sw.WriteLine("11:00-12:00 --> {0} - {1}", MutableNevLista[segedLista[0]].Nev, MutableNevLista[segedLista[1]].Nev);
                vizsgalatUtanniLepesek(MutableNevLista, segedLista, banList);



                MessageBoxResult result = MessageBox.Show("A tervezés sikeresen befelyeződött. Biztonság esetére ellenőrizze hogy a beosztás megfelelő.");
            }
        }
        public static void vizsgalatUtanniLepesek(ObservableCollection<ResztvevoClass>MutableNevLista, List<int> segedLista, List<int> banList)
        {
            MutableNevLista[segedLista[0]].Prio = 3;
            MutableNevLista[segedLista[1]].Prio = 3;
            banList.Add(segedLista[0]);
            banList.Add(segedLista[1]);
            segedLista.Clear();
            //return banList;
            //if (MutableNevLista[segedLista[0]].Prio == 1)
            //{
            //    MutableNevLista[segedLista[0]].Prio = 2;
            //    MutableNevLista[segedLista[0]].alkalmak = 1;
            //}
            //else if (MutableNevLista[segedLista[0]].Prio == 2 && MutableNevLista[segedLista[0]].alkalmak == 0)
            //{
            //    MutableNevLista[segedLista[0]].alkalmak = 1;
            //}
            //else if (MutableNevLista[segedLista[0]].Prio == 2 && MutableNevLista[segedLista[0]].alkalmak == 1)
            //{
            //    MutableNevLista[segedLista[0]].alkalmak = 2;
            //}
            //else
            //{
            //    MutableNevLista[segedLista[0]].Prio = 3;
            //}
            ////---------------------------------------------
            //if (MutableNevLista[segedLista[1]].Prio == 1)
            //{
            //    MutableNevLista[segedLista[1]].Prio = 2;
            //    MutableNevLista[segedLista[1]].alkalmak = 1;
            //}
            //else if (MutableNevLista[segedLista[1]].Prio == 2 && MutableNevLista[segedLista[1]].alkalmak == 0)
            //{
            //    MutableNevLista[segedLista[1]].alkalmak = 1;
            //}
            //else if (MutableNevLista[segedLista[1]].Prio == 2 && MutableNevLista[segedLista[1]].alkalmak == 1)
            //{
            //    MutableNevLista[segedLista[1]].alkalmak = 2;
            //}
            //else
            //{
            //    MutableNevLista[segedLista[1]].Prio = 3;
            //}
            //MutableNevLista.RemoveAt(segedLista[0]);
            //MutableNevLista.RemoveAt(segedLista[1]);
            //segedLista.Clear();
            //return MutableNevLista;
        }
    }
}
