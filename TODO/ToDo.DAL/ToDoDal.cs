using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo.BusinessObjects;
using ToDo.Contracts;
using ToDo.Core.Responses;

namespace ToDo.DAL
{
    public class ToDoDal : IToDoDal
    {
        private static int i = 0;
        
        public Response CreateTask(Task task, ref List<Task> tasks)
        {
            if (tasks.Any(x => x.Name == task.Name))
            {
                return new Response { Message = "A task with that name already exists!" };
            }

            task.Id = i++;
            tasks.Add(task);

            return new Response { Message = string.Empty };
        }

        public Task GetTaskById(int id, ref List<Task> tasks)
        {
            return tasks.FirstOrDefault(x => x.Id == id);
        }

        public Response EditTask(Task task, ref List<Task> tasks)
        {
            if (tasks.Any(x => x.Name == task.Name))
            {
                return new Response { Message = "A task with that name already exists!" };
            }

            var item = tasks.FirstOrDefault(x => x.Id == task.Id);

            return new Response { Message = string.Empty };
        }
    }
}
