using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o.Query;

namespace cai
{
    interface IDB4OCompare : IQueryComparator
    {
        // 摘要:
        //     Implement to compare two arguments for sorting.
        //
        // 备注:
        //     False Not Same; True the SAME
        new bool Compare(object first, object second);
    }
}
