using System.Collections.Generic;
using System;

namespace DTO.Task
{
    public class TaskBaseDTO
    {
        public int ID { get; }

        public string Designation { get; }
        public string Unit { get; }
        public decimal UnitPrice { get; }
        public double Quantity { get; }
        public string VAT { get; }
        public DateTime CreationDate { get; }
        public int CreatedBy { get; }       

        protected TaskBaseDTO(int id, string designation, string unit, decimal unitPrice, double quantity, string vat, DateTime creationDate, int createdBy)
        {
            ID = id;
            Designation = designation;
            Unit = unit;
            UnitPrice = unitPrice;
            Quantity = quantity;
            VAT = vat;
            CreationDate = creationDate;
            CreatedBy = createdBy;
        }
    }
}