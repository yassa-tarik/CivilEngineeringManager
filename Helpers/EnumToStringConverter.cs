using Common.Enums;
using System;

namespace CivilEngineeringManager.Helpers
{
    public static class EnumToStringConverter
    {
        public static string AssignedWorkStatusToString(AssignedWorkStatus status)
        {
            switch (status)
            {
                case AssignedWorkStatus.NotAssigned:
                    return "Not Assigned";
                case AssignedWorkStatus.InProgress:
                    return "In Progress";
                case AssignedWorkStatus.Completed:
                    return "Completed";
                case AssignedWorkStatus.Archived:
                    return "Archived";
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
        }
    }
}
