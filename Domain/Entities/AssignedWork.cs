using Common.Enums;
using System;

namespace Domain.Entities
{
    /// <summary>
    /// A domain entity representing the assignment of a WorkSpec to a Subcontractor.
    /// This is a one-to-one relationship.
    /// </summary>
    public class AssignedWork
    {
        public int ID { get; private set; }
        public int WorkSpec_ID { get; private set; }
        public int Subcontractor_ID { get; private set; }
        public decimal NegotiatedUnitPrice { get; private set; }
        public double AssignedQuantity { get; private set; } = 0;
        public DateTime AssignedDate { get; private set; }
        public double ProducedQuantity { get; private set; } = 0;

        public byte Progress => AssignedQuantity == 0 ? (byte)0 : (byte)((ProducedQuantity * 100.0) / AssignedQuantity);
        public AssignedWorkStatus Status { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsDeleted { get; private set; }

        // Audit
        public DateTime CreationDate { get; private set; }
        public int CreatedBy { get; private set; }
        public DateTime ModificationDate { get; private set; }
        public int ModifiedBy { get; private set; }

        public AssignedWork(int iD, int workSpec_ID, int subcontractor_ID, decimal negotiatedUnitPrice, double assignedQuantity, DateTime assignedDate, double producedQuantity, AssignedWorkStatus status, DateTime endDate, bool isActive, bool isDeleted)
        {
            if (iD <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(iD));
            }
            if (workSpec_ID <= 0)
            {
                throw new ArgumentException("WorkSpec_ID must be greater than zero.", nameof(workSpec_ID));
            }
            if (subcontractor_ID <= 0)
            {
                throw new ArgumentException("Subcontractor_ID must be greater than zero.", nameof(subcontractor_ID));
            }
            ID = iD;
            WorkSpec_ID = workSpec_ID;
            Subcontractor_ID = subcontractor_ID;
            NegotiatedUnitPrice = negotiatedUnitPrice;
            AssignedQuantity = assignedQuantity;
            AssignedDate = assignedDate;
            ProducedQuantity = producedQuantity;
            //Progress = progress;
            Status = status;
            EndDate = endDate;
            IsActive = isActive;
            IsDeleted = isDeleted;
        }

        // Constructor for creating a new AssignedWork entity
        public AssignedWork(int workSpec_ID, int subcontractor_ID, decimal negotiatedUnitPrice, double assignedQuantity, DateTime assignedDate, double producedQuantity, AssignedWorkStatus status, DateTime endDate, bool isActive, bool isDeleted)
        {
            Validate(workSpec_ID, subcontractor_ID, negotiatedUnitPrice, assignedQuantity, assignedDate, producedQuantity, status, endDate, isActive, isDeleted);

            WorkSpec_ID = workSpec_ID;
            Subcontractor_ID = subcontractor_ID;
            NegotiatedUnitPrice = negotiatedUnitPrice;
            AssignedQuantity = assignedQuantity;
            AssignedDate = assignedDate;
            ProducedQuantity = producedQuantity;
            //Progress = progress;
            Status = status;
            EndDate = endDate;
            IsActive = isActive;
            IsDeleted = isDeleted;
        }


        /// <summary>
        /// Updates the AssignedWork's properties and modification details.
        /// </summary>
        public void Update(int workSpec_ID, int subcontractor_ID, decimal negotiatedUnitPrice, double assignedQuantity, DateTime assignedDate, double producedQuantity, byte progress, AssignedWorkStatus status, DateTime endDate, bool isActive, bool isDeleted)
        {
            if (progress > 100)
            {
                throw new ArgumentException("Progress cannot exceed 100%.", nameof(progress));
            }

            WorkSpec_ID = WorkSpec_ID;
            Subcontractor_ID = subcontractor_ID;
            NegotiatedUnitPrice = negotiatedUnitPrice;
            AssignedQuantity = assignedQuantity;
            AssignedDate = assignedDate;
            ProducedQuantity = producedQuantity;
            Status = status;
            EndDate = endDate;
            IsActive = isActive;
            IsDeleted = isDeleted;

            ModificationDate = DateTime.Now;
            ModifiedBy = 1;
            Validate();
        }

        // used for Update
        private void Validate()
        {
            //TODO: will implement later
        }

        // for create new
        private void Validate(int workSpec_ID, int subcontractor_ID, decimal negotiatedUnitPrice, double assignedQuantity, DateTime assignedDate, double producedQuantity, AssignedWorkStatus status, DateTime endDate, bool isActive, bool isDeleted)
        { //TODO: will implement later
            try
            {/*
                // 1. Validate ID parameters 
                if (workCategory_ID == null && workType_ID == null)
                {
                    throw new ArgumentException("WorkSpec must have a Parent!.", nameof(workCategory_ID));
                }

                // 2. Validate String parameters (must not be null, empty, or whitespace)
                if (string.IsNullOrWhiteSpace(designation))
                {
                    throw new ArgumentException("Designation cannot be empty or whitespace.", nameof(designation));
                }

                if (string.IsNullOrWhiteSpace(unit))
                {
                    throw new ArgumentException("Unit cannot be empty or whitespace.", nameof(unit));
                }

                // Optional: Validate VAT format/content if you have specific allowed values (e.g., "0%", "5%", "20%")
                // if (string.IsNullOrWhiteSpace(vat))
                // {
                //     throw new ArgumentException("VAT field cannot be empty or whitespace.", nameof(vat));
                // }

                // 3. Validate Numeric parameters (must be non-negative)
                if (unitPrice < 0)
                {
                    throw new ArgumentException("Unit Price cannot be negative.", nameof(unitPrice));
                }

                if (quantity <= 0) // Quantity usually must be positive, not just non-negative
                {
                    throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
                }
                */
                // If the method reaches this point, all parameters are considered valid based on these rules.
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
