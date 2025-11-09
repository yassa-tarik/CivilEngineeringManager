using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Cities
{
    public class CityDTO
    {
        public int ID { get; private set; }
        public int Country_ID { get; private set; }
        public string Name { get; private set; }

        public CityDTO(int id, int countryId, string name)
        {
            ID = id;
            Name = name;
            Country_ID = countryId;
        }
    }
}
