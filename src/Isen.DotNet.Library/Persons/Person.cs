using System;

namespace Isen.DotNet.Library.Persons
{
    public class Person
    {
        public string FirstName { get;set; }
        public string LastName { get;set; }
        public DateTime? DateOfBirth { get;set; }

        public int? Age 
        { 
            get 
            {
                if(!DateOfBirth.HasValue)
                    return null;

                var age = 
                    DateTime.Now - DateOfBirth.Value;
                return (int)Math.Floor(
                    age.TotalDays / 365);
            }
        }

        public Person(
            string firstName,
            string lastName,
            DateTime dateOfBirth) :
            this(firstName, lastName)
        {
            DateOfBirth = dateOfBirth;
        }

        public Person(
            string firstName,
            string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Person()
        {
            
        }

        public override string ToString(){
            var sAge = Age.HasValue ? 
                Age.ToString() : 
                "undef";
            var display = $"{FirstName} {LastName.ToUpper()} [{sAge}]";
            return display;
        }
            
    }
}