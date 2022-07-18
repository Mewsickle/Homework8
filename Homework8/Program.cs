using System;
using System.Reflection;

namespace Homework8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Type t = typeof(DateTime);
                foreach (var prop in t.GetProperties())
                {
                    Console.WriteLine(prop.Name);
                }

                Console.ReadKey();
            }
        }
    }
}
