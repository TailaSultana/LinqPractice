using System;
using System.Collections.Generic;

namespace LinqPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinqClass linq = new();
            /* linq.Ex1();
             Console.WriteLine("---------------");
             linq.FluentSyntax();
             Console.WriteLine("---------------");
             linq.GroupExample();
             Console.WriteLine("---------------");
            

             LinqEFCore linqEFCore = new();
             linqEFCore.EFCoreGetData();*/
            
            linq.CallingTestForSquares();
            linq.CallingGetTheLastWord();        
            Console.ReadLine();
        }
    }
}
