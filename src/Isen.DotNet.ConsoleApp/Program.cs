using System;
using Isen.DotNet.Library;
using Isen.DotNet.Library.Lists;

namespace Isen.DotNet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var hello = new Hello("Alexis");
            var message = hello.Greet();
            Console.WriteLine(message);

            var list = new MyCollection<string>();
            list.Add("A");
            list.Add("B");
            list.Add("C");
            var enumerator = 
                list.GetEnumerator();
            while (enumerator.MoveNext())
                Console.WriteLine(enumerator.Current);
        }
    }
}
