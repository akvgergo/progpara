using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPara_MintaZH_2
{
    class Korok : IStatisztika
    {
        //privát adattag
        Kor[] korTmb;

        //mint az 1.feladat, csak most tömböt kell létrehozni és feltölteni, kicsit más értékekkel
        public Korok(int count)
        {
            korTmb = new Kor[count];
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                korTmb[i] = new Kor(rnd.Next(-99, 100), rnd.Next(-99, 100), rnd.Next(1, 150));
            }
        }

        //Feltételezem hogy a feladatban "pontoknak a számát" az elírás és körök számát kéri, egyébként semmi értelme
        public int TengelyenK()
        {
            return korTmb.Where(k => k.X == 0 || k.Y == 0).Count();
        }

        public int Kicsik(int r)
        {
            //A feladat mondja hogy pozitív szám kell. Kivételdobás a legkézenfekvőbb
            if (r <= 0) throw new ArgumentException("r");
            return korTmb.Where(k => k.r < r).Count();
        }

        public Kor Legtávolabb()
        {
            //LINQ, létrehozunk egy ideiglenes listát amibe a körök és a távolságuk van. A lista elemei névtelen típusok.
            //Távolság alapján csökkenő sorrendbe rendezzük ezt a listát,ennek a listának pedig az első eleme lesz a legtávolabbi kör
            //és annak távolsága. A kör-távolság párból csak a kört adjuk vissza.
            return korTmb.Select(k => new { k, distance = Math.Sqrt(k.X * k.X + k.Y * k.Y) - k.r })
                .OrderByDescending(k_d => k_d.distance).First().k;
        }
    }
}
