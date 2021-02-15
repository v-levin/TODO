using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using ToDo.BusinessObjects;
using Xunit;

namespace ToDo.BLL.Tests
{
    public class GetTests
    {
        private readonly Mock<ILogger<ToDoBll>> _loggerMock;
        private readonly ToDoBll _toDoBll;

        public GetTests()
        {
            _loggerMock = new Mock<ILogger<ToDoBll>>();
            _toDoBll = new ToDoBll(_loggerMock.Object);
        }

        [Fact]
        public void GetTask_ReturnNull_WhenIdDoesNotExists()
        {
            // Arrange
            var id = 3;
            var tasks = new List<Task> { new Task { Id = 1, Name = "Test" }, new Task { Id = 2, Name = "Test 1" } };

            // Act
            var result = _toDoBll.GetTaskById(id, ref tasks);

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
            var result = _toDoBll.GetTaskById(id, ref tasks);

            // Assert
            Assert.NotNull(result);
        }
    }
}
