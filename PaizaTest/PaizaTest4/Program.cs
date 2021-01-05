//#define M1

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaizaTest4
{
    class Program
    {
        static void Main(string[] args)
        {
            Hello hello = new Hello();

            hello.Test112();
            //nmootan.RegexNormalizeTest();

            Console.ReadLine();
        }
    }





    /*
    
    
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Hello
    {

        public static void Main(){
            // 自分の得意な言語で
            // Let's チャレンジ！！
    
            Hello hello = new Hello();
    
            hello.Test111();
            //Console.WriteLine( hello.Test78());
        }

    
    
    
        /// <summary>
        /// paiza暦y年m月d日が何曜日か表示してください。
        /// ただし、paiza暦は現実世界で用いられているグレゴリオ暦とは異なる以下のルールで運用されることに注意してください。
        /// ・1年は12ヶ月からなる
        /// ・1ヶ月は30日からなる
        /// ・paiza暦年が閏年の場合は、12月が31日からなる
        /// ただし、閏年は次のような年のことをいいます。
        /// ・paiza暦が4で割り切れる年は閏年
        /// ・ただし、100で割り切れる年は平年
        /// ・ただし、400で割り切れる年は閏年
        /// また、曜日には次のルールがあります。
        /// ・1週間は7日からなり、西暦のカレンダーと同様に"月", "火", "水", "木", "金", "土", "日"の各曜日が順に繰り返される
        /// ・paiza暦0年1月1日は、"木"曜日である
        /// 整数yとmとdが次のように、スペース区切りで1行で入力されます。
        /// </summary>
        public void Test111()
        {
            string[] dw = { "Thursday", "Friday", "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday" };
            string[] ymd = nmootan.GetStdStrsSplit();
            bool isLeap = nmootan.ExIsLeapYear(ymd[0]);

            //if (nmootan.ExMod(ymd[0], "4") == "0")
            //{

            //    if (nmootan.ExMod(ymd[0], "100") == "0")
            //    {
            //        if (nmootan.ExMod(ymd[0], "400") == "0")
            //        {
            //            isLeap = true;
            //        }
            //        else isLeap = false;

            //    }
            //    else isLeap = true;
            //}

            int[] sums = new int[13];
            sums[0] = 0;
            for (int i = 1; i < 13; i++)
            {
                sums[i] = 30 * i;
            }
            //if (isLeap) sums[12] = sums[11] + 31;

            string div4, div100, div400;
            nmootan.ExMod(ymd[0], "4", out div4);
            nmootan.ExMod(ymd[0], "100", out div100);
            nmootan.ExMod(ymd[0], "400", out div400);
            string leapCount = nmootan.ExMinus(nmootan.ExPlus(div4, div400), div100);

            string sum = nmootan.ExPlus(nmootan.ExPlus(nmootan.ExPlus( nmootan.ExMultiply(nmootan.ExMinus(ymd[0],leapCount),sums[12].ToString()),nmootan.ExMultiply(leapCount,(sums[12]+1).ToString())), sums[int.Parse(ymd[1]) - 1].ToString()), (int.Parse(ymd[2]) - 1).ToString());

            //Console.WriteLine(nmootan.ExMod("7777777777777777777777777777777776", "7"));
            //Console.WriteLine("isLeap={0}", isLeap);
            //Console.WriteLine("nmootan.ExMultiply(ymd[0], sums[12].ToString())={0}", nmootan.ExMultiply(ymd[0], sums[12].ToString()));
            //Console.WriteLine("int.Parse(ymd[1]) - 1={0}", int.Parse(ymd[1]) - 1);
            //Console.WriteLine("sum={0}", sum);
            //Console.WriteLine("nmootan.ExMod={0}", nmootan.ExMod(sum, "7"));
            //Console.ReadLine();
            //Console.WriteLine(dw[int.Parse(nmootan.ExMod(sum, "7"))]);
            Console.WriteLine(nmootan.GetTranslateDayOfWeek(dw[int.Parse(nmootan.ExMod(sum, "7"))]) + "曜日");

        }


    }




    static class nmootan
    {
    
    
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

    
        public static int GetParseCharToInt(char ch)
        {

            return ch - '0';
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
        /// 小数かどうかを判定する。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool JudgeIsFloat(string str)
        {
            if (str.Contains(".")) return true;
            else return false;

        }


    
        public static string GetParseCharListToStr(List<char> chList)
        {

            return new string(chList.ToArray());
        }



    
        /// <summary>
        /// 何桁でもその年の日付の曜日を得る。
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetExDayOfWeek(string year, string month, string day)
        {
            string result = "";
            //Dictionary<int,string> dow = { {0,"" },{1,"" },{2, ""},{3,"" },{4,"" },{5,"" },{6,"" } }
            string[] dw = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

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
                sub = ExMinus(year, YEAR);
                sub1= ExMod(sub, "100", out sub);
                num = 7 - int.Parse( ExMod(sub, "7"));

                num1 = dd[int.Parse(month) - 1];
                if (int.Parse( day)>=num1)
                {
                    num += (int.Parse( day) - num1) % 7;
                    result = GetTranslateDayOfWeek(dw[num]);
                }
                else
                {
                    num += (num1 - int.Parse( day)) % 7;
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

    
        public static string[] GetStdStrsSplit()
        {

            return System.Console.ReadLine().Trim().Split(' ');
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

    
        public static char[] GetParseStrToCharArray(string str)
        {

            return str.ToCharArray();
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

    
        public static int[] GetParseStrToIntArray(string str)
        {
            int[] nums = new int[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                nums[i] = int.Parse(str[i].ToString());
            }

            return nums;
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



    }






    /*


99
66.162252 2
6.614223 4
4.311039 1
89.502924 3
46.855139 3
77.158048 4
55.362305 4
7.394249 4
6.148813 1
13.888018 3
7.162086 3
76.207111 1
8.573399 3
79.648562 3
67.467358 4
15.756736 4
37.394585 4
7.905873 2
3.331409 2
3.911585 2
22.139126 4
8.580618 2
2.622692 2
88.718562 4
46.290362 1
2.815133 4
3.847426 4
38.556685 3
4.332416 2
6.199277 3
1.361932 2
41.313875 2
23.552326 1
85.593199 3
63.40920 4
7.787017 4
42.136454 1
79.661987 3
72.818919 1
3.154319 3
4.949167 3
13.360183 4
8.747707 4
62.467793 3
6.486046 3
82.639265 4
62.68599 1
8.696826 3
4.219498 3
3.4367 3
23.809514 1
97.756197 4
7.801187 3
43.847548 4
4.646655 3
16.490166 1
41.209000 2
6.60356 1
55.247972 1
3.402927 1
41.157091 2
3.988325 3
8.710521 2
2.857875 3
68.425375 4
13.839091 4
71.84788 1
2.691121 4
6.84236 4
93.355585 4
6.15551 4
3.61747 1
78.226115 2
37.315972 3
1.908466 2
48.792990 1
18.615592 1
13.335965 2
91.486651 3
5.713964 4
5.785312 4
7.697196 1
57.21173 3
5.134873 4
41.810829 2
1.866548 3
2.671891 1
4.97113 1
6.841678 4
5.862228 4
3.685825 2
6.40856 2
17.856298 3
1.474073 2
4.576625 2
5.330920 1
4.943101 2
4.300828 1
5.305225 3

    







35
20 28 70 21 61 2 29 47 43 56 95 33 65 47 92 68 4 27 30 20 3
65 2 62 72 24 7 26 5 79 77 70 59 72 83 34 57 74 47 32 89 47 77 23 80 84 70 34 31 100 20 93 91 80 10 94 59 69 85 64 20 17 47 62 16 42 25 91 52 34 10 20 76 45 89 62 59 42 28 80 84 71 18 33 67 89 96
22 88 29 23 52 17 6 65 34 40 95 63 55 93 59 93 11 85 20 7 24 29 1
86 77 3 5 79 18 99 32 13 66 95 34 87 79 78 55 88 32 2 46 82 2 86 40 34 23 14 98 58 4 90 5 75 64 50 19 38 23 52 82 90 30 66 49 27 51 100 8 54 39 29 17 84 81 69 43 20 21 65 62 7 9 95 51 28 45 70 16 76 62 53 19 10 53 16 15 54 28 56 94 58 38 63 63 53 91 31
44 70 77 36 33 8 31 24 88 87 17 79 46 28 97 88 34 67 46 94 72 23 26 26 9 84 5 22 66 71 25 18 4 20 20 51 32 21 81 74 43 61 59 9 37
52 37 28 62 15 7 75 27 40 35 23 72 13 9 52 52 6 41 6 27 32 78 65 88 21 16 42 100 21 16 94 90 3 97 40 65 98 65 49 80 93 55 8 99 21 14 63 82 94 50 90 33 74
45 99 75 16 45 8 48 13 12 73 61 17 26 97 9 69 77 85 82 68 78 83 94 52 14 20 10 9 15 91 28 46 32 71 16 26 78 98 73 1 7 24 40 31 55 71
51 33 48 75 84 21 45 15 71 50 81 73 90 30 61 56 80 90 63 84 20 28 27 85 13 15 64 55 46 36 47 94 3 57 91 4 6 10 22 67 43 81 72 20 2 75 13 10 3 7 97 47
89 97 97 90 25 21 48 48 4 83 97 25 51 86 3 71 20 58 71 26 40 60 48 46 85 49 100 8 98 13 48 50 64 86 60 36 64 19 41 90 60 39 73 65 19 100 47 7 73 67 67 55 25 89 73 45 92 17 28 40 84 72 26 28 87 91 21 48 68 9 7 44 17 7 65 5 29 56 71 25 30 61 48 88 24 18 100 97 16 15
65 7 95 81 39 52 45 52 96 86 9 60 51 4 44 35 25 21 21 13 31 3 6 61 1 89 89 28 26 29 31 29 62 65 86 83 74 13 75 21 13 88 24 16 66 40 41 8 68 40 11 27 82 4 63 14 11 63 49 25 65 67 60 79 94 59
9 50 93 77 34 44 64 2 26 51
55 77 91 45 39 26 90 65 99 90 43 89 31 23 50 44 59 100 88 5 72 19 25 11 48 31 54 65 42 54 55 100 49 61 26 37 20 64 13 27 79 16 41 36 55 45 75 60 66 68 13 76 34 58 64 61
24 41 57 14 40 60 88 72 59 58 37 47 82 16 43 87 21 67 85 48 73 65 87 100 86
76 38 45 70 97 26 32 2 98 4 96 39 80 17 8 81 30 27 44 8 1 85 98 67 82 53 71 31 30 78 37 61 71 6 58 92 71 17 84 14 76 72 36 6 26 92 44 81 82 81 1 31 90 62 89 72 40 8 89 62 8 89 10 65 82 97 98 65 61 54 75 60 34 98 17 37 45
49 100 11 70 63 91 24 86 75 54 13 91 25 61 83 69 83 61 52 89 93 25 72 41 4 81 16 72 33 37 1 30 34 52 82 36 7 97 17 90 91 71 75 10 22 69 58 39 14 64
45 96 15 45 52 8 16 72 41 81 61 15 35 24 21 31 48 74 38 68 50 96 50 29 50 10 100 57 90 37 80 45 13 87 40 4 21 5 17 68 90 24 82 63 64 6
16 9 74 25 21 54 18 72 61 33 73 85 22 4 70 7 83
31 11 84 80 4 31 35 44 5 3 7 82 88 37 63 29 44 13 79 73 45 72 31 22 46 96 81 53 58 27 57 98
83 44 6 13 81 96 2 84 86 29 48 27 44 59 51 98 30 66 93 22 55 40 7 62 3 59 20 21 29 83 100 83 70 63 35 17 72 99 49 44 10 55 28 70 82 99 65 25 79 11 91 92 26 2 28 77 81 97 32 73 64 1 40 46 90 35 92 17 50 12 50 14 49 94 52 61 5 7 9 79 64 48 4 87
57 6 62 70 31 92 60 24 56 71 68 45 75 46 45 49 13 7 55 51 100 45 8 9 94 4 22 2 53 28 80 64 29 69 69 45 42 40 77 82 13 67 73 22 49 93 11 64 70 97 46 70 42 18 99 96 90 18
38 89 7 70 10 7 88 65 10 85 80 48 24 99 52 45 23 3 82 2 71 51 55 100...













    28 70 21 61 2 29 47 43 56 95 33 65 47 92 68 4 27 30 20 3
 2 62 72 24 7 26 5 79 77 70 59 72 83 34 57 74 47 32 89 47 77 23 80 84 70 34 31 100 20 93 91 80 10 94 59 69 85 64 20 17 47 62 16 42 25 91 52 34 10 20 76 45 89 62 59 42 28 80 84 71 18 33 67 89 96
 88 29 23 52 17 6 65 34 40 95 63 55 93 59 93 11 85 20 7 24 29 1
 77 3 5 79 18 99 32 13 66 95 34 87 79 78 55 88 32 2 46 82 2 86 40 34 23 14 98 58 4 90 5 75 64 50 19 38 23 52 82 90 30 66 49 27 51 100 8 54 39 29 17 84 81 69 43 20 21 65 62 7 9 95 51 28 45 70 16 76 62 53 19 10 53 16 15 54 28 56 94 58 38 63 63 53 91 31
 70 77 36 33 8 31 24 88 87 17 79 46 28 97 88 34 67 46 94 72 23 26 26 9 84 5 22 66 71 25 18 4 20 20 51 32 21 81 74 43 61 59 9 37
 37 28 62 15 7 75 27 40 35 23 72 13 9 52 52 6 41 6 27 32 78 65 88 21 16 42 100 21 16 94 90 3 97 40 65 98 65 49 80 93 55 8 99 21 14 63 82 94 50 90 33 74
 99 75 16 45 8 48 13 12 73 61 17 26 97 9 69 77 85 82 68 78 83 94 52 14 20 10 9 15 91 28 46 32 71 16 26 78 98 73 1 7 24 40 31 55 71
 33 48 75 84 21 45 15 71 50 81 73 90 30 61 56 80 90 63 84 20 28 27 85 13 15 64 55 46 36 47 94 3 57 91 4 6 10 22 67 43 81 72 20 2 75 13 10 3 7 97 47
 97 97 90 25 21 48 48 4 83 97 25 51 86 3 71 20 58 71 26 40 60 48 46 85 49 100 8 98 13 48 50 64 86 60 36 64 19 41 90 60 39 73 65 19 100 47 7 73 67 67 55 25 89 73 45 92 17 28 40 84 72 26 28 87 91 21 48 68 9 7 44 17 7 65 5 29 56 71 25 30 61 48 88 24 18 100 97 16 15
 7 95 81 39 52 45 52 96 86 9 60 51 4 44 35 25 21 21 13 31 3 6 61 1 89 89 28 26 29 31 29 62 65 86 83 74 13 75 21 13 88 24 16 66 40 41 8 68 40 11 27 82 4 63 14 11 63 49 25 65 67 60 79 94 59
50 93 77 34 44 64 2 26 51
 77 91 45 39 26 90 65 99 90 43 89 31 23 50 44 59 100 88 5 72 19 25 11 48 31 54 65 42 54 55 100 49 61 26 37 20 64 13 27 79 16 41 36 55 45 75 60 66 68 13 76 34 58 64 61
 41 57 14 40 60 88 72 59 58 37 47 82 16 43 87 21 67 85 48 73 65 87 100 86
 38 45 70 97 26 32 2 98 4 96 39 80 17 8 81 30 27 44 8 1 85 98 67 82 53 71 31 30 78 37 61 71 6 58 92 71 17 84 14 76 72 36 6 26 92 44 81 82 81 1 31 90 62 89 72 40 8 89 62 8 89 10 65 82 97 98 65 61 54 75 60 34 98 17 37 45
 100 11 70 63 91 24 86 75 54 13 91 25 61 83 69 83 61 52 89 93 25 72 41 4 81 16 72 33 37 1 30 34 52 82 36 7 97 17 90 91 71 75 10 22 69 58 39 14 64
 96 15 45 52 8 16 72 41 81 61 15 35 24 21 31 48 74 38 68 50 96 50 29 50 10 100 57 90 37 80 45 13 87 40 4 21 5 17 68 90 24 82 63 64 6
 9 74 25 21 54 18 72 61 33 73 85 22 4 70 7 83
 11 84 80 4 31 35 44 5 3 7 82 88 37 63 29 44 13 79 73 45 72 31 22 46 96 81 53 58 27 57 98
 44 6 13 81 96 2 84 86 29 48 27 44 59 51 98 30 66 93 22 55 40 7 62 3 59 20 21 29 83 100 83 70 63 35 17 72 99 49 44 10 55 28 70 82 99 65 25 79 11 91 92 26 2 28 77 81 97 32 73 64 1 40 46 90 35 92 17 50 12 50 14 49 94 52 61 5 7 9 79 64 48 4 87
 6 62 70 31 92 60 24 56 71 68 45 75 46 45 49 13 7 55 51 100 45 8 9 94 4 22 2 53 28 80 64 29 69 69 45 42 40 77 82 13 67 73 22 49 93 11 64 70 97 46 70 42 18 99 96 90 18
 89 7 70 10 7 88 65 10 85 80 48 24 99 52 45 23 3 82 2 71 51 55 100 33 15 78 39 86 55 12 46 87 9 75 17 30 93 47
...

    */

}
