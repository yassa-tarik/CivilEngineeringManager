using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    /// <summary>
    /// An enumeration for the status of an assigned work item.
    /// </summary>
    public enum AssignedWorkStatus
    {
        NotAssigned,
        Assigned,
        InProgress,
        Completed,
        Archived
    }
}
