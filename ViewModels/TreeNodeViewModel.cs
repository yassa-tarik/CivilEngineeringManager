using DTO.TreeDTOs;
using DTO.Works.WorkSpecs;
using System.Collections.Generic;
using System.Linq;

namespace CivilEngineeringManager.ViewModels
{
    internal class TreeNodeViewModel
    {
        public int ID { get; }
        public string Designation { get; }
        public string Unit { get; }
        public decimal? UnitPrice { get; }
        public double? Quantity { get; }
        public decimal? Amount => UnitPrice * (decimal)Quantity;

        public bool canExpand
        {
            get
            {
                if (WorkTypes == null && WorkSpecs == null)
                    return false;
                return
                    WorkTypes.Count() > 0 || WorkSpecs.Count() > 0;
            }
        }

        public ICollection<WorkTypeTreeDTO> WorkTypes { get; set; }
        public ICollection<WorkSpecUpdateDTO> WorkSpecs { get; set; }

        public TreeNodeViewModel(int iD, string designation, string unit, decimal? unitPrice, double? quantity, ICollection<WorkTypeTreeDTO> workTypes, ICollection<WorkSpecUpdateDTO> workSpecs)
        {
            ID = iD;
            Designation = designation;
            Unit = unit;
            UnitPrice = unitPrice;
            Quantity = quantity;

            WorkTypes = workTypes;
            WorkSpecs = workSpecs;
        }
        public TreeNodeViewModel(int iD, string designation, string unit, decimal? unitPrice, double? quantity, decimal? amount, ICollection<WorkTypeTreeDTO> workTypes, ICollection<WorkSpecUpdateDTO> workSpecs)
        {
            ID = iD;
            Designation = designation;
            Unit = unit;
            UnitPrice = unitPrice;
            Quantity = quantity;
            //Amount = amount;
            WorkTypes = workTypes;
            WorkSpecs = workSpecs;
        }
    }
}
