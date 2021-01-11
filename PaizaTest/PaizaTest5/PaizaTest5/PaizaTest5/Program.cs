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

            int[] whmn = nmootan.GetStdIntSplit().ToArray();

            int[][] cams = nmootan.GetParseStdStrToMatrix(whmn[2]);
            int[][] a = nmootan.GetParseStdStrToMatrix(whmn[3]);
            bool[] isCovered = new bool[whmn[3]]; //カバーチェック
            for (int i = 0; i < whmn[3]; i++)
            {
                isCovered[i] = false; //初期値
            }

            double[][] b = new double[whmn[2]][]; //各カメラの傾き
            for (int i = 0; i < whmn[2]; i++)
            {
                b[i] = new double[2];
                b[i][0] = Math.Tan(0.0174444444 * (cams[i][2] - (cams[i][3] / 2.0)));
                b[i][1] = Math.Tan(0.0174444444 * (cams[i][2] + (cams[i][3] / 2.0)));
                for (int j = 0; j < whmn[3]; j++) //各美術品のチェック
                {
                    int r2 = (a[j][0] - cams[i][0]) * (a[j][0] - cams[i][0]) + (a[j][1] - cams[i][1]) * (a[j][1] - cams[i][1]);
                    if (a[j][0] - cams[i][0]==0)
                    {
                        if (a[j][1] - cams[i][1]>0)
                        {
                            if (cams[i][2] - (cams[i][3] / 2.0)<90)
                            {
                                if (cams[i][2] + (cams[i][3] / 2.0)>90)
                                {
                                    if (r2 < cams[i][4] * cams[i][4]) //距離のチェック
                                    {
                                        isCovered[j] = true;
                                    }
                                }
                            }
                        }
                        else if (a[j][1] - cams[i][1]<0)
                        {

                            if (cams[i][2] - (cams[i][3] / 2.0) < 270)
                            {
                                if (cams[i][2] + (cams[i][3] / 2.0) > 270)
                                {
                                    if (r2 < cams[i][4] * cams[i][4]) //距離のチェック
                                    {
                                        isCovered[j] = true;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {

                        double d = (double)(a[j][1] - cams[i][1]) / (double)(a[j][0] - cams[i][0]);
                        if (b[i][0] < d) //範囲のチェック
                        {
                            if (b[i][1] > d)
                            {
                                if (r2 < cams[i][4] * cams[i][4]) //距離のチェック
                                {
                                    isCovered[j] = true;
                                }
                            }

                        }
                        else if (b[i][0] > d)
                        {
                            if (b[i][1] < d)
                            {
                                if (r2 < cams[i][4] * cams[i][4]) //距離のチェック
                                {
                                    isCovered[j] = true;
                                }

                            }
                        }
                        //Console.WriteLine("d=" + (a[j][1] - cams[i][1]) + " / " + (a[j][0] - cams[i][0]));
                        //Console.WriteLine("tan-=" + b[i][0] + " tan+=" + b[i][1] + " d=" + d.ToString());
                        //Console.ReadLine();
                    }
                }
            }

            for (int i = 0; i < whmn[3]; i++)
            {
                if (isCovered[i]) Console.WriteLine("yes");
                else Console.WriteLine("no");
            }




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
