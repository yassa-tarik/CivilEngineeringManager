using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.TaskTypeName
{
    public class TaskTypeNameDTO
    {
        public int ID { get; private set; }
        public string Name { get; private set; }

        public TaskTypeNameDTO(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
