using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ToDo.BusinessObjects;
using ToDo.Contracts.Interfaces;
using ToDo.Core.Constants;
using TODO.Models;

namespace TODO.Controllers
{
    public class ToDoController : Controller
    {
        private static readonly List<Task> _tasks = new();

        private readonly IToDoBll _toDoBll;
        private readonly IMapper _mapper;

        public ToDoController(IToDoBll toDoBll, IMapper mapper)
        {
            _toDoBll = toDoBll;
            _mapper = mapper;
        }

        public IActionResult All()
        {
            var model = _mapper.Map<List<TaskViewModel>>(_tasks);
            model = model.OrderByDescending(x => x.Priority)
                         .ThenBy(x => x.Name)
                         .ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                var task = _mapper.Map<Task>(model);
                var response = _toDoBll.CreateTask(task, _tasks);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    TempData["ValidationMessage"] = response.Message;
                    return View();
                }

                TempData["Success"] = Constant.SuccessfullyCreated;
                return RedirectToAction("All");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _toDoBll.GetTaskById(id, _tasks);
            if (task is null)
            {
                return RedirectToAction("All");
            }

            var model = _mapper.Map<TaskViewModel>(task);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(TaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                var task = _mapper.Map<Task>(model);
                var response = _toDoBll.EditTask(task, _tasks);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    TempData["ValidationMessage"] = response.Message;
                    return View();
                }

                TempData["Success"] = Constant.SuccessfullyUpdated;
                return RedirectToAction("All");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var task = _toDoBll.GetTaskById(id, _tasks);
            if (task is null)
            {
                return RedirectToAction("All");
            }

            var model = _mapper.Map<TaskViewModel>(task);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(TaskViewModel model)
        {
            var response = _toDoBll.DeleteTask(model.Id, _tasks);
            if (!string.IsNullOrEmpty(response.Message))
            {
                TempData["ValidationMessage"] = response.Message;
                return View();
            }

            TempData["Success"] = Constant.SuccessfullyDeleted;
            return RedirectToAction("All");
        }
    }
}
