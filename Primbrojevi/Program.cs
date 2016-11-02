using System;

namespace Vsite.Pood
{
    public class Program
    {
        static void Main(string[] args)
        {
            IspišiPrimbrojeve(0);
            Console.ReadKey();
            IspišiPrimbrojeve(1);
            Console.ReadKey();
            IspišiPrimbrojeve(2);
            Console.ReadKey();
            IspišiPrimbrojeve(100);
            Console.ReadKey();
        }

        static void IspišiPrimbrojeve(int max)
        {
            Console.WriteLine("Primbrojevi do {0}:", max);
            var brojevi = GenerirajPrimBrojeve(max);
            if (brojevi.Length == 0)
                Console.WriteLine("Nema");
            else
            {
                foreach (var broj in brojevi)
                    Console.WriteLine(broj);
            }
        }

        static bool[] f;

        // Primjer iz knjige  Robert C. Martin: "Agile Software Development"!!!
        public static int[] GenerirajPrimBrojeve(int max)
        {
            return IzdvojiPrimBrojeve(max);
        }

        private static int[] IzdvojiPrimBrojeve(int max)
        {
            if (max < 2)
                return new int[0]; // vrati prazan niz
            else
            {
                // deklaracije
                InicijalizirajSito(max);

                // sito (ide do kvadratnog korijena maksimalnog broja)
                Prosijaj();


                //da bi rezervirali duljinu niza
                int[] primovi = new int[IzračunajKolikoJePrimBrojeva()];

                // prebaci primbrojeve u rezultat
                for (int i = 2, j = 0; i < f.Length; ++i)
                {
                    if (f[i])
                        primovi[j++] = i;
                }
                return primovi; // vrati niz brojeva
            }

        }

        private static int IzračunajKolikoJePrimBrojeva()
        {
            int broj = 0;
            for (int i = 2; i < f.Length; ++i)
            {
                if (f[i])
                    ++broj;
            }

            return broj;
        }

        private static void Prosijaj()
        {

            for (int i = 2; i < DajNajvećiPrimFaktor(); ++i)
            {
                if (f[i]) // ako je i prekrižen, prekriži i višekratnike
                    EliminirajVišekratnike(i);
            }
        }

        private static void EliminirajVišekratnike(int i)
        {
            for (int j = 2 * i; j < f.Length; j += i)
                f[j] = false; // višekratnik nije primbroj
        }

        private static int DajNajvećiPrimFaktor()
        {
            return (int)Math.Sqrt(f.Length);
        }

        private static void InicijalizirajSito(int max)
        {
            f = new bool[max+1]; // niz f.Length primbrojevima
            int i;

            // inicijaliziramo sve na true kao da su svi prim brojevi pretpostavimo
            for (i = 2; i < f.Length; ++i)
                f[i] = true;

        }
    }
}
