using ToDo.Core.Enums;

namespace ToDo.BusinessObjects
{
    public class Task
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Priority { get; set; }

        public Status Status { get; set; }
    }
}
