using System;
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

                if (exN == 1) chsList.Add(GetParseIntToChar(1));

            }

            return GetMirrorStr(GetParseCharListToStr(chsList));


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

            for (int i = 4; i < n; i++)
            {
                for (int j = 2; j < i; j++)
                {
                    i/j
                }


            }

            return 
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



    }
}
