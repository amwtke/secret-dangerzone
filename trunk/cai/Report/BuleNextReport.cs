using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cai.Report
{
    public class BuleNextReport:IReport
    {
        static log4net.ILog LOGGER = null;
        static BuleNextReport()
        {
            if (LOGGER == null)
            {
                LOGGER = log4net.LogManager.GetLogger(typeof(BuleNextReport));
            }
        }
        public void Compute(object o)
        {
            if (o is int)
            {
                int blue = Convert.ToInt32(o);
                DoubleBoll[] allballs = DBHelper.GetALL<DoubleBoll>(MainWindow._db,new DoubleBallCompareImp());
                Dictionary<string, int> _dic = new Dictionary<string, int>();
                LOGGER.Info("=========blue:" + blue + "============");
                for (int i = 0; i < allballs.Length; i++)
                {
                    if (allballs[i].Blue == blue)
                    {
                        int next = allballs[i + 1].Blue;
                        if (_dic.ContainsKey(next.ToString()))
                        {
                            int temp = ++_dic[next.ToString()];
                            _dic[next.ToString()] = temp;
                        }
                        else
                        {
                            _dic.Add(next.ToString(), 1);
                        }
                    }
                }
                foreach (KeyValuePair<string, int> pair in _dic)
                {
                    string blueno = pair.Key;
                    string no = pair.Value.ToString();
                    LOGGER.Info("篮球：" + blueno + " 次数:" + no);
                }
                ///////
                DoubleBoll example = new DoubleBoll();
                example.Blue=blue;
                DoubleBoll[] blues = DBHelper.FindByExample<DoubleBoll>(MainWindow._db, example);
                SortedList<string, DoubleBoll> _sortedBules = new SortedList<string, DoubleBoll>();
                foreach (DoubleBoll b in blues)
                {
                    _sortedBules.Add(b.QiShu, b);
                }
                foreach (KeyValuePair<string, DoubleBoll> pair in _sortedBules)
                {
                    LOGGER.Info("期数：" + pair.Key + " info:" + pair.Value.ToString());
                }
            }
        }
    }
}
