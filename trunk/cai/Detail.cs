using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cai
{
    public partial class Detail : Form
    {
        DoubleBoll _data;
        public Detail()
        {
            InitializeComponent();
        }
        public Detail(DoubleBoll data)
        {
            InitializeComponent();
            if (data != null)
            {
                _data = data;
            }
            LoadData();
        }

        private void Bt_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bt_OK_Click(object sender, EventArgs e)
        {
            LoadBack();
            Bt_Cancel.PerformClick();
        }

        void LoadData()
        {
            textbox_date.Text       = _data.OpenDate.ToString();
            textBox_fBonus.Text     = _data.TouJiang.ToString();
            textBox_fNo.Text        = _data.TouJiangZhuShu.ToString();
            textBox_qi.Text         = _data.QiShu.ToString();
            textBox_sales.Text      = _data.SaleTotal.ToString();
            textBox_seBonus.Text    = _data.ErJiang.ToString();
            textBox_seNo.Text       = _data.ErJiangZhuShu.ToString();
            textBox_thBonus.Text    = _data.SanJiang.ToString();
            textBox_thNo.Text       = _data.SanJiangZhuShu.ToString();
            Red1.Text               = _data.Red1.ToString();
            Red2.Text               = _data.Red2.ToString();
            Red3.Text               = _data.Red3.ToString();
            Red4.Text               = _data.Red4.ToString();
            Red5.Text               = _data.Red5.ToString();
            Red6.Text               = _data.Red6.ToString();
            
            Blue1.Text              = _data.Blue.ToString();
        }

        void LoadBack()
        {
            if (_data != null)
            {
                //Update
                DoubleBoll newOne = new DoubleBoll();
                newOne.OpenDate = DateTime.Parse(textbox_date.Text);
                newOne.TouJiang = int.Parse(textBox_fBonus.Text);
                newOne.TouJiangZhuShu = int.Parse(textBox_fNo.Text);
                newOne.QiShu = textBox_qi.Text;
                newOne.SaleTotal = int.Parse(textBox_sales.Text);
                newOne.ErJiang = int.Parse(textBox_seBonus.Text);
                newOne.ErJiangZhuShu = int.Parse(textBox_seNo.Text);
                newOne.SanJiang = int.Parse(textBox_thBonus.Text);
                newOne.SanJiangZhuShu = int.Parse(textBox_thNo.Text);
                newOne.Red1 = int.Parse(Red1.Text);
                newOne.Red2 = int.Parse(Red2.Text);
                newOne.Red3 = int.Parse(Red3.Text);
                newOne.Red4 = int.Parse(Red4.Text);
                newOne.Red5 = int.Parse(Red5.Text);
                newOne.Red6 = int.Parse(Red6.Text);
                newOne.Blue = int.Parse(Blue1.Text);
                DBHelper.UpdateFromDB(MainWindow._db,newOne);
            }
            else
            {
                _data = new DoubleBoll();//ADD
                _data.OpenDate = DateTime.Parse(textbox_date.Text);
                _data.TouJiang = int.Parse(textBox_fBonus.Text.Replace(",",string.Empty));
                _data.TouJiangZhuShu = int.Parse(textBox_fNo.Text);
                _data.QiShu = textBox_qi.Text;
                _data.SaleTotal = int.Parse(textBox_sales.Text.Replace(",", string.Empty));
                _data.ErJiang = int.Parse(textBox_seBonus.Text.Replace(",", string.Empty));
                _data.ErJiangZhuShu = int.Parse(textBox_seNo.Text);
                _data.SanJiang = int.Parse(textBox_thBonus.Text.Replace(",", string.Empty));
                _data.SanJiangZhuShu = int.Parse(textBox_thNo.Text.Replace(",", string.Empty));
                _data.Red1 = int.Parse(Red1.Text);
                _data.Red2 = int.Parse(Red2.Text);
                _data.Red3 = int.Parse(Red3.Text);
                _data.Red4 = int.Parse(Red4.Text);
                _data.Red5 = int.Parse(Red5.Text);
                _data.Red6 = int.Parse(Red6.Text);
                _data.Blue = int.Parse(Blue1.Text);
                DBHelper.SaveToDB(MainWindow._db, _data,true);
            }

        }
    }
}
