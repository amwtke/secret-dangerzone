using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cai
{
    public delegate void ProcessLineHandler(string linestr); 
    public interface IProcessText
    {
        ProcessLineHandler datahandler
        {
            get;
        }
    }
}
