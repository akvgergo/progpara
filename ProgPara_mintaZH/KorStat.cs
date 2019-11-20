using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPara_mintaZH
{
    //1. feladat
    class KorStat
    {
        //Privát listának a feladat meghatározta a nevét, arra mindig ügyeljunk mert hibás névért is jár minuszpont
        List<EgyKor> korList = new List<EgyKor>();
        
        //indexelő ami a lista n-edik elemét adja vissza
        public EgyKor this [int n] {
            get { return korList[n]; }
        }

        //feladat nem írja hogy így kell csinálni, de a main metódus feladatához szükséges
        public int Count {
            get { return korList.Count; }
        }

        //Feladat szerinti konstruktor
        public KorStat(int count)
        {
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                //Véletlenszerű feltöltés, feladat annyit mond hogy "-20 és 20" között. Vegyük úgy hogy ezek exkluzív határok,
                //vagyis "(-19, 20)" a helyes, mivel a Random.Next felső határ paramétere exkluzív, az alsó viszont inkluzív.
                //ugyanez az elv az r-re
                korList.Add(new EgyKor(rnd.Next(-19, 20), rnd.Next(-19, 20), rnd.Next(1, 10)));
            }
        }

        public int BenneOrigo()
        {
            //LINQ gyorsszűrés, Where-rel szűrjük a feltételnek megfelelő köröket (origót tartalmazza,
            //számítást a feladat definiálja) lambda operátorral meghatározzuk a szűréshez használt függvényt,
            //majd a szűrés után megkapott köröket megszámoljuk Count-tal, és ezt az értéket a metódus vissza is adja.
            return korList.Where(k => Math.Sqrt(k.X * k.X + k.Y * k.Y) <= k.r).Count();
        }

        public double TeruletOsszeg()
        {
            //Ismét LINQ, Sum-mal összegezzük a körök területeit, ez a metódus is függvényt kér, amit lambda operátorral csinálunk
            return korList.Sum(k => k.r * k.r * Math.PI);
        }

        public void LegtavolabbiKorok()
        {

            //A feladat a két egymástól legtávolabbi kört kéri, tehát nem tudunk trükközni, mindegyik kört össze kell hasonlítani
            //az összes többivel. Összehasonlítás közben a kor1 és kor2 tárolja az eddigi legtávolabbi körpárt, a distance pedig
            //ennek a tárolt körpárnak a távolsága amit számon tartunk hogy a többivel összehasonlítsuk.
            int kor1index = 0, kor2index = 0;
            //Ennek a lehető legkisebb értéket adjuk, mivel kicsi rá az esély, de lehet hogy az összes kör metszi egymást
            //ebben az esetben ha 0 lenne a kezdőérték, végul nem lenne körpár kiválasztva, mivel az összes körpár távolsága negatív lenne.
            double distance = double.MinValue;

            for (int i = 0; i < korList.Count; i++)
            {
                //Összehasonlítást végzünk, tehát hogy ne hasonlítsuk össze kétszer ugyanazt a körpárt, a pár második tagja
                //lehet mindig az első pártag után a listában következő kör.
                for (int j = i + 1; j < korList.Count; j++)
                {
                    var kor1 = korList[i];
                    var kor2 = korList[j];
                    //Feladat megadja a számítás menetét
                    var d = Math.Sqrt((kor1.X - kor2.X) * (kor1.X - kor2.X) + (kor1.Y - kor2.Y) * (kor1.Y - kor2.Y)) - kor1.r - kor2.r;
                    //Eredményt összehasonlítjuk az eddigi legnagobb távolsággal, ha a most vizsgált körpár
                    //távolsága nagyobb, felvesszük őket a kor1, kor2 változókba, távolságukat feljegyezzük
                    if (d > distance)
                    {
                        kor1index = i;
                        kor2index = j;
                        distance = d;
                    }

                }
            }

            Console.WriteLine("A(z) {0}. és a(z) {1}. kör körvonala van a legtávolabb!", kor1index + 1, kor2index + 1);
            //Két tizedesre kerekítünk
            Console.WriteLine("Távolságuk: {0}", Math.Round(distance, 2));
        }

    }
}
