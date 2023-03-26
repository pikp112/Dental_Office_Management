using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using WhiteDentalClinic.Application.MappingProfiles;
using WhiteDentalClinic.Application.Services;
using WhiteDentalClinic.DataAccess;
using WhiteDentalClinic.Shared.Services;
using WhiteDentalClinic.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WhiteDentalClinic.DataAccess.Repositories.IRepositories;
using WhiteDentalClinic.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add dependecy injection
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddScoped<IDentistService,DentistService>();
builder.Services.AddScoped<IDentistRepository, DentistRepository>();

builder.Services.AddScoped<IDentistServiceRepository, DentistServiceRepositoryBase>();

builder.Services.AddScoped<IMedicalServiceService, MedicalServiceService>();
builder.Services.AddScoped<IMedicalServiceRepository, MedicalServiceRepository>();

builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

builder.Services.AddScoped<ITemplateService, TemplateService>();

builder.Services.AddTransient<IClaimService, ClaimService>();

builder.Services.AddAutoMapper(typeof(CustomerProfile));
builder.Services.AddAutoMapper(typeof(DentistProfile));
builder.Services.AddAutoMapper(typeof(MedicalServiceProfile));
builder.Services.AddAutoMapper(typeof(AppointmentProfile));


builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

// Add db connection
builder.Services.AddDbContext<ApiDbTempContext>(options =>
{
    options.UseSqlServer(builder.Configuration["Database:ConnectionString"]);
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;       //sa foloseasca Jwt
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,     //request de oriunde
        ValidateAudience = false,   //request de oriunde
        ValidateLifetime = true,     // expire date
        ValidateIssuerSigningKey= true,    //check the key
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTConfiguration:SecretKey"]))
    };
});


 var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors(corsPolicyBuilder =>                //request de ORIUNDE, orice Header si orice Metoda (get, post, put etc.) 
{
    corsPolicyBuilder.AllowAnyOrigin()          //depinde de business
    .AllowAnyHeader()
    .AllowAnyMethod();
});


app.Run();
