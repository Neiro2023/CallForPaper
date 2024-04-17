using CFP.Api.Exceptions;
using CFP.Application;
using CFP.Application.Mappers;
using CFP.Application.Services;
using CFP.Application.Services.Repos;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers(opt =>
    {
        opt.Filters.Add<CallForPaperExceptionFilter>();
    })
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CallForPaperContext>();
builder.Services.AddScoped<ICallForPaperRepo, CallForPaperRepo>();
builder.Services.AddScoped<ICallForPaperService, CallForPaperService>();
builder.Services.AddSingleton<CallForPaperMapper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
