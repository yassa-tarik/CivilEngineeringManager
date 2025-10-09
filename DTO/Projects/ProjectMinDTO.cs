using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Projects
{
    public class ProjectMinDTO
    {
        public int ID { get; }
        public string Name { get; set; }
        public bool IsSpecComplete { get; private set; }
        public ProjectMinDTO(int iD, string name, bool isSpecComplete)
        {
            ID = iD;
            Name = name;
            IsSpecComplete = isSpecComplete;
        }
    }
}
