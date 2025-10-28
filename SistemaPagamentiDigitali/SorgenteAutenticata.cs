using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPagamentiDigitali
{
    internal abstract class SorgenteAutenticata : Sorgente
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
            if (credenziali != null && Autentica(credenziali))
                return base.EseguiTransazione(credito);
            else
                return -1;
        }

        protected virtual bool Autentica (string credenziali)
        {
            return credenziali == Credenziali;
        }

        protected SorgenteAutenticata (float saldo, string credenzaili) : base(saldo)
        {
            Credenziali = credenzaili;
        }
    }
}
