using System;
using System.Collections.Generic;
using System.Text;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.Query;
namespace cai
{
    public class TextProcessToDB4OImp:IProcessText
    {
        IObjectContainer _db;
        ProcessLineHandler _lineHandler;
        public readonly string DataPath;
        ProcessLineHandler IProcessText.datahandler
        {
            get
            {
                return _lineHandler;
            }
        }
        public TextProcessToDB4OImp(IObjectContainer db)
        {
            _db = db;
            _lineHandler = new ProcessLineHandler(processline);
            DataPath = @"E:\cai.txt";
        }
        void processline(string str)
        {
            if (str != null && str.Length > 0)
            {
                string[] _dataSection = str.Split(new char[] { ' ','\t' });
                List<string> dataSection = new List<string>();
                foreach (string s in _dataSection)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        dataSection.Add(s);
                    }
                }
                if (dataSection.Count == 16)
                {
                    try
                    {
                        DoubleBoll _data = new DoubleBoll();
                        _data.QiShu = dataSection[0];
                        _data.KaiJiangRiQi = DateTime.Parse(dataSection[1]);
                        _data.SaleTotal = int.Parse(dataSection[2]);
                        _data.Red1 = int.Parse(dataSection[3]);
                        _data.Red2 = int.Parse(dataSection[4]);
                        _data.Red3 = int.Parse(dataSection[5]);
                        _data.Red4 = int.Parse(dataSection[6]);
                        _data.Red5 = int.Parse(dataSection[7]);
                        _data.Red6 = int.Parse(dataSection[8]);
                        _data.Blue = int.Parse(dataSection[9]);
                        _data.TouJiangZhuShu = int.Parse(dataSection[10]);
                        _data.TouJiang = int.Parse(dataSection[11]);
                        _data.ErJiangZhuShu = int.Parse(dataSection[12]);
                        _data.ErJiang = int.Parse(dataSection[13]);
                        _data.SanJiangZhuShu = int.Parse(dataSection[14]);
                        _data.SanJiang = int.Parse(dataSection[15]);
                        _data.AllBolls = dataSection[3] + " " + dataSection[4] + " " + dataSection[5] + " " + dataSection[6] + " " + dataSection[7] + " " + dataSection[8];
                        CommonHelper.SaveToDB(_db,_data);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    throw new Exception("大于16个");
                }
            }
        }
    }
}
