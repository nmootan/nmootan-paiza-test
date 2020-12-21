﻿using System;
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

            hello.Test49();
            //nmootan.Matrix99();

            Console.ReadLine();
        }
    }





    /*
    
    
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;

    public class Hello{


        public static void Main(){
            // 自分の得意な言語で
            // Let's チャレンジ！！
    
            Hello hello = new Hello();
    
            hello.Test49();
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

            for (int i = 0; i < q; i++)
            {
                Test48();
            }


        }



    }


    

    static class nmootan
    {
    
        public static int GetStdInt()
        {

            return int.Parse(Console.ReadLine());
        }


    
        public static string[] GetStdStrsSplit()
        {

            return System.Console.ReadLine().Trim().Split(' ');
        }

        /// <summary>
        /// 実数 N が入力されます。N を四捨五入して小数第 n 位まで出力
        /// また、N の小数部が小数第 n 位に満たない場合は 0 で埋めて出力
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
                    if (r > 4) 
                    {
                        r = nmootan.GetParseCharToInt(str[point + n]) + 1;
                        str = nmootan.GetReplaceStrIndexIChar(str, r.ToString(), point + n);
                    } 
                    str = str.Remove(point + n+1);
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

        public static char[] GetParseStrToCharArray(string str)
        {

            return str.ToCharArray();
        }

        public static int GetParseCharToInt(char ch)
        {

            return ch - '0';
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







    }









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
