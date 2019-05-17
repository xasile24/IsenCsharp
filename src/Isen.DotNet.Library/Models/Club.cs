using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Isen.DotNet.Library.Models
{
    public class Club : BaseModel<Club>
    {
        public override int Id { get;set; }
        public override string Name { get;set; }
        public string logo { get;set; }
        public string address { get;set; }
        public float latitude { get;set; }
        public float longitude { get;set; }
        public List<Historic> HistoricCollection { get; set; } =
            new List<Historic>();

/* 
        public List<Person> PersonCollection = 
            new List<Person>();*/
    
    /*
        private static List<T> List<T>()
        {
            throw new NotImplementedException();
        }*/

        [NotMapped]
        public override string Display =>
            $"{base.Display} | logo={logo} | latitude={latitude} | longitude={longitude}";

        public override void Map(Club copy)
        {
            base.Map(copy);
            logo = copy.logo;
            latitude = copy.latitude;
            longitude = copy.longitude;
            address = copy.address;
        }

        
        public override dynamic ToDynamic()
        {
            var baseDynamic = base.ToDynamic();
            baseDynamic.logo = logo;
            baseDynamic.latitude = latitude;
            baseDynamic.longitude = longitude;
            baseDynamic.address = address;
            baseDynamic.nb = HistoricCollection?.Count;
            return baseDynamic;
        }

    }
}