using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjektMuratColak
{
    internal class StandartKonto : AbstractKonto
    {

        public StandartKonto(Kontoinhaber haber, string hesapAdi):base(haber,hesapAdi)
        {
        Saldo1 = 500;
        MonatlicheZinsen1 = 0.3;
        MonatlicheKontoFührungsBebühr1 = 7;
        Überweisungsgebühr1 = 5;
        MaxLimit = 10000;

        }
       

    }
}