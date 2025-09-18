using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// A domain entity representing a subcontractor.
    /// </summary>
    public class Subcontractor
    {
        public int ID { get; internal set; }
        public int ID_Contact { get; internal set; }
        public string CompanyName { get; internal set; }
        public string Representative { get; internal set; }
        public string BankAccountNumber { get; internal set; }
        public bool IsActive { get; internal set; }
        public int Contact_ID { get; internal set; }

        // Audit
        public DateTime CreationDate { get; private set; }
        public int CreatedBy { get; private set; }
        public DateTime ModificationDate { get; private set; }
        public int ModifiedBy { get; private set; }

        public Subcontractor(int id, int id_contact, string companyName, string representative, string bankAccountNumber, bool isActive, int contact_ID, int createdBy)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }

            ID = id;
            ID_Contact = id_contact;
            CompanyName = companyName;
            Representative = representative;
            BankAccountNumber = bankAccountNumber;
            IsActive = isActive;
            Contact_ID = contact_ID;
            CreationDate = DateTime.Now;
            CreatedBy = createdBy;
            ModificationDate = DateTime.Now;
            ModifiedBy = createdBy;
        }

        /// <summary>
        /// Updates the Subcontractor's properties and modification details.
        /// </summary>
        public void Update(string companyName, string representative, string bankAccountNumber, bool isActive, int id_contact, int contact_ID, int modifiedBy)
        {
            CompanyName = companyName;
            Representative = representative;
            BankAccountNumber = bankAccountNumber;
            IsActive = isActive;
            ID_Contact = id_contact;
            Contact_ID = contact_ID;
            ModificationDate = DateTime.Now;
            ModifiedBy = modifiedBy;
        }
    }

}
