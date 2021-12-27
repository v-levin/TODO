using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.BusinessObjects;
using ToDo.Contracts.Interfaces;
using ToDo.Contracts.Responses;
using ToDo.Core.Constants;
using ToDo.Core.Enums;

namespace ToDo.BLL
{
    public class ToDoBll : IToDoBll
    {
        private static int i = 0;

        private readonly ILogger<ToDoBll> _logger;
        private readonly Response _response;

        public ToDoBll(ILogger<ToDoBll> logger)
        {
            _logger = logger;
            _response = new Response();
        }

        public Response CreateTask(Task task, List<Task> tasks)
        {
            try
            {
                if (CheckIfNameExists(task.Name, tasks))
                {
                    _response.Message = Constant.TaskAlreadyExists;
                    return _response;
                }

                task.Id = i++;
                tasks.Add(task);

                return _response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("En error occurred while creating a task");
            }
        }

        public Task GetTaskById(int id, List<Task> tasks)
        {
            try
            {
                return tasks.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("En error occurred while getting task by id");
            }
        }

        public Response EditTask(Task task, List<Task> tasks)
        {
            try
            {
                if (CheckIfNameExists(task.Name, tasks))
                {
                    _response.Message = Constant.TaskAlreadyExists;
                    return _response;
                }

                var item = tasks.FirstOrDefault(x => x.Id == task.Id);
                if (item is not null)
                {
                    item.Name = task.Name;
                    item.Priority = task.Priority;
                    item.Status = task.Status;
                }

                return _response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("En error occurred while editing a task");
            }
        }

        public Response DeleteTask(int id, List<Task> tasks)
        {
            try
            {
                var taskToDelete = tasks.FirstOrDefault(x => x.Id == id);
                if (taskToDelete is not null && taskToDelete.Status is Status.Completed)
                {
                    tasks.Remove(taskToDelete);
                    return _response;
                }

                _response.Message = Constant.DeleteOnlyCompletedTask;
                return _response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("En error occurred while deleting a task");
            }
        }

        private static bool CheckIfNameExists(string taskName, List<Task> tasks)
        {
            return tasks.Any(x => x.Name == taskName);
        }
    }
}
