using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaizaTest4
{
    class Hello
    {

        public void Test3()
        {
            string[] line = new string[3];

            for (int i = 0; i < 3; i++)
            {
                line[i] = Console.ReadLine();

            }

            for (int i = 0; i < line.Length; i++)
            {
                Console.WriteLine(line[i]);
            }
        }


        public void Test4()
        {
            int n = int.Parse(Console.ReadLine());

            StdNLines(n);
        }


        public void Test5()
        {

            int n = int.Parse(Console.ReadLine());

            StdSplit();
        }


        public void Test6()
        {
            string s = Console.ReadLine();
            int i = GetStdNum();

            ShowICharInString(i, s);


        }


        public void Test7()
        {
            EqualStd("paiza");

        }


        public void Test8()
        {
            Console.WriteLine(Console.ReadLine().Length);
        }


        public void Test9()
        {

            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();

            Console.WriteLine(str1.IndexOf(str2) + 1);
        }


        public void Test10()
        {
            int n = GetStdNum();

            Console.WriteLine(AppendNStdStrs(n));
        }


        public void Test11()
        {
            string std= Console.ReadLine();

            List<int> iList = GetStdIntSplit();

            Console.WriteLine(std.Substring(iList[0]-1, iList[1] - iList[0] + 1));


        }


        public void Test12()
        {
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();

            StringBuilder sb = new StringBuilder(str1);

            sb.Insert(int.Parse(Console.ReadLine()), str2);
            Console.WriteLine(sb.ToString());
        }


        public void Test13()
        {
            string str = Console.ReadLine();
            string[] str2 = GetStdStrsSplit();

            Console.WriteLine(GetReplaceStrNoIChar(str, str2[1], int.Parse(str2[0])));
        }


        public void Test14()
        {
            int i = int.Parse(Console.ReadLine());

            Console.WriteLine(i - 813);

        }


        public void Test15()
        {
            int i1 = GetStdInt();
            int i2 = GetStdInt();
            int i3 = GetStdInt();
            string str = (i1 + i2).ToString();

            Console.WriteLine(GetICharInString(i3, str).ToString());

        }


        public void Test16()
        {
            Console.WriteLine(GetStdLowerStr(Console.ReadLine()));

        }


        public void Test17()
        {
            Console.WriteLine(GetStdUpperStr(Console.ReadLine()));

        }


        public void Test18()
        {
            Console.WriteLine(GetSwithCharsInStr(Console.ReadLine()));
        }


        public void Test19()
        {
            string str1= Console.ReadLine();

            if (str1.Contains(Console.ReadLine())) Console.WriteLine("YES");
            else Console.WriteLine("NO");

        }


        public void Test20()
        {
            Console.WriteLine(GetMirrorStr(Console.ReadLine()));
        }


        public void Test21()
        {

            string std = Console.ReadLine();
            string mirror = GetMirrorStr(std);

            if (Equals(mirror, std)) Console.WriteLine("YES");
            else Console.WriteLine("NO");
            
        }


        public void Test22()
        {
            DateTime dt = GetParseStrToDateTime(Console.ReadLine());

            Console.WriteLine(dt.ToString("yyyy"));
            Console.WriteLine(dt.ToString("MM"));
            Console.WriteLine(dt.ToString("dd"));
            Console.WriteLine(dt.ToString("HH"));
            Console.WriteLine(dt.ToString("mm"));

        }


        public void Test23()
        {
            string str = Console.ReadLine();
            List<string> strs = new List<string>();
            long num;
            int length = 7;

            for (int i = 0; i < str.Length; i++)
            {


                //if(!int.TryParse(str[i].ToString(), out num))
                //{
                //    Console.WriteLine("NO");
                //    return;
                //}

                if ((i + 1) * 7 > str.Length) length=str.Length-i*7;

                strs.Add(str.Substring(i * 7, length));
                //Console.WriteLine(strs[i]);
                if (!long.TryParse(strs[i], out num))
                {
                    //Console.WriteLine(num);
                    Console.WriteLine("NO");
                    return;
                }

                if ((i + 1) * 7 > str.Length) break;
            }

            Console.WriteLine("YES");
        }


        public void Test24()
        {

            Console.WriteLine(DistinctAllChar(Console.ReadLine()));
        }


        public void Test25()
        {
            int n = GetStdInt();
            int q = GetStdInt();

            Dictionary<int, char> passTable = new Dictionary<int, char>();

            for (int i = 0; i < q; i++)
            {
                string[] str = GetStdStrsSplit();

                passTable.Add(int.Parse(str[0]), char.Parse(str[1]));
            }

            char c = char.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                if (passTable.ContainsKey(i+1)) sb.Append(passTable[i+1]);
                else sb.Append(c);
            }

            Console.WriteLine(sb.ToString());
        }


        public void Test26()
        {
            string str = Console.ReadLine();

            if (JudgeIsFloat(str)) str = DistinctChar(str, '.');

            Console.WriteLine(GetFormatZero(str));

        }

        /// <summary>
        /// 正しい数式を表す文字列 S が与えられるので、その数式を計算した結果を出力してください。
        /// ただし、出てくる計算は足し算・引き算のみとし、数式に出てくる数字は全て 1 桁であるものとします。
        /// S = "4+3-2+1"   答えは 6
        /// 1-3-5-6-2-1+9
        /// </summary>
        public void Test27()
        {

            Console.WriteLine(GetParseStrToIntPlusMinusResult(Console.ReadLine()));
        }

        /// <summary>
        /// 数値を表す文字列 S , T が与えられるので、S + T の結果を表す文字列を出力してください。
        /// 123546131325115412512543111111111111111112345151515111111111111111111124245216
        /// 212121212121212121212121268854784674464635352424242476758767563673467333221111
        /// 335667343446327533724664379965895785575747697575757587869878674784578457466327
        /// </summary>
        public void Test28()
        {

            Console.WriteLine(ExPlus(Console.ReadLine(), Console.ReadLine()));
        }

        /// <summary>
        /// 数値を表す文字列 S と 1 桁の数値 T が与えられるので、S * T の結果を表す文字列を出力してください。
        /// 123456789987654321123456789987654321123456789987654321123456789987654321
        /// 5
        /// 617283949938271605617283949938271605617283949938271605617283949938271605
        /// 
        /// 11111111111111111111111111111111111111111111111111111111111111111111112222222222222222222222222222222222222222222222222222333333333333333333333333333333333333333333333333344444444444444444444444444444444445555555555555555555555555555555555666666666666666666666666666666667777777777777777777777777777778888888888888888888888888888999999999999999999999999999999
        /// 0
        /// </summary>
        public void Test29()
        {
            string str = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(ExMultiply1(str, n));
        }



        public string ExMultiply1(string str, int n)
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


        public string ExPlus(string str1, string str2)
        {
            //str1 = GetMirrorStr(str1);
            //str2 = GetMirrorStr(str2);

            char[] chs1 = GetParseStrToCharArray(GetMirrorStr(str1));
            char[] chs2 = GetParseStrToCharArray(GetMirrorStr(str2));
            List<char> chsList = new List<char>();
            int exN = 0;
            int n = 0;

            if (chs1.Length>chs2.Length)
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


        public char GetParseIntToChar(int n)
        {

            return (char)(48 + n);
        }


        public int GetParseCharToInt(char ch)
        {

            return ch - '0';
        }


        public int GetParseStrToIntPlusMinusResult(string str)
        {
            string[] plusStrs = GetStdStrsSplitByChar(str,'+');

            //List<string> plusStrsList = new List<string>();
            //List<int> plusNumsList = new List<int>();
            //List<string[]> minusStrsList = new List<string[]>();
            int n = 0;
            int sum = 0;

            for (int i = 0; i < plusStrs.Length; i++)
            {
                string[] strs = GetStdStrsSplitByChar(plusStrs[i],'-');

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

        public string GetFormatZero(string str)
        {
            List<char> chs = str.ToList<char>();
            int length = chs.Count;

            if (JudgeIsFloat(str))
            {
                for (int i = 0; i < length; i++)
                {
                    if (chs[length - 1 - i] != '0') break;
                    else chs.RemoveAt(length - 1 - i);
                }

                //length = chs.Count;
                int n=0;
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
                for (int i = n; i < chs.Count-1; i++)
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


        public bool JudgeIsFloat(string str)
        {
            if (str.Contains(".")) return true;
            else return false;
            
        }


        public string DistinctChar(string str, char ch)
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

        public string DistinctAllChar(string str)
        {
            char[] ch = GetParseStrToCharArray(str);
            List<char> chList = new List<char>();

            for (int i = 0; i < ch.Length; i++)
            {
                if (!chList.Contains(ch[i])) chList.Add(ch[i]);
            }


            return GetParseCharListToStr(chList);
        }


        public DateTime GetParseStrToDateTime(string str)
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


        public string GetMirrorStr(string str)
        {
            char[] cs = str.ToCharArray();
            char[] mirror = new char[cs.Length];

            int i = cs.Length-1;
            int length = i;
            while (i >= 0)
            {
                mirror[length - i] = cs[i];

                i--;
            }

            return new string(mirror);
        }


        public string GetParseCharListToStr(List<char> chList)
        {

            return new string(chList.ToArray());
        }


        public string GetSwithCharsInStr(string str)
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


        public char[] GetParseStrToCharArray(string str)
        {

            return str.ToCharArray();
        }


        public string GetStdLowerStr(string str)
        {

            //現在のカルチャのTextInfoを取得する
            System.Globalization.TextInfo ti =
                System.Globalization.CultureInfo.CurrentCulture.TextInfo;

            return ti.ToLower(str);
        }


        public string GetStdUpperStr(string str)
        {

            //現在のカルチャのTextInfoを取得する
            System.Globalization.TextInfo ti =
                System.Globalization.CultureInfo.CurrentCulture.TextInfo;

            return ti.ToUpper(str);
        }


        public string GetReplaceStrNoIChar(string str, string ch, int i)
        {
            StringBuilder sb = new StringBuilder(str);

            sb.Remove(i - 1, 1);
            sb.Insert(i - 1, ch);

            return sb.ToString();
        }


        public string AppendNStdStrs(int n)
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


        public void EqualStd(string s)
        {

            string std = Console.ReadLine();
            if (Equals(s, std)) Console.WriteLine("YES");
            else Console.WriteLine("NO");
        }


        public char GetICharInString(int i, string s)
        {
            return s[i - 1];
        }


        public void ShowICharInString(int i, string s)
        {
            Console.WriteLine(s[i-1]);
        }



        public int GetStdNum()
        {

            return int.Parse(Console.ReadLine());

            
        }


        /// <summary>
        /// n行の文字列を標準入力して、それぞれの行を3文字目以降から標準出力する。
        /// </summary>
        public void StdNMatrix()
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
                for (int j = 1; j < line[i].Length-1; j++)
                {
                    sb[i].Append(line[i][j]);
                    sb[i].Append(" ");
                }
                sb[i].Append(line[i][line[i].Length-1]);
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


        public void SubstringTest()
        {
            string str = "1 2 3 4 5 6 7";

            Console.WriteLine(str.Substring(2, str.Length-2));

        }



        public int GetStdInt()
        {

            return int.Parse(Console.ReadLine());
        }


        public void StdInt()
        {

            int n = int.Parse(Console.ReadLine());
        }



        public void StdNLines2()
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



        public void StdNLines3()
        {
            int n = int.Parse(Console.ReadLine());
            string[] line = new string[n];

            for (int i = 0; i < n; i++)
            {
                line[i] = Console.ReadLine();

            }

            Console.WriteLine(line[7]);
        }


        public void StdNLines(int n)
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


        public void StdSplit2()
        {
            string[] strs = "Hello paiza".Trim().Split(' ');

            for (int i = 0; i < strs.Length; i++)
            {
                Console.WriteLine(strs[i]);
            }
        }

        public void StdSplit3()
        {
            int n = int.Parse(Console.ReadLine());

            string[] strs = System.Console.ReadLine().Trim().Split(' ');

            for (int i = 0; i < strs.Length; i++)
            {
                Console.WriteLine(strs[i]);
            }
        }

        public void StdSplit4()
        {
            string[] strs = System.Console.ReadLine().Trim().Split(' ');

            for (int i = 1; i < strs.Length; i++)
            {
                Console.WriteLine(strs[i]);
            }
        }


        public void StdSplit()
        {
            string[] strs = System.Console.ReadLine().Trim().Split(' ');

            for (int i = 0; i < strs.Length; i++)
            {
                Console.WriteLine(strs[i]);
            }
        }


        public void StdSplitConma()
        {
            string[] strs = System.Console.ReadLine().Trim().Split(',');

            for (int i = 0; i < strs.Length; i++)
            {
                Console.WriteLine(strs[i]);
            }
        }



        public string[] GetStdStrsSplit()
        {

            return System.Console.ReadLine().Trim().Split(' ');
        }


        public List<int> GetStdIntSplit()
        {
            string[] strs = GetStdStrsSplit();

            List<int> iList = new List<int>();

            for (int i = 0; i < strs.Length; i++)
            {
                iList.Add(int.Parse(strs[i]));
            }

            return iList;
        }


        public string[] GetStdStrsSplitByChar(string str, char ch)
        {

            return str.Trim().Split(ch);
        }












    }
}
