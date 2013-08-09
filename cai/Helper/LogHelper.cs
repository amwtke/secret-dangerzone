using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cai.Helper
{
    public class LoggerHelper
    {
        static log4net.ILog LOGGER = null;
        static LoggerHelper()
        {
            if (LOGGER == null)
            {
                LOGGER = log4net.LogManager.GetLogger(typeof(LoggerHelper));
            }
        }
        //public static void LogTCStackError(Type type)
        //{
        //    if (errortask != null && errortask.Messages != null && errortask.Messages.Length > 0)
        //    {
        //        LOGGER.Error("********************" + type.ToString() + "********************");
        //        foreach (string s in errortask.Messages)
        //        {
        //            LOGGER.Error(s);
        //        }
        //        LOGGER.Error("********************END " + type.ToString() + " END********************");
        //    }
        //}
    }
}
