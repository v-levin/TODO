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
    public class DeleteTests
    {
        private readonly Mock<ILogger<ToDoBll>> _loggerMock;
        private readonly ToDoBll _toDoBll;

        public DeleteTests()
        {
            _loggerMock = new Mock<ILogger<ToDoBll>>();
            _toDoBll = new ToDoBll(_loggerMock.Object);
        }

        [Fact]
        public void DeleteTask_NotSuccessful_IfStatusIdNotCompleted()
        {
            // Arrange
            var response = new Response { Message = Constant.DeleteOnlyCompletedTask };
            var id = 1;
            var tasks = new List<Task> { new Task { Id = 1, Name = "Test", Status = Status.InProgress }, new Task { Id = 2, Name = "Test 1" } };

            // Act
            var result = _toDoBll.DeleteTask(id, ref tasks);

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
            var result = _toDoBll.DeleteTask(id, ref tasks);

            // Assert
            Assert.Equal(response.Message, result.Message);
        }
    }
}
