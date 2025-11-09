using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class City
    {
        public int ID { get; private set; }
        public int Country_ID { get; private set; }
        public string Name { get; private set; }

        public City(int id, string name, int countryId)
        {
            ID = id;
            Name = name;
            Country_ID = countryId;
        }
    }
}
