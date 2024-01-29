using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjektMuratColak
{
    internal static class HauptKlasse
    {
        private static Kontoinhaber einhaber;
        private static BankKontoMenu Schirm;
        public static void menu()
        {


            if (AlleListe.KontoInhaberList == null)
            {
                AlleListe.machBeispielList();
                Menu.getBankLogo();
                Console.ReadKey();
                Menu.Erläuterung();
                Console.ReadKey();
            }

            bool exit1 = false;
            do
            {

                Console.Clear();
                Menu.mainButtons();

                string wahl = Console.ReadLine();
                if (wahl != "3")
                {
                    if (wahl == "1") wahl1();

                    else if (wahl == "2") wahl2();

                    else if (wahl == "4")
                    {

                        AlleListe.alleUserNameListAnzeigen();
                        AlleListe.alleIbanListAnzeigen();
                        Console.ReadKey();
                    }
                    else Menu.getMessageWarnung12oder3();
                }
                else exit1 = true;
            } while (!exit1);
            Environment.Exit(0);
        }
        public static void wahl1()
        {
            bool exit1 = false;
            do
            {
                Menu.Anmeldung();
                Console.WriteLine("Benutzer name::");
                string eingabeUsername = Console.ReadLine().ToLower();
                if (eingabeUsername == "3") break;

                if (eingabeUsername == null || eingabeUsername.Length! < 5)
                {
                    Menu.getMessageNULL5Buchstaben();
                }

                else
                {
                    if (!AlleListe.IstUserNameInDerListe(eingabeUsername))// 
                    {
                        bool exit = false;
                        while (true)
                        {
                            Menu.Anmeldung();
                            Console.WriteLine("Benutzer name:");
                            Console.WriteLine(eingabeUsername);
                            Console.WriteLine("Password:");
                            string eingabePassword = Console.ReadLine().ToLower();

                            if (eingabePassword != "3")
                            {
                                if (eingabePassword == "" || eingabePassword.Length < 6)//
                                {
                                    Menu.getMessagePasswordBuchstabenUndDigit();
                                }
                                else
                                {
                                    if (IstPasswordPass(eingabePassword))
                                    {
                                        List<string> user = new List<string>() { eingabeUsername, eingabePassword };
                                        AlleListe.addUserNamePasswordList(user);
                                        AlleListe.addUserKontoinhaberList(new Kontoinhaber(eingabeUsername));

                                        Menu.getMessageAnmeldungErfolgt();
                                        Menu.getMessageNeuKontoınhaberErstellt();

                                        exit = true;
                                        exit1 = true;

                                    }
                                    else
                                    {
                                        Menu.getMessagePasswordBuchstabenUndDigit();

                                    }


                                }
                            }
                            else
                            {

                                break;
                            }
                        }
                        break;
                    }
                    else Menu.getMessageEsGibtGleicheUsername();
                }
            } while (true);

        }


        public static void wahl2()
        {
            do
            {
                Menu.Register1();
                Console.WriteLine("Benutzer name::");
                string eingabeUsername = Console.ReadLine().ToLower();

                if (eingabeUsername == "3") break;

                if (eingabeUsername != null || eingabeUsername.Length < 5) // eger kullanici adi bos degilse sifre isteniyor
                {
                    Console.WriteLine("Password:");
                    string eingabePassword = Console.ReadLine().ToLower();

                    if (eingabePassword != null) // eger sifre bos degilse 
                    {
                        if (AlleListe.GibtEsSolcheUser(eingabeUsername, eingabePassword))// ve eger listede bu bilgilerde bi hesap sahibi varsa
                        {
                            Console.WriteLine("Willkommen " + eingabeUsername);// kullanıcı bilgileri getiriliyor

                            einhaber = AlleListe.getKontoinhaber(eingabeUsername);
                            Schirm = new BankKontoMenu(einhaber);
                        }
                        else Menu.getMessageProbierenWieder();
                    }
                    else Menu.getMessageNULLVerboten();
                }
                else Menu.getMessageNULL5Buchstaben();
            } while (true);
        }
        public static bool IstPasswordPass(string password)
        {
            char[] passwordChar = password.ToCharArray();
            int digitCount = 0, letterCount = 0;

            for (int i = 0; i < passwordChar.Length; i++)
            {
                if (Char.IsDigit(passwordChar[i])) digitCount++;
                if (Char.IsLetter(passwordChar[i])) letterCount++;

            }

            if (digitCount > 0 && letterCount > 0) return true;
            else return false;
        }


    }
}
