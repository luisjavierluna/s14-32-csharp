using eventPlannerBack.BLL.Behaviors;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.BLL.Service;
using eventPlannerBack.BLL.Validators;
using eventPlannerBack.DAL.Dbcontext;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.DAL.Repository;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.Utilities;
using eventPlannerBack.Models.VModels;
using eventPlannerBack.Models.VModels.DatosDTO;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<AplicationDBcontext>(option =>

    option.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection"), p => p.MigrationsAssembly("eventPlannerBack.DAL"))
    
);

builder.Services.AddIdentity<User, IdentityRole>(option => { option.Password.RequireNonAlphanumeric = false; option.User.RequireUniqueEmail = true; }).AddEntityFrameworkStores<AplicationDBcontext>().AddDefaultTokenProviders();

var CorsRules = "CorsRules";
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: CorsRules, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

//Configuraci�n para validar el token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtKey"])),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {

        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header

    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {

            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                Type  = ReferenceType.SecurityScheme,
                Id = "Bearer"

                }
            },

            new string[]{}

        }

    });


});

//Configuracion Automapper

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//Configuracion FluentValidation
#region FluentValidation
builder.Services.AddTransient(typeof(ValidationBehavior<>));
builder.Services.AddTransient<IValidator<UserCreationDTO>, UserCreationDTOValidator>();
builder.Services.AddTransient<IValidator<DataCreationDTO>, DataCreationDTOValidator>();
#endregion

//Inyeccion de Dependencia

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();

//Data
builder.Services.AddScoped<IGenericRepository<DataCreationDTO, DataDTO, Data>, DataRepository>();
builder.Services.AddScoped<IGenericService<DataCreationDTO, DataDTO>, DataService>();
builder.Services.AddScoped<IDataService, DataService>();





//Email
builder.Services.AddScoped<IEmailService, EmailService>();

//Data Seeder
builder.Services.AddScoped<IDataSeeder, DataSeeder>();

//Event
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();

//City-Province
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICityService, CityService>();

var app = builder.Build();






using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var dataSeeder = services.GetRequiredService<IDataSeeder>();
        await dataSeeder.CreateRoles();
        await dataSeeder.CreateUserAdmin();        
    }
    catch (Exception)
    {


    }
}

//Db migration

using (var scope = app.Services.CreateScope()) 
{
    var Context = scope.ServiceProvider.GetRequiredService<AplicationDBcontext>();
    Context.Database.Migrate();
}



// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(CorsRules);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
