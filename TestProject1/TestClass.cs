using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    // These are the simple data models returned by the mock repositories.
    // They mimic the data structure you'd likely get from your database.

    public class WorkCategory
    {
        public int ID { get; set; }
        public string?   WorkCategoryName { get; set; }
    }

    public class WorkType
    {
        public int ID { get; set; }
        public int WorkCategory_ID { get; set; }
        public int? Parent_ID { get; set; }
        public string? Designation { get; set; }
    }

    public class WorkSpec
    {
        public int ID { get; set; }
        public int WorkType_ID { get; set; }
        public string? Designation { get; set; }
        public string? Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public double Quantity { get; set; }
        public string? VAT { get; set; }
    }

}
