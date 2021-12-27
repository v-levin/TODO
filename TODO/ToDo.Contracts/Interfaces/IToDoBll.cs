using System.Collections.Generic;
using ToDo.BusinessObjects;
using ToDo.Contracts.Responses;

namespace ToDo.Contracts.Interfaces
{
    public interface IToDoBll
    {
        Response CreateTask(Task task, List<Task> tasks);
        Task GetTaskById(int id, List<Task> tasks);
        Response EditTask(Task task, List<Task> tasks);
        Response DeleteTask(int id, List<Task> tasks);
    }
}
