using System;

namespace DTO.Task
{
    public class TaskDTO : TaskBaseDTO
    {
        // this properties
        public int? ID_Type_Travaux { get; set; }
        public decimal Montant
        {
            get { return base.prix_Unitaire * (Decimal)base.quantite; }
        }
        public int? ParentID { get; set; }
        public bool HasChild { get; set; }

        public TaskDTO(int iD, string designation, string unite, decimal prix_Unitaire, double quantite, int? iD_Type_Travaux, string tVA, DateTime creationDate, int? parentID, bool hasChild) : base(iD, designation, unite, prix_Unitaire, quantite, tVA, creationDate)
        {
            this.ID_Type_Travaux = iD_Type_Travaux;
            this.ParentID = parentID;
            this.HasChild = hasChild;
        }

    }
}