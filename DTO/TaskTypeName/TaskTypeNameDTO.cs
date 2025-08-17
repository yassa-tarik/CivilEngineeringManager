using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.TaskTypeName
{
    public class TaskTypeNameDTO
    {
        public int ID { get; set; }
        public string Nom { get; set; }

        public TaskTypeNameDTO(int ID, string Nom)
        {
            this.ID = ID;
            this.Nom = Nom;
        }
    }
}
