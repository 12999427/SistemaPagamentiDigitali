namespace SistemaPagamentiDigitali
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nSeleziona il metodo di pagamento:");
                Console.WriteLine("1. PayPal");
                Console.WriteLine("2. Carta");
                Console.WriteLine("3. Crypto");
                Console.Write("Scelta (1-3) o 'esci' per terminare: ");

                string scelta = Console.ReadLine().ToLower();

                if (scelta == "esci")
                    break;

                Sorgente sorgente = null;

                try
                {
                    switch (scelta)
                    {
                        case "1":
                            Console.Write("Inserisci email PayPal: ");
                            string email = Console.ReadLine();
                            Console.Write("Inserisci password: ");
                            string passwordPayPal = Console.ReadLine();
                            Console.Write("Inserisci saldo iniziale: ");
                            float saldoPayPal = float.Parse(Console.ReadLine());
                            sorgente = new PayPalSorgente(saldoPayPal, passwordPayPal, email);
                            break;

                        case "2":
                            Console.Write("Inserisci numero carta: ");
                            string numeroCarta = Console.ReadLine();
                            Console.Write("Inserisci data scadenza (MM/AA): ");
                            string dataScadenza = Console.ReadLine();
                            Console.Write("Inserisci limite carta: ");
                            float limiteCarta = float.Parse(Console.ReadLine());
                            Console.Write("Inserisci PIN: ");
                            string pin = Console.ReadLine();
                            Console.Write("Inserisci saldo iniziale: ");
                            float saldoCarta = float.Parse(Console.ReadLine());
                            sorgente = new CartaSorgente(saldoCarta, pin, numeroCarta, dataScadenza, limiteCarta);
                            break;

                        case "3":
                            Console.Write("Inserisci ID wallet: ");
                            int idWallet = int.Parse(Console.ReadLine());
                            Console.Write("Inserisci saldo iniziale: ");
                            float saldoCrypto = float.Parse(Console.ReadLine());
                            sorgente = new CryptoSorgente(saldoCrypto, idWallet);
                            break;

                        default:
                            Console.WriteLine("Scelta non valida!");
                            continue;
                    }

                    Console.Write("Inserisci importo da pagare: ");
                    float importo = float.Parse(Console.ReadLine());

                    int risultatoTransazione;

                    if (sorgente is SorgenteAutenticata)
                    {
                        Console.Write("Inserisci credenziali per autenticazione: ");
                        string credenziali = Console.ReadLine();
                        risultatoTransazione = ((SorgenteAutenticata)sorgente).EseguiTransazione(importo, credenziali);
                    }
                    else
                    {
                        risultatoTransazione = sorgente.EseguiTransazione(importo);
                    }

                    if (risultatoTransazione == -1)
                    {
                        Console.WriteLine("Transazione negata: fondi insufficienti o credenziali errate!");
                    }
                    else
                    {
                        Console.WriteLine("Transazione completata con successo!");
                        Console.WriteLine(sorgente.RicevutaTransazione(risultatoTransazione));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore nell'inserimento: {ex.Message}");
                }
            }
        }
    }
}