using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Works.WorkCategoryNames
{
    internal class WorkCategoryNameUpdateDTO : WorkCategoryNameBaseDTO
    {
        public WorkCategoryNameUpdateDTO(int iD, string name) : base(name)
        {
            this.ID = iD;
        }
        public int ID { get; set; }
    }
}
