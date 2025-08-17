using DTO.Address;
using System;

namespace DTO.Project
{
    public class ProjectDTO
    {
        public int ID { get; }
        public string Nom { get; }
        public string CodeProjet { get; }
        public bool isDeleted { get; set; }
        public DateTime DateDebut { get; set; }
        public int Duree { get; set; }
        public string TypeProjet { get; set; }
        public string Description { get; set; }
        public int Avancement { get; set; }
        public bool IsActive { get; set; }
        public int CreePar { get; set; }
        public string ConcervationFonciere { get; set; }
        public string PermisDeLotirNum { get; set; }
        public Nullable<DateTime> PermisDeLotirDu { get; set; }
        public string PermisDeConstNum { get; set; }
        public DateTime PermisDeConstDu { get; set; }
        public string ActeVolume { get; set; }
        public string ActeNum { get; set; }
        public string ActeFolio { get; set; }
        public string LivretFoncier { get; set; }
        public Nullable<DateTime> LivretFoncierLe { get; set; }
        public string LivretFoncierPar { get; set; }
        public bool isSpecComplete { get; set; }
        public byte Progress { get; set; }
        public AddressDTO Address { get; }

        public ProjectDTO(int ID, string Nom, string CodeProjet, bool isDeleted, DateTime DateDebut, int Duree, string TypeProjet, string Description, int Avancement, bool IsActive, int CreePar, string ConcervationFonciere, string PermisDeLotirNum, Nullable<DateTime> PermisDeLotirDu, string PermisDeConstNum, DateTime PermisDeConstDu, string ActeVolume, string ActeNum, string ActeFolio, string LivretFoncier, Nullable<DateTime> LivretFoncierLe, string LivretFoncierPar, bool isSpecComplete, byte Progress, AddressDTO address)
        {
            this.ID = ID;
            this.Nom = Nom;
            this.CodeProjet = CodeProjet;
            this.isDeleted = isDeleted;
            this.DateDebut = DateDebut;
            this.Duree = Duree;
            this.TypeProjet = TypeProjet;
            this.Description = Description;
            this.Avancement = Avancement;
            this.IsActive = IsActive;
            this.CreePar = CreePar;
            this.ConcervationFonciere = ConcervationFonciere;
            this.PermisDeLotirNum = PermisDeLotirNum;
            this.PermisDeLotirDu = PermisDeLotirDu;
            this.PermisDeConstNum = PermisDeConstNum;
            this.PermisDeConstDu = PermisDeConstDu;
            this.ActeVolume = ActeVolume;
            this.ActeNum = ActeNum;
            this.ActeFolio = ActeFolio;
            this.LivretFoncier = LivretFoncier;
            this.LivretFoncierLe = LivretFoncierLe;
            this.LivretFoncierPar = LivretFoncierPar;
            this.isSpecComplete = isSpecComplete;
            this.Progress = Progress;
            this.Address = address;
        }
    }
}
