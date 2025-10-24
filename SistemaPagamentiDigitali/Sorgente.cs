using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPagamentiDigitali
{
    internal class Sorgente
    {
        private float saldo;
        public float Saldo
        {
            get
            {
                return saldo;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();
                saldo = value;
            }
        }

        public Sorgente(float saldo)
        {
            Saldo = saldo;
        }

        public 
    }
}
