using System;
using Isen.DotNet.Library;
using Isen.DotNet.Library.Lists;
using Isen.DotNet.Library.Persons;

namespace Isen.DotNet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var jd = new Person(
                "Jhon",
                "Doe",
                new DateTime(1964, 12, 4)
            );
            var unborn = new Person(
                "The",
                "Unborn"
            );
            Console.WriteLine(jd);
            Console.WriteLine(unborn);

            var inlineperson = new Person()
            {
                FirstName = "Jon",
                LastName = "Appleseed",
                DateOfBirth = new DateTime(1965, 10, 5)
            };
            Console.WriteLine(inlineperson);
        }
    }
}
