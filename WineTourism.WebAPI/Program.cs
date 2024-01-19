using WineTourism.Infrastructure.Extensions;
using WineTourism.Persistance.Extensions;
using WineTourism.Application.Extensions;
using WineTourism.Application.Common;
using WineTourism.WebAPI.Common;
using WineTourism.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureLayer();
builder.Services.AddPersistanceLayer();
builder.Services.AddApplicationLayer();
builder.Services.AddScoped<IUser, CurrentUser>();
builder.Services.AddScoped<UserDataAccessMiddleware>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<UserDataAccessMiddleware>();

app.MapControllers();

app.Run();
