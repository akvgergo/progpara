using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPara_mintaZH
{
    //1. feladat
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Kérem adja meg a körök számát!");

            //ellenőrzött bekérés. A feladat nem mondja hogy a "try" az egy un. try-metódust kér, vagy try-catch blokkot,
            //az előbbi nekem szimpatikusabb
            int N;
            if (!int.TryParse(Console.ReadLine(), out N) || N < 1)
            {
                Console.WriteLine("Nem megfelelő érték! A körök száma 10-re lett állítva.");
                N = 10;
            }

            KorStat korStat = new KorStat(N);

            //ide console.writeline kéne magyarázatokkal, lusta vagyok
            Console.WriteLine(korStat.BenneOrigo());
            Console.WriteLine(korStat.TeruletOsszeg());
            korStat.LegtavolabbiKorok();

            for (int i = 0; i < korStat.Count; i++)
            {
                var kor = korStat[i];
                //itt megfontolhatjuk hogy akarunk-e ToString() metódust az EgyKor struktúrába,
                //lehet az érne több pontot de a feladat nem írja, úgyhogy én nem teszem és helybe formázom a kiírást
                Console.WriteLine("({0},{1}) - {2}", kor.X, kor.Y, kor.r);
            }
            
            Console.ReadKey();
        }
    }
}
