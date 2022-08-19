using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Result
{

    /*
     * Complete the 'commonSubstring' function below.
     *
     * The function accepts following parameters:
     *  1. STRING_ARRAY a
     *  2. STRING_ARRAY b
     */

    public static void commonSubstring(List<string> a, List<string> b)
    {
        for (int i = 0; i < a.Count; i++)
        {
            if(a[i].ToCharArray().Any(acharater => b[i].Any(bcharacter => bcharacter == acharater)))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int aCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> a = new List<string>();

        for (int i = 0; i < aCount; i++)
        {
            string aItem = Console.ReadLine();
            a.Add(aItem);
        }

        int bCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> b = new List<string>();

        for (int i = 0; i < bCount; i++)
        {
            string bItem = Console.ReadLine();
            b.Add(bItem);
        }

        Result.commonSubstring(a, b);
    }
}