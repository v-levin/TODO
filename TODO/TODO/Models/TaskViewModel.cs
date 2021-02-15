using System.ComponentModel.DataAnnotations;
using ToDo.Core.Enums;

namespace TODO.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        public int? StatusId { get; set; }

        [Required]
        public string Name { get; set; }

        public int? Priority { get; set; }

        public Status Status { get; set; }
    }
}
