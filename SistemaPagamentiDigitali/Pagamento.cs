using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPagamentiDigitali
{
    internal class Pagamento
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

        private float importo;
        public float Importo
        {
            get
            { return importo; }
            set
            {
                if (value < 0)
                    throw new ArgumentException();
                importo = value;
            }
        }

        public Pagamento (float saldo, float importo)
        {
            Saldo = saldo;
            Importo = importo;
        }

        public abstract bool VerificaDisponibilita ()
        {

        }
    }
}
