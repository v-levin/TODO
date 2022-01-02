using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using ToDo.BusinessObjects;
using ToDo.Contracts.Responses;
using ToDo.Core.Constants;
using ToDo.Core.Enums;
using Xunit;

namespace ToDo.BLL.Tests
{
    public class ToDTests
    {
        private readonly Mock<ILogger<ToDoBll>> _loggerMock;
        private readonly ToDoBll _toDoBll;

        public ToDTests()
        {
            _loggerMock = new Mock<ILogger<ToDoBll>>();
            _toDoBll = new ToDoBll(_loggerMock.Object);
        }

        [Fact]
        public void CreateTask_NotSuccessful_WhenTaskWithSameName()
        {
            // Arrange
            var response = new Response { Message = Constant.TaskAlreadyExists };
            var task = new Task { Id = 0, Name = "Test" };
            var tasks = new List<Task> { new Task { Id = 1, Name = "Test" } };

            // Act
            var result = _toDoBll.CreateTask(task, tasks);

            // Assert
            Assert.Equal(response.Message, result.Message);
        }

        [Fact]
        public void CreateTask_Successful_WhenTaskWithUniqeName()
        {
            // Arrange
            var response = new Response();
            var task = new Task { Id = 0, Name = "Test" };
            var tasks = new List<Task> { new Task { Id = 1, Name = "Test 1" } };

            // Act
            var result = _toDoBll.CreateTask(task, tasks);

            // Assert
            Assert.Equal(response.Message, result.Message);
        }

        [Fact]
        public void GetTask_ReturnNull_WhenIdDoesNotExists()
        {
            // Arrange
            var id = 3;
            var tasks = new List<Task> { new Task { Id = 1, Name = "Test" }, new Task { Id = 2, Name = "Test 1" } };

            // Act
            var result = _toDoBll.GetTaskById(id, tasks);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetTask_ReturnTask_WhenIdExists()
        {
            // Arrange
            var id = 2;
            var tasks = new List<Task> { new Task { Id = 1, Name = "Test" }, new Task { Id = 2, Name = "Test 1" } };

            // Act
            var result = _toDoBll.GetTaskById(id, tasks);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void EditTask_NotSuccessful_WhenTaskWithSameName()
        {
            // Arrange
            var response = new Response { Message = Constant.TaskAlreadyExists };
            var task = new Task { Id = 0, Name = "Test" };
            var tasks = new List<Task> { new Task { Id = 1, Name = "Test" } };

            // Act
            var result = _toDoBll.EditTask(task, tasks);

            // Assert
            Assert.Equal(response.Message, result.Message);
        }

        [Fact]
        public void EditTask_Successful_WhenTaskWithUniqeName()
        {
            // Arrange
            var response = new Response();
            var task = new Task { Id = 0, Name = "Test" };
            var tasks = new List<Task> { new Task { Id = 1, Name = "Test 1" } };

            // Act
            var result = _toDoBll.EditTask(task, tasks);

            // Assert
            Assert.Equal(response.Message, result.Message);
        }

        [Fact]
        public void DeleteTask_NotSuccessful_IfStatusIdNotCompleted()
        {
            // Arrange
            var response = new Response { Message = Constant.DeleteOnlyCompletedTask };
            var id = 1;
            var tasks = new List<Task> { new Task { Id = 1, Name = "Test", Status = Status.InProgress }, new Task { Id = 2, Name = "Test 1" } };

            // Act
            var result = _toDoBll.DeleteTask(id, tasks);

            // Assert
            Assert.Equal(response.Message, result.Message);
        }

        [Fact]
        public void DeleteTask_Successful_WhenStatusIsCompleted()
        {
            // Arrange
            var response = new Response();
            var id = 1;
            var tasks = new List<Task> { new Task { Id = 1, Name = "Test", Status = Status.Completed }, new Task { Id = 2, Name = "Test 1" } };

            // Act
            var result = _toDoBll.DeleteTask(id, tasks);

            // Assert
            Assert.Equal(response.Message, result.Message);
        }
    }
}
