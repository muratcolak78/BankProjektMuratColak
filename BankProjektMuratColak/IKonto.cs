using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjektMuratColak
{
    interface IKonto
    {

        public abstract void geldAnlegen(double zah);
        public abstract void geldAbheben(double zahl);
        public abstract void geldTransfer(string IBAN, double zahl);


    }
}
