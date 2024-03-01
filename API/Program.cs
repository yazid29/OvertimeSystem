using API.Data;
using API.Repositories.Data;
using API.Repositories.Interfaces;
using API.Services;
using API.Services.Interfaces;
using API.Utilities.Handlers;
using API.Utilities.Middlewares;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
       .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ErrorHandlingMiddleware>();
// Add Automapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Add emal handler
builder.Services.AddTransient<IEmailHandler, EmailHandler>(x =>
    new EmailHandler(builder.Configuration["EmailSettings:SmtpServer"],
                        int.Parse(builder.Configuration["EmailSettings:SmtpPort"]),
                        builder.Configuration["EmailSettings:Username"],
                        builder.Configuration["EmailSettings:Password"],
                        builder.Configuration["EmailSettings:MailFrom"]));
// Add database Context
var connectionString = builder.Configuration.GetConnectionString("SqlConnections");
builder.Services.AddDbContext<OvertimeServiceDbContext>(option =>
{
    option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    option.UseLazyLoadingProxies();
});
// Add FluentValidation Services
builder.Services.AddFluentValidationAutoValidation()
    .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// Add repository to the container
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountRoleRepository, AccountRoleRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IOvertimeRepository, OvertimeRepository>();
builder.Services.AddScoped<IOvertimeRequestRepository, OvertimeRequestRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

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

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
