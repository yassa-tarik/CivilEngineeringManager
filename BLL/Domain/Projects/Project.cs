using BLL.Domain.Addresses;
using BLL.Mappers.Addesses;
using DTO.Project;
using System;

namespace BLL.Domain.Projects
{
    internal class Project
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
        public Address Address { get; }

        public Project(int ID, string Nom, string CodeProjet, bool isDeleted, DateTime DateDebut, int Duree, string TypeProjet, string Description, int Avancement, bool IsActive, int CreePar, string ConcervationFonciere, string PermisDeLotirNum, Nullable<DateTime> PermisDeLotirDu, string PermisDeConstNum, DateTime PermisDeConstDu, string ActeVolume, string ActeNum, string ActeFolio, string LivretFoncier, Nullable<DateTime> LivretFoncierLe, string LivretFoncierPar, bool isSpecComplete, byte Progress, Address address)
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

        internal static Project AddEdit(ProjectDTO DTO)
        {
            //TODO: implement validation logic here
            if (DTO == null)
                throw new ArgumentNullException(nameof(DTO), "ProjectDTO cannot be null");

            // Example: ID validation (0 means new, >0 means edit)
            if (DTO.ID < 0)
                throw new ArgumentException("Project ID cannot be negative.", nameof(DTO.ID));

            if (string.IsNullOrWhiteSpace(DTO.Nom))
                throw new ArgumentException("Project name cannot be empty.", nameof(DTO.Nom));

            if (DTO.DateDebut == default)
                throw new ArgumentException("Project start date must be specified.", nameof(DTO.DateDebut));

            if (DTO.Duree <= 0)
                throw new ArgumentException("Project duration must be greater than zero.", nameof(DTO.Duree));
            var address = DTO.Address != null
        ? AddressMapper.ToDomain(DTO.Address)
        : null; // or you could decide to throw if Address is mandatory
            return new Project(DTO.ID, DTO.Nom, DTO.CodeProjet, DTO.isDeleted, DTO.DateDebut, DTO.Duree, DTO.TypeProjet, DTO.Description, DTO.Avancement, DTO.IsActive, DTO.CreePar, DTO.ConcervationFonciere, DTO.PermisDeLotirNum, DTO.PermisDeLotirDu, DTO.PermisDeConstNum, DTO.PermisDeConstDu, DTO.ActeVolume, DTO.ActeNum, DTO.ActeFolio, DTO.LivretFoncier, DTO.LivretFoncierLe, DTO.LivretFoncierPar, DTO.isSpecComplete, DTO.Progress, AddressMapper.ToDomain(DTO.Address));
        }
    }
}
