using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Api.Controllers;
using TaskTracker.Api.Repositories.Contracts;
using Xunit;
using Moq;
using TaskTracker.Api.Entities;

namespace TaskTracker.Api.Test.Unit.Controllers
{
    public class TaskItemControllerTest
    {


        [Fact]
        public async Task GetTaskItems_ReturnsListOfTaskItems()
        {
            //Arrange 
            var mockTaskITemService = new Mock<ITaskItemRepository>();
            mockTaskITemService.Setup(service => service.GetTaskItems())
                .ReturnsAsync(new List<TaskItem>()
                {
                    new()
                    {
                        Text = "Learning C#",
                        day = "Monday, 13",
                        IsReminder = true,
                    }
                });

            var sut = new TaskItemController(mockTaskITemService.Object);

            //Act
            var result = await sut.GetTaskItems();

            //Assert
            result.Should().BeOfType<OkObjectResult>();

            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<TaskItem>>();   
            
            //mockTaskITemService.Verify(service => service.GetTaskItems(), Times.Once);
        }

        [Fact]
        public async Task GetTaskItems_NoFound_Returns404()
        {
            //Arrange 
            var mockTaskITemService = new Mock<ITaskItemRepository>();

            mockTaskITemService.Setup(service => service.GetTaskItems())
                .ReturnsAsync(new List<TaskItem>());

            var sut = new TaskItemController(mockTaskITemService.Object);

            //Act
            var result = await sut.GetTaskItems();

            //Assert
            result.Should().BeOfType<NotFoundResult>();
            var objectResult = (NotFoundResult)result;
            objectResult.StatusCode.Should().Be(404);

        }


        [Fact]
        public async Task GetTaskItem_Returns_StatusCode200()
        {
            //Arrange 
            var mockTaskITemService = new Mock<ITaskItemRepository>();

            mockTaskITemService.Setup(service => service.GetTaskItem(1))
                .ReturnsAsync(new TaskItem());

            var sut = new TaskItemController(mockTaskITemService.Object);

            //Act
            var result = (OkObjectResult)await sut.GetTaskItem(1);

            //Assert
            // result.StatusCode.Should().Be(200);
            mockTaskITemService.Verify(service => service.GetTaskItem(1), Times.Once);
        }
    }
}
