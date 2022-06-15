using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Api.Data;
using TaskTracker.Api.Repositories;
using Xunit;

namespace TaskTracker.Api.Test.Unit.Services
{
    public class TaskItemRepositoryTest
    {
        [Fact]
        public async Task GetTaskItems()
        {
            //Arrange 
            var mockTaskItemDbContext = new Mock<TaskItemDbContext>();

            var sut = new TaskItemRepository(mockTaskItemDbContext.Object);

            await sut.GetTaskItems();
            //Act 


            //Assert
        }
    }
}
