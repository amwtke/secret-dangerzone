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
namespace cai
{
    public partial class MainWindow : Form
    {
        public static IObjectContainer _db = CommonHelper.InitDB4O("Cai.yap", typeof(DoubleBoll));
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
            if(_db==null)
                _db = CommonHelper.InitDB4O("Cai.yap", typeof(DoubleBoll));
            TextProcessToDB4OImp _textProcessImp = new TextProcessToDB4OImp(_db);
            CommonHelper.ProcessText(_textProcessImp.DataPath, _textProcessImp);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(_db.Close())
                CommonHelper.DeleteDBFile("Cai.yap");
        }

        DoubleBoll[] LoadAll()
        {
            return CommonHelper.Find<DoubleBoll>(_db,"_date");

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
                data.KaiJiangRiQi = DateTime.Parse(dataGridView1.Rows[rowIndex].Cells[1].Value.ToString());
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
            Dictionary<int, List<IDataType>> recode = CommonHelper.GetSameRecord(all,compare);
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

                        retAray = CommonHelper.Find<DoubleBoll>(_db,JoinType.And,ContainType.StartsWith,para.ToArray());
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
                            retAray = CommonHelper.Find<DoubleBoll>(_db, JoinType.And, ContainType.Like, para.ToArray());
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
            HtmlHelper.HtmlFromWebReq req = new HtmlHelper.HtmlFromWebReq(
                @"http://kaijiang.zhcw.com/zhcw/html/ssq/list_10.html", delegate(byte[] data)
                {
                    string constructedString = System.Text.Encoding.UTF8.GetString(data);
                    MessageBox.Show(constructedString); 
                });
            req.BeginCreateHtml();
        }
    }
}
