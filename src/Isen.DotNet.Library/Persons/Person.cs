using System;

namespace Isen.DotNet.Library.Persons
{
    public class Persons
    {
        public string FirstName { get;set; }
        public string LastName { get;set; }
        public DateTime? DateOfBirth { get;set; }

        public Persons(
            string firstName,
            string lastName,
            DateTime dateOfBirth) :
            this(firstName, lastName)
        {
            DateOfBirth = dateOfBirth;
        }

        public Persons(
            string firstName,
            string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}