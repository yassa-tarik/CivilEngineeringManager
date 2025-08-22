using System;
namespace DAL.Contract.Project
{
    public class ProjectEntityDTO
    {
        public int ID { get; }
        public int ID_Adresse { get; }
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
        //Address part
        public int ID_Country { get; set; }
        public int ID_City { get; set; }
        public string APC { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string LieuDit { get; set; }
        public string Reper { get; set; }

        public ProjectEntityDTO(int ID, int ID_Adresse, string Nom, string CodeProjet, bool isDeleted, DateTime DateDebut, int Duree, string TypeProjet, string Description, int Avancement, bool IsActive, int CreePar, string ConcervationFonciere, string PermisDeLotirNum, Nullable<DateTime> PermisDeLotirDu, string PermisDeConstNum, DateTime PermisDeConstDu, string ActeVolume, string ActeNum, string ActeFolio, string LivretFoncier, Nullable<DateTime> LivretFoncierLe, string LivretFoncierPar, bool isSpecComplete, byte Progress, int ID_Country, int ID_City, string aPC, string street, string PostalCode, string lieuDit, string reper)
        {
            this.ID = ID;
            this.ID_Adresse = ID_Adresse;
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
            this.ID_Country = ID_Country;
            this.ID_City = ID_City;
            this.APC = aPC;
            this.Street = street;
            this.PostalCode = PostalCode;
            this.LieuDit = lieuDit;
            this.Reper = reper;
        }
    }
}
