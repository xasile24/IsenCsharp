using System;
using System.Collections.Generic;
using System.Linq;

namespace Isen.DotNet.Library.Models
{
    public class City : BaseModel<City>
    {
        public override int Id { get;set; }
        public override string Name { get;set; }
        public string ZipCode { get;set; }

        //Relation réciproque de Person.BornIN (City)
        public List<Person> PersonCollection = 
            new List<Person>();
    
        private static List<T> List<T>()
        {
            throw new NotImplementedException();
        }

        public override string Display =>
            $"{base.Display} | ZipCode={ZipCode}";

        public override void Map(City copy)
        {
            base.Map(copy);
            ZipCode = copy.ZipCode;
        }
    }
}