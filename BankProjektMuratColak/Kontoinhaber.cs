using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjektMuratColak
{
    internal class Kontoinhaber
    {
        private int LogCount = 0;
        private int count = 0;
        private double totalGeld;
        private string IBAN;
        private string username;
        private string vorname;
        private string nachname;
        private string email;
        private string adres;
        private string phone;
        private string kontoType;
        private List<AbstractKonto> kontos;
        private List<string> log;
        private StandartKonto standart;

        public int Count { get => count; set => count = value; }
        public string Username { get => username; set => username = value; }
        public string Vorname { get => vorname; set => vorname = value; }
        public string Nachname { get => nachname; set => nachname = value; }
        public string Email { get => email; set => email = value; }
        public string Adres { get => adres; set => adres = value; }
        public string KontoType { get => kontoType; set => kontoType = value; }
        public string Phone { get => phone; set => phone = value; }
        public string IBAN1 { get => IBAN; set => IBAN = value; }
        public List<string> Log { get => log; set => log = value; }
        public double TotalGeld { get => totalGeld; set => totalGeld = value; }
        internal List<AbstractKonto> Kontos { get => kontos; set => kontos = value; }

        public Kontoinhaber(string username)
        {

            this.username = username;
            count++;
            kontos = new List<AbstractKonto>(5);
            standart = new StandartKonto(this, "ersteKonto");
            kontos.Add(standart);

            TotalGeld = standart.Saldo1;

            log = new List<string>();
            Menu.saveLogData(log, Menu.HesabAcilisKaydi(IBAN1));

        }
        public void addStandartKonto(string kontname)
        {
            kontos.Add(new StandartKonto(this, kontname));
            TotalGeld += standart.Saldo1;
        }
        public void addStudentKonto(string kontname)
        {
            kontos.Add(new StudentKonto(this, kontname));
        }
        public void addGeschaflischeKonto(string kontname)
        {
            kontos.Add(new GeschaftlischesKonto(this, kontname));
        }
        public override string ToString()
        {
            return $"Count   \t: {Count}\n" +
                   $"Username\t: {Username}\n" +
                   $"Vorname \t: {Vorname}\n" +
                   $"Nachname\t: {Nachname}\n" +
                   $"Email   \t: {Email}\n" +
                   $"Adres   \t: {Adres}\n" +
                   $"KontoType\t: {KontoType}\n" +
                   $"Phone   \t: {Phone}\n" +
                   $"IBAN1   \t: {IBAN1}\n" +
                   $"TOTAL GELD   \t: {TotalGeld}\n";
        }

        public void showAlleKonto()
        {
            int count = 1;
            Menu.machGrün($"S.N Konto Type\t\t Konto Name\t\tKonto Saldo\tMax Limit  ");
            foreach (var hesap in kontos)
            {
                Menu.machGrün(count + ". " + hesap);
                count++;
            }
            Console.WriteLine();
            Console.WriteLine($"═════════════════════════════════════════════════════════════════════════════════════════════════");
        }
    }
}
