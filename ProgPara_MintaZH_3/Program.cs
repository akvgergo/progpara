using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPara_MintaZH_3
{
    class Program
    {
        //3.feladat
        static void Main(string[] args)
        {

            Console.WriteLine("Kérem adjon meg egy kettőnél nagyobb egész számot!");
            //ezzel már dolgoztunk, csak most addig kell kéregetni ameddig nem jó az érték
            //végtelen ciklus ami csak akkor áll meg ha helyes az érték a legegyszerűbb
            int N;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out N) && N > 2) break;
                Console.WriteLine("Nem megfelelő érték! próbálja újra.");
            }
            
            Kor[] korok = new Kor[N];

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("Kérem adja meg a(z) {0}. kör adatait:", i + 1);
                int korX, korY, Korradius;

                //feladat nem kér bemenet ellenőrzést, úgyhogy ¯\_(ツ)_/¯
                Console.Write("Középpont X koordinátája: ");
                korX = int.Parse(Console.ReadLine());
                Console.Write("Középpont Y koordinátája: ");
                korY = int.Parse(Console.ReadLine());
                Console.Write("A kör sugara: ");
                Korradius = int.Parse(Console.ReadLine());

                korok[i] = new Kor(korX, korY, Korradius);
            }

            Array.Sort(korok);

            foreach (var kor in korok)
            {
                Console.WriteLine(kor);
                Console.WriteLine(kor.OrigoTavolsag());
            }

            //olvashatóbb konzol, ennél többhöz lusta vagyok
            Console.WriteLine();

            //LINQ rendezés távolság alapján, majd kiválasztjuk az utolsó értéket
            var legtavolabb = korok.OrderBy(k => k.OrigoTavolsag()).Last();
            Console.WriteLine(legtavolabb);
            Console.WriteLine(legtavolabb.OrigoTavolsag());

            Console.ReadKey();
        }
    }
}
