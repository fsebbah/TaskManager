using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using TaskManager.API.Data;
using TaskManager.API.Dtos;
using TaskManager.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Déclaration et instantation de la connexionStrind
var sqlConBuilder = new SqlConnectionStringBuilder();
sqlConBuilder.ConnectionString = builder.Configuration.GetConnectionString("SqlDbConnection");
// Utilisation des 
sqlConBuilder.UserID = builder.Configuration["UserId"];
sqlConBuilder.Password = builder.Configuration["Password"];

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(sqlConBuilder.ConnectionString));
// Déclaration de l'interface et du repo
builder.Services.AddScoped<ITaskRepo, TaskRepo>();
// Mappage entre le Model et les Dto
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("api/v1/tasks", async (ITaskRepo repo, IMapper mapper) =>
{
    var tasks = await repo.GetAllTasks();
    return Results.Ok(mapper.Map<IEnumerable<TaskReadDto>>(tasks));
});


app.MapGet("api/v1/tasks/{id}", async (ITaskRepo repo, IMapper mapper,Guid id) =>
{
    var task = await repo.GetTaskById(id);

    if (task != null)
        return Results.Ok(mapper.Map<TaskReadDto> (task));

    return Results.NotFound();
});


app.MapPost("api/v1/tasks/", async (ITaskRepo repo, IMapper mapper, TaskCreateDto taskCreateDto) =>
{
    var taskModel = mapper.Map<TaskOne>(taskCreateDto);
    await repo.CreateTask(taskModel);
    await repo.SaveChanges();
    var taskReadDto = mapper.Map<TaskReadDto>(taskModel);
    return Results.Created($"api/v1/tasks/{taskReadDto.Id}", taskReadDto);

});


app.MapPut("api/v1/tasks/{id}",async(ITaskRepo repo,IMapper mapper,Guid id, TaskUpdateDto taskUpdateDto) =>
{

    var task = await repo.GetTaskById(id);
    if (task == null)
        return Results.NotFound();

    mapper.Map(taskUpdateDto, task);
    await repo.SaveChanges();
    return Results.NoContent();

});

app.MapDelete("api/v1/tasks/{id}", async (ITaskRepo repo, IMapper mapper, Guid id) =>
{
    var task = await repo.GetTaskById(id);
    if (task == null)
        return Results.NotFound();

    repo.DeleteTask(task);
    await repo.SaveChanges();
    return Results.NoContent();

});


app.Run();

