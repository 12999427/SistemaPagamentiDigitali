using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPagamentiDigitali
{
    internal class CartaSorgente : SorgenteAutenticata
    {
        public string NumeroCarta { get; private set; }
        public string DataScadenza { get; private set; }
        public float LimiteCarta { get; private set; }

        public CartaSorgente(float saldo, string credenziali, string cardNumber, string expiryDate, float creditLimit) : base(saldo, credenziali)
        {
            NumeroCarta = cardNumber;
            DataScadenza = expiryDate;
            LimiteCarta = creditLimit;
        }

        public virtual bool VerificaDisponibilita(float credito)
        {
            float totaleSpeso = 0;
            foreach (var i in transazioni)
            {
                totaleSpeso += i.importo;
            }
            if (LimiteCarta > totaleSpeso)
            {
                return true;
            }
            return false;
        }

    }
}
