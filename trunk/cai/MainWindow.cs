using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.Query;
using CSharpChartExplorer;
using HtmlAgilityPack;
namespace cai
{
    public partial class MainWindow : Form
    {
        static log4net.ILog LOGGER = null;
        static MainWindow()
        {
            if (LOGGER == null)
            {
                LOGGER = log4net.LogManager.GetLogger(typeof(MainWindow));
            }
        }
        public static IObjectContainer _db = DBHelper.InitDB4O("Cai.yap", typeof(DoubleBoll));
        DoubleBoll[] all;
        public MainWindow()
        {
            InitializeComponent();
            all = LoadAll();
            dataGridView1.DataSource = all;
            dataGridView1.Refresh();
            label1.Text = all.Length.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if(_db==null)
            //    _db = DBHelper.InitDB4O("Cai.yap", typeof(DoubleBoll));
            //TextProcessToDB4OImp _textProcessImp = new TextProcessToDB4OImp(_db);
            //DBHelper.ProcessText(_textProcessImp.DataPath, _textProcessImp);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(_db.Close())
                DBHelper.DeleteDBFile("Cai.yap");
        }

        DoubleBoll[] LoadAll()
        {
            return DBHelper.GetALL<DoubleBoll>(_db, "_No");
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Detail d = new Detail();
            d.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int rowIndex = e.RowIndex;
                DoubleBoll data = new DoubleBoll();
                data.QiShu = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                data.OpenDate = DateTime.Parse(dataGridView1.Rows[rowIndex].Cells[1].Value.ToString());
                data.SaleTotal = int.Parse(dataGridView1.Rows[rowIndex].Cells[2].Value.ToString());
                data.Red1 = int.Parse(dataGridView1.Rows[rowIndex].Cells[3].Value.ToString());
                data.Red2 = int.Parse(dataGridView1.Rows[rowIndex].Cells[4].Value.ToString());
                data.Red3 = int.Parse(dataGridView1.Rows[rowIndex].Cells[5].Value.ToString());
                data.Red4 = int.Parse(dataGridView1.Rows[rowIndex].Cells[6].Value.ToString());
                data.Red5 = int.Parse(dataGridView1.Rows[rowIndex].Cells[7].Value.ToString());
                data.Red6 = int.Parse(dataGridView1.Rows[rowIndex].Cells[8].Value.ToString());
                data.Blue = int.Parse(dataGridView1.Rows[rowIndex].Cells[9].Value.ToString());
                data.TouJiangZhuShu = int.Parse(dataGridView1.Rows[rowIndex].Cells[10].Value.ToString());
                data.TouJiang = int.Parse(dataGridView1.Rows[rowIndex].Cells[11].Value.ToString());
                data.ErJiangZhuShu = int.Parse(dataGridView1.Rows[rowIndex].Cells[12].Value.ToString());
                data.ErJiang = int.Parse(dataGridView1.Rows[rowIndex].Cells[13].Value.ToString());
                data.SanJiangZhuShu = int.Parse(dataGridView1.Rows[rowIndex].Cells[14].Value.ToString());
                data.SanJiang = int.Parse(dataGridView1.Rows[rowIndex].Cells[15].Value.ToString());

                Detail d = new Detail(data);
                d.Show();
            }
        }

        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                all = LoadAll();
                dataGridView1.DataSource = all;
                dataGridView1.Refresh();
                label1.Text = all.Length.ToString();
            }
        }

        void RefreshDataView()
        {
            all = LoadAll();
            dataGridView1.DataSource = all;
            dataGridView1.Refresh();
            label1.Text = all.Length.ToString();
        }

        void RefreshDataView(DoubleBoll[] array)
        {
            dataGridView1.DataSource = array;
            dataGridView1.Refresh();
            label1.Text = array.Length.ToString();
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                RefreshDataView();
            }
        }

        private void Bt_duplicate_Click(object sender, EventArgs e)
        {
            ICaiCompare compare = new DoubleColorCompareImp();
            Dictionary<int, List<IDataType>> recode = CommonHelper.GetSameRecord(all, compare);
            List<IDataType> data = new List<IDataType>();
            if (recode.Count > 0)
            {
                foreach (KeyValuePair<int, List<IDataType>> pair in recode)
                {
                    foreach (IDataType d in pair.Value)
                    {
                        data.Add(d);
                    }
                }

                List<DoubleBoll> data2 = new List<DoubleBoll>();
                foreach (IDataType d in data)
                {
                    data2.Add((DoubleBoll)d);
                }
                dataGridView1.DataSource = data2;
                dataGridView1.Refresh();
            }
        }

        private void tb_search_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tb_search.Text != null && tb_search.Text != string.Empty)
                {
                    DoubleBoll[] retAray;
                    string searchStr = tb_search.Text;
                    if (searchStr.StartsWith("~"))
                    {
                        searchStr = searchStr.Remove(0,1);
                        List<Dictionary<string,string>> para = new List<Dictionary<string,string>>();
                        Dictionary<string,string> dic = new Dictionary<string,string>();
                        dic.Add("_No", searchStr);
                        para.Add(dic);

                        retAray = DBHelper.Find<DoubleBoll>(_db, JoinType.And, ContainType.StartsWith, para.ToArray());
                        RefreshDataView(retAray);
                    }
                    else
                    {
                        string[]Ball = searchStr.Split(new char[]{'|'});
                        if (Ball.Length == 1)//no blue
                        {
                            string[] balls = Ball[0].Split(new char[] { ' ' });
                            List<Dictionary<string, string>> para = new List<Dictionary<string, string>>();
                            foreach (string bal in balls)
                            {
                                Dictionary<string, string> dic = new Dictionary<string, string>();
                                dic.Add("_allballs", bal);
                                para.Add(dic);
                            }
                            retAray = DBHelper.Find<DoubleBoll>(_db, JoinType.And, ContainType.Like, para.ToArray());
                            RefreshDataView(retAray);
                        }
                        else
                        {

                        }
                    }
                }
            }
        }

        private void Bt_report_Click(object sender, EventArgs e)
        {
            ChartExplorer ce = new ChartExplorer();
            ce.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CommonHelper.IsInterNetConnected())
            {
                try
                {
                    string ulrPrefix = @"http://kaijiang.zhcw.com/zhcw/html/ssq/list_";
                    string ulrSufix = @".html";
                    int total = 77;
                    int done = 0;
                    for (int i = 1; i <= total; i++)
                    {
                        string realUlr = ulrPrefix + i.ToString() + ulrSufix;
                        HtmlHelper.HtmlFromWebReq req = new HtmlHelper.HtmlFromWebReq(
                            realUlr, delegate(byte[] data)
                            {
                                string constructedString = System.Text.Encoding.UTF8.GetString(data);
                                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                                doc.LoadHtml(constructedString);
                                //HtmlAgilityPack.HtmlNode node = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/table[1]/tr[3]/td[3]");
                                HtmlAgilityPack.HtmlNodeCollection _nodes = doc.DocumentNode.SelectNodes("/html[1]/body[1]/table[1]/tr[position()>2]");
                                foreach (HtmlAgilityPack.HtmlNode no in _nodes)
                                {
                                    string s = no.InnerText;
                                    s = s.Trim().Replace(" ", "");//.Replace('\n',' ').Replace('\r',' ');//Replace(" ","|");
                                    string[] lines = s.Split(new char[] { '\r', '\n' });
                                    List<string> _infos = new List<string>();
                                    foreach (string ss in lines)
                                    {
                                        if (string.IsNullOrEmpty(ss))
                                            continue;
                                        _infos.Add(ss);
                                    }
                                    if (!(_infos.Count == 12 || _infos.Count == 13))
                                        continue;
                                    DoubleBoll temp = new DoubleBoll();
                                    string riqi = _infos[0];
                                    string qishu = _infos[1];
                                    string r1 = _infos[2];
                                    string r2 = _infos[3];
                                    string r3 = _infos[4];
                                    string r4 = _infos[5];
                                    string r5 = _infos[6];
                                    string r6 = _infos[7];
                                    string b1 = _infos[8];
                                    string allmoney = _infos[9];
                                    string fno="", fpro="", sno="";
                                    if (_infos.Count == 13)
                                    {
                                        fno = _infos[10];
                                        fpro = _infos[11];
                                        sno = _infos[12];
                                    }
                                    else if (_infos.Count == 12)
                                    {
                                        fno = _infos[10];
                                        sno = _infos[11];
                                    }

                                    string[] ymd = riqi.Split(new char[] { '-' });
                                    DateTime opendate = new DateTime(Convert.ToInt32(ymd[0]), Convert.ToInt32(ymd[1]), Convert.ToInt32(ymd[2]));
                                    temp.OpenDate = opendate;
                                    temp.Red1 = Convert.ToInt32(r1);
                                    temp.Red2 = Convert.ToInt32(r2);
                                    temp.Red3 = Convert.ToInt32(r3);
                                    temp.Red4 = Convert.ToInt32(r4);
                                    temp.Red5 = Convert.ToInt32(r5);
                                    temp.Red6 = Convert.ToInt32(r6);
                                    temp.Blue = Convert.ToInt32(b1);
                                    temp.SaleTotal = Convert.ToInt32(allmoney.Replace(",", ""));
                                    temp.TouJiangZhuShu = Convert.ToInt32(fno);
                                    temp.ErJiangZhuShu = Convert.ToInt32(sno);
                                    temp.FirstProvince = fpro;
                                    temp.QiShu = qishu;
                                    if (!DBHelper.SaveToDB(_db, temp, true))
                                        DBHelper.UpdateFromDB(_db, temp);
                                }
                                //string temp = node.InnerText;
                                done++;
                                if (done == 77)
                                    MessageBox.Show("完成");
                            });

                        req.BeginCreateHtml();
                    }
                }
                catch (Exception ex)
                {
                    LOGGER.Error("**************导入数据错误***********", ex);
                }
            }
            else
                MessageBox.Show("没有互联网！");
        }

        private void bt_myreport_Click(object sender, EventArgs e)
        {
            cai.Report.IReport b = new Report.BasicReport();
            b.Compute();
        }
    }
}
