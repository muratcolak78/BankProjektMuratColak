using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjektMuratColak
{
    internal class AbstractKonto
    {
        private string IBAN;
        private string KontoName;
        private string KontoEinHaber;
        private double Saldo;
        private double MonatlicheZinsen;
        private double MonatlicheKontoFührungsBebühr;
        private double Überweisungsgebühr;
        private double maxLimit;
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

        public AbstractKonto(Kontoinhaber haber, string hesapAdi)
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
             
                Inhaber.TotalGeld += betrag;
               
               

            }


        }

        public void geldAbheben(double betrag)
        {

            if (betrag > Saldo1) Menu.getMessageUnzureichenderSaldo();
            else
            {
                Saldo1 -= (betrag );
                Inhaber.TotalGeld -= (betrag );
                
            }

        }

        public void geldTransfer(string IBAN, double zahl)
        {

            if (zahl + Saldo1 > maxLimit) Menu.getMessageMaxLimit();

            else
            {
                Saldo1 += zahl;
               
                Inhaber.TotalGeld += zahl;
              
               
                Menu.getMessageTransfer(IBAN, zahl);
            }

        }

    }
}
