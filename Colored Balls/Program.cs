using Microsoft.VisualBasic.FileIO;
using System;
using System.Globalization;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;

namespace Colored_Balls
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, k;
            Console.WriteLine("Enter N value - ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter K value - ");
            k = Convert.ToInt32(Console.ReadLine());
            if (k < 1 || n < k || k > 210 || n > 210)
            {
                Console.WriteLine("Invalid Input!");
                return;
            }
            Console.WriteLine("Enter ball color values - \n");
            String balls = Console.ReadLine();
            balls = balls.Substring(0, n);
            String[] pieces = new String[n * k + 1];
            int index = 0;
            for (int i = 0; i < (n - k) + 1; i++)
                pieces[index++] = balls.Substring(i, k);
            if (k > 1)
                pieces[index++] = balls[0].ToString() + balls[n - 1].ToString();
            char[] temp1 = new char[k];
            char[] temp2 = new char[k];
            int[] toBeDeleted = new int[n * n];
            int deletedIndex = 0;
            for (int i = 0; i < index - 1; i++)
            {
                temp1 = pieces[i].ToArray();
                Array.Sort(temp1);
                for (int m = i + 1; m < index; m++)
                {
                    temp2 = pieces[m].ToArray();
                    Array.Sort(temp2);
                    bool flag = true;
                    for (int j = 0; j < k; j++)
                        if (temp1[j] != temp2[j])
                            flag = false;
                    if (flag)
                        toBeDeleted[deletedIndex++] = m;
                }
            }
            toBeDeleted = toBeDeleted.Distinct().ToArray();
            for(int i = 0; i < toBeDeleted.Length; i++)
                if (toBeDeleted[i] > 0)
                {
                    var listPieces = new List<String>(pieces);
                    listPieces.RemoveAt(toBeDeleted[i] - i);
                    pieces = listPieces.ToArray();
                }
            Console.WriteLine("Output - ");
            int length = 0;
            for (int i = 0; i < pieces.Length; i++)
                if (pieces[i] != null)
                    length++;
            Console.WriteLine(length);
        }
    }
}