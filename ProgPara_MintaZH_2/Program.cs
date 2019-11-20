using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPara_MintaZH_2
{
    //2. feladat
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kérem adja meg a körök számát!");

            //lásd 1. feladat
            int N;
            if (!int.TryParse(Console.ReadLine(), out N) || N < 1)
            {
                Console.WriteLine("Nem megfelelő érték! A körök száma 15-re lett állítva.");
                N = 15;
            }

            Korok proba = new Korok(N);

            //ide console.writeline kéne magyarázatokkal, lusta vagyok
            Console.WriteLine(proba.TengelyenK());
            var legtavolabb = proba.Legtávolabb();
            Console.WriteLine("({0},{1}) - {2}", legtavolabb.X, legtavolabb.Y, legtavolabb.r);
            Console.Write("Kérem adjon meg egy sugarat:");
            var kicsik = proba.Kicsik(int.Parse(Console.ReadLine()));
            
            Console.WriteLine(kicsik == 0 ? "nincsen kicsi kör" : "kicsi körök száma: " + kicsik.ToString());

            Console.ReadKey();




        }
    }
}
