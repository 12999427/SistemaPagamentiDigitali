using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPagamentiDigitali
{
    internal class SorgenteAutenticata : Sorgente
    {
        private string credenziali;
        protected string Credenziali
        {
            get
            {
                return credenziali;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    credenziali = value;
                }
                else
                    throw new ArgumentException();
            }
        }
        public override int EseguiTransazione(float credito, string credenziali = null)
        {
            if (credenziali != null || autentica(credenziali))
                return base.EseguiTransazione(credito);
            else
                return -1;
        }

        protected virtual bool autentica (string credenziali)
        {
            return credenziali == Credenziali;
        }

        public SorgenteAutenticata (float saldo, string credenzaili) : base(saldo)
        {
            Credenziali = credenzaili;
        }
    }
}
