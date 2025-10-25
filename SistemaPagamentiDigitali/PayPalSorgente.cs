using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPagamentiDigitali
{
    internal class PayPalSorgente : SorgenteAutenticata
    {
        private string email;

        public PayPalSorgente(float saldo, string credenziali, string email) : base(saldo, credenziali)
        {
            this.email = email;
        }
    }
}
