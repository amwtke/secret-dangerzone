using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cai
{
    interface ICaiCompare
    {
        // 摘要:
        //     Implement to compare two arguments for sorting.
        //
        // 备注:
        //     False Not Same; True the SAME
        bool Compare(object first, object second);
    }
}
