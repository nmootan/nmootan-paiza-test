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


            int n = int.Parse(Console.ReadLine());
            int[][] matrix = new int[n][];
            //n行n列のマトリックスをn行の入力から作成
            for (int i = 0; i < n; i++)
            {
                matrix[i] = nmootan.GetStdIntSplit().ToArray();
            }

            //2か所の0を特定する　（iとjを得る）文字列a[2]: a[0]= "i j"; a[1]="i j";
            string[] a = new string[2];
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        a[count] = i + " " + j;
                        count++;
                    }

                }
            }
            //2行2列のマトリックスに変換する
            int[][] a22 = new int[2][];
            a22[0] = nmootan.GetStrSplitToIntList(a[0]).ToArray();//a22[0][0]=i1 a22[0][1]=j1
            a22[1] = nmootan.GetStrSplitToIntList(a[1]).ToArray();//a22[1][0]=i2 a22[1][1]=j2
            //Console.WriteLine("a22[0][0]=" + a22[0][0] + ", a22[1][0]=" + a22[1][0]);

            //2か所の塗りつぶしが同一の行でないとき
            if (a22[0][0] != a22[1][0])
            {
                //塗りつぶし以外の行の合計を得る
                int sum = 0;
                for (int i = 0; i < n; i++)
                {
                    if (i != a22[0][0])
                    {
                        if (i != a22[1][0])
                        {
                            sum = matrix[i].Sum();
                            break;
                        }
                    }
                }
                //Console.WriteLine("sum={0}", sum);
                //塗りつぶしのある2行の合計をそれぞれ得る
                int[] bugSums = new int[2];
                bugSums[0] = matrix[a22[0][0]].Sum();
                bugSums[1] = matrix[a22[1][0]].Sum();
                //Console.WriteLine("bugSums[0]={0}, bugSums[1]=", bugSums[0], bugSums[1]);

                //2か所の塗りつぶし部分の数字を書き換える
                matrix[a22[0][0]][a22[0][1]] = sum - bugSums[0];
                matrix[a22[1][0]][a22[1][1]] = sum - bugSums[1];

            }
            //2か所の塗りつぶしが同一の行のとき
            else
            {
                //塗りつぶし以外の行の合計を得る
                int sum = 0;
                for (int i = 0; i < n; i++)
                {
                    if (i != a22[0][0])
                    {
                        sum = matrix[i].Sum();
                        break;
                    }
                }

                //塗りつぶしのある2列の合計をそれぞれ得る
                int[] bugSums = new int[2];
                //bugSums[0] = matrix[a22[0][0]].Sum();
                //bugSums[1] = matrix[a22[1][0]].Sum();
                bugSums[0] = 0;
                bugSums[1] = 0;
                for (int i = 0; i < n; i++)
                {
                    bugSums[0] += matrix[i][a22[0][1]];
                    bugSums[1] += matrix[i][a22[1][1]];
                }

                //2か所の塗りつぶし部分の数字を書き換える
                matrix[a22[0][0]][a22[0][1]] = sum - bugSums[0];
                matrix[a22[1][0]][a22[1][1]] = sum - bugSums[1];

            }

            //マトリックスを表示する
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(nmootan.GetJoinIntArrayToStrByStr(matrix[i], " "));
            }



            Console.ReadLine();


        }

    }




    static class nmootan
    {

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
