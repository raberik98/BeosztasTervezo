using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeosztasTervezo.MVVM.Model
{
    public class ResztvevoClass
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public int Nem { get; set; }
        public int CsaladId { get; set; }
        public int Prio { get; set; }
        public bool sz8 { get; set; }
        public bool sz9 { get; set; }
        public bool sz10 { get; set; }
        public bool sz11 { get; set; }
        public bool sz14 { get; set; }
        public bool sz15 { get; set; }
        public bool sz16 { get; set; }
        public bool sz17 { get; set; }
        public bool p8 { get; set; }
        public bool p9 { get; set; }
        public bool p10 { get; set; }
        public bool p11 { get; set; }
        public bool p14 { get; set; }
        public bool p15 { get; set; }
        public bool p16 { get; set; }
        public bool p17 { get; set; }
        public bool szo8 { get; set; }
        public bool szo9 { get; set; }
        public bool szo10 { get; set; }
        public bool szo11 { get; set; }
        public int alkalmak { get; set; }
        public bool csakCsaladdal { get; set; }
        public bool aktív { get; set; }
        public DateTime resztvetelDatum { get; set; }

        public ResztvevoClass() { }

        public ResztvevoClass(string sor)
        {
            string[] adatok = sor.Split(';');
            this.Id = int.Parse(adatok[0]);
            this.Nev = adatok[1];
            this.Nem = int.Parse(adatok[2]);
            this.CsaladId = int.Parse(adatok[3]);
            this.Prio = int.Parse(adatok[4]);
            this.sz8 = bool.Parse(adatok[5]);
            this.sz9 = bool.Parse(adatok[6]);
            this.sz10 = bool.Parse(adatok[7]);
            this.sz11 = bool.Parse(adatok[8]);
            this.sz14 = bool.Parse(adatok[9]);
            this.sz15 = bool.Parse(adatok[10]);
            this.sz16 = bool.Parse(adatok[11]);
            this.sz17 = bool.Parse(adatok[12]);
            this.p8 = bool.Parse(adatok[13]);
            this.p9 = bool.Parse(adatok[14]);
            this.p10 = bool.Parse(adatok[15]);
            this.p11 = bool.Parse(adatok[16]);
            this.p14 = bool.Parse(adatok[17]);
            this.p15 = bool.Parse(adatok[18]);
            this.p16 = bool.Parse(adatok[19]);
            this.p17 = bool.Parse(adatok[20]);
            this.szo8 = bool.Parse(adatok[21]);
            this.szo9 = bool.Parse(adatok[22]);
            this.szo10 = bool.Parse(adatok[23]);
            this.szo11 = bool.Parse(adatok[24]);
            this.alkalmak = 0;
            this.csakCsaladdal = bool.Parse(adatok[26]);
            this.aktív = bool.Parse(adatok[27]);
            this.resztvetelDatum = DateTime.Parse(adatok[28]);
        }

        public static void MentesFajlba(ObservableCollection<ResztvevoClass> NevLista)
        {
            List<string> segedStringLista = ResztvevoClass.ConvertObservableCollectionToStringArray(NevLista);
            File.WriteAllLines("Resztvevok.txt", segedStringLista);
        }

        public static List<string> ConvertObservableCollectionToStringArray(ObservableCollection<ResztvevoClass> NevLista)
        {
            List<string> segedStringLista = new List<string>();
            for (int i = 0; i < NevLista.Count; i++)
            {
                segedStringLista.Add(String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};{16};{17};{18};{19};{20};{21};{22};{23};{24};{25};{26};{27};{28}",
                    NevLista[i].Id,
                    NevLista[i].Nev,
                    NevLista[i].Nem,
                    NevLista[i].CsaladId,
                    NevLista[i].Prio,
                    NevLista[i].sz8,
                    NevLista[i].sz9,
                    NevLista[i].sz10,
                    NevLista[i].sz11,
                    NevLista[i].sz14,
                    NevLista[i].sz15,
                    NevLista[i].sz16,
                    NevLista[i].sz17,
                    NevLista[i].p8,
                    NevLista[i].p9,
                    NevLista[i].p10,
                    NevLista[i].p11,
                    NevLista[i].p14,
                    NevLista[i].p15,
                    NevLista[i].p16,
                    NevLista[i].p17,
                    NevLista[i].szo8,
                    NevLista[i].szo9,
                    NevLista[i].szo10,
                    NevLista[i].szo11,
                    NevLista[i].alkalmak,
                    NevLista[i].csakCsaladdal,
                    NevLista[i].aktív,
                    NevLista[i].resztvetelDatum
                ));
            }
            return segedStringLista;
        }

        public static List<int> IdopontVizsgalat(ObservableCollection<ResztvevoClass> NevLista, int IdopontIndex, List<int>banList)
        {

            List<string> segedLista = ResztvevoClass.ConvertObservableCollectionToStringArray(NevLista);
            List<int> talalatok = new List<int>();
            List<int> megfeleloPartnerek = new List<int>();
            Random r = new Random();
            int elsoTalalatIndex;
            int masodikTalalatIndex;
            List<int> Vegeredmeny = new List<int>();

            //Találatok lista feltöltése azoknak az indexével akiknek jó az adott időpont 
            for (int i = 0; i < segedLista.Count; i++)
            {
                string[] adatok = segedLista[i].Split(';');
                if (bool.Parse(adatok[IdopontIndex]) == true)
                {
                    if (adatok[27] == "True")
                    {
                            talalatok.Add(int.Parse(adatok[0]));
                    }
                }
            }


            //Az első résztvevő keresése prioritás szerint
           
                elsoTalalatIndex = talalatok[r.Next(0,talalatok.Count - 1)];
                for (int i = 0; i < talalatok.Count; i++)
                {
                    if (NevLista[talalatok[i]].resztvetelDatum < NevLista[elsoTalalatIndex].resztvetelDatum)
                    {
                        elsoTalalatIndex = talalatok[i];
                    }
                }


            //Ha az első résztvevő csak családtaggal szereten menni akkor megpróbál egy családtagot keresni neki partnerként.
            if (NevLista[elsoTalalatIndex].csakCsaladdal == true)
            {
                for (int i = 0; i < talalatok.Count; i++)
                {
                    if (NevLista[talalatok[i]].CsaladId == NevLista[elsoTalalatIndex].CsaladId)
                    {
                        megfeleloPartnerek.Add(talalatok[i]);
                    }
                }
            }
            else
            {
                //A második résztvevő lehetséges társainak a keresése


                for (int i = 0; i < talalatok.Count - 1; i++)
                {
                    if (NevLista[talalatok[i]].csakCsaladdal == true && NevLista[talalatok[i]].CsaladId == NevLista[elsoTalalatIndex].CsaladId)
                    {
                        megfeleloPartnerek.Add(talalatok[i]);
                    }
                    else
                    {
                        if (NevLista[elsoTalalatIndex].CsaladId != 0)
                        {
                            if (NevLista[elsoTalalatIndex].Nem == NevLista[talalatok[i]].Nem || NevLista[elsoTalalatIndex].CsaladId == NevLista[talalatok[i]].CsaladId)
                            {
                                if (NevLista[elsoTalalatIndex].Id == NevLista[talalatok[i]].Id)
                                {

                                }
                                else
                                {
                                    megfeleloPartnerek.Add(talalatok[i]);
                                }
                            }
                        }
                        else
                        {
                            if (NevLista[elsoTalalatIndex].Nem == NevLista[talalatok[i]].Nem)
                            {
                                if (NevLista[elsoTalalatIndex].Id == NevLista[talalatok[i]].Id)
                                {

                                }
                                else
                                {
                                    megfeleloPartnerek.Add(talalatok[i]);
                                }
                            }
                        }
                    }

                }
            }
                

                

            if (megfeleloPartnerek.Count != 1)
            {
                //if (megfeleloPartnerek.Count == 1)
                //{
                //    if (NevLista[megfeleloPartnerek[0]].csakCsaladdal == true)
                //    {
                //        if (NevLista[megfeleloPartnerek[0]].CsaladId == NevLista[elsoTalalatIndex].CsaladId)
                //        {
                //            masodikTalalatIndex = megfeleloPartnerek[0];
                //        }
                //        else
                //        {
                //            masodikTalalatIndex = elsoTalalatIndex;
                //        }
                //    }
                //    else
                //    {
                //        masodikTalalatIndex = megfeleloPartnerek[0];
                //    }
                //}
                //else
                //{
                    masodikTalalatIndex = megfeleloPartnerek[r.Next(0, megfeleloPartnerek.Count - 1)];
                    for (int i = 0; i < megfeleloPartnerek.Count; i++)
                    {
                        if (NevLista[megfeleloPartnerek[i]].resztvetelDatum < NevLista[masodikTalalatIndex].resztvetelDatum)
                        {
                            if (NevLista[megfeleloPartnerek[i]].csakCsaladdal == true)
                            {
                                if (NevLista[megfeleloPartnerek[i]].CsaladId == NevLista[elsoTalalatIndex].CsaladId)
                                {
                                    if (megfeleloPartnerek[i] != elsoTalalatIndex)
                                    {
                                        masodikTalalatIndex = megfeleloPartnerek[i];
                                    }
                                }
                                
                            }
                            else
                            {
                                if (megfeleloPartnerek[i] != elsoTalalatIndex)
                                {
                                    masodikTalalatIndex = megfeleloPartnerek[i];
                                }
                            }
                        }
                    }
                //}
            }
            else
            {
                masodikTalalatIndex = elsoTalalatIndex;
            }

            Vegeredmeny.Add(elsoTalalatIndex);
            Vegeredmeny.Add(masodikTalalatIndex);

            return Vegeredmeny;
        }
    }
}
