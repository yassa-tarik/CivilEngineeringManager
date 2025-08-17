using CivilEngineeringManager.DTO.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.TaskAssigned
{
    internal class TaskAssignedDTO : TaskBaseDTO
    {
        // Task properties
        public int? ID_Type_Travaux { get; set; }
        public decimal Montant
        {
            get { return Prix_Unitaire * (Decimal)Quantite; }
        }
        public int? ParentID { get; set; }
        public bool HasChild { get; set; }
        // this properties
        public double QuantiteCumul { get; set; }
        public double QuantiteRemain { get; set; }


        public TaskAssignedDTO(int iD, string designation, string unite, decimal prix_Unitaire, double quantite, int? iD_Type_Travaux, string tVA, DateTime creationDate, int? parentID, bool hasChild, double QuantiteCumul, double QuantiteRemain) : base(iD, designation, unite, prix_Unitaire, quantite, tVA, creationDate)
        {
            this.ID_Type_Travaux = iD_Type_Travaux;
            this.ParentID = parentID;
            this.HasChild = hasChild;
            this.QuantiteCumul = QuantiteCumul;
            this.QuantiteRemain = QuantiteRemain;
        }
    }
}
