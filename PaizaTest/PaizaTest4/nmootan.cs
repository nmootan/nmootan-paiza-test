﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PaizaTest4
{
    static class nmootan
    {


        /// <summary>
        /// 大きな数値を 3 けたごとにカンマ区切りで出力
        /// 123456789
        /// 123,456,789
        /// </summary>
        public static string ExFormatCurrency(string str)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append(str);
            //int mod = str.Length % 3;

            for (int i = 0; i < str.Length; i++)
            {
                int n = str.Length - (i * 3);
                if (n < 1) break;

                if(n<str.Length) sb.Insert(n, ",");
            }


            return sb.ToString();
        }

        /// <summary>
        /// 何桁でもLogをとれる。（未完成）
        /// </summary>
        /// <param name="str"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string ExLog(string str,double num)
        {


            return str;
        }

        /// <summary>
        /// 自然数strに含まれる素因数primeの個数を得る。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetPrimeCount(string str, string prime)
        {
            string count = "0";
            string strCopy = str.Substring(0);
            string syou;

            while (ExMod(strCopy, prime, out syou) == "0" && syou!="0")
            {
                strCopy = syou.Substring(0);
                count = ExPlus(count, "1");
                //Console.WriteLine("count={0}, strCopy={1}, syou={2}", count, strCopy,syou);
            }

            return count;
        }


        /// <summary>
        /// str1をstr2で割った余りを得る。（その商も参照可能。）（未完成）
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static string ExMod(string str1, string str2, out string syou)
        {
            //StringBuilder sb1 = new StringBuilder(str1);
            StringBuilder syouSb = new StringBuilder();
            //StringBuilder strSb = new StringBuilder();
            StringBuilder subSb = new StringBuilder();
            string str, subStr, s;
            syou = "";
            syouSb.Append(syou);

            str = str1.Substring(0, str1.Length);
            if (ExCompareTo(str, str2) == -1)
            {
                syou = "0";
                return str;
            }
            //Console.WriteLine("str={0}, syou={1}", str, syou);

            for (int i = 0; i < str1.Length; i++)
            {
                subStr = subSb.Append(str[i]).ToString();
                subStr = GetFormatZero(subStr);
                subSb.Remove(0, subSb.Length);

                //if (i + 1 > str.Length) subStr=str.Substring(0,str.Length);
                //else subStr = str.Substring(0, i+1);
                //Console.WriteLine("i={0}, str={1}, syou={2}, subStr={3}", i, str, syou, subStr);

                //if (subStr.CompareTo(str2) == -1)
                //{
                //    if (str.Length == str2.Length)
                //    {
                //        syouSb.Append("0");
                //        syou = GetFormatZero(syouSb.ToString());
                //        Console.WriteLine("syou={0}, str={1}, subStr={2}", syou, str, subStr);
                //        return str;
                //    }
                //    //else subStr = str.Substring(0, str2.Length + 1);
                //}
                //else i = -1;

                //str = str.Remove(0, subStr.Length);
                //Console.WriteLine("str={0}, subStr={1}, i={2}", str, subStr, i);
                for (int j = 1; ; j++)
                {
                    s = ExMultiply1(str2, j);
                    if (ExCompareTo(subStr, s )==-1)
                    {
                        //subStr = ExMinus(subStr, ExMultiply1(str2, j - 1));
                        
                        subSb.Append( ExMinus(subStr, ExMultiply1(str2, j - 1)));

                        //str = str.Insert(0, subStr);
                        //str = GetFormatZero(str);
                        syouSb.Append(j - 1);
                        syou = GetFormatZero( syouSb.ToString());
                        //Console.WriteLine("j-1={0}, syou={1}, str={2}, subStr={3}, i={4}", j - 1, syou,str,subStr,i);
                        break;
                    }
                }
            }

            //syou = str1;

            return subSb.ToString();
        }

        /// <summary>
        /// str1をstr2で割った余りを得る。
        /// ExMod("1023", "4")="143"
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static string ExMod(string str1, string str2)
        {

            //StringBuilder sb1 = new StringBuilder(str1);
            //StringBuilder syouSb = new StringBuilder();
            //StringBuilder strSb = new StringBuilder();
            StringBuilder subSb = new StringBuilder();
            string str, subStr, s;
            //string syou = "";
            //syouSb.Append(syou);

            str = str1.Substring(0, str1.Length);
            if (ExCompareTo(str, str2) == -1)
            {
                //syou = "0";
                return str;
            }
            //Console.WriteLine("str={0}, syou={1}", str, syou);

            for (int i = 0; i < str1.Length; i++)
            {
                subStr = subSb.Append(str[i]).ToString();
                subStr = GetFormatZero(subStr);
                subSb.Remove(0, subSb.Length);

                //if (i + 1 > str.Length) subStr=str.Substring(0,str.Length);
                //else subStr = str.Substring(0, i+1);
                //Console.WriteLine("i={0}, str={1}, syou={2}, subStr={3}", i, str, syou, subStr);

                //if (subStr.CompareTo(str2) == -1)
                //{
                //    if (str.Length == str2.Length)
                //    {
                //        syouSb.Append("0");
                //        syou = GetFormatZero(syouSb.ToString());
                //        Console.WriteLine("syou={0}, str={1}, subStr={2}", syou, str, subStr);
                //        return str;
                //    }
                //    //else subStr = str.Substring(0, str2.Length + 1);
                //}
                //else i = -1;

                //str = str.Remove(0, subStr.Length);
                //Console.WriteLine("str={0}, subStr={1}, i={2}", str, subStr, i);
                for (int j = 1; ; j++)
                {
                    s = ExMultiply1(str2, j);
                    if (ExCompareTo(subStr, s) == -1)
                    {
                        //subStr = ExMinus(subStr, ExMultiply1(str2, j - 1));

                        subSb.Append(ExMinus(subStr, ExMultiply1(str2, j - 1)));

                        //str = str.Insert(0, subStr);
                        //str = GetFormatZero(str);
                        //syouSb.Append(j - 1);
                        //syou = GetFormatZero(syouSb.ToString());
                        //Console.WriteLine("j-1={0}, syou={1}, str={2}, subStr={3}, i={4}", j - 1, syou,str,subStr,i);
                        break;
                    }
                }
            }

            //syou = str1;

            return subSb.ToString();
            ////StringBuilder sb1 = new StringBuilder(str1);
            //StringBuilder sb = new StringBuilder();
            //string str, subStr, s;
            ////syou = "";

            //str = str1.Substring(0, str1.Length);
            //for (int i = 0; i < str1.Length; i++)
            //{
            //    subStr = str.Substring(0, str2.Length);
            //    if (subStr.CompareTo(str2) == -1)
            //    {
            //        //Console.WriteLine("subStr={0}, str={1}, i={2}", subStr, str,i);
            //        if (str.Length == str2.Length) return str;
            //        else subStr = str.Substring(0, str2.Length + 1);
            //    }

            //    str = str.Remove(0, subStr.Length);

            //    for (int j = 1; j <= 9; j++)
            //    {
            //        s = ExMultiply1(str2, j);
            //        if (ExCompareTo(subStr, s) == -1)
            //        {
            //            subStr = ExMinus(subStr, ExMultiply1(str2, j - 1));
            //            str = str.Insert(0, subStr);
            //            //Console.WriteLine("j={0}, subStr={1}, str={2}", j, subStr, str);
            //            //sb.Append(j - 1);
            //            //syou = sb.ToString();
            //            break;
            //        }
            //    }
            //}

            ////syou = str1;
            ////Console.WriteLine("End");
            //return GetFormatZero( str);

        }

        /// <summary>
        /// 何桁でも整数値の大小比較を行う。
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static int ExCompareTo(string str1, string str2)
        {
            //Console.ReadLine();
            if (str1[0] == '-')
            {
                if (str2[0] == '-')
                {
                    str1 = str1.Remove(0, 1);
                    str2 = str2.Remove(0, 1);

                    if (str1.Length > str2.Length) return -1;
                    else if (str1.Length == str2.Length) return str1.CompareTo(str2) * -1;
                    else return 1;
                }
                else return -1;
            }
            else
            {
                if (str2[0] == '-') return 1;
                else
                {
                    if (str1.Length > str2.Length) return 1;
                    else if (str1.Length == str2.Length) return str1.CompareTo(str2);
                    else return -1;
                }
            }

        }


        /// <summary>
        /// 何桁でも掛け算する。
        /// 4629375*578765932
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static string ExMultiply(string str1, string str2)
        {
            int[] nums1 = GetParseStrToIntArray(str1);
            int[] nums2 = GetParseStrToIntArray(str2);
            string result = "0";
            string str3;

            for (int i = 0; i < str2.Length; i++)
            {
                str3 = ExMultiply1(str1, nums2[str2.Length- i-1]);
                for (int j = 0; j < i; j++)
                {
                    str3 = ExMultiply10(str3);
                    //Console.WriteLine("i={0}, j={1}, str3={2}", i, j, str3);
                }
                result = ExPlus(result, str3);
            }
            //Console.WriteLine("result={0}", result);
            return GetFormatZero(result);
        }


        /// <summary>
        /// 大きな年数のうるう年を判定する。
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static bool ExIsLeapYear(string year)
        {
            //string[] dw = { "Thursday", "Friday", "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday" };
            //string[] year = nmootan.GetStdStrsSplit();
            bool isLeap = false;

            if (nmootan.ExMod(year, "4") == "0")
            {

                if (nmootan.ExMod(year, "100") == "0")
                {
                    if (nmootan.ExMod(year, "400") == "0")
                    {
                        isLeap = true;
                    }
                    else isLeap = false;

                }
                else isLeap = true;
            }

            return isLeap;
        }


        /// <summary>
        /// 指定した年yearの前年までのうるう年をカウントする
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static string ExLeapCount(string year)
        {
            string div4, div100, div400;
            ExMod(nmootan.ExMinus(year, "1"), "4", out div4);
            ExMod(nmootan.ExMinus(year, "1"), "100", out div100);
            ExMod(nmootan.ExMinus(year, "1"), "400", out div400);
            string leapCount = nmootan.ExMinus(nmootan.ExPlus(div4, div400), div100);

            return leapCount;
        }


        /// <summary>
        /// 何桁の整数値でも掛け算できる。　str:数値の文字列　n:一桁の整数値
        /// </summary>
        /// <param name="str"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string ExMultiply1(string str, int n)
        {
            bool isPlus = true;
            if (str[0] == '-')
            {
                str = str.Remove(0, 1);
                isPlus = false;
            }

            str = GetMirrorStr(str);

            char[] chs = GetParseStrToCharArray(str);
            List<char> chList = new List<char>();
            List<int> intList = new List<int>();
            int m1 = 0;
            int m2 = 0;


            for (int i = 0; i < chs.Length; i++)
            {
                intList.Add(GetParseCharToInt(chs[i]));
            }

            for (int i = 0; i < chs.Length; i++)
            {
                m1 = intList[i] * n + m2;
                m2 = m1 / 10;
                chList.Add(GetParseIntToChar(m1 % 10));
            }

            if (m2 > 0) chList.Add(GetParseIntToChar(m2));

            if (!isPlus) chList.Add('-');


            return GetFormatZero(GetMirrorStr(GetParseCharListToStr(chList)));
        }

        /// <summary>
        /// 何桁でも１０倍する。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ExMultiply10(string str)
        {
            StringBuilder sb = new StringBuilder(str);

            return sb.Append('0').ToString();

            //return str.Insert(str.Length - 1, "0");
        }



        public static ulong ExPrimeCount(ulong num1, ulong num2)
        {
            ulong count = 0;
            for (ulong i = 2; i < num1+1; i++)
            {
                ulong dev = i;
                while (dev%num2==0)
                {
                    dev /= 2;
                    count++;
                }
            }

            return count;
        }


        /// <summary>
        /// 何桁の整数値でも足し算できる。　
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static string ExPlus(string str1, string str2)
        {
            //str1 = GetMirrorStr(str1);
            //str2 = GetMirrorStr(str2);

            char[] chs1 = GetParseStrToCharArray(GetMirrorStr(str1));
            char[] chs2 = GetParseStrToCharArray(GetMirrorStr(str2));
            List<char> chsList = new List<char>();
            int exN = 0;
            int n = 0;

            if (chs1.Length > chs2.Length)
            {
                for (int i = 0; i < chs2.Length; i++)
                {
                    n = GetParseCharToInt(chs1[i]) + GetParseCharToInt(chs2[i]) + exN;

                    if (n >= 10)
                    {
                        exN = 1;
                        n -= 10;
                        chsList.Add(GetParseIntToChar(n));
                    }
                    else
                    {
                        exN = 0;
                        chsList.Add(GetParseIntToChar(n));
                    }
                }

                for (int i = chs2.Length; i < chs1.Length; i++)
                {
                    n = GetParseCharToInt(chs1[i]) + exN;

                    if (n >= 10)
                    {
                        exN = 1;
                        n -= 10;
                        chsList.Add(GetParseIntToChar(n));
                    }
                    else
                    {
                        exN = 0;
                        chsList.Add(GetParseIntToChar(n));
                    }
                }
                if (exN == 1) chsList.Add('1');
            }
            if (chs1.Length < chs2.Length)
            {
                for (int i = 0; i < chs1.Length; i++)
                {
                    n = GetParseCharToInt(chs2[i]) + GetParseCharToInt(chs1[i]) + exN;

                    if (n >= 10)
                    {
                        exN = 1;
                        n -= 10;
                        chsList.Add(GetParseIntToChar(n));
                    }
                    else
                    {
                        exN = 0;
                        chsList.Add(GetParseIntToChar(n));
                    }
                }

                for (int i = chs1.Length; i < chs2.Length; i++)
                {
                    n = GetParseCharToInt(chs2[i]) + exN;

                    if (n >= 10)
                    {
                        exN = 1;
                        n -= 10;
                        chsList.Add(GetParseIntToChar(n));
                    }
                    else
                    {
                        exN = 0;
                        chsList.Add(GetParseIntToChar(n));
                    }
                }
                if (exN == 1) chsList.Add('1');
            }
            if (chs1.Length == chs2.Length)
            {
                for (int i = 0; i < chs2.Length; i++)
                {
                    n = GetParseCharToInt(chs1[i]) + GetParseCharToInt(chs2[i]) + exN;

                    if (n >= 10)
                    {
                        exN = 1;
                        n -= 10;
                        chsList.Add(GetParseIntToChar(n));
                    }
                    else
                    {
                        exN = 0;
                        chsList.Add(GetParseIntToChar(n));
                    }
                }

                if (exN == 1) chsList.Add('1');

            }

            return GetMirrorStr(GetParseCharListToStr(chsList));


        }

        /// <summary>
        /// 何桁の整数値でも引き算できる。　（未完成）
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static string ExMinus(string str1, string str2)
        {
            //str1 = GetMirrorStr(str1);
            //str2 = GetMirrorStr(str2);

            char[] chs1 = GetParseStrToCharArray(GetMirrorStr(str1));
            char[] chs2 = GetParseStrToCharArray(GetMirrorStr(str2));
            List<char> chsList = new List<char>();
            int exN = 0;
            int n = 0;
            int num1, num2;

            if (chs1.Length > chs2.Length)
            {
                for (int i = 0; i < chs2.Length; i++)
                {
                    num1 = GetParseCharToInt(chs1[i]) - exN;
                    num2 = GetParseCharToInt(chs2[i]);
                    if (num1 < 0) 
                    {
                        num1 = 9;
                        n = num1 - num2;
                        chsList.Add(GetParseIntToChar(n));
                        exN = 1;
                    } 

                    else if (num1 < num2) 
                    {
                        n = 10 + num1 - num2;
                        chsList.Add(GetParseIntToChar(n));
                        //n = GetParseCharToInt(chs1[i]) + GetParseCharToInt(chs2[i]) - exN;
                        exN = 1;
                    }

                    //if (n >= 10)
                    //{
                    //    exN = 1;
                    //    n -= 10;
                    //    chsList.Add(GetParseIntToChar(n));
                    //}
                    else
                    {
                        n = num1 - num2;
                        chsList.Add(GetParseIntToChar(n));
                        exN = 0;
                    }
                }

                for (int i = chs2.Length; i < chs1.Length; i++)
                {
                    num1 = GetParseCharToInt(chs1[i]) - exN;
                    //num2 = GetParseCharToInt(chs2[i]);

                    if(num1<0)
                    {
                        chsList.Add('9');//1000-2=998
                        exN = 1;
                    }
                    else if (num1 == 0)
                    {
                        //Console.WriteLine("num1={0}", num1);
                        exN = 0;
                        if (i == chs1.Length - 1) break;
                        else chsList.Add('0');
                        //break;10010-2=10008 //1000-2=998
                        //exN = 1;
                        //n -= 10;
                        //chsList.RemoveAt(i);
                    }
                    else
                    {
                        //Console.WriteLine("num1={0}", num1);
                        exN = 0;
                        chsList.Add(GetParseIntToChar(num1));
                    }
                }
            }
            if (chs1.Length < chs2.Length)
            {
                int num3, num4;
                for (int i = 0; i < chs1.Length; i++)
                {
                    num3 = GetParseCharToInt(chs2[i]) - exN;
                    num4 = GetParseCharToInt(chs1[i]);
                    if (num3 < 0)
                    {
                        num3 = 9;
                        n = num3 - num4;
                        chsList.Add(GetParseIntToChar(n));
                        exN = 1;
                    }

                    else if (num3 < num4)
                    {
                        n = 10 + num3 - num4;
                        chsList.Add(GetParseIntToChar(n));
                        exN = 1;
                    }

                    else
                    {
                        n = num3 - num4;
                        chsList.Add(GetParseIntToChar(n));
                        exN = 0;
                    }
                }

                for (int i = chs1.Length; i < chs2.Length; i++)
                {
                    num3 = GetParseCharToInt(chs2[i]) - exN;
                    //num4 = GetParseCharToInt(chs1[i]);

                    if (num3 < 0)
                    {
                        chsList.Add('9');//1000-2=998
                        exN = 1;
                    }
                    else if (num3 == 0)
                    {
                        exN = 0;
                        if (i == chs2.Length - 1) break;
                        else chsList.Add('0');
                        //break;10010-2=10008 //1000-2=998
                        //exN = 1;
                        //n -= 10;
                        //chsList.RemoveAt(i);
                    }
                    else
                    {
                        exN = 0;
                        chsList.Add(GetParseIntToChar(num3));
                    }
                }

                chsList.Add('-');
            }
            if (chs1.Length == chs2.Length)
            {
                if(str1.CompareTo(str2) == 1)
                {

                    for (int i = 0; i < chs2.Length; i++)
                    {
                        num1 = GetParseCharToInt(chs1[i]) - exN;
                        num2 = GetParseCharToInt(chs2[i]);
                        if (num1 < 0)
                        {
                            num1 = 9;
                            n = num1 - num2;
                            chsList.Add(GetParseIntToChar(n));
                            exN = 1;
                        }

                        else if (num1 < num2)
                        {
                            n = 10 + num1 - num2;
                            chsList.Add(GetParseIntToChar(n));
                            //n = GetParseCharToInt(chs1[i]) + GetParseCharToInt(chs2[i]) - exN;
                            exN = 1;
                        }

                        else
                        {
                            n = num1 - num2;
                            //if (n == 0 && i == str1.Length - 1) break;
                            chsList.Add(GetParseIntToChar(n));
                            exN = 0;
                        }
                    }

                }
                else if (str1.CompareTo(str2)==-1)
                {
                    int num3, num4;
                    for (int i = 0; i < chs1.Length; i++)
                    {
                        num3 = GetParseCharToInt(chs2[i]) - exN;
                        num4 = GetParseCharToInt(chs1[i]);
                        if (num3 < 0)
                        {
                            num3 = 9;
                            n = num3 - num4;
                            chsList.Add(GetParseIntToChar(n));
                            exN = 1;
                        }

                        else if (num3 < num4)
                        {
                            n = 10 + num3 - num4;
                            chsList.Add(GetParseIntToChar(n));
                            exN = 1;
                        }

                        else
                        {
                            n = num3 - num4;
                            chsList.Add(GetParseIntToChar(n));
                            exN = 0;
                        }
                    }

                    chsList.Add('-');

                }
                else
                {
                    chsList.Add('0');
                }

            }

            return GetFormatZero( GetMirrorStr(GetParseCharListToStr(chsList)));


        }

        /// <summary>
        /// 一桁のint型整数値を文字型に変換する。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static char GetParseIntToChar(int n)
        {

            return (char)(48 + n);
        }


        public static int GetParseCharToInt(char ch)
        {

            return ch - '0';
        }

        /// <summary>
        /// 文字列で与えられた数式を計算して、結果をint型で返す。（足し算、引き算のみ。int型整数値の計算のみ。）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetParseStrToIntPlusMinusResult(string str)
        {
            string[] plusStrs = nmootan.GetStrsSplitByChar(str, '+');

            //List<string> plusStrsList = new List<string>();
            //List<int> plusNumsList = new List<int>();
            //List<string[]> minusStrsList = new List<string[]>();
            int n = 0;
            int sum = 0;

            for (int i = 0; i < plusStrs.Length; i++)
            {
                string[] strs = nmootan.GetStrsSplitByChar(plusStrs[i], '-');

                if (strs.Length > 1)
                {
                    n = int.Parse(strs[0]);
                    for (int j = 1; j < strs.Length; j++)
                    {
                        n -= int.Parse(strs[j]);
                    }

                    //plusNumsList.Add(n);
                    sum += n;
                }
                else
                {
                    //plusNumsList.Add(int.Parse(plusStrs[i]));
                    sum += int.Parse(plusStrs[i]);
                }
            }

            return sum;
        }

        /// <summary>
        /// 実数 N が入力されます。N を四捨五入して小数第 n 位まで出力
        /// また、N の小数部が小数第 n 位に満たない場合は 0 で埋めて出力
        /// 7.764976 4
        /// 7.7740
        /// </summary>
        /// <param name="str"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string GetRoundFloatPointN(string str,int n)
        {

            str = nmootan.GetFormatZero(str);
            char[] chs = nmootan.GetParseStrToCharArray(str);
            StringBuilder sb = new StringBuilder();
            sb.Append(str);
            
            if (JudgeIsFloat(str))
            {
                int point = str.IndexOf('.');
                if (str.Length - 1 - point > n) 
                {
                    int r = nmootan.GetParseCharToInt(str[point + n+1]);
                    str = str.Remove(point + n + 1);
                    if (r > 4)
                    {
                        for (int i = 0; i < point+n+1; i++)
                        {
                            r = nmootan.GetParseCharToInt(str[point + n-i]) + 1;
                            if (r == 10)
                            {
                                str = nmootan.GetReplaceStrIndexIChar(str, "0", point + n-i);
                                if(point + n - i == 0) 
                                {
                                    str= str.Insert(0, "1");
                                    break;
                                }
                                else if (str[point+n-i-1]=='.')
                                {
                                    i++;
                                    //if()
                                    //str = nmootan.GetReplaceStrIndexIChar(str, (nmootan.GetParseCharToInt(str[point + n - 1-i]) + 1).ToString(), point + n - 1);
                                }
                            }
                            else
                            {
                                str = nmootan.GetReplaceStrIndexIChar(str, r.ToString(), point + n-i);
                                break;
                            }
                        }
                    } 
                    //str = str.Remove(point + n+1);
                }

                else 
                {
                    for (int i = 0; i < n - (str.Length - 1 - str.IndexOf('.')); i++)
                    {
                        sb.Append("0");
                    }
                    str = sb.ToString();
                } 
            }

            return str;
        }

        /*
                public int GetParseStrToFomula(string str)
                {
                    char[] chs = GetParseStrToCharArray(str);

                    List<int> nums = new List<int>();
                    StringBuilder sb = new StringBuilder();
                    string numStr;

                    sb.Append(chs[0]);

                    for (int i = 1; i < chs.Length; i++)
                    {
                        if(chs[i]=='+') 
                    }

                    return 
                }
        */

        /// <summary>
        /// 文字列で与えられた数値の余分な０を消す。（整数値や小数。先頭と末尾の０）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetFormatZero(string str)
        {
            List<char> chs = str.ToList<char>();
            int length = chs.Count;

            if (JudgeIsFloat(str))
            {
                for (int i = 0; i < length; i++)
                {
                    if (chs[length - 1 - i] != '0')
                    {
                        if (chs[length - 1 - i] == '.') chs.RemoveAt(length - 1 - i);
                        
                        break;
                    }
                    else chs.RemoveAt(length - 1 - i);
                }

                //length = chs.Count;
                int n = 0;
                if (chs[0] == '-') n = 1;
                for (int i = n; i < chs.Count; i++)
                {

                    if (chs[i] != '0') break;
                    else if (chs[i] == '0' && chs[i + 1] == '.') break;
                    else
                    {
                        chs.RemoveAt(i);
                        i--;
                    }
                }
            }
            else
            {
                int n = 0;
                if (chs[0] == '-') n = 1;
                for (int i = n; i < chs.Count - 1; i++)
                {

                    if (chs[i] != '0') break;
                    else if (chs[i] == '0')
                    {
                        chs.RemoveAt(i);
                        i--;
                    }
                }
            }


            return new string(chs.ToArray());
        }

        /// <summary>
        /// n桁になるように数値の先頭に空白を加える。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string GetFormatWithSpace(string str, int n)
        {
            int m = n - str.Length;
            for (int i = 0; i < m; i++)
            {
                str= str.Insert(0, " ");
            }

            return str;
        }


        /// <summary>
        /// n桁になるように数値の先頭に文字chを加える。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string GetFormatWithChar(string str, int n, char ch)
        {
            int m = n - str.Length;
            for (int i = 0; i < m; i++)
            {
                str = str.Insert(0, ch.ToString());
            }

            return str;
        }


        /// <summary>
        /// 小数かどうかを判定する。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool JudgeIsFloat(string str)
        {
            if (str.Contains(".")) return true;
            else return false;

        }

        /// <summary>
        /// 文字列に含まれる、指定した文字の重複を消す。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        public static string DistinctChar(string str, char ch)
        {
            char[] chs = GetParseStrToCharArray(str);
            List<char> chList = new List<char>();

            for (int i = 0; i < chs.Length; i++)
            {
                if (chs[i] == ch && chList.Contains(ch))
                    ;
                else chList.Add(chs[i]);
            }


            return GetParseCharListToStr(chList);
        }

        /// <summary>
        /// 文字列に含まれる全ての文字の重複を消す。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DistinctAllChar(string str)
        {
            char[] ch = GetParseStrToCharArray(str);
            List<char> chList = new List<char>();

            for (int i = 0; i < ch.Length; i++)
            {
                if (!chList.Contains(ch[i])) chList.Add(ch[i]);
            }


            return GetParseCharListToStr(chList);
        }

        /// <summary>
        /// 文字列で表された日付時間をDateTime型に変換する。（文字列の表現が違いすぎると変換できない。）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime GetParseStrToDateTime(string str)
        {
            str = GetReplaceStrNoIChar(str, " ", 11);

            Console.WriteLine(str);

            Console.ReadLine();
            //DateTime dt = DateTime.Now;

            //MyDateTime myDateTime = new MyDateTime();


            //string result = dt.ToString("yyyy/MM/dd HH:mm:ss");
            //Console.WriteLine(result);

            //result = dt.ToString("yyyy年MM月dd日 HH時mm分ss秒");
            //Console.WriteLine(result);

            //Console.ReadKey();

            return DateTime.Parse(str);
        }


        /// <summary>
        /// DateTime型に変換する。
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTime GetParseToDateTime(int year, int month, int day)
        {
            string str = year + "/" + month + "/" + day;

            return DateTime.Parse(str);
        }

        /// <summary>
        /// 英語の曜日を日、月、火、水、木、金、土に変換する。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetTranslateDayOfWeek(string name)
        {
            string result = "";

            switch (name)
            {
                case "Sunday":
                    result = "日";
                    break;
                case "Monday":
                    result = "月";
                    break;
                case "Tuesday":
                    result = "火";
                    break;
                case "Wednesday":
                    result = "水";
                    break;
                case "Thursday":
                    result = "木";
                    break;
                case "Friday":
                    result = "金";
                    break;
                case "Saturday":
                    result = "土";
                    break;
                default:
                    break;
            }

            return result;
        }

        /// <summary>
        /// 何桁でもその年の日付の曜日を得る。
        /// 9999999992 2 29
        /// 土曜日
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static string GetExDayOfWeekByZeller(string year, string month, string day)
        {
            if (month == "1")
            {
                month = "13";
                year = ExMinus(year, "1");
            }
            if (month=="2")
            {
                month = "14";
                year = ExMinus(year, "1");
            }

            string[] dw = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            string div4, div100, div400;
            ExMod(year, "4", out div4);
            ExMod(year, "100", out div100);
            ExMod(year, "400", out div400);
            Console.WriteLine("div4={0}, div100={1}, div400={2}", div4, div100, div400);

            int mod = int.Parse(ExMod(ExPlus(ExPlus(ExPlus(ExMinus(ExPlus(year, div4), div100), div400), ((13 * int.Parse(month) + 8) / 5).ToString()), day), "7"));


            return GetTranslateDayOfWeek(dw[mod]);
        }


        /// <summary>
        /// 何桁でもその年の日付の曜日を得る。（未完成）
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetExDayOfWeekByDoomsday(string year, string month, string day)
        {
            string result = "";
            //Dictionary<int,string> dow = { {0,"" },{1,"" },{2, ""},{3,"" },{4,"" },{5,"" },{6,"" } }
            string[] dw = { "Sunday", "Saturday", "Friday", "Thursday", "Wednesday", "Tuesday", "Monday" };

            int[] dd = { 3, 28, 7, 4, 9, 6, 11, 8, 5, 10, 7, 12 };
            const string YEAR = "2200";
            string sub, sub1;
            int num, num1;

            if (GetExIsLeapYear(year))
            {
                dd[0] = 4;
                dd[1] = 29;
            }
            if (ExCompareTo(year, YEAR)>-1)
            {
                int mod = int.Parse(ExMod(year, "100"));
                if( mod%2 == 1)
                {
                    mod += 11;
                }
                mod /= 2;
                if (mod==1)
                {
                    mod += 11;
                }
                mod %= 7;


                sub = ExMinus(year, YEAR);
                sub1= ExMod(sub, "100", out sub);
                Console.WriteLine("sub={0}, ExMod={1}", sub, ExMod(sub, "7"));
                Console.ReadLine();
                num = (mod + 7 - int.Parse(ExMod(sub, "7"))) % 7;

                num1 = dd[int.Parse(month) - 1];
                if (int.Parse( day)>=num1)
                {
                    num += (int.Parse( day) - num1) % 7;
                    num %= 7;
                    result = GetTranslateDayOfWeek(dw[num]);
                }
                else
                {
                    num += (num1 - int.Parse( day)) % 7;
                    num %= 7;
                    result = GetTranslateDayOfWeek(dw[num]);
                }
            }
            else
            {
                DateTime dt = GetParseToDateTime(int.Parse(year), int.Parse(month), int.Parse(day));
                result = GetTranslateDayOfWeek( dt.DayOfWeek.ToString());
            }

            return result+"曜日";
        }


        /// <summary>
        /// 文字列をミラー変換して返す。（文字の並び順を逆さまにする。）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMirrorStr(string str)
        {
            char[] cs = str.ToCharArray();
            char[] mirror = new char[cs.Length];

            int i = cs.Length - 1;
            int length = i;
            while (i >= 0)
            {
                mirror[length - i] = cs[i];

                i--;
            }

            return new string(mirror);
        }


        public static int[] GetParseStrToIntArray(string str)
        {
            int[] nums = new int[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                nums[i] = int.Parse(str[i].ToString());
            }

            return nums;
        }


        public static string GetParseCharListToStr(List<char> chList)
        {

            return new string(chList.ToArray());
        }

        /// <summary>
        /// 与えられた文字列の全ての文字の大文字を小文字に、小文字を大文字に変換する。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetSwithCharsInStr(string str)
        {
            //Char型の配列にする
            char[] cs = str.ToCharArray();
            for (int i = 0; i < cs.Length; i++)
            {
                //大文字か調べる
                if (char.IsUpper(cs[i]))
                {
                    //小文字にする
                    cs[i] = char.ToLower(cs[i]);
                }
                //小文字か調べる
                else if (char.IsLower(cs[i]))
                {
                    //大文字にする
                    cs[i] = char.ToUpper(cs[i]);
                }
            }
            //String型にする
            return new string(cs);

        }


        public static char[] GetParseStrToCharArray(string str)
        {

            return str.ToCharArray();
        }

        /// <summary>
        /// 文字列の全ての文字を小文字に変換する。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetStdLowerStr(string str)
        {

            //現在のカルチャのTextInfoを取得する
            System.Globalization.TextInfo ti =
                System.Globalization.CultureInfo.CurrentCulture.TextInfo;

            return ti.ToLower(str);
        }

        /// <summary>
        /// 文字列の全ての文字を大文字に変換する。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetStdUpperStr(string str)
        {

            //現在のカルチャのTextInfoを取得する
            System.Globalization.TextInfo ti =
                System.Globalization.CultureInfo.CurrentCulture.TextInfo;

            return ti.ToUpper(str);
        }

        /// <summary>
        /// 文字列strのi-1番目の一文字を文字列chで置き換える。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ch"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string GetReplaceStrNoIChar(string str, string ch, int i)
        {
            StringBuilder sb = new StringBuilder(str);

            sb.Remove(i - 1, 1);
            sb.Insert(i - 1, ch);

            return sb.ToString();
        }


        /// <summary>
        /// 文字列strのインデックス番号iの一文字を文字列str1で置き換える。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ch"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string GetReplaceStrIndexIChar(string str, string str1, int i)
        {
            StringBuilder sb = new StringBuilder(str);

            sb.Remove(i, 1);
            sb.Insert(i, str1);

            return sb.ToString();
        }


        /// <summary>
        /// 文字列strのインデックス番号iから長さlengthの文字列を文字列chで置き換える。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ch"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string GetReplaceCharIndexIInStr(string str, string ch, int i, int length)
        {
            StringBuilder sb = new StringBuilder(str);

            sb.Remove(i, length);
            sb.Insert(i, ch);

            return sb.ToString();
        }

        /// <summary>
        /// n回標準入力から入力した文字列を順に全てつなぎ合わせた文字列を返す。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string AppendNStdStrs(int n)
        {
            List<string> strs = new List<string>();

            for (int i = 0; i < n; i++)
            {
                strs.Add(Console.ReadLine());
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                sb.Append(strs[i]);
            }


            return sb.ToString();
        }

        /// <summary>
        /// 標準入力した文字列と、指定した文字列が一致したら"YES"、不一致なら"NO"を標準出力する
        /// </summary>
        /// <param name="s"></param>
        public static void EqualStd(string s)
        {

            string std = Console.ReadLine();
            if (Equals(s, std)) Console.WriteLine("YES");
            else Console.WriteLine("NO");
        }


        /// <summary>
        /// 文字列str1のうち、文字列str2が現れるインデックス番号を返す。
        /// </summary>
        public static int GetFindStrInStr(string str1, string str2)
        {

            //string str1 = Console.ReadLine();
            //string str2 = Console.ReadLine();

            return str1.IndexOf(str2);
        }

        /// <summary>
        /// 文字列sのi番目の文字を返す。
        /// </summary>
        /// <param name="i"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static char GetICharInString(int i, string s)
        {
            return s[i - 1];
        }

        /// <summary>
        /// 文字列sのインデックス番号iの文字を返す。
        /// </summary>
        /// <param name="i"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static char GetIndexICharInString(int i, string s)
        {
            return s[i - 1];
        }

        /// <summary>
        /// 文字列sのi番目の文字を標準出力する
        /// </summary>
        /// <param name="i"></param>
        /// <param name="s"></param>
        public static void ShowICharInString(int i, string s)
        {
            Console.WriteLine(s[i - 1]);
        }


        /// <summary>
        /// 標準入力をint型に変換して返す。
        /// </summary>
        /// <returns></returns>
        public static int GetStdNum()
        {

            return int.Parse(Console.ReadLine());


        }


        /// <summary>
        /// n行の文字列を標準入力して、それぞれの行を3文字目以降から標準出力する。
        /// </summary>
        public static void StdNMatrix()
        {
            int n = int.Parse(Console.ReadLine());

            string[][] line = new string[n][];
            StringBuilder[] sb = new StringBuilder[n];
            //List<List<string[]>> strList = new List<List<string[]>>();
            //string[] lines = new string[n];

            for (int i = 0; i < n; i++)
            {
                //lines[i] = Console.ReadLine();
                sb[i] = new StringBuilder();

                line[i] = System.Console.ReadLine().Trim().Split(' ');
                for (int j = 1; j < line[i].Length - 1; j++)
                {
                    sb[i].Append(line[i][j]);
                    sb[i].Append(" ");
                }
                sb[i].Append(line[i][line[i].Length - 1]);
            }
            for (int i = 0; i < sb.Length; i++)
            {
                Console.WriteLine(sb[i].ToString());
            }
            //for (int j = 0; j < n; j++)
            //{
            //    //Console.WriteLine(lines[j].Substring(2, lines[j].Length-2));
            //    //for (int i = 2; i < lines[j].Length; i++)
            //    //{
            //    //    Console.Write(lines[j][i].ToString());
            //    //}
            //    //Console.WriteLine();
            //}
        }

        /// <summary>
        /// 九九表を表示する。
        /// </summary>
        public static void Matrix99()
        {

            //List<int> ints = nmootan.GetStrSplitToIntList(Console.ReadLine());


            int[][] rect99 = new int[9][];
            for (int i = 0; i < rect99.Length; i++)
            {
                rect99[i] = new int[9];
            }

            //int k = 0;
            for (int i = 0; i < rect99.Length; i++)
            {
                for (int j = 0; j < rect99[i].Length; j++)
                {
                    rect99[i][j] = (i+1)*(j+1);
                }
            }
            //rect33[0][0] = 0; rect33[0][1] = 8; rect33[1][0] = 1; rect33[1][1] = 3;

            //string[] strs = new string[rect22.Length];

            for (int i = 0; i < rect99.Length; i++)
            {
                Console.WriteLine(nmootan.GetJoinIntArrayToStrByStr(rect99[i], " "));

            }

        }



        /// <summary>
        /// 自然数 N が入力されます。N 行 N 列の九九表を出力してください。具体的には、出力の i 行 j 列目 (1 ≦ i, j ≦ N ) の数値は i * j になるように出力してください。
        /// ただし、数値の間には半角スペースを、各行の末尾には、半角スペースの代わりに改行を入れてください。
        /// </summary>
        public static void MatrixNN()
        {
            int n = GetStdInt();
            //List<int> ints = nmootan.GetStrSplitToIntList(Console.ReadLine());


            int[][] rectNN = new int[n][];
            for (int i = 0; i < rectNN.Length; i++)
            {
                rectNN[i] = new int[n];
            }

            for (int i = 0; i < rectNN.Length; i++)
            {
                for (int j = 0; j < rectNN[i].Length; j++)
                {
                    rectNN[i][j] = (i + 1) * (j + 1);
                }
            }
            //rect33[0][0] = 0; rect33[0][1] = 8; rect33[1][0] = 1; rect33[1][1] = 3;

            //string[] strs = new string[rect22.Length];

            for (int i = 0; i < rectNN.Length; i++)
            {
                Console.WriteLine(nmootan.GetJoinIntArrayToStrByStr(rectNN[i], " "));

            }

        }


        /// <summary>
        /// n行n列の九九表を、横の数値間ではstr1、縦の数値間ではstr2で区切って出力。
        /// ただし、数値を出力する際は m けたになるよう半角スペース埋めで出力します。また、縦の数値間でstr2を出力する際は、その上の行と文字数が等しくなるように出力します。
        ///  3 |  6 |  9 | 12 | 15 | 
        ///  = |  = |  = | == | == | 
        ///  4 |  8 | 12 | 16 | 20 | 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        public static void MatrixNNRestoreFormat(int n, int m, string str1, string str2)
        {
            //int n = GetStdInt();
            //List<int> ints = nmootan.GetStrSplitToIntList(Console.ReadLine());
            //str1 = "=";
            //str2 = " | ";

            int[][] rectNN = new int[n][];
            string[][] rectStrNN = new string[n*2][]; 
            for (int i = 0; i < rectNN.Length; i++)
            {
                rectNN[i] = new int[n];
                rectStrNN[i * 2] = new string[n];
                rectStrNN[i * 2 + 1] = new string[n];
            }

            for (int i = 0; i < rectNN.Length; i++)
            {
                for (int j = 0; j < rectNN[i].Length; j++)
                {
                    rectNN[i][j] = (i + 1) * (j + 1);
                    rectStrNN[i * 2][j] = GetFormatWithChar(rectNN[i][j].ToString(), m, ' ');
                    rectStrNN[i * 2 + 1][j] = Regex.Replace(rectNN[i][j].ToString(), ".", str2);
                    rectStrNN[i * 2 + 1][j] = GetFormatWithChar(rectStrNN[i * 2 + 1][j], m, ' ');
                }
            }
            //rect33[0][0] = 0; rect33[0][1] = 8; rect33[1][0] = 1; rect33[1][1] = 3;

            string[] strs = new string[n*2];

            for (int i = 0; i < rectNN.Length; i++)
            {


                strs[i * 2] = nmootan.GetJoinStrArrayToStrByStr(rectStrNN[i * 2], str1);
                Console.WriteLine(strs[i * 2]);
                if (i == rectNN.Length - 1) break;
                strs[i * 2 + 1] = nmootan.GetJoinStrArrayToStrByStr(rectStrNN[i * 2 + 1], str1);
                Console.WriteLine(strs[i * 2 + 1]);
            }



        }



        /// <summary>
        /// n行n列の九九表を、横の数値間ではstr1、縦の数値間ではstr2で区切って出力。
        /// ただし、数値を出力する際は m けたになるよう半角スペース埋めで出力します。また、縦の数値間でstr2を出力する際は、その上の行と文字数が等しくなるように出力します。
        ///  3 |  6 |  9 | 12 | 15 | 
        /// ======================== 
        ///  4 |  8 | 12 | 16 | 20 | 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        public static void MatrixNNRestoreFormat2(int n, int m, string str1, string str2)
        {
            //int n = GetStdInt();
            //List<int> ints = nmootan.GetStrSplitToIntList(Console.ReadLine());
            //str1 = "=";
            //str2 = " | ";

            int[][] rectNN = new int[n][];
            string[][] rectStrNN = new string[n * 2][];
            for (int i = 0; i < rectNN.Length; i++)
            {
                rectNN[i] = new int[n];
                rectStrNN[i * 2] = new string[n];
                rectStrNN[i * 2 + 1] = new string[n];
            }

            for (int i = 0; i < rectNN.Length; i++)
            {
                for (int j = 0; j < rectNN[i].Length; j++)
                {
                    rectNN[i][j] = (i + 1) * (j + 1);
                    rectStrNN[i * 2][j] = GetFormatWithChar(rectNN[i][j].ToString(), m, ' ');
                    //rectStrNN[i * 2 + 1][j] = GetFormatWithChar(rectNN[i][j].ToString(), m, ' ');
                    //rectStrNN[i * 2 + 1][j] = Regex.Replace(rectNN[i][j].ToString(), ".", str2);
                }
            }
            //rect33[0][0] = 0; rect33[0][1] = 8; rect33[1][0] = 1; rect33[1][1] = 3;

            string[] strs = new string[n * 2];

            for (int i = 0; i < rectNN.Length; i++)
            {


                strs[i * 2] = nmootan.GetJoinStrArrayToStrByStr(rectStrNN[i * 2], str1);
                Console.WriteLine(strs[i * 2]);
                if (i == rectNN.Length - 1) break;
                strs[i * 2 + 1] = Regex.Replace(strs[i * 2], ".", str2);
                Console.WriteLine(strs[i * 2 + 1]);
            }



        }



        /// <summary>
        /// n行n列の九九表を、横の数値間ではstr1、縦の数値間ではstr2で区切って出力。
        /// ただし、数値を出力する際は m けたになるよう半角スペース埋めで出力します。また、縦の数値間でstr2を出力する際は、その上の行と文字数が等しくなるように出力します。
        ///  3 |  6 |  9 | 12 | 15 | 
        /// ======================== 
        ///  4 |  8 | 12 | 16 | 20 | 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        public static void MatrixNNRestoreFormat3(int n, int m, string str1, string str2)
        {
            //int n = GetStdInt();
            //List<int> ints = nmootan.GetStrSplitToIntList(Console.ReadLine());
            //str1 = "=";
            //str2 = " | ";

            int[][] rectNN = new int[n][];
            string[][] rectStrNN = new string[n * 2][];
            for (int i = 0; i < rectNN.Length; i++)
            {
                rectNN[i] = new int[n];
                rectStrNN[i * 2] = new string[n];
                rectStrNN[i * 2 + 1] = new string[n];
            }

            for (int i = 0; i < rectNN.Length; i++)
            {
                for (int j = 0; j < rectNN[i].Length; j++)
                {
                    rectNN[i][j] = (i + 1) * (j + 1);
                    rectStrNN[i * 2][j] = GetFormatWithChar(rectNN[i][j].ToString(), m, ' ');
                    //rectStrNN[i * 2 + 1][j] = GetFormatWithChar(rectNN[i][j].ToString(), m, ' ');
                    //rectStrNN[i * 2 + 1][j] = Regex.Replace(rectNN[i][j].ToString(), ".", str2);
                }
            }
            //rect33[0][0] = 0; rect33[0][1] = 8; rect33[1][0] = 1; rect33[1][1] = 3;

            string[] strs = new string[n * 2];

            for (int i = 0; i < rectNN.Length; i++)
            {


                strs[i * 2] = nmootan.GetJoinStrArrayToStrByStr(rectStrNN[i * 2], str1);
                Console.WriteLine(strs[i * 2]);
                if (i == rectNN.Length - 1) break;
                strs[i * 2 + 1] = "==========================================";
                Console.WriteLine(strs[i * 2 + 1]);
            }



        }


        /// <summary>
        /// 配列str[][]をマトリックス表示する。、横の数値間ではstr1、縦の数値間ではstr2で区切って出力。
        /// ただし、縦の数値間でstr2を出力する際は、その上の行と文字数が等しくなるように出力します。
        ///  3 |  6 |  9 | 12 | 15 | 
        /// ======================== 
        ///  4 |  8 | 12 | 16 | 20 | 
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        public static void MatrixStrArrayFormat(string[][] str, string str1, string str2)
        {
            //int n = GetStdInt();
            //List<int> ints = nmootan.GetStrSplitToIntList(Console.ReadLine());
            //str1 = "=";
            //str2 = " | ";

            //int[][] rectNN = new int[n][];
            //string[][] rectStrNN = new string[str.Length * 2][];
            //for (int i = 0; i < str.Length; i++)
            //{
            //    //rectNN[i] = new int[n];
            //    rectStrNN[i * 2] = new string[str[i*2].Length];
            //    rectStrNN[i * 2 + 1] = new string[str[i * 2].Length];
            //}

            //for (int i = 0; i < str.Length; i++)
            //{
            //    for (int j = 0; j < str[i].Length; j++)
            //    {
            //        rectStrNN[i * 2][j] = str[i][j];
            //        //rectStrNN[i * 2+1][j] = GetFormatWithChar(rectNN[i][j].ToString(), m, ' ');
            //        //rectStrNN[i * 2 + 1][j] = GetFormatWithChar(rectNN[i][j].ToString(), m, ' ');
            //        //rectStrNN[i * 2 + 1][j] = Regex.Replace(rectNN[i][j].ToString(), ".", str2);
            //    }
            //}
            //rect33[0][0] = 0; rect33[0][1] = 8; rect33[1][0] = 1; rect33[1][1] = 3;

            string[] strs = new string[str.Length * 2];

            for (int i = 0; i < str.Length; i++)
            {
                //strs[i * 2] = nmootan.GetJoinStrArrayToStrByStr(rectStrNN[i * 2], str1);
                strs[i * 2] = nmootan.GetJoinStrArrayToStrByStr(str[i], str1);
                Console.WriteLine(strs[i * 2]);
                if (i == str.Length - 1) break;
                strs[i * 2 + 1] = Regex.Replace(strs[i * 2], ".", str2);
                Console.WriteLine(strs[i * 2 + 1]);
            }

        }


        /// <summary>
        /// 行数nを指定して、続けて下記文字列をn行標準入力して、マトリックスに変換する
        /// m_{1, 1} m_{1, 2} ... m_{1, N}
        /// m_{2, 1} m_{2, 2} ... m_{2, N}
        /// ...
        /// m_{N, 1} m_{N, 2} ... m_{N, N}
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[][] GetParseStdStrToMatrix(int n)
        {
            
            /*
            N
            m_{1, 1} m_{1, 2} ... m_{1, N}
            m_{2, 1} m_{2, 2} ... m_{2, N}
            ...
            m_{N, 1} m_{N, 2} ... m_{N, N}

                        */

            //int n = int.Parse(Console.ReadLine());
            int[][] matrix = new int[n][];
            //n行x列のマトリックスをn行の入力から作成
            for (int i = 0; i < n; i++)
            {
                matrix[i] = GetStdIntSplit().ToArray();
            }


            return matrix;
        }


        /// <summary>
        /// 下記文字列の形式の文字列配列を、マトリックスに変換する
        /// m_{1, 1} m_{1, 2} ... m_{1, N}
        /// m_{2, 1} m_{2, 2} ... m_{2, N}
        /// ...
        /// m_{N, 1} m_{N, 2} ... m_{N, N}
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static int[][] GetParseStdStrToMatrix(string[] strs)
        {

            /*
            m_{1, 1} m_{1, 2} ... m_{1, N}
            m_{2, 1} m_{2, 2} ... m_{2, N}
            ...
            m_{N, 1} m_{N, 2} ... m_{N, N}

                        */

            int[][] matrix = new int[strs.Length][];
            //n行x列のマトリックスをn行の文字列から作成
            for (int i = 0; i < strs.Length; i++)
            {
                matrix[i] = GetStrSplitToIntList(strs[i]).ToArray();
            }

            return matrix;
        }


        /// <summary>
        /// 指定したマトリックスを、スペース区切りで標準出力する
        /// </summary>
        /// <param name="matrix"></param>
        public static void ShowMatrix(int[][] matrix)
        {
            //マトリックスを表示する
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(GetJoinIntArrayToStrByStr(matrix[i], " ") + "\n");
            }
        }


        /// <summary>
        /// 指定したマトリックスのインデックス番号rawIndex列の合計を得る（縦方向の合計）
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static int GetRawSumInMatrix(int[][] matrix, int rawIndex)
        {
            //塗りつぶしのある2列の合計をそれぞれ得る
            int sum = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                sum += matrix[i][rawIndex];
            }

            return sum;
        }


        public static void RegexNormalizeTest()
        {
            string str = "afeighre1234";

            str = Regex.Replace(str, ".", "=");

            Console.WriteLine(str);

        }


        public static void SubstringTest()
        {
            string str = "1 2 3 4 5 6 7";

            Console.WriteLine(str.Substring(2, str.Length - 2));

        }

        /// <summary>
        /// 文字列strのインデックス番号iから末尾までを抜き出して返す。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="i"></param>
        public static void SubstringIndexIToEnd(string str, int i)
        {
            //string str = "1 2 3 4 5 6 7";

            Console.WriteLine(str.Substring(i, str.Length - i));

        }


        public static int GetStdInt()
        {

            return int.Parse(Console.ReadLine());
        }

        public static void StdInt()
        {

            int n = int.Parse(Console.ReadLine());
        }

        public static void StdNLines2()
        {
            int n = int.Parse(Console.ReadLine());
            string[] line = new string[n];

            for (int i = 0; i < n; i++)
            {
                line[i] = Console.ReadLine();

            }

            for (int i = 0; i < line.Length; i++)
            {
                Console.WriteLine(line[i]);
            }
        }

        public static void StdNLines3()
        {
            int n = int.Parse(Console.ReadLine());
            string[] line = new string[n];

            for (int i = 0; i < n; i++)
            {
                line[i] = Console.ReadLine();

            }

            Console.WriteLine(line[7]);
        }

        /// <summary>
        /// 指定した行数だけ標準入力して、そのまま標準出力
        /// </summary>
        /// <param name="n"></param>
        public static void StdNLines(int n)
        {
            string[] line = new string[n];

            for (int i = 0; i < n; i++)
            {
                line[i] = Console.ReadLine();

            }

            for (int i = 0; i < line.Length; i++)
            {
                Console.WriteLine(line[i]);
            }
        }


        public static void StdSplit2()
        {
            string[] strs = "Hello paiza".Trim().Split(' ');

            for (int i = 0; i < strs.Length; i++)
            {
                Console.WriteLine(strs[i]);
            }
        }

        public static void StdSplit3()
        {
            int n = int.Parse(Console.ReadLine());

            string[] strs = System.Console.ReadLine().Trim().Split(' ');

            for (int i = 0; i < strs.Length; i++)
            {
                Console.WriteLine(strs[i]);
            }
        }

        public static void StdSplit4()
        {
            string[] strs = System.Console.ReadLine().Trim().Split(' ');

            for (int i = 1; i < strs.Length; i++)
            {
                Console.WriteLine(strs[i]);
            }
        }

        /// <summary>
        /// 標準入力の文字列をスペースで区切って、1行ずつ標準出力する
        /// </summary>
        public static void StdSplit()
        {
            string[] strs = System.Console.ReadLine().Trim().Split(' ');

            for (int i = 0; i < strs.Length; i++)
            {
                Console.WriteLine(strs[i]);
            }
        }


        public static void StdSplitConma()
        {
            string[] strs = System.Console.ReadLine().Trim().Split(',');

            for (int i = 0; i < strs.Length; i++)
            {
                Console.WriteLine(strs[i]);
            }
        }

        /// <summary>
        /// 文字列を','でスプリットする。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string[] GetStrSplitConma(string str)
        {
            return str.Trim().Split(',');

            
        }



        public static string[] GetStdStrsSplit()
        {

            return System.Console.ReadLine().Trim().Split(' ');
        }


        /// <summary>
        /// n行の標準入力を得る
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string[] GetStdNRaws(int n)
        {
            string[] strs = new string[n];

            for (int i = 0; i < n; i++)
            {
                strs[i] = Console.ReadLine();
            }

            return strs;
        }


        public static List<int> GetStdIntSplit()
        {
            string[] strs = GetStdStrsSplit();

            List<int> iList = new List<int>();

            for (int i = 0; i < strs.Length; i++)
            {
                iList.Add(int.Parse(strs[i]));
            }

            return iList;
        }

        /// <summary>
        /// 文字列を空白でスプリットして、int型リストを返す。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<int> GetStrSplitToIntList(string str)
        {
            string[] strs = str.Trim().Split(' ');

            List<int> iList = new List<int>();

            for (int i = 0; i < strs.Length; i++)
            {
                iList.Add(int.Parse(strs[i]));
            }

            return iList;
        }


        /// <summary>
        /// 文字列strを文字chでスプリットする。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        public static string[] GetStrsSplitByChar(string str, char ch)
        {

            return str.Trim().Split(ch);
        }

        /// <summary>
        /// 文字列strを文字列str2でスプリットする。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static string[] GetStrsSplitByStr(string str, string str2)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(str);
            sb.Replace(str2, " ");

            //char[] chs = GetParseStrToCharArray(str2);

            //return str.Trim().Split(chs);

            return sb.ToString().Trim().Split(' ');
        }

        /// <summary>
        /// n行の標準入力から、マトリックスを得る。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string[][] GetStdMatrix(int n)
        {
            string[][] strs = new string[n][];

            for (int i = 0; i < n; i++)
            {
                strs[i] = nmootan.GetStdStrsSplit();
            }

            //nmootan.MatrixStrArrayFormat(strs, " ", "");
            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine(nmootan.GetJoinStrArrayToStrByStr(strs[i], " "));
            //}


            return strs;
        }


        /// <summary>
        /// n行の標準入力から、マトリックスを得る。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[][] GetStdIntMatrix(int n)
        {
            int[][] ns = new int[n][];

            for (int i = 0; i < n; i++)
            {
                ns[i] = nmootan.GetStdIntSplit().ToArray();
            }

            //nmootan.MatrixStrArrayFormat(strs, " ", "");
            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine(nmootan.GetJoinStrArrayToStrByStr(strs[i], " "));
            //}


            return ns;
        }


        /// <summary>
        /// 文字列の長さで昇順に並び替える
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static string[] GetSortStrArrayByLength(string[] strs)
        {
            //並び替えを行う配列
            //string[] strs = new string[] { "b", "aaaaa", "cc" };

            //並び替えの対象となる配列を作成
            int[] keys = new int[strs.Length];
            for (int i = 0; i < keys.Length; i++)
            {
                //文字列の長さを格納する
                keys[i] = strs[i].Length;
            }

            //keysに基づいて、strsの並び替えを行う
            Array.Sort(keys, strs);

            return strs;
        }


        /// <summary>
        /// 文字の出現回数をカウント
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int GetCountCharInStr(string s, char c)
        {
            return s.Length - s.Replace(c.ToString(), "").Length;
        }


        /// <summary>
        /// マトリックスの逆行列を得る。
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static int[][] GetTranspose(int[][] matrix)
        {
            int[][] matrixCopy = new int[matrix[0].Length][];

            for (int i = 0; i < matrix[0].Length; i++)
            {
                matrixCopy[i] = new int[matrix.Length];
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrixCopy[j][i] = matrix[i][j];
                }

            }

            return matrixCopy;
        }

        /// <summary>
        /// 自然数nの素数を得る。（nは２以上）
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[] GetPrimeNum(int n)
        {
            List<int> primes = new List<int>();

            if (n == 2)
            {
                primes.Add(2);
                return primes.ToArray();
            }
            else
            {
                primes.Add(2);
                primes.Add(3);
                if(n==3) return primes.ToArray();
            }

            for (int i = 4; i <= n; i++)
            {
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0) break;
                    if (j == i - 1) primes.Add(i);
                }

            }

            return primes.ToArray();
        }

        /// <summary>
        /// 階乗を得る。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ExFact(string str)
        {
            string fact = "1";
            //ulong n = ulong.Parse(str);
            string numStr = "0";

            while (ExCompareTo(str,numStr)>0)
            {
                numStr = ExPlus(numStr, "1");
                fact = ExMultiply(fact, numStr);
                //Console.WriteLine("i={0}, fact={1}",i,fact);
            }
            //for (ulong i = 1; i <= n; i++)
            //{
            //}

            return fact;
        }


        /// <summary>
        /// int型配列の要素を文字列strを挟んでつないで、文字列で返す。
        /// </summary>
        /// <param name="ints"></param>
        /// <returns></returns>
        public static string GetJoinIntArrayToStrByStr(int[] ints, string str)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < ints.Length-1; i++)
            {
                sb.Append(ints[i]);
                sb.Append(str);
            }

            sb.Append(ints[ints.Length - 1]);
            //sb.Append(Environment.NewLine);

            return sb.ToString().Trim();
        }


        /// <summary>
        /// int配列の指定した２つのインデックス番号の要素を入れ替える。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        /// <returns></returns>
        public static int[] GetReplaceMembersInIntArray(int[] array, int index1, int index2)
        {
            //int[] xy = { array[index1], array[index2] };
            //int[] xy = nmootan.GetStdIntSplit().ToArray();
            int[] copy = new int[array.Length];
            array.CopyTo(copy, 0);

            //for (int i = 0; i < copy.Length; i++)
            //{
            //    Console.WriteLine(copy[i]);
            //}
            //Console.ReadLine();

            copy[index2] = array[index1];
            copy[index1] = array[index2];

            return copy;
        }


        /// <summary>
        /// intリストの指定した２つのインデックス番号の要素を入れ替える。
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        /// <returns></returns>
        public static List<int> GetReplaceMembersInIntList(List<int> list, int index1, int index2)
        {
            //int[] xy = { array[index1], array[index2] };
            //int[] xy = nmootan.GetStdIntSplit().ToArray();
            List<int> copy = new List<int>();
            copy.AddRange(list);

            //for (int i = 0; i < copy.Length; i++)
            //{
            //    Console.WriteLine(copy[i]);
            //}
            //Console.ReadLine();

            copy[index2] = list[index1];
            copy[index1] = list[index2];

            return copy;
        }



        /// <summary>
        /// int型配列のインデックス番号sIndexからeIndexの要素を文字列strを挟んでつないで、文字列で返す。
        /// </summary>
        /// <param name="ints"></param>
        /// <returns></returns>
        public static string GetJoinIntArrayToStrByStr(int[] ints, string str, int sIndex, int eIndex)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = sIndex; i < eIndex; i++)
            {
                sb.Append(ints[i]);
                sb.Append(str);
            }

            sb.Append(ints[eIndex]);
            //sb.Append(Environment.NewLine);

            return sb.ToString().Trim();
        }


        /// <summary>
        /// string型配列の要素を文字列strを挟んでつないで、文字列で返す。
        /// </summary>
        /// <param name="ints"></param>
        /// <returns></returns>
        public static string GetJoinStrArrayToStrByStr(string[] strs, string str)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < strs.Length-1; i++)
            {
                sb.Append(strs[i]);
                sb.Append(str);
            }

            sb.Append(strs[strs.Length - 1]);
            //sb.Append(Environment.NewLine);

            return sb.ToString();
        }


        /// <summary>
        /// 文字aとbを文字列(a, b)にする。
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string GetParseIntToVector2(string a,string b)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("(").Append(a).Append(", ").Append(b).Append(")");


            return sb.ToString();
        }


        /// <summary>
        /// うるう年かどうか（うるう年：true）
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static bool GetIsLeapYear(int year)
        {
            if (year%4==0)
            {
                if (year%100==0)
                {
                    if (year%400==0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }

        }


        public static bool GetExIsLeapYear(string year)
        {
            if (ExMod(year,"4")=="0")
            {
                if (ExMod(year,"100") == "0")
                {
                    if (ExMod( year, "400") == "0")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }

        }


        /// <summary>
        /// 西暦から和暦元号を得る。
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static string GetGengouFromAD(int year, int month, int day)
        {
            string gengou = "";
            if (year>=2020)
            {
                gengou = "令和";
            }
            else if (year==2019)
            {
                if (month>=5)
                {
                    gengou = "令和";
                }
                else
                {
                    gengou = "平成";
                }
            }
            else if (year>1989)
            {
                gengou = "平成";
            }
            else if (year==1989)
            {
                if (month>1)
                {
                    gengou = "平成";
                }
                else if(month==1)
                {
                    if (day >= 8)
                    {
                        gengou = "平成";
                    }
                    else
                    {
                        gengou = "昭和";
                    }
                }
                else
                {
                    gengou = "昭和";
                }
            }
            else if (year>1926)
            {
                gengou = "昭和";
            }
            else if (year==1926)
            {
                if (month==12)
                {
                    if (day>=25)
                    {
                        gengou = "昭和";
                    }
                    else
                    {
                        gengou = "大正";
                    }
                }
                else
                {
                    gengou = "大正";
                }
            }
            else if (year>1912)
            {
                gengou = "大正";
            }
            else if (year==1912)
            {
                if (month>7)
                {
                    gengou = "大正";
                }
                if (month==7)
                {
                    if (day>=30)
                    {
                        gengou = "大正";
                    }
                    else
                    {
                        gengou = "明治";
                    }
                }
                else
                {
                    gengou = "明治";
                }
            }
            else
            {
                gengou = "明治";
            }

            return gengou;
        }



        /// <summary>
        /// 西暦から和暦に変換する。
        /// ・明治は1868年1月25日から1912年7月29日まで
        /// ・大正は1912年7月30日から1926年12月24日まで
        /// ・昭和は1926年12月25日から1989年1月7日まで
        /// ・平成は1989年1月8日から2019年4月30日まで
        /// ・令和は2019年5月1日から
        /// </summary>
        /// <returns></returns>
        public static string GetParseADToJPYear(int year, int month, int day)
        {
            string gengou = GetGengouFromAD(year, month, day);
            int y=0;

            switch (gengou)
            {
                case "明治":
                    y = year - 1867;
                    break;
                case "大正":
                    y = year - 1911;
                    break;
                case "昭和":
                    y = year - 1925;
                    break;
                case "平成":
                    y = year - 1988;
                    break;
                case "令和":
                    y = year - 2018;
                    break;
                default:
                    break;
            }

            string nen;
            if (y == 1) nen = "元";
            else nen = y.ToString();

            return gengou + nen + "年" + month.ToString() + "月" + day.ToString() + "日";
        }


        /// <summary>
        /// 西暦y年m月の月の日数を表示を得る。
        /// ただし、各月の日数は以下のように決まることに注意してください。
        /// ・4, 6, 9, 11月は30日
        /// ・2月は閏年ならば29日、そうでなければ28日
        /// ・それ以外の月は31日
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static int GetDaysAMonth(int year, int month)
        {
            int days = 31;
            switch (month)
            {
                case 2:
                    if (GetIsLeapYear(year)) days = 29;
                    else days = 28;
                    break;
                case 4:
                    days = 30;
                    break;
                case 6:
                    days = 30;
                    break;
                case 9:
                    days = 30;
                    break;
                case 11:
                    days = 30;
                    break;
                default:
                    break;
            }

            return days;
        }


        /// <summary>
        /// 表のオートフィル（全ての行と列について、指定した数の行と列を、下記の要素から等差数列で埋める）
        /// ・hwは、表の行数を表す整数 H と 列数を表す整数 W をこの順で半角スペース区切りで与える。
        /// ・raw1は、表の 1 行目にある整数の 2 要素 a_ {1, 1}, a_{1, 2}をこの順で半角スペース区切りで与える。
        /// ・raw2は、表の 2 行目にある整数の 2 要素 a_ {2, 1}, a_{2, 2}をこの順で半角スペース区切りで与える。
        /// </summary>
        /// <param name="hw"></param>
        /// <param name="raw1"></param>
        /// <param name="raw2"></param>
        public static void GetAutoFill(string hw, string raw1, string raw2)
        {
            int[] hws = GetStrSplitToIntList(hw).ToArray();//0:h行、1:w列

            //List<int> raws1 = GetStrSplitToIntList(raw1);
            //List<int> raws2 = GetStrSplitToIntList(raw2);

            int[] raw1s = GetStrSplitToIntList(raw1).ToArray();
            int[] raw2s = GetStrSplitToIntList(raw2).ToArray();

            //全ての行列を初期化　raws[h][w] raws[i][j]
            int[][] raws = new int[hws[0]][];
            for (int i = 0; i < hws[0]; i++)
            {
                for (int j = 0; j < hws[1]; j++)
                {
                    raws[i] = new int[hws[1]];
                }
            }
            //初期値を入力
            raws[0][0]= raw1s[0];
            raws[0][1]= raw1s[1]; 
            raws[1][0] = raw2s[0];
            raws[1][1] = raw2s[1];
            //公差
            int[] subsh = new int[hws[1]];//各列の公差（縦方向）
            int[] subsw = new int[hws[0]];//各行の公差（横方向）
            subsw[0] = raws[0][1] - raws[0][0];//1行目
            subsw[1] = raws[1][1] - raws[1][0];//2行目

            //a(n)=(n-1)r+a0
            //1行目を完成させる
            //2行目を完成させる
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < hws[1]; j++)
                {
                    if (j > 1) raws[i][j] = j * subsw[i] + raws[i][0];
                }
            }

            //各列の公差（縦方向）
            for (int j = 0; j < hws[1]; j++)
            {
                subsh[j] = raws[1][j] - raws[0][j];
            }

            //それぞれの列を完成させる
            for (int j = 0; j < hws[1]; j++)//列
            {
                for (int i = 0; i < hws[0]; i++)//縦方向
                {
                    if (i > 1) raws[i][j] = i * subsh[j] + raws[0][j];
                }
            }


            //raws[0] = GetStrSplitToIntList(raw1).ToArray();
            //raws[1] = GetStrSplitToIntList(raw2).ToArray();

            //int[] subs = new int[2];
            //subs[0] = raw2s[0] - raw1s[0];
            //subs[1] = raw1s[1] - raw1s[0];

            //int[] subs1 = new int[hws[0]];
            //int[] subs2 = new int[hws[1]];

            //subs2[0] = raws[0][1] - raws[0][0];
            //subs2[1] = raws[1][1] - raws[1][0];

            //for (int i = 0; i < 2; i++)
            //{
            //    for (int j = 0; j < hws[1]; j++)
            //    {
            //        if(j>1) raws[i][j] = j * subs[1] + i * subs1[i] + raws[i][j];
            //    }
            //}

            ////subs[0] = raws1[1] - raws1[0];
            ////subs[1] = raws2[1] - raws2[0];
            ////a(n)=(n-1)r+a0

            //for (int i = 0; i < hws[0]; i++)
            //{
            //    for (int j = 0; j < hws[1]; j++)
            //    {
            //        if (i > 1 || j > 1) raws[i][j] = j*subs[1] + i * subs[0] + raws[0][0];
            //    }
            //}

            for (int i = 0; i < hws[0]; i++)
            {
                Console.WriteLine(GetJoinIntArrayToStrByStr(raws[i], " "));
            }

        }


        /// <summary>
        /// 扇形の視界に対象物が入っているかどうか
        /// </summary>
        /// <param name="situations"></param>
        /// <returns></returns>
        public static bool GetIsCaughtInSite(int[] situations)
        {



            return 
        }


    }
}
