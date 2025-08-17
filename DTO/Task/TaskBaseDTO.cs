using System;

namespace DTO.Task
{
    public class TaskBaseDTO
    {
        public int iD;
        public string designation;
        public string unite;
        public decimal prix_Unitaire;
        public double quantite;
        public string tVA;
        public DateTime creationDate;

        public TaskBaseDTO(int iD, string designation, string unite, decimal prix_Unitaire, double quantite, string tVA, DateTime creationDate)
        {
            this.iD = iD;
            this.designation = designation;
            this.unite = unite;
            this.prix_Unitaire = prix_Unitaire;
            this.quantite = quantite;
            this.tVA = tVA;
            this.creationDate = creationDate;
        }
    }
}