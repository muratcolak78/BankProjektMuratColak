using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjektMuratColak
{
    
        static class AlleListe
        {
            private static string iban = "12345";
            private static int ibanNummer = 0;
            private static List<List<string>> userNamePassworList;
            private static List<Kontoinhaber> kontoInhaberList;

            private static Dictionary<string, Kontoinhaber> ibanList;
            private static int UserIbanIndex;
            private static int kontoIbanIndex;
            public static List<List<string>> UserNamePassworList { get => userNamePassworList; }
            public static List<Kontoinhaber> KontoInhaberList { get => kontoInhaberList; }
            public static int UserIbanIndex1 { get => UserIbanIndex; set => UserIbanIndex = value; }
            public static int KontoIbanIndex { get => kontoIbanIndex; set => kontoIbanIndex = value; }
            internal static Dictionary<string, Kontoinhaber> IbanList { get => ibanList; set => ibanList = value; }
            public static string Iban { get => iban; set => iban = value; }
            public static int IbanNummer { get => ibanNummer; set => ibanNummer = value; }

            public static void machBeispielList()
            {
                ibanList = new Dictionary<string, Kontoinhaber>();

                kontoInhaberList = new List<Kontoinhaber>();
                kontoInhaberList.Add(new Kontoinhaber("murat"));
                kontoInhaberList.Add(new Kontoinhaber("fabian"));
                kontoInhaberList.Add(new Kontoinhaber("nadine"));
                kontoInhaberList.Add(new Kontoinhaber("patric"));
                kontoInhaberList.Add(new Kontoinhaber("marian"));
                kontoInhaberList.Add(new Kontoinhaber("1"));
                kontoInhaberList[5].Count = 2;

                userNamePassworList = new List<List<string>>();
                userNamePassworList.Add(new List<string>() { "murat", "12345a" });
                userNamePassworList.Add(new List<string>() { "fabian", "12345a" });
                userNamePassworList.Add(new List<string>() { "nadine", "12345a" });
                userNamePassworList.Add(new List<string>() { "patric", "12345a" });
                userNamePassworList.Add(new List<string>() { "marian", "12345a" });
                userNamePassworList.Add(new List<string>() { "1", "1" });

            }

            public static void addUserNamePasswordList(List<string> usernamepasword)
            {

                userNamePassworList.Add(usernamepasword);
            }
            public static void addUserKontoinhaberList(Kontoinhaber einhaber)
            {
                kontoInhaberList.Add(einhaber);


            }
            public static void addIBANList(string iban, Kontoinhaber inhaber)
            {
                ibanList[iban] = inhaber;
            }
            public static bool IstUserNameInDerListe(string username)
            {
                int count = 0;
                for (int i = 0; i < userNamePassworList.Count; i++)
                {
                    if (userNamePassworList[i][0] == username) count++;
                    if (count > 0) break;

                }
                if (count > 0) return true;
                else return false;
            }
            public static bool GibtEsSolcheUser(string Username, string Password)
            {
                List<string> user = new List<string>() { Username, Password };

                int count = 0;
                for (int i = 0; i < userNamePassworList.Count; i++)
                {
                    if (userNamePassworList[i][0] == user[0] && userNamePassworList[i][1] == user[1]) count++;
                    if (count > 0) break;
                }

                if (count > 0) return true;
                else return false;

            }
            public static Kontoinhaber getKontoinhaber(string username)
            {
                int count = 0;
                for (int i = 0; i < KontoInhaberList.Count; i++)
                {
                    if (KontoInhaberList[i].Username == username)
                    {
                        return KontoInhaberList[i];
                    }
                }
                return null;
            }
            public static void alleUserNameListAnzeigen()
            {
                Menu.machRot("Benutzername und password");
                foreach (List<string> i in userNamePassworList)
                {
                    Console.WriteLine(i[0] + " - " + i[1]);
                }
            }
            public static Kontoinhaber wemGehörtDieseIban(string iban)
            {

                foreach (var deger in IbanList)
                {
                    if (deger.Key == iban)
                    {
                        return deger.Value;

                    }

                }
                return null;

            }
            public static void alleIbanListAnzeigen()
            {
                Console.WriteLine("\niban list numbber " + ibanList.Count);

                foreach (var deger in IbanList)
                {
                    Console.WriteLine(deger.Key + " - " + deger.Value.Username);
                }
            }
            public static Kontoinhaber WennEsSocheIbanGibtGetInhaber(string Iban)
            {

                foreach (var deger in IbanList.Values)
                {
                    if (deger.IBAN1 == Iban)
                    {
                        Console.WriteLine(deger.IBAN1 + " esleşir  " + Iban);
                        Console.WriteLine(deger.Username);
                        return deger;
                    }

                }
                return null;

            }
            public static int getIbanIndex(Kontoinhaber inhaber, string iban)
            {
                int index = 0;
                for (int i = 0; i < inhaber.Kontos.Count; i++)
                {
                    if (inhaber.Kontos[i] is StandartKonto)
                    {
                        if (((StandartKonto)inhaber.Kontos[i]).IBAN1 == iban) index = i; break;
                    }
                    else if (inhaber.Kontos[i] is StudentKonto)
                    {
                        if (((StudentKonto)inhaber.Kontos[i]).IBAN1 == iban) index = i; break;
                    }
                    else if (inhaber.Kontos[i] is GeschaftlischesKonto)
                    {
                        if (((GeschaftlischesKonto)inhaber.Kontos[i]).IBAN1 == iban) index = i; break;
                    }
                }
                return index;
            }
            public static string IBANGenerator()
            {
                int x = ibanNummer++;


                if (ibanNummer < 10) return iban + "0" + x;

                return iban + x;
            }
            public static void getLogData(List<string> logList)
            {
                int count = 1;
                foreach (string s in logList)
                {
                    Console.WriteLine(count + ". " + s);
                    count++;
                }



            }

        }
    }

