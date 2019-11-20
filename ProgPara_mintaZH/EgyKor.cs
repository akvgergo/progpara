using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPara_mintaZH
{
    //1. feladat
    struct EgyKor
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
        public EgyKor(int x, int y, int r)
        {
            _x = x;
            _y = y;
            _r = r;
        }
    }
}
