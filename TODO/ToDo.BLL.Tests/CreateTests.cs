using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using ToDo.BusinessObjects;
using ToDo.Contracts.Responses;
using ToDo.Core.Constants;
using Xunit;

namespace ToDo.BLL.Tests
{
    public class CreateTests
    {
        private readonly Mock<ILogger<ToDoBll>> _loggerMock;
        private readonly ToDoBll _toDoBll;

        public CreateTests()
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
            var result = _toDoBll.CreateTask(task, ref tasks);

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
            var result = _toDoBll.CreateTask(task, ref tasks);

            // Assert
            Assert.Equal(response.Message, result.Message);
        }
    }
}
