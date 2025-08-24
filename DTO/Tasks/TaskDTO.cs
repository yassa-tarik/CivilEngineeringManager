using System;

namespace DTO.Task
{
    public class TaskDTO : TaskBaseDTO
    {
        public int? TaskTypeID { get; set; }

        // Computed property
        public decimal Amount => UnitPrice * (decimal)Quantity;

        // For hierarchical tasks
        public int? ParentID { get; set; }
        public bool HasChild { get; set; }

        public TaskDTO(int id, string name, string unit, decimal unitPrice,
                       double quantity, string vat, DateTime creationDate, int createdBy, int? taskTypeID = null, int? parentID = null, bool hasChild = false)
            : base(id, name, unit, unitPrice, quantity, vat, creationDate, createdBy)
        {
            TaskTypeID = taskTypeID;
            ParentID = parentID;
            HasChild = hasChild;
        }
    }
}