using System.ComponentModel.DataAnnotations;

namespace ToDo.Core.Enums
{
    public enum Status
    {
        [Display(Name = "Not Started")]
        NotStarted,

        [Display(Name = "In Progress")]
        InProgress,

        [Display(Name = "Completed")]
        Completed
    }
}
