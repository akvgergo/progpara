using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPara_MintaZH_3
{
    //3. feladat
    //1-2 feladat copy paste, csak most osztály, és a feladat direkt nem mondja meg melyik interfészt kell implementálni
    //órán mi nem tértunk ki arra hogy mi a különbség IComparable és IComparable<> között, ha ti se akkor ennek jónak kéne lenni
    class Kor : IComparable
    {
        // A feladat az adatmezők definiálását kéri ezért nem biztos hogy az automatikus tulajdonságokat a tanár elfogadná
        // Egyéként annyi lenne hogy "public int X { get; }", és ugyanez Y-ra és r-re
        // Ha privát mezőkből kellenek tulajdonságok, akkor érdemes "_" jellel kezdeni a változók nevét
        // ebbe a tanár nem köthet bele mert ezt a Microsoft ajánlja :)
        int _x, _y, _r;

        //Mind a háromra lekérdező tulajdonság
        public int X {
            get { return _x; }
        }

        public int Y {
            get { return _y; }
        }

        public int r {
            get { return _r; }
        }

        //Konstruktor ami mind a három mezőnket feltölti
        public Kor(int x, int y, int r)
        {
            _x = x;
            _y = y;
            _r = r;
        }

        //előző két feladatba már megvolt, most metódus ízvilágban ugyanaz, feladat megadja a számítás menetét
        public double OrigoTavolsag()
        {
            return Math.Sqrt(X * X + Y * Y) - r;
        }

        public override string ToString()
        {
            //string.Format-ot preferálom mert ugyanazon az elven működik mint a WriteLine,
            //de a tanárnő nem fog megsértődni ha + jelekkel adogatod össze a stringeket
            //teljesen preferencia kérdése
            return string.Format("K({0},{1}) R({2})", X, Y, r);
        }

        public int CompareTo(object obj)
        {
            //kivételt dobunk mivel hibának számít hogyha ezt a típust másik típushoz akarjuk hasonlítgatni
            if (!(obj is Kor)) throw new ArgumentException("obj");
            //r az int, vagyis felhasználhatjuk az int összehasonlító függvényét
            return r.CompareTo(((Kor)obj).r);
        }
    }
}