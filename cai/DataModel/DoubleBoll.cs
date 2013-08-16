using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cai
{
    public class DoubleBoll : IDataType
    {
        [Key("_No")]
        private string _No;
        private int _totalsale;
        private int _redOne;
        private int _redTwo;
        private int _redThree;
        private int _redFour;
        private int _redFive;
        private int _redSix;
        private int _blueBall;
        private int _firstPriceNo;
        private int _secondPriceNo;
        private int _firstPrice;
        private int _secondPrice;
        private int _thirdPireceNo;
        private int _thirdPirce;
        private string _allballs;
        private string _firstProvince;
        private DateTime _opendate;
        //public DoubleBoll(string qi, DateTime kaijiangriqi, int totalsale,
        //    int red1, int red2, int red3, int red4, int red5, int red6, int blue
        //    , int firstPriceNo, int firstPrice, int secondPriceNo, int secondPrice, int thridPriceNo, int thridPrice)
        //{
        //    _No = qi;
        //    _date = kaijiangriqi;
        //    _totalsale = totalsale;
        //    _redOne = red1;
        //    _redTwo = red2;
        //    _redThree = red3;
        //    _redFour = red4;
        //    _redFive = red5;
        //    _redSix = red6;
        //    _blueBall = blue;
        //    _firstPrice = firstPrice;
        //    _firstPriceNo = firstPriceNo;
        //    _secondPrice = secondPrice;
        //    _secondPriceNo = secondPriceNo;
        //    _thirdPirce = thridPrice;
        //    _thirdPireceNo = thridPriceNo;
        //}
        public DoubleBoll() { }
        public DateTime OpenDate
        {
            get { return _opendate; }
            set { _opendate = value; }
        }
        public string FirstProvince
        {
            get { return _firstProvince; }
            set { _firstProvince = value; }
        }
        public string QiShu
        {
            get
            {
                return _No;
            }
            set
            {
                _No = value;
            }
        }
        public int SaleTotal
        {
            get
            {
                return _totalsale;
            }
            set
            {
                _totalsale = value;
            }
        }
        public int Red1
        {
            get
            {
                return _redOne;
            }
            set
            {
                _redOne = value;
            }
        }
        public int Red2
        {
            get
            {
                return _redTwo;
            }
            set
            {
                _redTwo = value;
            }
        }
        public int Red3
        {
            get
            {
                return _redThree;
            }
            set
            {
                _redThree = value;
            }
        }
        public int Red4
        {
            get
            {
                return _redFour; 
            }
            set
            {
                _redFour = value;
            }
        }
        public int Red5
        {
            get
            {
                return _redFive;
            }
            set
            {
                _redFive = value;
            }
        }
        public int Red6
        {
            get
            {
                return _redSix;
            }
            set
            {
                _redSix = value;
            }
        }
        public int Blue
        {
            get
            {
                return _blueBall;
            }
            set
            {
                _blueBall = value;
            }
        }
        public int TouJiang
        {
            get
            {
                return _firstPrice;
            }
            set
            {
                _firstPrice = value;
            }
        }
        public int TouJiangZhuShu
        {
            get { return _firstPriceNo; }
            set { _firstPriceNo = value; }
        }
        public int ErJiang
        {
            get { return _secondPrice; }
            set { _secondPrice = value; }
        }
        public int ErJiangZhuShu
        {
            get { return _secondPriceNo; }
            set { _secondPriceNo = value; }
        }
        public int SanJiang
        {
            get { return _thirdPirce; }
            set { _thirdPirce = value; }
        }
        public int SanJiangZhuShu
        {
            get { return _thirdPireceNo; }
            set { _thirdPireceNo = value; }
        }
        public string AllBolls
        {
            get { return _allballs; }
            set { _allballs = value; }
        }
        public int GetGetSumNo()
        {
            return Red1 + Red2 + Red3 + Red4 + Red5 + Red6 + Blue;
        }

        string IDataType.key
        {
            get { return QiShu; }
        }
        public override string ToString()
        {
            return Red1.ToString() + " " + Red2.ToString() + " " + Red3.ToString() + " "
                + Red4.ToString() + " " + Red5.ToString() + " " + Red6.ToString() + " " + Blue.ToString();
        }
    }
}
