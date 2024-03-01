using API.Data;
using API.Repositories.Data;
using API.Repositories.Interfaces;
using API.Services;
using API.Services.Interfaces;
using API.Utilities.Handlers;
using API.Utilities.Middlewares;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
       .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => {
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Metrodata MBKM 6",
        Description = "ASP.NET Core API 6.0"
    });
    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    x.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

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
// Add authentication schema using JWT
builder.Services.AddScoped<IJwtHandler, JwtHandler>(_ =>
    new JwtHandler(builder.Configuration["Jwt:Key"],
                     builder.Configuration["Jwt:Issuer"],
                     builder.Configuration["Jwt:Audience"],
                     int.Parse(builder.Configuration["Jwt:DurationInMinutes"])
));
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.AddCors(x =>
{
    x.AddDefaultPolicy(option =>
    {
        //option.WithOrigins("https://brm.metrodataacademy.id", "https://portal.metrodataacademy.id");
        //option.WithHeaders("Content-Type", "Authorization", "Accept");
        //option.WithMethods("GET", "POST", "PUT", "DELETE");
        option.AllowAnyOrigin();
        option.AllowAnyHeader();
        option.AllowAnyMethod();
    });
});
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
