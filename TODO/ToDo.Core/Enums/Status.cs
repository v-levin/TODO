using System.ComponentModel;

namespace ToDo.Core.Enums
{
    public enum Status
    {
        [Description("Not Started")]
        NotStarted,

        [Description("In Progress")]
        InProgress,

        [Description("Completed")]
        Completed
    }
}
