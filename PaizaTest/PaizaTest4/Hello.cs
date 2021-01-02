﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaizaTest4
{
    class Hello
    {
        /// <summary>
        /// 3行標準入力で３行標準出力
        /// </summary>
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

        /// <summary>
        /// 標準入力で入力した行数だけ、標準入力して標準出力する
        /// </summary>
        public void Test4()
        {
            int n = int.Parse(Console.ReadLine());

            nmootan.StdNLines(n);
        }


        /// <summary>
        /// 標準入力の文字列をスペースで区切って、1行ずつ標準出力する
        /// </summary>
        public void Test5()
        {

            //int n = int.Parse(Console.ReadLine());

            nmootan.StdSplit();
        }

        /// <summary>
        /// 標準入力で、任意の文字列を入力する。
        /// 標準入力で、int型整数を入力する。
        /// 指定した文字列の指定した番号の文字を標準出力する
        /// </summary>
        public void Test6()
        {
            string s = Console.ReadLine();
            int i = nmootan.GetStdNum();

            nmootan.ShowICharInString(i, s);


        }

        /// <summary>
        /// 標準入力した文字列が"paiza"なら、"YES"、そうでないなら"NO"を標準出力する
        /// </summary>
        public void Test7()
        {
            nmootan.EqualStd("paiza");

        }

        /// <summary>
        /// 標準入力した文字列の文字数を標準出力する
        /// </summary>
        public void Test8()
        {
            Console.WriteLine(Console.ReadLine().Length);
        }

        /// <summary>
        /// 標準入力1行目の文字列のうち、2行目の文字列が現れる番号を標準出力する
        /// </summary>
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
            string str = "813, 1, 2, 923874, 23648, 782356, 3256, 2342, 24324, 112";

            string[] strs = nmootan.GetStrsSplitByStr(str, ", ");

            for (int i = 0; i < strs.Length; i++)
            {
                Console.WriteLine(strs[i]);
            }

        }

        /// <summary>
        /// １から１０００までの1000個の整数値を空白区切りで、1行で標準出力する。
        /// </summary>
        public void Test31()
        {
            int[] ints = new int[10];

            for (int i = 0; i < 10; i++)
            {
                ints[i] = i + 1;
            }

            Console.WriteLine(nmootan.GetJoinIntArrayToStrByStr(ints, ","));

        }


        public void Test32()
        {
            int n = 3;
            string[] strs = new string[n];

            for (int i = 0; i < n; i++)
            {
                strs[i]= Console.ReadLine();

            }

            Console.WriteLine(nmootan.GetJoinStrArrayToStrByStr(strs, "|"));
        }


        public void Test33()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Console.ReadLine().Replace(" ", ","));

            //sb.Append(",");

            Console.WriteLine(sb.ToString());

        }


        public void Test34()
        {
            string[] strs = Console.ReadLine().Trim().Split(' ');

            for (int i = 0; i < strs.Length; i++)
            {
                Console.WriteLine(strs[i]);
            }


        }

        public void Test35()
        {
            int n = 10;
            string[] strs = new string[n];

            for (int i = 0; i < n; i++)
            {
                strs[i] = Console.ReadLine();

            }

            Console.WriteLine(nmootan.GetJoinStrArrayToStrByStr(strs, " | "));
        }


        public void Test36()
        {

            Console.WriteLine(int.Parse(Console.ReadLine()).ToString("#,0"));

        }

        /// <summary>
        /// 大きな数値を 3 けたごとにカンマ区切りで出力
        /// 123456789
        /// 123,456,789
        /// </summary>
        public void Test37()
        {
            string str = Console.ReadLine();

            Console.WriteLine(nmootan.ExFormatCurrency(str));


        }


        public void Test38()
        {

            string str = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            sb.Append(str);
            sb.Insert(3, ",");

            Console.WriteLine(sb.ToString());

        }


        /// <summary>
        /// 4 つの数値 0, 8, 1, 3 をこの順に、2 行 2 列の形で出力してください。
        /// ただし、数値の間には半角スペースを、各行の末尾には、半角スペースの代わりに改行を入れてください。
        /// </summary>
        public void Test39()
        {
            int[][] rect22 = new int[2][];
            for (int i = 0; i < rect22.Length; i++)
            {
                rect22[i] = new int[2];
            }

            //for (int i = 0; i < rect22.Length; i++)
            //{
            //    for (int j = 0; j < rect22.Length; j++)
            //    {
            //        rect22[i][j] = int.Parse(Console.ReadLine());
            //    }
            //}
            rect22[0][0] = 0; rect22[0][1] = 8; rect22[1][0] = 1; rect22[1][1] = 3;

            //string[] strs = new string[rect22.Length];

            for (int i = 0; i < rect22.Length; i++)
            {
                Console.WriteLine(nmootan.GetJoinIntArrayToStrByStr(rect22[i], " "));

            }

        }


        /// <summary>
        /// 9 個の数値が半角スペース区切りで入力されます。この数値を 3 行 3 列の形式で出力してください。
        /// 具体的には、入力された数値を N_1 , N_2 , N_3 , ..., N_9 とするとき、 1 行目にはN_1 からN_3 を、2 行目には N_4 から N_6 を、3 行目には N_7 から N_9 を出力してください。
        /// ただし、数値の間には半角スペースを、各行の末尾には、半角スペースの代わりに改行を入れてください。
        /// </summary>
        public void Test40()
        {
            List<int> ints = nmootan.GetStrSplitToIntList(Console.ReadLine());

            int[][] rect33 = new int[3][];
            for (int i = 0; i < rect33.Length; i++)
            {
                rect33[i] = new int[3];
            }

            //int k = 0;
            for (int i = 0; i < rect33.Length; i++)
            {
                for (int j = 0; j < rect33[i].Length; j++)
                {
                    rect33[i][j] = ints[i*3+j];
                }
            }
            //rect33[0][0] = 0; rect33[0][1] = 8; rect33[1][0] = 1; rect33[1][1] = 3;

            //string[] strs = new string[rect22.Length];

            for (int i = 0; i < rect33.Length; i++)
            {
                Console.WriteLine(nmootan.GetJoinIntArrayToStrByStr(rect33[i], " "));

            }

        }


        /// <summary>
        /// 偶数 N が入力されます。まず、 1 行目には 1 以上 N / 2 以下の数値を半角スペース区切りですべて出力してください。次に、 2 行目には N / 2 + 1 以上 N 以下の数値を半角スペース区切りですべて出力してください。
        /// 各行の末尾には、半角スペースの代わりに改行を入れてください。
        /// </summary>
        public void Test41()
        {
            int n = nmootan.GetStdInt();
            //int[] ns = new int[n/2];
            List<int> nList = new List<int>();

            for (int i = 0; i < n/2; i++)
            {
                nList.Add(i + 1);
            }

            Console.WriteLine( nmootan.GetJoinIntArrayToStrByStr(nList.ToArray(), " "));

            nList.Clear();

            for (int i = 0; i < n/2; i++)
            {
                nList.Add(i + n / 2 + 1);
            }

            Console.WriteLine( nmootan.GetJoinIntArrayToStrByStr(nList.ToArray(), " "));
        }


        /// <summary>
        /// 自然数 N, M が与えられます。1 行目には 1 以上 N 以下の数値を半角スペース区切りで出力してください。また、2 行目には 1 以上 M 以下の数値を半角スペース区切りで出力してください。
        /// さらに、各行の末尾には、半角スペースの代わりに改行を入れてください。
        /// </summary>
        public void Test42()
        {
            int[] ns = nmootan.GetStdIntSplit().ToArray();
            int n = ns[0];
            int m = ns[1];
            //int[] ns = new int[n/2];
            List<int> nList = new List<int>();

            for (int i = 0; i < n; i++)
            {
                nList.Add(i + 1);
            }

            Console.WriteLine(nmootan.GetJoinIntArrayToStrByStr(nList.ToArray(), " "));

            nList.Clear();

            for (int i = 0; i < m; i++)
            {
                nList.Add(i + 1);
            }

            Console.WriteLine(nmootan.GetJoinIntArrayToStrByStr(nList.ToArray(), " "));
        }


        /// <summary>
        /// 自然数 N が与えられます。1 ≦ i ≦ N の各 i について、i 行目には以下の数列を出力してください。
        ///  1 以上 i 以下の数値をすべて、半角スペース区切りで出力してください
        /// </summary>
        public void Test43()
        {
            int n = nmootan.GetStdInt();
            int[][] ns = new int[n][];

            for (int i = 0; i < n; i++)
            {
                ns[i] = new int[i + 1];
                for (int j = 0; j < i+1; j++)
                {
                    ns[i][j] = j + 1;
                }

                Console.WriteLine(nmootan.GetJoinIntArrayToStrByStr(ns[i], " "));
            }

        }


        /// <summary>
        /// 自然数 N と N 個の要素の数列 M が与えられます。1 ≦ i ≦ N の各 i について、i 行目には以下の数列を出力してください。
        /// 1 以上 M_i 以下のすべての自然数を昇順、半角スペース区切りで出力してください。
        /// </summary>
        public void Test44()
        {
            int n = nmootan.GetStdInt();
            int[] m = nmootan.GetStrSplitToIntList(Console.ReadLine()).ToArray();
            List<int> ms = new List<int>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m[i]; j++)
                {
                    ms.Add(j + 1);
                }
                Console.WriteLine(nmootan.GetJoinIntArrayToStrByStr(ms.ToArray(), " "));
                ms.Clear();
            }

        }


        /// <summary>
        /// 自然数 N, M と N 個の自然数からなる数列 A と M 個の自然数からなる数列 B が与えられます。1 行目には数列 A の最初の B_1 個の値を出力し、 2 行目にはその次から B_2 個の値を出力します。このように、i 行目には数列 A の 1 + B_1 + B_2 + ... + B_{i - 1} 番目の値から B_i 個の値を出力してください。言い換えると、数列 A の値を B_1 個、B_2個、... B_M 個で分割し、それぞれの数列を改行区切りで出力してください。
        /// 10 4
        /// 1 2 3 4 5 6 7 8 9 10
        /// 2 6 1 1
        /// </summary>
        public void Test45()
        {
            Console.ReadLine();
            int[] ns = nmootan.GetStrSplitToIntList(Console.ReadLine()).ToArray();
            int[] ms = nmootan.GetStrSplitToIntList(Console.ReadLine()).ToArray();
            string str;
            //StringBuilder sb = new StringBuilder();

            Console.WriteLine( nmootan.GetJoinIntArrayToStrByStr(ns, " ", 0, ms[0] - 1));
            int sum = ms[0];
            
            for (int i = 1; i < ms.Length; i++)
            {
                Console.WriteLine( nmootan.GetJoinIntArrayToStrByStr(ns, " ", sum, sum+ ms[i]-1));

                sum += ms[i];
            }
        }


        /// <summary>
        /// 実数Nが入力されます。Nをそのまま出力してください。
        /// なお、末尾に余分な 0 を出力しないでください。
        /// </summary>
        public void Test46()
        {
            Console.WriteLine(nmootan.GetFormatZero(Console.ReadLine()));

        }


        /// <summary>
        /// 実数 N が入力されます。N を四捨五入して小数第 3 位まで出力してください。
        /// また、N の小数部が小数第 3 位に満たない場合は 0 で埋めて出力してください。
        /// </summary>
        public void Test47()
        {
            string str = Console.ReadLine();

            Console.WriteLine(nmootan.GetRoundFloatPointN(str, 3));

        }


        /// <summary>
        /// 実数 N、自然数 M が入力されます。N を四捨五入して小数第 M 位まで出力してください。
        /// また、N の小数部が小数第 M 位に満たない場合は 0 で埋めて出力してください。
        /// </summary>
        public void Test48()
        {

            string[] strs = nmootan.GetStdStrsSplit();



            Console.WriteLine(nmootan.GetRoundFloatPointN(strs[0], int.Parse( strs[1])));

        }


        /// <summary>
        /// 自然数 Q が与えられます。Q 回以下の問題に答えてください。
        /// 実数 N、自然数 M が入力されます。N を四捨五入して小数第 M 位まで出力してください。また、N の小数部が小数第 M 位に満たない場合は 0 で埋めて出力してください。
        /// </summary>
        public void Test49()
        {
            int q = nmootan.GetStdInt();
            string[][] strs = new string[q][];

            for (int i = 0; i < q; i++)
            {
                strs[i] = nmootan.GetStdStrsSplit();
            }

            for (int i = 0; i < q; i++)
            {
                Console.WriteLine(nmootan.GetRoundFloatPointN(strs[i][0], int.Parse(strs[i][1])));
            }

        }


        /// <summary>
        /// 自然数 N が与えられます。N が 3 けたになるよう数値の前に半角スペースを埋めて出力してください。
        /// </summary>
        public void Test50()
        {
            Console.WriteLine( nmootan.GetFormatWithSpace(Console.ReadLine(), 3));
        }


        /// <summary>
        /// 自然数 N が与えられます。N が 3 けたになるよう数値の前に 0 を埋めて出力してください。
        /// </summary>
        public void Test51()
        {

            Console.WriteLine(nmootan.GetFormatWithChar(Console.ReadLine(), 3,'0'));

        }


        /// <summary>
        /// 自然数 N が与えられます。N 個の自然数が与えられるので、それぞれを数値 M_i について以下の処理を行ってください。
        /// M_i が 3 けたになるよう数値の前に半角スペースを埋めて出力してください。
        /// </summary>
        public void Test52()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(nmootan.GetFormatWithChar(Console.ReadLine(), 3, ' '));
            }

        }


        /// <summary>
        /// 自然数 N, M が与えられます。N が M けたになるよう数値の前に半角スペースを埋めて出力してください。
        /// N M
        /// </summary>
        public void Test53()
        {
            int[] nm = nmootan.GetStdIntSplit().ToArray();

            Console.WriteLine(nmootan.GetFormatWithChar(nm[0].ToString(), nm[1], ' '));

        }


        /// <summary>
        /// 自然数 N, M と N 個の自然数 A_1, A_2, ..., A_N が与えられます。それぞれの数値が M けたになるよう数値の前に半角スペースを埋めて、改行区切りで出力してください。
        /// </summary>
        public void Test54()
        {
            int[] nm = nmootan.GetStdIntSplit().ToArray();

            for (int i = 0; i < nm[0]; i++)
            {
                Console.WriteLine(nmootan.GetFormatWithChar(Console.ReadLine(), nm[1], ' '));
            }

        }


        /// <summary>
        /// 文字列 S, T が与えられます。S + T = ST という形式で文字列を出力してください。
        /// </summary>
        public void Test55()
        {
            string s = Console.ReadLine();
            string t = Console.ReadLine();
            string[] st = { s, t };
            StringBuilder sb = new StringBuilder();

            sb.Append(nmootan.GetJoinStrArrayToStrByStr(st, " + "));
            sb.Append(" = ");
            sb.Append(s);
            sb.Append(t);

            Console.WriteLine(sb.ToString());
        }


        /// <summary>
        /// 自然数 N, A, B が与えられます。(A, B) という形式の文字列を N 回、カンマと半角スペース区切りで出力してください。
        /// N A B
        /// </summary>
        public void Test56()
        {
            int[] nab = nmootan.GetStdIntSplit().ToArray();
            StringBuilder sb = new StringBuilder();

            sb.Append("(");
            sb.Append(nab[1].ToString());
            sb.Append(", ");
            sb.Append(nab[2].ToString());
            sb.Append(")");

            string str = sb.ToString();

            for (int i = 0; i < nab[0]-1; i++)
            {
                sb.Append(", ");
                sb.Append(str);
            }

            str = sb.ToString();

            Console.WriteLine(str);
        }


        /// <summary>
        /// 九九表を、横の数値間では | (半角スペース 2 つとバーティカルライン)、縦の数値間では = で区切って出力してください。
        /// ただし、数値を出力する際は 2 けたになるよう半角スペース埋めで出力します。また、縦の数値間で = を出力する際は、その上の行と文字数が等しくなるように出力します。
        ///  3 |  6 |  9 | 12 | 15 | 
        ///  = |  = |  = | == | == | 
        ///  4 |  8 | 12 | 16 | 20 | 
        /// </summary>
        public void Test57()
        {

            nmootan.MatrixNNRestoreFormat2(9, 2, " | ", "=");

        }


        /// <summary>
        /// 自然数 H, W, A, B が与えられます。縦に H 行、横に W 列で計 H * W 個の (A, B) という形式の文字列を出力してください。ただし、横は | (半角スペース 2 つとバーティカルライン) 区切りで、縦は = で区切って出力してください。また、縦の文字列間で = を出力する際は、その上の行と文字数が等しくなるように出力します。
        /// </summary>
        public void Test58()
        {
            string[] hwab = nmootan.GetStdStrsSplit();

            string vec = nmootan.GetParseIntToVector2(hwab[2], hwab[3]);

            int h = int.Parse(hwab[0]);
            int w = int.Parse(hwab[1]);

            string[][] strs = new string[h][];
            for (int i = 0; i < h; i++)
            {
                strs[i] = new string[w];

                for (int j = 0; j < w; j++)
                {
                    strs[i][j] = vec;
                }
            }

            nmootan.MatrixStrArrayFormat(strs, " | ", "=");

        }


        /// <summary>
        /// 自然数 H, W, A, B が与えられます。縦に H 行、横に W 行で計 H * W 個の (A, B) という形式で文字列を出力してください。ただし、横は | (半角スペース 2 つとバーティカルライン) 区切りで、縦は = で区切って出力してください。また、縦の文字列間で = を出力する際は、その上の行と文字数がそろうように出力します。また、A と B は 9 けたになるように半角スペース埋めで出力してください。
        /// </summary>
        public void Test59()
        {

            string[] hwab = nmootan.GetStdStrsSplit();

            hwab[2] = nmootan.GetFormatWithChar(hwab[2], 9, ' ');
            hwab[3] = nmootan.GetFormatWithChar(hwab[3], 9, ' ');

            string vec = nmootan.GetParseIntToVector2(hwab[2], hwab[3]);

            int h = int.Parse(hwab[0]);
            int w = int.Parse(hwab[1]);

            string[][] strs = new string[h][];
            for (int i = 0; i < h; i++)
            {
                strs[i] = new string[w];

                for (int j = 0; j < w; j++)
                {
                    strs[i][j] = vec;
                }
            }

            nmootan.MatrixStrArrayFormat(strs, " | ", "=");


        }


        /// <summary>
        /// 正の整数 N が与えられるので、1 〜 N の整数を 1 から順に半角スペース区切りで 1 行で出力してください。
        /// </summary>
        public void Test60()
        {
            int[] ns = new int[int.Parse( Console.ReadLine())];
            for (int i = 0; i < ns.Length; i++)
            {
                ns[i] = i + 1;
            }

            Console.WriteLine(nmootan.GetJoinIntArrayToStrByStr(ns, " "));

        }


        /// <summary>
        /// 正の整数 N が与えられるので、1 〜 N の整数を 1 から順に改行区切りで N 行で出力してください。
        /// </summary>
        public void Test61()
        {
            int[] ns = new int[int.Parse(Console.ReadLine())];
            for (int i = 0; i < ns.Length; i++)
            {
                ns[i] = i + 1;
            }

            Console.WriteLine(nmootan.GetJoinIntArrayToStrByStr(ns, "\n"));

        }


        /// <summary>
        /// 整数 N が与えられるので、 1 から 5 までの数字を半角スペース区切りしたもの
        /// "1 2 3 4 5" を N 行出力してください。
        /// </summary>
        public void Test62()
        {
            int n = int.Parse(Console.ReadLine());
            int[] ns = new int[5];
            for (int i = 0; i < 5; i++)
            {
                ns[i] = i + 1;
            }

            string str = nmootan.GetJoinIntArrayToStrByStr(ns, " ");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(str);
            }

        }


        /// <summary>
        /// 整数 N , K が与えられるので、 1 から N までの数字を半角スペース区切りしたもの
        /// "1 2 ... (N-1) N" を K 行出力してください。
        /// </summary>
        public void Test63()
        {
            int[] nk = nmootan.GetStdIntSplit().ToArray();

            int[] ns = new int[nk[0]];
            for (int i = 0; i < nk[0]; i++)
            {
                ns[i] = i + 1;
            }

            string str = nmootan.GetJoinIntArrayToStrByStr(ns, " ");

            for (int i = 0; i < nk[1]; i++)
            {
                Console.WriteLine(str);
            }


        }


        /// <summary>
        /// 整数 N , K と N 行 K 列 の二次元配列 A が与えられるので、その配列をそのまま出力してください。
        /// </summary>
        public void Test64()
        {
            int[] nk = nmootan.GetStdIntSplit().ToArray();

            string[][] strs = new string[nk[0]][];

            for (int i = 0; i < nk[0]; i++)
            {
                strs[i] = nmootan.GetStdStrsSplit();
            }

            //nmootan.MatrixStrArrayFormat(strs, " ", "");
            for (int i = 0; i < nk[0]; i++)
            {
                Console.WriteLine(nmootan.GetJoinStrArrayToStrByStr(strs[i], " "));
            }
        }


        /// <summary>
        /// 整数 N , K と N 行 K 列 の二次元配列 A が与えられます。 A の要素のうち、1 要素だけ 1 になっている要素があるので、その要素の行と列を出力してください。
        /// </summary>
        public void Test65()
        {
            int[] nk = nmootan.GetStdIntSplit().ToArray();

            string[][] strs = nmootan.GetStdMatrix(nk[0]);
            int foundI = -1, foundK = -1;

            for (int i = 0; i < nk[0]; i++)
            {
                foundK = Array.IndexOf(strs[i], "1");
                if(foundK>=0)
                {
                    foundI = i;
                    break;
                }
            }

            nk[0] = foundI + 1;
            nk[1] = foundK + 1;

            Console.WriteLine(nmootan.GetJoinIntArrayToStrByStr(nk, " "));
        }


        /// <summary>
        /// 整数 N , K と N 行 K 列 の二次元配列 A が与えられます。 A の要素のうち、最大の要素の値を出力してください。
        /// </summary>
        public void Test66()
        {
            int[] nk = nmootan.GetStdIntSplit().ToArray();

            int[][] ns = nmootan.GetStdIntMatrix(nk[0]);

            //int[] max = new int[nk[0]];
            int[] max = new int[nk[0]];
            for (int i = 0; i < nk[0]; i++)
            {
                max[i] = ns[i].Max();
            }

            Console.WriteLine(max.Max());
        }


        /// <summary>
        /// 整数 N , K と N 行 K 列 の二次元配列 A が与えられるので、 A の行ごとの和を出力してください。
        /// </summary>
        public void Test67()
        {
            int[] nk = nmootan.GetStdIntSplit().ToArray();

            int[][] ns = nmootan.GetStdIntMatrix(nk[0]);

            //int[] max = new int[nk[0]];
            int[] sum = new int[nk[0]];

            for (int i = 0; i < nk[0]; i++)
            {
                Console.WriteLine( ns[i].Sum());

            }

        }


        /// <summary>
        /// 整数 N が与えられるので、次の処理を N 回してください。
        ///・ 配列のサイズ K とその要素 A1 ... AK が与えられるので、全ての要素の和を求めて出力してください。
        ///N
        ///K1 A1_1 A1_2...A1_K1
        ///...
        ///KN AN_1 AN_2...AN_KN
        /// </summary>
        public void Test68()
        {
            int n = int.Parse(Console.ReadLine());

            List<int> ks;
            for (int i = 0; i < n; i++)
            {
                ks = nmootan.GetStdIntSplit();
                ks.RemoveAt(0);
                Console.WriteLine(ks.Sum());
            }

        }


        /// <summary>
        /// 整数 N が与えられるので、次の規則に従って N 行の出力をしてください。
        ///・ N 行のうち、 i 行目では、1 から i までの数字を半角スペース区切りで出力してください。
        ///例として、 N = 3 のとき、出力は次の通りになります。
        /// </summary>
        public void Test69()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] ns = new int[i + 1];
                for (int j = 0; j < i+1; j++)
                {
                    ns[j] = j + 1;
                }

                Console.WriteLine(nmootan.GetJoinIntArrayToStrByStr(ns, " "));
            }

        }


        /// <summary>
        /// 配列 A と B についての情報が与えられるので、(A の 1 つの要素) × (B の 1 つの要素) の最大値を求めてください。
        /// ・ 1 行目では、配列 A の要素数を表す整数 N と配列 B の要素数を表す整数 K が半角スペース区切りで与えられます。
        /// ・ 2 行目では、配列 A の各要素が半角スペース区切りで与えられます。
        /// ・ 3 行目では、配列 B の各要素が半角スペース区切りで与えられます。
        /// </summary>
        public void Test70()
        {
            int[] nk = nmootan.GetStdIntSplit().ToArray();

            int[] ns = nmootan.GetStdIntSplit().ToArray();
            int[] ks = nmootan.GetStdIntSplit().ToArray();

            //int[] max = new int[nk[0]];
            int[][] multi = new int[nk[0]][];
            int[] max = new int[nk[0]];

            for (int i = 0; i < nk[0]; i++)
            {
                multi[i] = new int[nk[1]];
                for (int j = 0; j < nk[1]; j++)
                {
                    multi[i][j] = ns[i] * ks[j];
                }
                max[i] = multi[i].Max();
            }

            Console.WriteLine(max.Max());
        }


        /// <summary>
        /// N 行 K 列の行列 A の i 行 j 列 の要素 A_ij を A_ji とした K 行 N 列の行列を元の配列 A の転置行列と言います。
        /// 行列 A についての情報が与えられるので、A の転置行列を出力してください。
        /// ・ 1 行目では行列の行数 N と列数 K が半角スペース区切りで与えられます。
        /// ・ 続く N 行では、A の各要素 A_ij(1 ≦ j ≦ Ki) が半角スペース区切りで与えられます。
        /// </summary>
        public void Test71()
        {
            int[] nk = nmootan.GetStdIntSplit().ToArray();

            int[][] matrix = nmootan.GetStdIntMatrix(nk[0]);
            //int[][] nsCopy = ns;

            ////int[] max = new int[nk[0]];
            ////int[] sum = new int[nk[0]];

            //for (int i = 0; i < nk[0]; i++)
            //{
            //    for (int j = 0; j < nk[1]; j++)
            //    {
            //        nsCopy[j][i] = ns[i][j];
            //    }

            //}

            matrix = nmootan.GetTranspose(matrix);

            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(nmootan.GetJoinIntArrayToStrByStr(matrix[i], " "));
            }

        }


        /// <summary>
        /// 配列 A の要素数 N とその要素 A_i (1 ≦ i ≦ N) が与えられるので、A についてのかけ算表 B を出力してください。かけ算表は N * N の二次元配列の形式とし、B の i 行 j 列の要素 B_ij について、B_ij = Ai * Aj (1 ≦ i , j ≦ N) が成り立つものとします。
        /// ・ 1 行目では配列 A の要素数 N が与えられます。
        /// ・ 2 行目では、A の各要素 A_i(1 ≦ i ≦ N) が半角スペース区切りで与えられます。
        /// </summary>
        public void Test72()
        {
            int n = int.Parse(Console.ReadLine());
            int[] aArray = nmootan.GetStdIntSplit().ToArray();
            int[][] matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    matrix[i][j] = aArray[i] * aArray[j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(nmootan.GetJoinIntArrayToStrByStr(matrix[i], " "));
            }
        }


        /// <summary>
        /// 整数 N が与えられるので、2 以上 N 以下の素数の個数を求めてください。
        /// 素数とはの約数が 1 と X のみであるような整数 X のことを指します。
        /// </summary>
        public void Test73()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(nmootan.GetPrimeNum(n).Length);

        }


        /// <summary>
        /// 整数 N が与えられるので、1 × 2 × ... × (N-1) × N を最大で何回 2 で割ることができるかを求めてください。
        /// 123456789 10
        /// </summary>
        public void Test74()
        {
            Console.WriteLine(nmootan.ExPrimeCount(ulong.Parse(Console.ReadLine()), (ulong)2));
            //Console.WriteLine(nmootan.GetPrimeCount(nmootan.ExFact(Console.ReadLine()), "2"));

            //Console.WriteLine(nmootan.ExPlus("999", "1"));
            //Console.WriteLine(nmootan.GetFormatZero("00"));
            //string syou;
            //Console.WriteLine("mod={0}, syou={1}", nmootan.ExMod(Console.ReadLine(), Console.ReadLine(), out syou), syou);
            //Console.WriteLine(nmootan.ExMod("1023", "4"));
            //Console.WriteLine(nmootan.ExMultiply("234", "100"));
            //Console.WriteLine(nmootan.ExCompareTo("100", "101"));
            //Console.WriteLine(nmootan.ExMinus("1022", "20"));
            //Console.WriteLine(nmootan.ExFact(Console.ReadLine()));
            //Console.WriteLine(nmootan.GetPrimeCount(Console.ReadLine(), Console.ReadLine()));
            //int count = 0;
            //ulong n = ulong.Parse(nmootan.GetFact(Console.ReadLine()));
            //ulong m = n % 2;
            //while (n % 2 == 0)
            //{
            //    //Console.WriteLine(n);
            //    n /= 2;
            //    count++;
            //}
            //Console.WriteLine(count);
            ////Console.WriteLine(Math.Log(double.Parse(nmootan.GetFact(Console.ReadLine())), 2));
        }


        /// <summary>
        /// 普通の鳩時計は 1 時間に 1 回しか鳴かないのでつまらないと思ったあなたは、鳩時計を改造してスーパー鳩時計を作りました。このスーパー鳩時計は時刻が x 時 y 分のとき x + y が 3の倍数のとき"FIZZ"、5 の倍数のとき"BUZZ", 3の倍数かつ5の倍数のとき "FIZZBUZZ" と鳴き、これらのいずれにも当てはまらなかった場合は鳴きません。なお、0 は 3 の倍数かつ 5 の倍数であるとします。 0 時 0 分　〜 23 時 59 分 の各分のスーパー鳩時計の様子を出力してください。
        /// 0 時 0 分の鳩時計の鳴き声
        /// 0 時 1 分の鳩時計の鳴き声
        /// ...
        /// 23 時 58 分の鳩時計の鳴き声
        /// 23 時 59 分の鳩時計の鳴き声
        /// 0 時 0 分から 23 時 59 分までの各分の鳩時計の鳴き声を以上の形式で出力してください。
        /// 何も鳴かない時間は改行のみを出力してください。
        /// </summary>
        public void Test75()
        {
            const string STR3 = "FIZZ";
            const string STR5 = "BUZZ";
            const string STR35 = "FIZZBUZZ";
            //DateTime dateTime;

            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    if ((i + j) % 3 == 0)
                    {
                        if((i + j) % 5 == 0)
                        {
                            Console.WriteLine(STR35);
                        }
                        else
                        {
                            Console.WriteLine(STR3);
                        }
                    }
                    else if ((i + j) % 5 == 0)
                    {
                        Console.WriteLine(STR5);
                    }
                    else
                    {
                        Console.WriteLine("");
                    }
                }
            }

        }



        /// <summary>
        /// x + y < 100 かつ (x ^ 3) + (y ^ 3) < 100000 が成り立つような正の整数 x , y について x × y の最大値を求めてください。
        /// ・ ヒント
        /// 2 つの式を連立不等式として解きたくなりますが、x + y< 100 に注目すると、(x, y) のとりうる値は(1,1) , (1,2) , (1,98) , (2,1)... (98,1) のいずれかであり、これらは高々 98 + 97 + ... + 1 = 99 × 44 = 4356 通り（等差数列の和の公式を利用）であるため、全ての組を調べても実行時間制限に間に合います。
        /// </summary>
        public void Test76()
        {
            List<int> results = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (i+j<100 && i*i*i+j*j*j< 100000)
                    {
                        results.Add(i * j);
                    }
                }
            }

            Console.WriteLine(results.Max().ToString());

        }



        /// <summary>
        /// paiza国では、1 円と X 円と Y 円の 3 種類の硬貨しかありません。ちょうど Z 円を支払うとき、支払う硬貨の枚数が最小になるように支払ったときの硬貨の枚数を求めてください。ただし、支払う各硬貨の枚数に制限は無いものとします。
        /// </summary>
        public void Test77()
        {
            List<int> zs = new List<int>();
            int[] xyz = nmootan.GetStdIntSplit().ToArray();


            for (int i = 0; i <= xyz[2]; i++)
            {
                for (int j = 0; j*xyz[0] <= xyz[2]; j++)
                {
                    for (int k = 0; k*xyz[1] <= xyz[2]; k++)
                    {
                        if (i+j*xyz[0]+k*xyz[1]==xyz[2])
                        {
                            //Console.WriteLine("{0},{1},{2}",i, j, k);
                            zs.Add(i + j + k);
                        }
                    }
                }
            }

            Console.WriteLine(zs.Min().ToString());

        }



        /// <summary>
        /// 整数 N が与えられるので、三角形の三辺の長さの和が N であり、全ての辺の長さが整数であるような直角三角形が存在するかどうかを判定してください。なお、直角三角形の斜辺 a と他の二辺 b , c の間には次のような三平方の定理が成り立ちます。
        /// 三辺の長さの和が N であるような全ての三角形の三辺 a , b , c の組み合わせのうち、三平方の定理を満たすものが 1 つでもあれば "YES" , それ以外の場合は "NO" が答えとなります。全ての三辺の場合を全列挙することができれば三平方の定理を満たすかの判定をすることで答えを求めることができます。
        /// </summary>
        public string Test78()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    for (int k = 1; k < n; k++)
                    {
                        if (i + j + k == n)
                        {
                            if (i*i==j*j+k*k)
                            {
                                return "YES";
                            }
                        }
                    }
                }
            }

            return "NO";

        }


        /// <summary>
        /// 配列 A の要素数 N と整数 K, 配列 A の各要素 A_1, A_2, ..., A_N が与えられるので、配列 A に K がいくつ含まれるか数えてください。
        /// ・1 行目では、配列 A の要素数 N と整数 K が半角スペース区切りで与えられます。
        /// ・続く N 行では、配列 A の要素が先頭から順に与えられます。
        /// </summary>
        public void Test79()
        {
            int[] nk = nmootan.GetStdIntSplit().ToArray();
            //int[] a = new int[nk[0]];
            int count = 0;
            for (int i = 0; i < nk[0]; i++)
            {
                if (int.Parse(Console.ReadLine()) == nk[1]) count++;

            }

            //int found = 0;
            //while (found<=nk[0])
            //{
            //    found = Array.IndexOf(a, nk[1], found+1);
            //    count++;
            //}

            Console.WriteLine(count);

        }


        /// <summary>
        /// 配列 A の要素数 N と配列 A の各要素 A_1, A_2, ..., A_N が整数として与えられるので、配列 A の全ての要素の和を求めてください。
        /// ・1 行目では、配列 A の要素数 N が与えられます。
        /// ・続く N 行では、配列 A の要素が先頭から順に与えられます。
        /// </summary>
        public void Test80()
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(a.Sum());

        }


        /// <summary>
        /// 配列 A の要素数 N と配列 A の各要素である整数 A_1, A_2, ..., A_N が与えられるので、配列 A の要素の最大値 max を求めてください。
        /// ・1 行目では、配列 A の要素数 N が与えられます。
        /// ・続く N 行では、配列 A の要素が先頭から順に与えられます。
        /// </summary>
        public void Test81()
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(a.Max());

        }


        /// <summary>
        /// 配列 A の要素数 N と整数 K , 配列 A の各要素 A_1, A_2, ..., A_N が与えられるので、A に K が 1 つでも含まれている場合は Yes を、含まれていない場合は No を出力してください。
        /// </summary>
        public void Test82()
        {
            int[] nk = nmootan.GetStdIntSplit().ToArray();
            int[] a = new int[nk[0]];

            for (int i = 0; i < nk[0]; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            }

            if (a.Contains(nk[1])) Console.WriteLine("Yes");
            else Console.WriteLine("No");


        }


        /// <summary>
        /// 配列 A の要素数 N と整数 K , 配列 A の各要素 A_1, A_2, ..., A_N が与えられるので、K であるような A の要素のうち、要素番号が最小のものを出力してください。
        /// A に K が含まれない場合は -1 を出力してください。
        /// </summary>
        public void Test83()
        {
            int[] nk = nmootan.GetStdIntSplit().ToArray();
            int[] a = new int[nk[0]];

            for (int i = 0; i < nk[0]; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            }

            int index = Array.IndexOf(a, nk[1]);
            if (index == -1) Console.WriteLine("-1");
            else Console.WriteLine( Array.IndexOf(a, nk[1])+1);
            //if (index == -1) Console.WriteLine("-1");
            //else Console.WriteLine(a[index]);


        }


        /// <summary>
        /// 配列 A の要素数 N と配列 A の各要素 A_1, A_2, ..., A_N が与えられるので、配列 A には何種類の値が含まれているかを求めてください。
        /// </summary>
        public void Test84()
        {
            int[] nk = nmootan.GetStdIntSplit().ToArray();
            int[] a = new int[nk[0]];

            for (int i = 0; i < nk[0]; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            }

            HashSet<int> hs = new HashSet<int>(a);
            //int[] results = new int[hs.Count];
            //hs.CopyTo(results, 0);
            Console.WriteLine(hs.Count);


        }


        /// <summary>
        /// 配列 A の要素数 N と整数 K, 配列 A の各要素 A_1, A_2, ..., A_N が与えられるので、配列 A の全ての要素を + K した後の A の各要素を出力してください。
        /// </summary>
        public void Test85()
        {
            int[] nk = nmootan.GetStdIntSplit().ToArray();
            int[] a = new int[nk[0]];

            for (int i = 0; i < nk[0]; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
                a[i] += nk[1];
            }

            for (int i = 0; i < nk[0]; i++)
            {
                Console.WriteLine(a[i]);
            }

        }


        /// <summary>
        /// 配列 A の要素数 N と配列 A の各要素 A_1, A_2, ..., A_N が与えられるので、A の要素の順序を逆にした配列 B を作成し、出力してください。
        /// ・1 行目では、配列 A の要素数 N が与えられます。
        /// ・続く N 行では、配列 A の要素が先頭から順に与えられます。
        /// </summary>
        public void Test86()
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            }

            int[] b = a.Reverse().ToArray();

            for (int i = 0; i < b.Length; i++)
            {
                Console.WriteLine(b[i]);
            }


        }


        /// <summary>
        /// 整数型の変数を 2 つ宣言して整数 X, Y を格納したのち、2 つの変数の中身を入れ替えた後の 2 つの変数の値を出力してください。
        /// ・1 行で、整数 X, Y が半角スペース区切りで入力されます。
        /// </summary>
        public void Test87()
        {
            int[] xy = nmootan.GetStdIntSplit().ToArray();

            int[] yx = xy.Reverse().ToArray();

            Console.WriteLine(nmootan.GetJoinIntArrayToStrByStr(yx, " "));

        }


        /// <summary>
        /// 配列 A の要素数 N と配列 A の各要素 A_1, A_2, ..., A_N , 交換する A の要素番号　X, Y が与えられるので、A_X と A_Y を入れ替えた後の A を出力してください。
        /// ・1 行目では、配列 A の要素数 N が与えられます。
        /// ・続く N 行では、配列 A の要素が先頭の A_1 から順に与えられます。
        /// ・最後の 1 行で、X, Y が半角スペース区切りで与えられます。
        /// </summary>
        public void Test88()
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            }

            int[] xy = nmootan.GetStdIntSplit().ToArray();

            a = nmootan.GetReplaceMembersInIntArray(a, xy[0]-1, xy[1]-1);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(a[i]);
            }
        }


        /// <summary>
        /// 配列 A と追加する要素 B が与えられるので、B を A の末尾に追加したのち、A の全ての要素を出力してください。
        /// ・1 行目では、配列 A の要素数 N が与えられます。
        /// ・続く N 行では、配列 A の要素が先頭の A_1 から順に与えられます。
        /// ・最後の行では、末尾に追加する値 B が与えられます。
        /// </summary>
        public void Test89()
        {
            int n = int.Parse(Console.ReadLine());
            List<int> a = new List<int>();

            for (int i = 0; i < n; i++)
            {
                a.Add( int.Parse(Console.ReadLine()));
            }

            a.Add(int.Parse(Console.ReadLine()));

            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }

        }


        /// <summary>
        /// 配列 A と追加する位置 n と追加する要素 B が与えられるので、B を A_n の後ろに追加した後の A を出力してください。
        /// ・1 行目では、配列 A の要素数 N が与えられます。
        /// ・続く N 行では、配列 A の要素が先頭(A_1)から順に与えられます。
        /// ・最後の行では、数値を追加する要素番号 n と、追加する値 B が与えられます。
        /// </summary>
        public void Test90()
        {
            int n = int.Parse(Console.ReadLine());
            List<int> a = new List<int>();

            for (int i = 0; i < n; i++)
            {
                a.Add(int.Parse(Console.ReadLine()));
            }

            int[] nb = nmootan.GetStdIntSplit().ToArray();

            a.Insert(nb[0], nb[1]);

            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }

        }


        /// <summary>
        /// 配列 A とその要素数 N と削除する要素の番号 n が与えられるので、A から A_n を削除し、A を要素数 N - 1 の配列とした後の A の各要素を出力してください。
        /// 1 行目では、配列 A の要素数 N が与えられます。
        /// 続く N 行では、配列 A の要素が先頭の A_1 から順に与えられます。
        /// 最後の行では、数値を削除する要素番号 n が与えられます。
        /// </summary>
        public void Test91()
        {
            int n = int.Parse(Console.ReadLine());
            List<int> a = new List<int>();

            for (int i = 0; i < n; i++)
            {
                a.Add(int.Parse(Console.ReadLine()));
            }

            int nr = int.Parse(Console.ReadLine());

            a.RemoveAt(nr - 1);

            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }


        }


        /// <summary>
        /// 期待する出力にあるような、九九表を出力してください。
        /// </summary>
        public void Test92()
        {
            nmootan.Matrix99();

        }


        /// <summary>
        /// 配列 A の要素数 N と配列 A の各要素 A_1, A_2, ..., A_N が与えられるので、A の要素の全てのペアについてのかけ算の結果を出力してください。
        /// ・1 行目では、配列 A の要素数 N が与えられます。
        /// ・続く N 行では、配列 A の要素が先頭から順に与えられます。
        /// </summary>
        public void Test93()
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 1; i < a.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.WriteLine(a[i] * a[j]);
                }
            }


        }


        /// <summary>
        /// 配列 A の要素数 N と新たに作成する配列のサイズ n , 配列 A の各要素 A_1 ... A_N が与えられるので、配列 A の先頭から n 要素を順に保持する配列を作成してください。新たに作成する配列の要素数が A の要素数よりも大きい時は、サイズが合うように 0 を A の要素の末尾に追加してください。
        /// ・ 1 行目では、配列 A の要素数 N と新たに作成する配列の要素数 n が半角スペース区切りで与えられます。
        /// ・ 続く N 行では、配列 A の要素が先頭から順に与えられます。
        /// </summary>
        public void Test94()
        {
            int[] nn = nmootan.GetStdIntSplit().ToArray();

            List<int> a = new List<int>();

            for (int i = 0; i < nn[0]; i++)
            {
                a.Add(int.Parse(Console.ReadLine()));
            }

            if (nn[0] < nn[1])
            {
                for (int i = 0; i < nn[1] - nn[0]; i++)
                {
                    a.Add(0);
                }

                for (int i = 0; i < a.Count; i++)
                {
                    Console.WriteLine(a[i]);
                }
            }
            else
            {
                for (int i = 0; i < nn[1]; i++)
                {
                    Console.WriteLine(a[i]);
                }
            }



        }


        /// <summary>
        /// 配列 A の要素数 N と配列 A の各要素 A_1, A_2, ..., A_N が与えられるので、同じ値の要素が 2 つ以上含まれないように A を加工した新たな配列 B を作成してください。
        /// ただし、 A に同じ値の要素が 2 つ以上あった場合、それらのうち先頭の要素を B に採用するものとします。
        /// ・ 1 行目では、配列 A の要素数 N が与えられます。
        /// ・ 続く N 行では、配列 A の要素が先頭から順に与えられます。
        /// </summary>
        public void Test95()
        {
            int n = int.Parse(Console.ReadLine());
            //int[] nk = nmootan.GetStdIntSplit().ToArray();
            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            }

            HashSet<int> hs = new HashSet<int>(a);
            int[] b = new int[hs.Count];
            hs.CopyTo(b, 0);

            for (int i = 0; i < b.Length; i++)
            {
                Console.WriteLine(b[i]);
            }

        }


        /// <summary>
        /// 配列 A の要素数 N と整数 K , 配列 A の各要素 A_1 ... A_N が与えられるので、K 以上であるような配列 A の要素のみを要素として持つ配列 B を作成し、その要素を出力してください。 B の要素の順は A と同じにしてください。
        /// </summary>
        public void Test96()
        {
            int[] nk = nmootan.GetStdIntSplit().ToArray();
            //int[] nk = nmootan.GetStdIntSplit().ToArray();
            int[] a = new int[nk[0]];

            for (int i = 0; i < nk[0]; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            }

            List<int> b = new List<int>();

            for (int i = 0; i < nk[0]; i++)
            {
                if (a[i] >= nk[1]) b.Add(a[i]);
            }

            for (int i = 0; i < b.Count; i++)
            {
                Console.WriteLine(b[i]);
            }


        }


        /// <summary>
        /// paiza の入社試験では 科目 1 〜 5 の 5 科目のテストが課せられており、それぞれの科目には重みが設定されています。受験者の得点は各科目の (とった点数) * (科目の重み) となります。 5 科目の得点の合計が最も高かった受験者の得点を求めてください。
        /// ・1 行目では、受験者の人数を表す整数 N が与えられます。
        /// ・2 行目では、1 〜 5 の各科目の重みを表す整数 M_1 〜 M_5 が半角スペース区切りで与えられます。
        /// ・続く N 行のうち i 行目では i 番目の受験者が各科目でとった点数を表す整数 A_ { i,1} 〜 A_{i,5}
        /// が半角スペース区切りで与えられます。
        /// </summary>
        public void Test97()
        {
            int n = int.Parse(Console.ReadLine());

            int[] ms = nmootan.GetStdIntSplit().ToArray();

            int[][] a = new int[n][];
            for (int i = 0; i < n; i++)
            {
                a[i] = nmootan.GetStdIntSplit().ToArray();
            }

            int[] sums = new int[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    sums[i] += a[i][j] * ms[j];
                }
            }

            Console.WriteLine(sums.Max());
        }


        /// <summary>
        /// 人事のあなたは、N 人の中から採用者を決定します。N 人のテストの点数はそれぞれ A_i (1 ≦ i ≦ N)です。テストの点数が K 点以上の人全員を採用したいのですが、得点の高い方から M 人に辞退されてしまいました。あなたの採用することのできる最大の人数を答えてください。採用できる人数が 0 人の場合もあることに気をつけてください。
        /// ・1 行目では、テストを受けた人数 N と、テストのボーダーの点数 K , 辞退された人数 M が半角スペース区切りで与えられます。
        /// ・続く N 行では、N 人のテストの点数 A_i(1 ≦ i ≦ N)が改行区切りで与えられます。
        /// </summary>
        public void Test98()
        {
            int[] nkm = nmootan.GetStdIntSplit().ToArray();
            int[] a = new int[nkm[0]];
            for (int i = 0; i < nkm[0]; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            }

            List<int> b = a.ToList();
            b.Sort();

            b.RemoveRange(nkm[0] - nkm[2], nkm[2]);

            int count = 0;
            for (int i = 0; i < b.Count; i++)
            {
                if (b[i] >= nkm[1]) count++;
            }

            Console.WriteLine(count);
        }


        /// <summary>
        /// データ構造の queue と同様の働きをするロボットがあります。ロボットは指示に応じて配列 A に対して 2 種類の仕事を行います、仕事の内容は以下の通りです。
        /// ・in n と指示された場合、A の末尾に n を追加してください。
        /// ・out と指示された場合、A の先頭の要素を削除してください。ただし、A が既に空の場合、何も行わないでください。
        /// ロボットに与えられる指示の回数 N と、各指示の内容 S_i が与えられるので、ロボットが全ての処理を順に行った後の A の各要素を出力してください。
        /// なお、初め配列 A は空であるものとします。
        /// </summary>
        public void Test99()
        {
            int n = int.Parse(Console.ReadLine());
            //int[] a = new int[n];
            List<int> a = new List<int>();
            string s;
            string[] t=new string[2];
            for (int i = 0; i < n; i++)
            {
                s = Console.ReadLine();
                if (s=="out")
                {
                    if(a.Count > 0) a.RemoveAt(0);
                }
                else
                {
                    t = nmootan.GetStrsSplitByChar(s,' ');
                    //Console.WriteLine("t[0]={0}, t[1]={1}", t[0], t[1]);
                    a.Add(int.Parse(t[1]));
                }
            }

            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }


        }


        /// <summary>
        /// 生徒の身長が A_1, ...., A_N であるような N 人のクラスで二人三脚の代表を決めることにしました。代表には、身長の差が最も小さいような 2 人を選出することにしました。選ばれた 2 人の身長を昇順に出力してください。
        /// ・1 行目では、クラスの人数 N が半角スペース区切りで与えられます。
        /// ・続く N 行では、クラスメイト N 人の身長が与えられます。
        /// </summary>
        public void Test100()
        {
            int n = int.Parse(Console.ReadLine());
            List<int> a = new List<int>();
            for (int i = 0; i < n; i++)
            {
                a.Add(int.Parse(Console.ReadLine()));
            }

            a.Sort();
            int sub=a[1]-a[0];
            int[] b=new int[2];
            for (int i = 1; i < a.Count-1; i++)
            {
                if (a[i + 1] - a[i] < sub)
                {
                    b[0] = a[i];
                    b[1] = a[i + 1];
                }
            }

            for (int i = 0; i < b.Length; i++)
            {
                Console.WriteLine(b[i]);
            }

        }


        /// <summary>
        /// 開店直後に店に入るために、番号 1 〜 N の N 人が開店前に店の前にブルーシートを合計 K 枚置きました。ブルーシートの先頭は A_1 , 最後尾は A_K です。しかし、店側は先頭から F 枚のブルーシートを撤去しました。
        /// 1 〜 N 番の人々は次のルールに従って店に並びます。
        /// ・自分のブルーシートが 1 枚以上残っているとき、自分のブルーシートのうち、最も先頭に近いブルーシートの位置に並ぶ。
        /// ・自分のブルーシートが 1 枚も残っていないとき、並ぶことなく帰宅する。
        /// 全員が並び終わった後に待機列にいる人の番号を先頭から順に答えてください。
        /// ・1 行目では、並びの人数 N とブルーシートの合計枚数 K と先頭から撤去されるブルーシートの枚数 F が半角スペース区切りで与えられます。
        /// ・続く K 行では、ブルーシートの所有者の番号 A_i(1 ≦ i ≦ N) が先頭から順に与えられます。
        /// </summary>
        public void Test101()
        {
            int[] nkf = nmootan.GetStdIntSplit().ToArray();
            List<int> a = new List<int>();
            for (int i = 0; i < nkf[2]; i++)
            {
                Console.ReadLine();
            }
            for (int i = nkf[2]; i < nkf[1]; i++)
            {
                a.Add(int.Parse(Console.ReadLine()));
            }
            HashSet<int> hs = new HashSet<int>(a);
            int[] b = hs.ToArray();

            for (int i = 0; i < b.Length; i++)
            {
                Console.WriteLine(b[i]);
            }

        }


        /// <summary>
        /// あなたはボウリングをしています。フレームの 1 投目を投げ終わったあなたは、次に狙うピンの番号と残っているピンの本数を知りたくなりました。ピンの情報が与えられるので、狙うべきピンの番号と残っているピンの本数を求めてください。
        /// 狙うピンの決め方は次の通りとします。
        /// - 残っているピンのうち、先頭(P_1側) のピンを狙います。ただし、同じ列に複数ピンがある場合は、それらのうちピン番号が最も小さいピンを狙います。
        /// ・4 行でピンの情報が与えられます。ピン番号は以上の通りです。
        /// ・P_1 が先頭のピンです。
        /// ・P_i(1 ≦ i ≦ 10) が 0 のとき、その位置にはピンがないことを、1 のときその位置にピンが残っていることを表します。
        /// P_10 P_9 P_8 P_7
        /// P_6 P_5 P_4
        /// P_3 P_2
        /// P_1
        /// </summary>
        public void Test102()
        {
            //int[][] p = new int[4][];
            List<int> p = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                p.AddRange(nmootan.GetStdIntSplit());
                //p[i] = nmootan.GetStdIntSplit().ToArray();
            }

            //int[] q = new int[10];

            for (int i = 0; i < 10; i++)
            {
                if (p[9 - i] == 1)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            }

            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                if (p[i] == 1) count++;
            }

            Console.WriteLine(count);
        }


        /// <summary>
        /// あなたは集団行動のリーダーです。次のような指示を出すことで様々な列の操作ができます。
        /// ・swap A B
        /// 先頭から A 番目の人と、先頭から B 番目の人の位置を入れ替える。
        /// ・reverse
        /// 列の前後を入れ替える。
        /// ・resize C
        /// 先頭から C 人を列に残し、それ以外の人を全員列から離れさせる。ただし、列が既に C 人以下の場合、何も行わない。
        /// 初め、列には番号 1 〜 N の N 人がおり、先頭から番号の昇順に並んでいます。(1, 2 , 3, ..., N)
        /// あなたの出した指示の回数 Q とその指示の内容 S_i(1 ≦ i ≦ Q) が順に与えられるので、全ての操作を順に行った後の列を出力してください。
        /// ・1 行目では、初めの列の人数 N と、指示の回数 Q が半角スペース区切りで与えられます。
        /// ・以降の N 行では指示の内容を表す S_i(1 ≦ i ≦ N) が与えられます。
        /// </summary>
        public void Test103()
        {
            int[] nq = nmootan.GetStdIntSplit().ToArray();
            List<int> a = new List<int>();
            for (int i = 0; i < nq[0]; i++)
            {
                //a[i] = i + 1;
                a.Add(i + 1);
            }

            List<string> q = new List<string>();
            for (int i = 0; i < nq[1]; i++)
            {
                q = nmootan.GetStdStrsSplit().ToList();
                switch (q[0])
                {
                    case "swap":
                        a = nmootan.GetReplaceMembersInIntList(a, int.Parse(q[1])-1, int.Parse(q[2])-1);
                        break;
                    case "reverse":
                        a.Reverse();
                        break;
                    case "resize":
                        if (a.Count > int.Parse(q[1])) a.RemoveRange(int.Parse(q[1]), a.Count - int.Parse(q[1]));
                        break;
                    default:
                        break;
                }
            }

            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }
        }


        /// <summary>
        /// 西暦yが与えられるので、閏年ならYesを、平年ならばNoを出力してください。
        /// 閏年か平年かは次のような条件によって判定することができます。
        /// ・西暦が4で割り切れる年は閏年
        /// ・ただし、100で割り切れる年は平年
        /// ・ただし、400で割り切れる年は閏年
        /// ・西暦が4で割り切れない年は平年
        /// 整数yが1行で入力されます。
        /// </summary>
        public void Test104()
        {
            if (nmootan.GetIsLeapYear(int.Parse(Console.ReadLine()))) Console.WriteLine("Yes");
            else Console.WriteLine("No");
            

        }


        /// <summary>
        /// 西暦年y、月m、日付dが与えられるので、和暦の元号を表示してください。
        /// 和暦は、以下の条件を確認し、西暦から変換してください。
        /// ・明治は1912年7月29日まで
        /// ・大正は1912年7月30日から1926年12月24日まで
        /// ・昭和は1926年12月25日から1989年1月7日まで
        /// ・平成は1989年1月8日から2019年4月30日まで
        /// ・令和は2019年5月1日から
        /// ※元号一覧_(日本)#明治時代以降（近代・現代）
        /// 整数y m dが次のように、スペース区切りで1行で入力されます。
        /// 令和年5月1日
        /// </summary>
        public void Test105()
        {
            int[] ymd = nmootan.GetStdIntSplit().ToArray();

            Console.WriteLine(nmootan.GetGengouFromAD(ymd[0], ymd[1], ymd[2])+"年"+ymd[1]+"月"+ymd[2]+"日");

        }


        /// <summary>
        /// 西暦年y、月m、日付dが与えられるので、和暦で表示してください。
        /// ・Gは"明治"、"大正"、"昭和"、"平成"、"令和"のいずれかの元号で、和暦のxは元号の年です。
        /// ・xは2より大きな整数か、"元"です。和暦が1年になる場合は、元年となることに注意してください。
        /// </summary>
        public void Test106()
        {
            int[] ymd = nmootan.GetStdIntSplit().ToArray();

            Console.WriteLine(nmootan.GetParseADToJPYear(ymd[0], ymd[1], ymd[2]));

        }



    }
}
