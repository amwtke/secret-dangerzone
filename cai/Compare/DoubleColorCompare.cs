using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cai
{
    class DoubleColorCompareImp : ICaiCompare
    {
        bool ICaiCompare.Compare(object first, object second)
        {
            DoubleBoll f = (DoubleBoll)first;
            DoubleBoll s = (DoubleBoll)second;
            if (f.Red1 == s.Red1 &&
                f.Red2 == s.Red2 &&
                f.Red3 == s.Red3 &&
                f.Red4 == s.Red4 &&
                f.Red5 == s.Red5 &&
                f.Red6 == s.Red6 &&
                f.Blue == s.Blue
            )
                return true;
            else
                return false;
        }
    }
}
