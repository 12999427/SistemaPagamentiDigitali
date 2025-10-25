using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPagamentiDigitali
{
    internal class CryptoSorgente : Sorgente
    {
        private int ID;

        public CryptoSorgente(float saldo, int IDwallet) : base(saldo)
        {
            ID = IDwallet;
        }
    }
}
