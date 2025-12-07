using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.TreeDTOs
{
    public class AssignedWorkSpecDTO
    {
        public int AssignedWork_ID { get; }        
        public string Designation { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public double Quantity { get; set; }
        public string VAT { get; }
        // AssignedWork part
        internal int WorkSpec_ID { get; private set; }
        internal int Subcontractor_ID { get; private set; } = 0;
        internal decimal NegotiatedUnitPrice { get; private set; } = 0;
        internal double AssignedQuantity { get; private set; } = 0;
        internal DateTime AssignedDate { get; private set; }
        internal double ProducedQuantity { get; private set; } = 0;

        internal byte Progress { get; private set; }
        internal AssignedWorkStatus Status { get; private set; }
        internal DateTime EndDate { get; private set; }
        internal bool IsActive { get; private set; }
        internal bool IsDeleted { get; private set; }
        public decimal Amount { get; set; }
    }
}
