using System.Collections.Generic;
using ToDo.BusinessObjects;
using ToDo.Contracts.Responses;

namespace ToDo.Contracts.Interfaces
{
    public interface IToDoBll
    {
        Response CreateTask(Task task, ref List<Task> tasks);
        Task GetTaskById(int id, ref List<Task> tasks);
        Response EditTask(Task task, ref List<Task> tasks);
        Response DeleteTask(int id, ref List<Task> tasks);
    }
}
