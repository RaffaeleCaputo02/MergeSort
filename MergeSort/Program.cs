using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> NonOrdinata = new List<int>();
            List<int> Ordinata;

            Random random = new Random();

            Console.WriteLine("Lista non ordinata:");
            for (int i = 0; i < 10; i++)
            {
                NonOrdinata.Add(random.Next(0, 100));
                Console.Write(NonOrdinata[i] + " ");
            }
            Console.WriteLine();

            Ordinata = MergeSort(NonOrdinata);

            Console.WriteLine("Lista ordinata: ");
            foreach (int x in Ordinata)
            {
                Console.Write(x + " ");
            }
            Console.Write("\n");

            Console.ReadLine();
        }

        //Ordinamento della lista di numeri
        private static List<int> MergeSort(List<int> NonOrdinata)
        {
            if (NonOrdinata.Count <= 1)
                return NonOrdinata;

            //Divisione dell'elenco in due liste 
            List<int> Sinistra = new List<int>();
            List<int> Destra = new List<int>();

            int Centro = NonOrdinata.Count / 2;
            for (int i = 0; i < Centro; i++)  //Divisione dell'elenco non ordinato
            {
                Sinistra.Add(NonOrdinata[i]);
            }
            for (int i = Centro; i < NonOrdinata.Count; i++)
            {
                Destra.Add(NonOrdinata[i]);
            }

            Sinistra = MergeSort(Sinistra);
            Destra = MergeSort(Destra);
            return Merge(Sinistra, Destra);
        }

        //Metodo per unire i due elenchi ordinati
        private static List<int> Merge(List<int> Sinistra, List<int> Destra)
        {
            List<int> result = new List<int>();

            while (Sinistra.Count > 0 || Destra.Count > 0)
            {
                if (Sinistra.Count > 0 && Destra.Count > 0)
                {
                    if (Sinistra.First() <= Destra.First())  //Confronto i primi due elementi per vedere quale è più piccolo
                    {
                        result.Add(Sinistra.First());
                        Sinistra.Remove(Sinistra.First());      //Il resto dell'elenco meno il primo elemento
                    }
                    else
                    {
                        result.Add(Destra.First());
                        Destra.Remove(Destra.First());
                    }
                }
                else if (Sinistra.Count > 0)
                {
                    result.Add(Sinistra.First());
                    Sinistra.Remove(Sinistra.First());
                }
                else if (Destra.Count > 0)
                {
                    result.Add(Destra.First());

                    Destra.Remove(Destra.First());
                }
            }
            return result;
        }
    
    }
}
