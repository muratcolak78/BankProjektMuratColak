using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjektMuratColak
{
    internal class StudentKonto : AbstractKonto
    {

        public StudentKonto(Kontoinhaber haber, string hesapAdi) : base(haber, hesapAdi)
        {
            Saldo1 = 0;
            MonatlicheZinsen1 = 0;
            MonatlicheKontoFührungsBebühr1 = 0;
            Überweisungsgebühr1 = 0;
            MaxLimit = 2000;

        }


    }
}
