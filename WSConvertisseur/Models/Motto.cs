using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WSConvertisseur.Models
{
    public class Motto
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        [Required]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private double rate;

        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public Motto()
        {

        }

        public Motto(int Id, string Name, double Rate)
        {
            this.Id = Id;
            this.Name = Name;
            this.Rate = Rate;
        }

        public override bool Equals(object obj)
        {
            return obj is Motto motto &&
                   id == motto.id &&
                   name == motto.name &&
                   rate == motto.rate;
        }
    }
}
