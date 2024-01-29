using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjektMuratColak
{
    internal class BankKontoMenu
    {
        private Kontoinhaber inhaber;

        public BankKontoMenu(Kontoinhaber inhaber)
        {
            this.inhaber = inhaber;
            controller();
        }
        public void controller()
        {
            if (inhaber.Count == 1) EingabeMenu();

            else if (inhaber.Count > 1) Kontobewegungen(); ;
        }
        public void EingabeMenu()
        {
            Console.Clear();


            Menu.VollstandigenAngaben(inhaber.Username);

            Console.Write("Bitte geben Sie Ihren Namen ein:"); string vorname = Console.ReadLine();
            inhaber.Vorname = vorname;

            Console.WriteLine("\nBitte geben Sie Ihren Nachnamen ein:"); string nachname = Console.ReadLine();
            inhaber.Nachname = nachname;

            Console.WriteLine("\nBitte E-Mail eingeben:"); string email = Console.ReadLine();
            inhaber.Email = email;

            Console.WriteLine("\nBitte Adresse eingeben:"); string adresse = Console.ReadLine();
            inhaber.Adres = adresse;

            Console.WriteLine("\nBitte geben Sie die Telefonnummer ein:"); string phone = Console.ReadLine();
            inhaber.Phone = phone;

            inhaber.Count++;

            Console.WriteLine("Ihr Konto abschließen...");
            Thread.Sleep(1000);

            Console.WriteLine("Ihr Konto wurde erstellt und Sie können nun Transaktionen vornehmen...");
            Thread.Sleep(1000);
            Kontobewegungen();



        }

        private void Kontobewegungen()
        {
            bool exit = false;
            while (!exit)
            {
                KontoBewegundmenu();

                string wahl = Console.ReadLine();
                if (wahl == "6")
                {
                    Console.Clear();
                    //inhaber = null;
                    exit = true;
                    HauptKlasse.menu();
                }
                else if (wahl == "4")
                {

                    while (true)
                    {

                        if (inhaber.Kontos.Count < 5)
                        {
                            Menu.Kontotype();
                            Menu.getMessageNeueKontoEröffnung();

                            string wahl3 = Console.ReadLine();
                            if (wahl3 != "x")
                            {

                                if (wahl3 == "1")
                                {
                                    erstelltKonto(1, "standart");
                                    break;
                                }
                                else if (wahl3 == "2")
                                {
                                    erstelltKonto(2, "öğreci");
                                    break;
                                }
                                else if (wahl3 == "3")
                                {
                                    erstelltKonto(3, "Ticari");
                                    break;
                                }
                            }
                            else break;
                        }
                        else
                        {
                            Menu.getMessageMAxKOnto();
                            break;
                        }

                    }
                    Console.Clear();

                }
                else if (wahl == "1")
                {
                    Menu.getMessageWechleKontoAnlegen();

                    string anlegenwahl = Console.ReadLine();
                    int contomenge = inhaber.Kontos.Count();
                    if (int.TryParse(anlegenwahl, out int wahlPrüfer) && wahlPrüfer <= contomenge)
                    {
                        Console.WriteLine(inhaber.Kontos[wahlPrüfer - 1].ToString());
                        if (anlegenwahl == "1") geldAnlegen(0);

                        else if (anlegenwahl == "2") geldAnlegen(1);
                        else if (anlegenwahl == "3") geldAnlegen(2);
                        else if (anlegenwahl == "4") geldAnlegen(3);
                        else if (anlegenwahl == "5") geldAnlegen(4);

                    }
                    else Menu.getMessageGibGültigKontoNummerEin();
                }
                else if (wahl == "2")
                {
                    Menu.getMessageWelcheKOntoAbheben();

                    string Abhebenwahl = Console.ReadLine();
                    int contomenge = inhaber.Kontos.Count();
                    int wahlPrüfer;
                    if (int.TryParse(Abhebenwahl, out wahlPrüfer) && wahlPrüfer <= contomenge)
                    {


                        Console.WriteLine(inhaber.Kontos[wahlPrüfer - 1].ToString());
                        if (Abhebenwahl == "1") geldAbheben(0);
                        else if (Abhebenwahl == "2") geldAbheben(1);
                        else if (Abhebenwahl == "3") geldAbheben(2);
                        else if (Abhebenwahl == "4") geldAbheben(3);
                        else if (Abhebenwahl == "5") geldAbheben(4);
                    }
                    else Menu.getMessageGibGültigKontoNummerEin();
                }
                else if (wahl == "3")
                {
                    Menu.getTransferMenu();

                    string wahl2 = Console.ReadLine();
                    if (wahl2 == "1")
                    {
                        Menu.getMessageVomWelchemKontoTransfer();

                        string abheben2 = Console.ReadLine();
                        if (int.TryParse(abheben2, out int index1))
                        {
                            if (index1 <= inhaber.Kontos.Count)
                            {
                                Menu.getMessageZuWelchemKontoTransfer();

                                string anlegen2 = Console.ReadLine();
                                if (int.TryParse(anlegen2, out int index2))
                                {
                                    Menu.getMessageMenge();

                                    string weisungzahl = Console.ReadLine();
                                    if (double.TryParse(weisungzahl, out double zahlung))
                                    {
                                        if (index2 <= inhaber.Kontos.Count)
                                        {
                                            UberweisungZwischenEigenenKonten(index1, index2, zahlung);
                                        }
                                        else Menu.getMessageEsgibtkeineSolcheKonto();
                                    }
                                    else Menu.getMessageUngültigeEingabe();
                                }
                                else Menu.getMessageUngültigeEingabe();
                            }
                            else Menu.getMessageUngültigeEingabe();
                        }
                        else Menu.getMessageUngültigeEingabe();

                    }
                    else if (wahl2 == "2")
                    {
                        Menu.getMessageVomWelchemKontoTransfer();
                        string abheben2 = Console.ReadLine();

                        if (int.TryParse(abheben2, out int index1) && index1 <= inhaber.Kontos.Count)
                        {
                            Menu.getMessageGibIban();
                            string iban = Console.ReadLine();

                            Kontoinhaber neuHaber = AlleListe.wemGehörtDieseIban(iban);
                            Console.WriteLine(neuHaber.Username);


                            if (neuHaber != null)
                            {
                                int index2 = AlleListe.getIbanIndex(neuHaber, iban);

                                Menu.getMessageMenge();
                                string weisungzahl = Console.ReadLine();
                                if (double.TryParse(weisungzahl, out double zahlung))
                                {
                                    KontoPrüferAbheben2(index1 - 1, zahlung, inhaber.IBAN1);
                                    KontoPrüferAnlegen2(neuHaber, index2, zahlung, iban);
                                }
                                else Menu.getMessageUngültigeEingabe();

                            }
                            else Menu.getMessageUngültigeEingabe();
                        }
                        else Menu.getMessageUngültigeEingabe();
                    }
                    else Menu.getMessageUngültigeEingabe();

                }
                else if (wahl == "5")
                {
                    Menu.LogDataMenu();
                    AlleListe.getLogData(inhaber.Log);
                    Console.ReadKey();
                }

            }

        }

        private void geldAnlegen(int index)
        {
            Menu.getMessageMenge();
            string zahl = Console.ReadLine();

            if (double.TryParse(zahl, out double z)) KontoPrüferAnlegen(index, z);
            else Menu.getMessageUngültigeEingabe();

        }
        private void geldAbheben(int index)
        {

            Menu.getMessageMenge();
            string zahl = Console.ReadLine();

            if (double.TryParse(zahl, out double z)) KontoPrüferAbheben(index, z);
            else Menu.getMessageUngültigeEingabe();

        }

        private void UberweisungZwischenEigenenKonten(int abhebenIndex, int AnlegenIndex, double zahl)
        {
            KontoPrüferAbheben(abhebenIndex - 1, zahl);
            KontoPrüferAnlegen(AnlegenIndex - 1, zahl);
        }
        private void KontoPrüferAbheben(int index, double zahl)
        {
            if (inhaber.Kontos[index] is StandartKonto) inhaber.Kontos[index].geldAbheben(zahl);
            else if (inhaber.Kontos[index] is StudentKonto) inhaber.Kontos[index].geldAbheben(zahl);
            else if (inhaber.Kontos[index] is GeschaftlischesKonto) inhaber.Kontos[index].geldAbheben(zahl);
            Console.WriteLine($"Hesabınızdan {zahl} cekildi");
            Menu.saveLogData(inhaber.Log, Menu.ParaCekmeKaydi(zahl));
            Thread.Sleep(1500);


        }
        private void KontoPrüferAbheben2(int index, double zahl, string iban)
        {
            if (inhaber.Kontos[index] is StandartKonto) ((StandartKonto)inhaber.Kontos[index]).geldAbheben(zahl);
            else if (inhaber.Kontos[index] is StudentKonto) ((StudentKonto)inhaber.Kontos[index]).geldAbheben(zahl);
            else if (inhaber.Kontos[index] is GeschaftlischesKonto) ((GeschaftlischesKonto)inhaber.Kontos[index]).geldAbheben(zahl);

            Menu.getMessageEsGibtAbheben(zahl);

            Menu.saveLogData(inhaber.Log, Menu.ParaHavaleÇıkışı(zahl, iban));

            Thread.Sleep(1500);
        }
        private void KontoPrüferAnlegen(int index, double zahl)
        {
            if (inhaber.Kontos[index] is StandartKonto) inhaber.Kontos[index].geldAnlegen(zahl);
            else if (inhaber.Kontos[index] is StudentKonto) inhaber.Kontos[index].geldAnlegen(zahl);
            else if (inhaber.Kontos[index] is GeschaftlischesKonto) inhaber.Kontos[index].geldAnlegen(zahl);

            Menu.getMessageEsGibtAnlegen(zahl);

            Menu.saveLogData(inhaber.Log, Menu.ParaYatirma(zahl));

            Thread.Sleep(1500);

        }
        private void KontoPrüferAnlegen2(Kontoinhaber inhaber, int index, double zahl, string iban)
        {
            if (inhaber.Kontos[index] is StandartKonto) inhaber.Kontos[index].geldAnlegen(zahl);
            else if (inhaber.Kontos[index] is StudentKonto) inhaber.Kontos[index].geldAnlegen(zahl);
            else if (inhaber.Kontos[index] is GeschaftlischesKonto) inhaber.Kontos[index].geldAnlegen(zahl);

            Menu.getMessageEsGibtAngeneTransfer(zahl);

            Menu.saveLogData(inhaber.Log, Menu.ParaHavaleGirişi(zahl, iban));

            Thread.Sleep(1500);
        }


        private void erstelltKonto(int Konto, string kontoType)
        {


            Menu.getMessageGibKOntoName();
            string kontoName = Console.ReadLine();
            if (Konto == 1) inhaber.addStandartKonto(kontoName);
            else if (Konto == 2) inhaber.addStudentKonto(kontoName);
            else if (Konto == 3) inhaber.addGeschaflischeKonto(kontoName);

            Console.WriteLine($"{kontoName} adlı {kontoType}  tipte hesabınız oluşturuldu");
            Menu.saveLogData(inhaber.Log, Menu.YeniHesapOlusturmaKaydi(kontoName, kontoType, inhaber.IBAN1));
        }

        private void KontoBewegundmenu()
        {
            Menu.KontoÜberschrift(inhaber);
            Console.WriteLine(inhaber.ToString());
            Menu.KontoButtons();
            inhaber.showAlleKonto();
        }
    }
}
