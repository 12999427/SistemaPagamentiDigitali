using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPagamentiDigitali
{
    internal class Sorgente
    {
        protected List<(float saldoPrec, float importo)> transazioni = new();

        public float Saldo { get; set; }

        public Sorgente(float saldo)
        {
            Saldo = saldo;
        }

        public virtual bool VerificaDisponibilita (float credito)
        {
            return credito > 0 && Saldo - credito >= 0;
        }

        public virtual int EseguiTransazione (float credito, string credenziali = null)
        {
            if (VerificaDisponibilita(credito))
            {
                transazioni.Add((Saldo, credito));
                Saldo -= credito;
                return transazioni.Count-1;
            }
            return -1;
        }

        public virtual string RicevutaTransazione (int n)
        {
            float s = transazioni[n].saldoPrec;
            float i = transazioni[n].importo;
            return $"===SCONTRINO===\nTransazione:\nConto Precedente: {s}\nImporto: {i}\nConto Successivo: {s} - {i} = {s-i}";
        }


    }
}
