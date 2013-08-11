using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cai.Algorithm
{
    public class BubbleSort
    {
        List<int> _list;
        public BubbleSort(List<int> sourceList)
        {
            _list = sourceList;
        }

        public void sort()
        {
            if (_list != null && _list.Count > 0)
            {
                for (int i = 1; i < _list.Count; i++)//趟数
                {
                    for (int j = _list.Count - 1; j >= i; j--)//比较
                    {
                        if (_list[j] > _list[j - 1])
                        {
                            int a = _list[j - 1];
                            _list[j - 1] = _list[j];
                            _list[j] = a;
                        }
                    }
                }
            }
        }
    }

    public class BitMap
    {
        byte[] ByteArray;
        List<int> _array;
        static List<int> counter = new List<int>(8);

        int columns
        {
            get
            {
                return ByteArray.Length;
            }
        }

        public BitMap(List<int> orginial)
        {
            int total = GetMaxint(orginial.ToArray());
            _array = orginial;

            if (total % 8 != 0)
            {
                ByteArray = new byte[total / 8 + 1];
            }
            else
            {
                ByteArray = new byte[total / 8];
            }
        }

        int GetPow(int number)
        {
            int ret = 0;
            switch (number)
            {
                case 1:
                    ret = 128;
                    break;
                case 2:
                    ret = 64;
                    break;
                case 3:
                    ret = 32;
                    break;
                case 4:
                    ret = 16;
                    break;
                case 5:
                    ret = 8;
                    break;
                case 6:
                    ret = 4;
                    break;
                case 7:
                    ret = 2;
                    break;
                case 8:
                    ret = 1;
                    break;
            }
            return ret;
        }

        int GetNumberInByte(int number)
        {
            int ret = 0;
            switch (number)
            {
                case 1:
                    ret = 8;
                    break;
                case 2:
                    ret = 7;
                    break;
                case 3:
                    ret = 6;
                    break;
                case 4:
                    ret = 5;
                    break;
                case 5:
                    ret = 4;
                    break;
                case 6:
                    ret = 3;
                    break;
                case 7:
                    ret = 2;
                    break;
                case 8:
                    ret = 1;
                    break;
            }
            return ret;
        }

        /// <summary>
        /// 获取byte中实际位数号
        /// </summary>
        /// <param name="number"></param>
        /// <param name="pow"></param>
        protected void Mod(int number, int pow)
        {
            int pow1 = (int)System.Math.Pow(2, pow);

            if (number == 0 || pow == -1)
            {
            }
            else
            {
                if (number >= pow1)
                {
                    counter.Add(pow + 1);
                    Mod(number % pow1, pow--);
                }
                else
                {
                    pow--;
                    Mod(number, pow);
                }
            }
        }
        protected List<int> Howmany1InAByte(Byte b)
        {
            counter.Clear();
            int i = Convert.ToInt32(b);
            Mod(i, 7);
            return counter;
        }
        protected List<int> HowMany(byte b)
        {
            int temp = (int)b;
            int p = 0;
            counter.Clear();
            for (int i = 1; i <= 8; i++)
            {
                p = GetPow(i);
                if ((temp | p) == temp)
                {
                    counter.Add(i);
                }
            }
            return counter;
        }

        protected int GetMaxint(int[] Array)
        {
            int max = 0;

            if (Array != null && Array.Length > 0)
            {
                max = Array[0];
                for (int i = 1; i < Array.Length; i++)
                {
                    if (Array[i] < 0)
                    {
                        throw new Exception("No negative is allowed!");
                    }
                    if (Array[i] > max)
                    {
                        max = Array[i];
                    }
                }
            }
            else
            {
                throw new Exception("Array[] is null or empty!");
            }
            return max;
        }


        List<int> duplicateList = new List<int>();
        public void sort()
        {
            List<int> ret = new List<int>();
            bool flag = false;

            foreach (int i in _array)
            {
                int col = i / 8;
                int mod = i % 8;
                if (mod == 0)
                {
                    col -= 1;
                    mod = 8;
                }
                byte tempByte = Convert.ToByte(GetPow(mod));

                if (ByteArray[col] != 0)
                {
                    flag = false;//默认是不要去重复值
                    //List<int> t1 = Howmany1InAByte(ByteArray[col]);
                    //foreach (int ii in t1)
                    //{
                    //    /*Howmany1InAByte是从右往左数
                    //     mod是从左往右数，所以必须转换*/
                    //    if ((8 - ii + 1) == mod) { flag = true; duplicateList.Add(i); }
                    //}

                    if (((int)ByteArray[col] | (int)tempByte) == (int)ByteArray[col])
                    {
                        flag = true;
                        duplicateList.Add(i);
                    }

                    if (!flag)
                    {
                        ByteArray[col] += tempByte;
                        tempByte = 0;
                    }
                }
                else
                {
                    ByteArray[col] += tempByte;
                    tempByte = 0;
                }
            }

            for (int i = ByteArray.Length - 1; i >= 0; i--)
            {
                if (ByteArray[i] != 0)
                {
                    // List<int> t2=Howmany1InAByte(ByteArray[i]);
                    List<int> t2 = HowMany(ByteArray[i]);
                    for (int j = t2.Count - 1; j >= 0; j--)
                    {
                        ret.Add(i * 8 + t2[j]);
                        //ret.Add(i * 8 +GetNumberInByte(t2[j]));
                    }
                }
            }

            int c = 0;
            foreach (int i in ret)
            {
                _array[c] = i;
                c++;
            }
            for (; c < _array.Count; c++)
            {
                _array[c] = -1;
            }

            Console.Write("Duplicated List: ");
            foreach (int d in duplicateList)
            {
                Console.Write(d.ToString() + ", ");
            }
        }
    }
}
