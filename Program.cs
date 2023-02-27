using MasterJob.Helper;
using MasterJob.Models;
using Microsoft.EntityFrameworkCore;

var policyName = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
                      builder =>
                      {
                          builder
                            //.WithOrigins("http://localhost:3000")
                            .AllowAnyOrigin()
                            //.WithMethods("GET")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/
builder.Services.AddDbContext<MasterJobContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("MasterJobContext")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policyName);
app.UseAuthorization();
//app.UseExceptionHandler("/error");
//app.UseMiddleware<DatabaseRelationalExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();
