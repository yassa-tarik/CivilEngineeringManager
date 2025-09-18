using DTO.TreeDTOs;
using DTO.Works.WorkSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilEngineeringManager.ViewModels
{
    internal class TreeNodeViewModel
    {
        public int ID { get; }
        public string Designation { get; }
        public string Unit { get; }
        public decimal? UnitPrice { get; }
        public double? Quantity { get; }
        public decimal? Amount { get; }
        public bool canExpand {
            get
            {
                if (WorkTypes == null && WorkSpecs == null)
                    return false;
                return
                    WorkTypes.Count() > 0 || WorkSpecs.Count() > 0;
            }
        }
        
        public ICollection<WorkTypeTreeDTO> WorkTypes { get; }
        public ICollection<WorkSpecDTO> WorkSpecs { get; set; }

        public TreeNodeViewModel(int iD, string designation, string unit, decimal? unitPrice, double? quantity, decimal? amount, ICollection<WorkTypeTreeDTO> workTypes, ICollection<WorkSpecDTO> workSpecs)
        {
            ID = iD;
            Designation = designation;
            Unit = unit;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Amount = amount;
            WorkTypes = workTypes;
            WorkSpecs = workSpecs;
        }
    }
}
