using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CSharpChartExplorer;
namespace cai
{
    static class Program
    {
        static Program()
        {
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(@"config/Log4net.xml"));
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(@"config/Log4net.xml"));
        }
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
