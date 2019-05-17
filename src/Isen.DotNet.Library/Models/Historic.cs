using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Isen.DotNet.Library.Models
{
    public class Historic : BaseModel<Historic>
    {
        public override int Id { get;set; }
        public override string Name { get;set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Club HPlayIn { get;set; }
        public int? HPlayInId { get;set; }
        public Player HPlayer { get;set; }
        public int? HPlayerId { get;set; }

        public override string ToString() 
            => Display;

        [NotMapped]
        public int? Duration
        {
            get
            { 
                if (!StartDate.HasValue)
                    return null;
                if (!EndDate.HasValue)
                    return null;
                var duration = 
                    EndDate.Value - StartDate.Value;
                return (int)Math.Floor(
                    duration.TotalDays / 365);
            }
        }

        [NotMapped]
        public override string Display
        {
            get
            {
                var sDuration = Duration.HasValue ?
                    Duration.ToString() : 
                    "undef";
                var startDateString = StartDate
                    .GetValueOrDefault(DateTime.MinValue)
                    .ToString("dd/MM/yyyy");
                var endDateString = EndDate
                    .GetValueOrDefault(DateTime.MinValue)
                    .ToString("dd/MM/yyyy");

                var display = $"noClubFound";

                if (this.HPlayInId != null)
                {
                    display = $"{this.HPlayIn.Name} de {startDateString} à {endDateString}";
                } 
                return display;
            }
        }

        public override void Map(Historic copy)
        {
            base.Map(copy);
            EndDate = copy.EndDate;
            StartDate = copy.StartDate;
            HPlayIn = copy.HPlayIn;
            HPlayer = copy.HPlayer;
        }

        public override dynamic ToDynamic()
        {
            var baseDynamic = base.ToDynamic();
            baseDynamic.start = StartDate;
            baseDynamic.end = EndDate;
            baseDynamic.duration = Duration;
            baseDynamic.HplayIn = HPlayIn?.ToDynamic();
            baseDynamic.HPlayer = HPlayer?.ToDynamic();
            return baseDynamic;
        }
    }
}