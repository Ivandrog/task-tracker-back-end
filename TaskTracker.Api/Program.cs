using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using TaskTracker.Api.Data;
using TaskTracker.Api.Repositories;
using TaskTracker.Api.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {

    });
});
builder.Services.AddDbContextPool<TaskItemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TaskItemConnection"))
);

builder.Services.AddScoped<ITaskItemRepository, TaskItemRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(policyName => policyName.WithOrigins("http://localhost:4200",
    "http://localhost:4200/")
        .AllowAnyMethod()
        .WithHeaders(HeaderNames.ContentType));


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
