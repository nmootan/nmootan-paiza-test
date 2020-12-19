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

            nmootan.StdNLines(n);
        }


        public void Test5()
        {

            int n = int.Parse(Console.ReadLine());

            nmootan.StdSplit();
        }


        public void Test6()
        {
            string s = Console.ReadLine();
            int i = nmootan.GetStdNum();

            nmootan.ShowICharInString(i, s);


        }


        public void Test7()
        {
            nmootan.EqualStd("paiza");

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
            int n = nmootan.GetStdNum();

            Console.WriteLine(nmootan.AppendNStdStrs(n));
        }


        public void Test11()
        {
            string std= Console.ReadLine();

            List<int> iList = nmootan.GetStdIntSplit();

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
            string[] str2 = nmootan.GetStdStrsSplit();

            Console.WriteLine(nmootan.GetReplaceStrNoIChar(str, str2[1], int.Parse(str2[0])));
        }


        public void Test14()
        {
            int i = int.Parse(Console.ReadLine());

            Console.WriteLine(i - 813);

        }


        public void Test15()
        {
            int i1 = nmootan.GetStdInt();
            int i2 = nmootan.GetStdInt();
            int i3 = nmootan.GetStdInt();
            string str = (i1 + i2).ToString();

            Console.WriteLine(nmootan.GetICharInString(i3, str).ToString());

        }


        public void Test16()
        {
            Console.WriteLine(nmootan.GetStdLowerStr(Console.ReadLine()));

        }


        public void Test17()
        {
            Console.WriteLine(nmootan.GetStdUpperStr(Console.ReadLine()));

        }


        public void Test18()
        {
            Console.WriteLine(nmootan.GetSwithCharsInStr(Console.ReadLine()));
        }


        public void Test19()
        {
            string str1= Console.ReadLine();

            if (str1.Contains(Console.ReadLine())) Console.WriteLine("YES");
            else Console.WriteLine("NO");

        }


        public void Test20()
        {
            Console.WriteLine(nmootan.GetMirrorStr(Console.ReadLine()));
        }


        public void Test21()
        {

            string std = Console.ReadLine();
            string mirror = nmootan.GetMirrorStr(std);

            if (Equals(mirror, std)) Console.WriteLine("YES");
            else Console.WriteLine("NO");
            
        }


        public void Test22()
        {
            DateTime dt = nmootan.GetParseStrToDateTime(Console.ReadLine());

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

            Console.WriteLine(nmootan.DistinctAllChar(Console.ReadLine()));
        }


        public void Test25()
        {
            int n = nmootan.GetStdInt();
            int q = nmootan.GetStdInt();

            Dictionary<int, char> passTable = new Dictionary<int, char>();

            for (int i = 0; i < q; i++)
            {
                string[] str = nmootan.GetStdStrsSplit();

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

            if (nmootan.JudgeIsFloat(str)) str = nmootan.DistinctChar(str, '.');

            Console.WriteLine(nmootan.GetFormatZero(str));

        }

        /// <summary>
        /// 正しい数式を表す文字列 S が与えられるので、その数式を計算した結果を出力してください。
        /// ただし、出てくる計算は足し算・引き算のみとし、数式に出てくる数字は全て 1 桁であるものとします。
        /// S = "4+3-2+1"   答えは 6
        /// 1-3-5-6-2-1+9
        /// </summary>
        public void Test27()
        {

            Console.WriteLine(nmootan.GetParseStrToIntPlusMinusResult(Console.ReadLine()));
        }

        /// <summary>
        /// 数値を表す文字列 S , T が与えられるので、S + T の結果を表す文字列を出力してください。
        /// 123546131325115412512543111111111111111112345151515111111111111111111124245216
        /// 212121212121212121212121268854784674464635352424242476758767563673467333221111
        /// 335667343446327533724664379965895785575747697575757587869878674784578457466327
        /// </summary>
        public void Test28()
        {

            Console.WriteLine(nmootan.ExPlus(Console.ReadLine(), Console.ReadLine()));
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

            Console.WriteLine(nmootan.ExMultiply1(str, n));
        }

        /// <summary>
        /// 以下の 10 個の整数を改行区切りで出力してください。
        /// 813, 1, 2, 923874, 23648, 782356, 3256, 2342, 24324, 112
        /// </summary>
        public void Test30()
        {


        }






    }
}
