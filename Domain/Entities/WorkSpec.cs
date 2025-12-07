using System;

namespace Domain.Entities
{
    /// <summary>
    /// A domain entity representing a specific work item or task.
    /// It contains detailed pricing and quantity information.
    /// </summary>
    public class WorkSpec
    {
        public int ID { get; private set; }

        // Business properties
        public int? WorkCategory_ID { get; private set; }
        public int? WorkType_ID { get; private set; }
        public string Designation { get; private set; }
        public string Unit { get; private set; }
        public decimal UnitPrice { get; private set; }
        public double Quantity { get; private set; }
        public string VAT { get; private set; }
        public bool IsAssigned { get; private set; }

        // Computed
        public decimal Amount => UnitPrice * (decimal)Quantity;

        // Audit
        public DateTime CreationDate { get; private set; }
        public int CreatedBy { get; private set; }
        public DateTime ModificationDate { get; private set; }
        public int ModifiedBy { get; private set; }

        //TODO: will turn it internal later
        public WorkSpec(int id, int? workCategory_ID, int? workType_ID, string designation, string unit, decimal unitPrice, double quantity, string vat, bool isAssigned)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }
            if (string.IsNullOrWhiteSpace(designation))
            {
                throw new ArgumentException("Designation cannot be null or empty.", nameof(designation));
            }
            if (unitPrice < 0)
            {
                throw new ArgumentException("Unit price cannot be negative.", nameof(unitPrice));
            }

            ID = id;
            WorkCategory_ID = workCategory_ID;
            WorkType_ID = workType_ID;
            Designation = designation;
            Unit = unit;
            UnitPrice = unitPrice;
            Quantity = quantity;
            VAT = vat;
            IsAssigned = isAssigned;
            CreationDate = DateTime.Now;
            CreatedBy = 1; //will be the current userID
            ModificationDate = DateTime.Now;
            ModifiedBy = 1; //will be the current userID
        }
        // Constructor for creating a new WorkSpec entity
        public WorkSpec(int? workCategory_ID, int? workType_ID, string designation, string unit, decimal unitPrice, double quantity, string vat, bool isAssigned)
        {
            Validate(workCategory_ID, workType_ID, designation, unit, unitPrice, quantity, vat);

            WorkCategory_ID = workCategory_ID;
            WorkType_ID = workType_ID;
            Designation = designation;
            Unit = unit;
            UnitPrice = unitPrice;
            Quantity = quantity;
            VAT = vat;
            IsAssigned = isAssigned;
            CreationDate = DateTime.Now;
            CreatedBy = 1; //will be the current userID
            ModificationDate = DateTime.Now;
            ModifiedBy = 1; //will be the current userID
        }

        // for create new
        private void Validate(int? workCategory_ID, int? workType_ID, string designation, string unit, decimal unitPrice, double quantity, string vat)
        {
            try
            {// 1. Validate ID parameters 
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

                // If the method reaches this point, all parameters are considered valid based on these rules.
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the WorkSpec's properties and modification details.
        /// </summary>
        public void Update(int? workCategory_ID, int? workType_ID, string designation, string unit, decimal unitPrice, double quantity, string vat, bool isAssigned)
        {
            WorkCategory_ID = WorkCategory_ID;
            WorkType_ID = workType_ID;
            Designation = designation;
            Unit = unit;
            UnitPrice = unitPrice;
            Quantity = quantity;
            VAT = vat;
            IsAssigned = isAssigned;
            ModificationDate = DateTime.Now;
            ModifiedBy = 1; //will be the current userID

            Validate();
        }
        // used for Update
        private void Validate()
        {
            if (ID <= 0)
                throw new InvalidOperationException("ID must be positive.");

            // Designation validation
            if (string.IsNullOrWhiteSpace(Designation))
                throw new InvalidOperationException("Designation is required.");
            else if (Designation.Length > 255)
                throw new InvalidOperationException("Designation cannot exceed 200 characters.");

            // Unit validation
            if (string.IsNullOrWhiteSpace(Unit))
                throw new InvalidOperationException("Unit is required.");
            else if (Unit.Length > 10)
                throw new InvalidOperationException("Unit cannot exceed 20 characters.");

            // UnitPrice validation
            if (UnitPrice < 0)
                throw new InvalidOperationException("Unit price cannot be negative.");
            if (UnitPrice > 9999999.99m)
                throw new InvalidOperationException("Unit price is too high.");

            // Quantity validation
            if (Quantity < 0)
                throw new InvalidOperationException("Quantity cannot be negative.");
            if (Quantity > 999999.999)
                throw new InvalidOperationException("Quantity is too high.");

            // VAT validation
            if (!string.IsNullOrWhiteSpace(VAT) && VAT.Length > 10)
                throw new InvalidOperationException("VAT information cannot exceed 10 characters.");

            // CreatedBy validation
            if (CreatedBy <= 0)
                throw new InvalidOperationException("CreatedBy must be a valid user ID.");

            // WorkCategory_ID validation (if provided)
            if (WorkCategory_ID.HasValue && WorkCategory_ID <= 0)
                throw new InvalidOperationException("WorkCategory_ID must be a positive value if provided.");

            // WorkType_ID validation (if provided)
            if (WorkType_ID.HasValue && WorkType_ID <= 0)
                throw new InvalidOperationException("WorkType_ID must be a positive value if provided.");
        }
    }
}
