using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjektMuratColak
{
    static class Menu
    {
        private static string[] Logo;
        private static string logo;

        public static void logoBank()
        {
            Logo = new string[11];

            string a1 = "█████████████████████████████████████████████\n"; Logo[0] = a1;
            string a2 = "██╔════════════════════════════════════════██╗\n"; Logo[1] = a2;
            string a3 = "██║  ███████╗  ███████╗ ██╗   ██╗ ██╗ ███╗ ██║\n"; Logo[2] = a3;
            string a4 = "██║  ██╔══██║  ██╔══██║ ███╗  ██║ ██║██╔═╝ ██║\n"; Logo[3] = a4;
            string b1 = "██║  ███████║  ███████║ ██╔██╗██║ ████╔╝   ██║\n"; Logo[4] = b1;
            string b2 = "██║  ██╔══██║  ██╔══██║ ██║ ████║ ██║██╗   ██║\n"; Logo[5] = b2;
            string b3 = "██║  ███████║  ██║  ██║ ██║   ██║ ██║ ███╗ ██║\n"; Logo[6] = b3;
            string b4 = "██║    ╚════╝   ╚╝   ╚╝  ╚╝    ╚╝  ╚╝  ╚═╝ ██║\n"; Logo[7] = b4;
            string c1 = "█████████████████████████████████████████████║\n"; Logo[8] = c1;
            string c2 = "  ╚══════════════════════════════════════════╝\n"; Logo[9] = c2;
            string c3 = "Willkommen bei unserer Bank......."; Logo[10] = c3;


        }
        public static void Erläuterung()
        {
            machRot("\n\n\tErläuterung");
            machGrün("\t->In diesem Projekt werden Bankgeschäfte programmiert");
            machGrün("\t->Der Benutzer muss einen Benutzernamen mit mindestens 5 Buchstaben eingeben");
            machGrün("\t->Das Benutzerpasswort muss mindestens 6 Zeichen lang sein und mindestens \n" +
                "\t  einen Buchstaben und mindestens 1 Zahl enthalten.");
            machGrün("\tEs wurden bereits 6 feste Benutzer zum Programm hinzugefügt. Die Informationen lauten wie folgt:");
            string users = "\t murat 12345a\n" +
                          "\t fabian 12345a\n" +
                          "\t nadine 12345a\n" +
                          "\t patric 12345a\n" +
                          "\t marian 12345a\n" +
                          "\t    1      1\n";
            Console.WriteLine(users);
            machGrün("\t->Die Registrierungs- und Anmeldeseiten für das Programm sind unterschiedlich.");
            machGrün("\t->Der Benutzer muss beim ersten Login einige zusätzliche Informationen eingeben,");
            machGrün("         \tdamit mit diesen Informationen ein Standard-Bankkonto erstellt werden kann.");
            machGrün("\t->Der Benutzer kann Geld auf sein Konto einzahlen, Geld abheben, ");
            machGrün("         \tGeldtransfers zwischen seinen eigenen Konten durchführen und");
            machGrün("         \tsogar Geld auf andere Konten senden und empfangen.");
            machGrün("\t->Aufzeichnungen über die Transaktionen des Benutzers werden aufgezeichnet, ");
            machGrün("         \tsodass sie jederzeit überprüft werden können.");
            machRot("\t->Tipp: Drücken Sie im Hauptmenü die 4, um Benutzernamen und Passwörter anzuzeigen");
            machRot("\t->Tipp: Sie können das Konto direkt als Benutzername\n" +
                                        "\t1 und Passwort 1 eingeben und die Funktionen steuern");
            machGrün("\t->Das Programm könnte noch weiter entwickelt werden, aber leider reichte die Zeit nicht aus..");
            Console.WriteLine("\tEs wurde von Murat Colak entwickelt.");
            Console.WriteLine("\t25.01.2024");


        }
        public static string getBankLogo()
        {
            if (Logo == null)
            {
                logoBank();
                for (int i = 0; i < Logo.Length; i++)
                {
                    char[] reih = Logo[i].ToCharArray();

                    for (int j = 0; j < reih.Length; j++)
                    {
                        logo += reih[j];
                        machGrün2(reih[j]);


                    }
                }
            }
            return logo;
        }
        public static void mainButtons()
        {

            machBlaue($"═══════════════════════════════════════════");
            machGrün($"╔════════════╗ ╔════════════╗ ╔═══════════╗");
            machGrün($"║ 1.Anmelden ║ ║ 2.Register ║ ║  3. Exit  ║");
            machGrün($"╚════════════╝ ╚════════════╝ ╚═══════════╝");
            machBlaue($"═══════════════════════════════════════════");
        }
        public static void Anmeldung()
        {
            Console.Clear();
            machRot("                      Für exit 3");
            machRot($"╔════════════════════════════════════════════════════════╗");
            machRot($"║                     Anmeldung                          ║");
            machRot($"╚════════════════════════════════════════════════════════╝");

        }
        public static void Register1()
        {
            Console.Clear();
            machRot("                        Für exit 3");
            machBlaue($"╔════════════════════════════════════════════════════════╗");
            machBlaue($"║                      Register                          ║");
            machBlaue($"╚════════════════════════════════════════════════════════╝");

        }
        public static void VollstandigenAngaben(string username)
        {
            machGrün($"╔═════════════════════════════════════════════════════════════════════════════════════════╗");
            machGrün($"║                          Vervollständigen Sie Ihre Angaben                              ║");
            machGrün($"╚═════════════════════════════════════════════════════════════════════════════════════════╝");
            machGrün($"    hallo {username} ");

            machRot("\nWir benötigen einige Informationen, um Ihr Konto abzuschließen");
        }




        public static void KontoÜberschrift(Kontoinhaber inhaber)
        {
            Console.Clear();
            machGrün($"╔══════════════════════════════════════════════════════════════════════════════════════════════╗");
            machGrün($"║                                         Kontoangaben                                         ║");
            machGrün($"╚══════════════════════════════════════════════════════════════════════════════════════════════╝");
            machGrün($"       hallo  {inhaber.Vorname} {inhaber.Nachname} \n");

        }
        public static void LogDataMenu()
        {
            machGrün($"╔══════════════════════════════════════════════════════════════════════════════════════════════╗");
            machGrün($"║                                         LOG DATA                                             ║\n\n");

        }


        public static void KontoButtons()
        {

            machBlaue($"╔═════════════════╗ ╔═════════════════╗ ╔═══════════════╗ ╔═════════════════╗ ╔═══════╗ ╔════════╗");
            machBlaue($"║1.Geld Einzahlen ║ ║ 2.Geld abheben  ║ ║3.Geldtransfer ║ ║4.Kontoeröffnung ║ ║ 5.Log ║ ║ 6.Exit ║");
            machBlaue($"╚═════════════════╝ ╚═════════════════╝ ╚═══════════════╝ ╚═════════════════╝ ╚═══════╝ ╚════════╝");
            machBlaue($"═════════════════════════════════════════════════════════════════════════════════════════════════");

        }
        public static void Kontotype()
        {
            string kontoType = "   Kontotype        MaxLimit    Überweisungskosten   Monatliche Zinssätze   KreditKarte      Monatliche Kontoführung\n\n" +
                                "1. Standardkonto    10000             5 Eur                 0.3  %              nein                  7 Eur\n" +
                                "2. Studentenkonto   2000              0 Eur                 0.1  %              nein                  0 Eur\n" +
                                "3. Geschäftskonto   100000            3 Eur                 0.5  %              ja                    5 Eur \n";

            machGrün(kontoType);
        }

        //warnungsmessage
        public static void getMessageNULL5Buchstaben()
        {
            machRot("Dieses Feld kann nicht leer gelassen werden, es muss mindestens 5 Zeichen enthalten\n");
            Thread.Sleep(1500);
        }
        public static void getMessageNULLVerboten()
        {
            machRot("Dieses Feld kann nicht leer gelassen werden\n");
            Thread.Sleep(1000);
        }
        public static void getMessagePasswordBuchstabenUndDigit()
        {
            machRot("\nDas Passwort muss mindestens 6 Zeichen enthalten, mindestens einen Buchstaben und mindestens eine Zahl (Exit 3)\n");
            Thread.Sleep(2000);

        }
        public static void getMessageAnmeldungErfolgt()
        {
            machGrün("Benutzername und Passwort erfolgreich registriert.\n");
            Thread.Sleep(1000);
        }
        public static void getMessageNeuKontoınhaberErstellt()
        {
            machGrün("Neues Benutzerkonto erstellt\n");
            Thread.Sleep(1000);
        }
        public static void getMessageEsGibtGleicheUsername()
        {
            machRot("\nEs gibt bereits einen Benutzer mit diesem Namen, bitte geben Sie einen anderen Benutzernamen ein.\n");
            Thread.Sleep(2000);
        }

        public static void getMessageProbierenWieder()
        {
            machRot("\nEs keinen solchen Benutzer gibt, überprüfen Sie bitte Ihren Benutzernamen und Ihr Passwort.\n");
            Thread.Sleep(2000);
        }
        public static void getMessageWarnung12oder3()
        {
            machRot("\nBitte 1,2 oder 3\n");
            Thread.Sleep(1000);
        }

        //log message
        public static void saveLogData(List<string> liste, string logMessage)
        {
            liste.Add(logMessage);
        }

        public static string HesabAcilisKaydi(string iban)
        {

            return $" {DateTime.Now} IBAN: {iban} Konto wurde eröffnet ";
        }
        public static string ParaCekmeKaydi(double zahl)
        {

            return $" {DateTime.Now} Menge: {zahl} Euro wurden von Ihrem Konto abgehoben";
        }

        public static string ParaHavaleÇıkışı(double zahl, string iban)
        {
            return $"{DateTime.Now}  {zahl} auf Ihrem Konto wurden auf iban :{iban}  überwiesen.";
        }
        public static string ParaHavaleGirişi(double zahl, string iban)
        {
            return $"{DateTime.Now} {zahl} auf Ihrem Konto wurden auf iban :{iban}  überwiesen.";
        }
        public static string ParaYatirma(double zahl)
        {
            return $"{DateTime.Now}  {zahl}  auf das Konto eingezahlt worden.";
        }
        public static string YeniHesapOlusturmaKaydi(string kontoName, string kontoType, string iban)
        {
            return $"{DateTime.Now} {kontoName} name {kontoType}  type mit nummer {iban} Ihr Konto ergesttelt worden";
        }

        //kontoBewegung message
        public static void getMessageNeueKontoEröffnung()
        {
            Console.WriteLine("Sie können bis zu 5 Konten eröffnen");
            Console.WriteLine("Welche Art von Konto möchten Sie eröffnen? (x zum Beenden)");
        }
        public static void getMessageMAxKOnto()
        {
            machRot("Die maximale Kontostufe ist erreicht, Sie können kein Konto mehr eröffnen");
            Thread.Sleep(1500);
        }
        public static void getMessageWechleKontoAnlegen()
        {
            machGrün("Auf welches Konto werden Sie Geld einzahlen?");
        }
        public static void getMessageGibGültigKontoNummerEin()
        {
            machRot("Bitte geben Sie ein bestehendes Konto ein");
            Thread.Sleep(1500);
        }
        public static void getMessageWelcheKOntoAbheben()
        {
            machGrün("Von welchem Konto werden Sie Geld abheben?");
        }
        public static void getTransferMenu()
        {
            Console.WriteLine("Überweisungsart auswählen\n");
            Console.WriteLine("1. Zwischen meinen Konten überweisen");
            Console.WriteLine("2. Auf ein anderes Konto überweisen\n");
        }
        public static void getMessageVomWelchemKontoTransfer()
        {
            machGrün("Von welchem Konto werden Sie überweisen?");
        }
        public static void getMessageZuWelchemKontoTransfer()
        {
            Console.WriteLine("Auf welches Konto werden Sie überweisen");
        }
        public static void getMessageMenge()
        {
            machGrün("Betrag\t: ");
        }
        public static void getMessageEsgibtkeineSolcheKonto()
        {
            machRot("Es gibt kein solches Konto");
            Thread.Sleep(2000);
        }
        public static void getMessageUngültigeEingabe()
        {
            machRot("Ungültige Eingabe");
            Thread.Sleep(2000);
        }
        public static void getMessageGibIban()
        {
            machGrün("Geben Sie die Iban-Adresse der Person ein, die Sie überweisen möchten");
        }
        public static void getMessageEsGibtAbheben(double zahl)
        {
            Console.WriteLine($"Es gab eine Überweisung von {zahl} von Ihrem Konto ");
        }
        public static void getMessageEsGibtAnlegen(double zahl)
        {
            Console.WriteLine($"{zahl} auf Ihr Konto gutgeschrieben");
        }
        public static void getMessageEsGibtAngeneTransfer(double zahl)
        {
            Console.WriteLine($"Ihr Konto hat eine Überweisung in Höhe von {zahl} Euro erhalten.");
        }
        public static void getMessageGibKOntoName()
        {
            machGrün("Bitte geben Sie den Kontonamen ein");
        }
        public static void machRot(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void machBlaue(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void machGrün(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void machGrün2(char message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message);
            Thread.Sleep(1);
            Console.ResetColor();
        }
        public static void getMessageMaxLimit()
        {
            machRot("Die Transaktion konnte nicht ausgeführt werden, weil das Höchstlimit überschritten wurde");
            Thread.Sleep(2000);
        }
        public static void getMessageTransfer(string IBAN, double zahl)
        {
            machRot("Es wurde eine Überweisung auf Ihr Konto " + zahl + " mit der Kontonummer " + IBAN + " vorgenommen.");
            Thread.Sleep(2000);
        }
        public static void getMessageUnzureichenderSaldo()
        {
            machRot("Unzureichender Saldo");
            Thread.Sleep(2000);
        }

    }
}
