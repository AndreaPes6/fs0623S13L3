using System;
using System.Globalization;

internal class Program
{
    static void Main()
    {
        ContoCorrente conto = new ContoCorrente();
        bool continua = true;

        while (continua)
        {
            Console.Clear();

            if (!conto.Aperto)
            {
                Console.WriteLine("Scegli un'opzione:");
                Console.WriteLine("1. Apri conto");
            }
            else
            {
                Console.WriteLine("Scegli un'opzione:");
                Console.WriteLine("2. Versamento");
                Console.WriteLine("3. Prelievo");
                Console.WriteLine("4. Visualizza bilancio");
            }

            Console.WriteLine("5. Esci");

            int scelta = Convert.ToInt32(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    GestoreConto.ApriConto(conto);
                    break;

                case 2:
                    GestoreConto.EseguiOperazione(conto, TipoOperazione.Versamento);
                    break;

                case 3:
                    GestoreConto.EseguiOperazione(conto, TipoOperazione.Prelievo);
                    break;

                case 4:
                    GestoreConto.VisualizzaBilancio(conto);
                    break;

                case 5:
                    continua = false;
                    break;

                default:
                    Console.WriteLine("Scelta non valida. Riprova.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}

enum TipoOperazione
{
    Versamento,
    Prelievo
}

class ContoCorrente
{
    private bool aperto;
    private decimal saldo;

    public ContoCorrente()
    {
        aperto = false;
        saldo = 0;
    }

    public bool Aperto
    {
        get { return aperto; }
    }

    public void ApriConto(decimal saldoIniziale)
    {
        if (!aperto && saldoIniziale >= 1000)
        {
            aperto = true;
            saldo = saldoIniziale;
            Console.WriteLine("Conto aperto con successo. Saldo iniziale: " + saldo);
        }
        else
        {
            Console.WriteLine("Il conto non può essere aperto.");
        }
    }

    public void EseguiOperazione(decimal importo, TipoOperazione tipoOperazione)
    {
        if (aperto)
        {
            if (tipoOperazione == TipoOperazione.Versamento)
            {
                saldo += importo;
                Console.WriteLine("Versamento di " + importo + " effettuato. Nuovo saldo: " + saldo);
            }
            else if (tipoOperazione == TipoOperazione.Prelievo && saldo >= importo)
            {
                saldo -= importo;
                Console.WriteLine("Prelievo di " + importo + " effettuato. Nuovo saldo: " + saldo);
            }
            else
            {
                Console.WriteLine("Impossibile effettuare l'operazione.");
            }
        }
        else
        {
            Console.WriteLine("Il conto non è aperto.");
        }
    }

    public void VisualizzaBilancio()
    {
        Console.WriteLine("Bilancio attuale: " + saldo);
    }
}

class GestoreConto
{
    public static void ApriConto(ContoCorrente conto)
    {
        if (!conto.Aperto)
        {
            Console.WriteLine("Inserisci il saldo iniziale per aprire il conto:");
            decimal saldoIniziale;

            while (!decimal.TryParse(Console.ReadLine(), NumberStyles.Currency, CultureInfo.InvariantCulture, out saldoIniziale))
            {
                Console.WriteLine("Inserisci un importo valido.");
            }

            conto.ApriConto(saldoIniziale);
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Il conto è già aperto.");
            Console.ReadLine();
        }
    }

    public static void EseguiOperazione(ContoCorrente conto, TipoOperazione tipoOperazione)
    {
        if (conto.Aperto)
        {
            Console.WriteLine($"Inserisci l'importo per effettuare un {tipoOperazione.ToString().ToLower()}:");
            decimal importo;

            while (!decimal.TryParse(Console.ReadLine(), NumberStyles.Currency, CultureInfo.InvariantCulture, out importo))
            {
                Console.WriteLine("Inserisci un importo valido.");
            }

            conto.EseguiOperazione(importo, tipoOperazione);
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Il conto non è aperto.");
            Console.ReadLine();
        }
    }

    public static void VisualizzaBilancio(ContoCorrente conto)
    {
        if (conto.Aperto)
        {
            conto.VisualizzaBilancio();
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Il conto non è aperto.");
            Console.ReadLine();
        }
    }
} 










//using System;

//class Program
//{
//    static void Main()
//    {
//        RicercaNome();
//    }

//    static void RicercaNome()
//    {
//        Console.Write("Inserisci la dimensione dell'array: ");
//        int n = int.Parse(Console.ReadLine());

//        string[] nomi = new string[n];
//        for (int i = 0; i < n; i++)
//        {
//            Console.Write($"Inserisci il nome {i + 1}: ");
//            nomi[i] = Console.ReadLine();
//        }

//        Console.Write("Inserisci il nome da cercare: ");
//        string nomeCercato = Console.ReadLine();

//        bool presente = false;
//        foreach (string nome in nomi)
//        {
//            if (nome.Equals(nomeCercato, StringComparison.OrdinalIgnoreCase))
//            {
//                presente = true;
//                break;
//            }
//        }

//        if (presente)
//            Console.WriteLine($"Il nome '{nomeCercato}' è presente nell'array.");
//        else
//            Console.WriteLine($"Il nome '{nomeCercato}' non è presente nell'array.");
//    }
//}

