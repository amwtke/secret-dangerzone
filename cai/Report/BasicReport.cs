using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cai.Report
{
    public class BasicReport:IReport
    {
        static log4net.ILog LOGGER = null;
        static BasicReport()
        {
            if (LOGGER == null)
            {
                LOGGER = log4net.LogManager.GetLogger(typeof(BasicReport));
            }
        }
        public void Compute()
        {
            if (LOGGER.IsInfoEnabled)
            {
                DoubleBoll[] allBalls = DBHelper.GetALL<DoubleBoll>(MainWindow._db, "_No");
                if (allBalls != null && allBalls.Length > 0)
                {
                    LOGGER.Info("================================Basic Report===============================");
                    int[] Redslots = new int[33];
                    int[] Blueslots = new int[16];
                    foreach (DoubleBoll boll in allBalls)
                    {
                        Redslots[boll.Red1 - 1] += 1;
                        Redslots[boll.Red2- 1] += 1;
                        Redslots[boll.Red3 - 1] += 1;
                        Redslots[boll.Red4 - 1] += 1;
                        Redslots[boll.Red5 - 1] += 1;
                        Redslots[boll.Red6 - 1] += 1;

                        Blueslots[boll.Blue - 1] += 1;
                    }

                    for (int i = 0; i < Redslots.Length; i++)
                    {
                        LOGGER.Info("红" + (i+1).ToString() +" 共："+ Redslots[i].ToString()+"\n");
                    }

                    for (int i = 0; i < Blueslots.Length; i++)
                    {
                        LOGGER.Info("蓝" + (i+1).ToString() + " 共：" + Blueslots[i].ToString() + "\n");
                    }

                    Dictionary<int, List<string>> _redDic = new Dictionary<int, List<string>>();
                    List<int> _redCishu = new List<int>();
                    for (int i = 0; i < Redslots.Length; i++)
                    {
                        string redno = (i + 1).ToString();
                        if (_redDic.ContainsKey(Redslots[i]))
                            _redDic[Redslots[i]].Add(redno);
                        else
                        {
                            List<string> _redlist = new List<string>();
                            _redlist.Add(redno);
                            _redDic.Add(Redslots[i], _redlist);
                        }

                        if(!_redCishu.Contains(Redslots[i]))
                            _redCishu.Add(Redslots[i]);
                    }

                    Dictionary<int, List<string>> _blueDic = new Dictionary<int, List<string>>();
                    List<int> _blueCishu = new List<int>();
                    for (int i = 0; i < Blueslots.Length; i++)
                    {
                        string blueno = (i + 1).ToString();
                        if (_blueDic.ContainsKey(Blueslots[i]))
                            _blueDic[Blueslots[i]].Add(blueno);
                        else
                        {
                            List<string> _bluelist = new List<string>();
                            _bluelist.Add(blueno);
                            _blueDic.Add(Blueslots[i], _bluelist);
                        }

                        if(!_blueCishu.Contains(Blueslots[i]))
                            _blueCishu.Add(Blueslots[i]);
                    }

                    cai.Algorithm.BitMap Redsort = new Algorithm.BitMap(_redCishu);
                    Redsort.sort();

                    cai.Algorithm.BitMap Bluesort = new Algorithm.BitMap(_blueCishu);
                    Bluesort.sort();

                    LOGGER.Info("红球排序输出\n");
                    foreach (int key in _redCishu)
                    {
                        foreach (string s in _redDic[key])
                        {
                            LOGGER.Info("红:" + s+" "+key.ToString()+"\n");
                        }
                    }

                    LOGGER.Info("篮球排序输出\n");
                    foreach (int key in _blueCishu)
                    {
                        foreach (string s in _blueDic[key])
                        {
                            LOGGER.Info("蓝:" + s + " " + key.ToString() + "\n");
                        }
                    }

                        LOGGER.Info("================================END Basic Report===============================");
                }
            }
        }
    }
}
