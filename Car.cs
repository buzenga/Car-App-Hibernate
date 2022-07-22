using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager
{
    public class Car
    {
        public virtual int ID { get; set; }
        public virtual string PlateNumber { get; set; }
        public virtual string Producer { get; set; }
        public virtual string Model { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
