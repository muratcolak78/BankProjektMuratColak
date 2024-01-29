using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjektMuratColak
{
    internal class StandartKonto : IKonto
    {



        private string IBAN;
        private string KontoName;
        private string KontoEinHaber;
        private double Saldo = 500;
        private double MonatlicheZinsen = 0.3;
        private double MonatlicheKontoFührungsBebühr = 7;
        private double Überweisungsgebühr = 5;
        private double maxLimit = 10000;
        private Kontoinhaber inhaber;
        private List<Object> ibanSaver;

        public string Kontoname1 { get => KontoName; set => KontoName = value; }
        public string HesapSahibi { get => KontoEinHaber; set => KontoEinHaber = value; }
        public double Saldo1 { get => Saldo; set => Saldo = value; }
        public double MonatlicheZinsen1 { get => MonatlicheZinsen; set => MonatlicheZinsen = value; }
        public double MonatlicheKontoFührungsBebühr1 { get => MonatlicheKontoFührungsBebühr; set => MonatlicheKontoFührungsBebühr = value; }
        public double Überweisungsgebühr1 { get => Überweisungsgebühr; set => Überweisungsgebühr = value; }
        public double MaxLimit { get => maxLimit; set => maxLimit = value; }
        internal Kontoinhaber Inhaber { get => inhaber; set => inhaber = value; }
        public string IBAN1 { get => IBAN; set => IBAN = value; }
        public List<object> IbanSaver { get => ibanSaver; set => ibanSaver = value; }

        public StandartKonto(Kontoinhaber haber, string hesapAdi)
        {
            Inhaber = haber;
            HesapSahibi = haber.Username;
            if (hesapAdi.Length < 13)
            {
                for (int i = 0; i < (13 - hesapAdi.Length); i++)
                {
                    hesapAdi += " ";
                }
            }
            Kontoname1 = hesapAdi;
            IbanSaver = new List<Object>();
            IBAN = AlleListe.IBANGenerator();

            AlleListe.addIBANList(IBAN, Inhaber);

        }
        public override string ToString()
        {
            return $"Standardkonto \t:{Kontoname1}\t\t{Saldo1}\t\t{maxLimit}";
        }

        public void geldAnlegen(double betrag)
        {

            if (betrag + Saldo > maxLimit) Menu.getMessageMaxLimit();

            else
            {
                Saldo += betrag;
                Saldo -= Überweisungsgebühr1;
                Inhaber.TotalGeld += betrag;
                Inhaber.TotalGeld -= Überweisungsgebühr1;
                if (Überweisungsgebühr1 != 0) Menu.saveLogData(Inhaber.Log, $"{DateTime.Now} {Überweisungsgebühr1} Euro Kontoführungsgebühr werden abgezogen");

            }


        }

        public void geldAbheben(double betrag)
        {

            if (betrag + Überweisungsgebühr1 > Saldo1) Menu.getMessageUnzureichenderSaldo();
            else
            {
                Saldo1 -= (betrag + Überweisungsgebühr);
                Inhaber.TotalGeld -= (betrag + Überweisungsgebühr);
                if (Überweisungsgebühr1 != 0) Menu.saveLogData(Inhaber.Log, $"{DateTime.Now} {Überweisungsgebühr1} Euro Kontoführungsgebühr werden abgezogen");
            }

        }

        public void geldTransfer(string IBAN, double zahl)
        {

            if (zahl + Saldo1 > maxLimit) Menu.getMessageMaxLimit();

            else
            {
                Saldo1 += zahl;
                Saldo1 -= Überweisungsgebühr1;
                Inhaber.TotalGeld += zahl;
                Inhaber.TotalGeld -= Überweisungsgebühr1;
                if (Überweisungsgebühr1 != 0) Menu.saveLogData(Inhaber.Log, $"{DateTime.Now} {Überweisungsgebühr1} Euro Kontoführungsgebühr werden abgezogen");
                Menu.getMessageTransfer(IBAN, zahl);
            }

        }

    }
}
