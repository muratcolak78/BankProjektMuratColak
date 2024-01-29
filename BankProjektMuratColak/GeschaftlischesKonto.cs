using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjektMuratColak
{
    internal class GeschaftlischesKonto : AbstractKonto
    {


        public GeschaftlischesKonto(Kontoinhaber haber, string hesapAdi) : base(haber, hesapAdi)
        {
            Saldo1 = 0;
            MonatlicheZinsen1 = 0.5;
            MonatlicheKontoFührungsBebühr1 = 5;
            Überweisungsgebühr1 = 3;
            MaxLimit = 100000;

        }


    }
}
