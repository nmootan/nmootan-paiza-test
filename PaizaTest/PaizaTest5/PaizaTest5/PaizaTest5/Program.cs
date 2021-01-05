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


            string str = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < str.Length + 2; i++)
            {
                sb.Append('+');
            }
            string str1 = sb.ToString();

            Console.WriteLine(str1);
            Console.WriteLine("+" + str + "+");
            Console.WriteLine(str1);



            Console.ReadLine();


        }

    }




    static class nmootan
    {


    }
}
