using System;

namespace Isen.DotNet.Library.Models
{
    public abstract class _BaseModel
    {
        public virtual int Id { get;set; }
        public virtual string Name { get;set; }

        public virtual string Display => 
            $"[{this.GetType()}] Id={Id} | Name={Name}";

        public override string ToString() => 
            Display;
    }
}