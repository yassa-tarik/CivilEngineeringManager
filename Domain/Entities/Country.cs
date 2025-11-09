using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Country
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Country(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
