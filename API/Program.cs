using API.Data;
using API.Repositories.Interfaces;
using API.Services;
using API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
       .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add database Context
var connectionString = builder.Configuration.GetConnectionString("SqlConnections");
builder.Services.AddDbContext<OvertimeServiceDbContext>(option =>
{
    option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Add repository to the container
builder.Services.AddScoped<IAccountRepository, IAccountRepository>();
builder.Services.AddScoped<IAccountRoleRepository, IAccountRoleRepository>();
builder.Services.AddScoped<IEmployeeRepository, IEmployeeRepository>();
builder.Services.AddScoped<IOvertimeRepository, IOvertimeRepository>();
builder.Services.AddScoped<IOvertimeRequestRepository, IOvertimeRequestRepository>();
builder.Services.AddScoped<IRoleRepository, IRoleRepository>();

// Add Service to the container
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountRoleService, AccountRoleService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IOvertimeRequestService, OvertimeRequestService>();
builder.Services.AddScoped<IOvertimeService, OvertimeService>();
builder.Services.AddScoped<IRoleService, RoleService>();

//build app
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
