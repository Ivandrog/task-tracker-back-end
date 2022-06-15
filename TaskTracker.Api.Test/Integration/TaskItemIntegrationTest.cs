using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using TaskTracker.Api.Entities;
using Xunit;

namespace TaskTracker.Api.Test.Integration
{
    internal class TaskItemIntegrationTest
    {
        //private readonly WebApplicationFactory factory;
        //private readonly HttpClient httpClient;

        //public TaskItemIntegrationTest(WebApplicationFactory factory)
        //{
        //    this.factory = factory;
        //    this.factory.CreateClient();
        //    httpClient = this.factory.CreateClient();
        //}
        //[Fact]
        //public void AddTaskItem()
        //{
        //    // Arrange
        //    var taskItem = new TaskItem
        //    {
        //        Text = "Learning C#",
        //        day = "Monday, 13",
        //        IsReminder = true,
        //    };

        //    StringContent content =
        //        new StringContent(JsonConvert.SerializeObject(taskItem));


        //    // Act
        //    var httpClientRequest = httpClient.PostAsync("/tasks", content).GetAwaiter().GetResult();


        //    //Assert
        //    Assert.Equal(HttpStatusCode.Created, httpClientRequest.StatusCode);

        //}
    }
}