using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PaizaTest5
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] dn = nmootan.GetStdIntSplit().ToArray();

            //操作の配列
            int[] sousa = new int[dn[1]];
            for (int i = 0; i < dn[1]; i++)
            {
                sousa[i] = int.Parse(Console.ReadLine());
            }

            //初期位置
            int result = 0;

            //真：R　偽：L
            //bool[] lr = new bool[dn[1]];
            //1：R　-1：L
            int[] lr = new int[dn[1]];
            //Random randam = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dn[1]; i++)
            {
                sb.Append('1');
            }
            string bitStr = sb.ToString(); //2進数文   字列
            int max = Convert.ToInt32(bitStr, 2); //最大値

            //Console.WriteLine("dn[0]=" + dn[0] + ", dn[1]=" + dn[1]);
            int increment = 0;
            while (increment <= max)
            {
                int count = 0;
                result = 0;
                //n桁の2進数をインクリメントして、0を-1に変換して、lr[]に転写する
                //incrementを2進数文字列bitStrに変換する
                bitStr = Convert.ToString(increment, 2).PadLeft(dn[1], '0');

                //bitStrからlr[]に-1,1を転写する
                for (int i = 0; i < dn[1]; i++)
                {
                    if (bitStr[i] == '0') lr[i] = -1;
                    else lr[i] = 1;
                }
                //操作による合計値を出す
                for (int i = 0; i < dn[1]; i++)
                {
                    result += sousa[i] * lr[i];
                    if (result < -dn[0] || result > dn[0]) break; //途中で±dの範囲外になったらループ中断
                    count++;
                }
                //Console.WriteLine("count=" + count);
                //Console.ReadLine();
                if (count == dn[1]) break; //全ての操作が実行されたらループ終了」
                //if (result < -dn[0] || result > dn[0]) break;
                increment++;
            }

            for (int i = 0; i < dn[1]; i++)
            {
                if (lr[i] == -1) Console.Write("L");
                else if (lr[i] == 1) Console.Write("R");
            }
            Console.WriteLine();




        }




        static class nmootan
        {

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


            public static bool JudgeIsFloat(string str)
            {
                if (str.Contains(".")) return true;
                else return false;

            }

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


            public static string GetFormatWithChar(string str, int n, char ch)
            {
                int m = n - str.Length;
                for (int i = 0; i < m; i++)
                {
                    str = str.Insert(0, ch.ToString());
                }

                return str;
            }

            public static string GetJoinStrArrayToStrByStr(string[] strs, string str)
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < strs.Length - 1; i++)
                {
                    sb.Append(strs[i]);
                    sb.Append(str);
                }

                sb.Append(strs[strs.Length - 1]);
                //sb.Append(Environment.NewLine);

                return sb.ToString();
            }

            public static string[] GetStrsSplitByChar(string str, char ch)
            {

                return str.Trim().Split(ch);
            }

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


            public static string[] GetStdStrsSplit()
            {

                return System.Console.ReadLine().Trim().Split(' ');
            }

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

            public static string GetJoinIntArrayToStrByStr(int[] ints, string str)
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < ints.Length - 1; i++)
                {
                    sb.Append(ints[i]);
                    sb.Append(str);
                }

                sb.Append(ints[ints.Length - 1]);
                //sb.Append(Environment.NewLine);

                return sb.ToString().Trim();
            }


        }
    }
}
