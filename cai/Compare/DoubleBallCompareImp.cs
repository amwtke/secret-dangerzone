using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.Query;

namespace cai
{
    /// <summary>
    /// 用于DB4O排序结果集合
    /// </summary>
    class DoubleBallCompareImp : IQueryComparator
    {

        int IQueryComparator.Compare(object first, object second)
        {
            DoubleBoll f = (DoubleBoll)first;
            DoubleBoll s = (DoubleBoll)second;
            int first_qi = int.Parse(f.QiShu);
            int second_qi = int.Parse(s.QiShu);
            return -(first_qi - second_qi);
        }
    }
}
