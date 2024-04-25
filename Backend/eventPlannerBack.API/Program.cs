using eventPlannerBack.BLL.Behaviors;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.BLL.Service;
using eventPlannerBack.BLL.Validators;
using eventPlannerBack.DAL.Dbcontext;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.DAL.Repository;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.Utilities;
using eventPlannerBack.Models.VModels;
using eventPlannerBack.Models.VModels.ClientDTO;
using eventPlannerBack.Models.VModels.ContractorDTO;
using eventPlannerBack.Models.VModels.EventsDTO;
using eventPlannerBack.Models.VModels.NotificationDTO;
using eventPlannerBack.Models.VModels.PostulationDTO;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
    //.AddJsonOptions(options =>
    //options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve); 

//builder.Services.AddControllers().AddJsonOptions(x =>
//                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


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
builder.Services.AddTransient<IValidator<UserCredentialsDTO>, UserCredentialsDTOValidator>();
builder.Services.AddTransient<IValidator<ClientCreationDTO>, ClientCreationDTOValidator>();
builder.Services.AddTransient<IValidator<ContractorCreationDTO>, ContractorCreationDTOValidator>();
builder.Services.AddTransient<IValidator<NotificationCreationDTO>, NotificationCreationDTOValidator>();
builder.Services.AddTransient<IValidator<EventCreationDTO>, EventCreationDTOValidator>();
builder.Services.AddTransient<IValidator<PostulationCreationDTO>, PostulationCreationDTOValidator>();

#endregion

//Inyeccion de Dependencia

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();
    
//Notification
builder.Services.AddScoped<IGenericRepository<NotificationCreationDTO, NotificationDTO, Notification>, NotificationRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IGenericService<NotificationCreationDTO, NotificationDTO>, NotificationService>();
builder.Services.AddScoped<INotificationService, NotificationService>();    

// Client
builder.Services.AddScoped<IGenericRepository<ClientCreationDTO, ClientDTO, Client>, ClientRepository>();
builder.Services.AddScoped<IGenericService<ClientCreationDTO, ClientDTO>, ClientService>();
builder.Services.AddScoped<IClientService, ClientService>();

// Contractor
builder.Services.AddScoped<IGenericRepository<ContractorCreationDTO, ContractorDTO, Contractor>, ContractorRepository>();
builder.Services.AddScoped<IContractorRepository, ContractorRepository>();
builder.Services.AddScoped<IGenericService<ContractorCreationDTO, ContractorDTO>, ContractorService>();
builder.Services.AddScoped<IContractorService, ContractorService>();

// Postulation
builder.Services.AddScoped<IGenericRepository<PostulationCreationDTO, PostulationDTO, Postulation>, PostulationRepository>();
builder.Services.AddScoped<IPostulationRepository, PostulationRepository>();
builder.Services.AddScoped<IGenericService<PostulationCreationDTO, PostulationDTO>, PostulationService>();
builder.Services.AddScoped<IPostulationService, PostulationService>();

// Vocation
builder.Services.AddScoped<IVocationRepository, VocationRepository>();
builder.Services.AddScoped<IVocationService, VocationService>();

//Email
builder.Services.AddScoped<IEmailService, EmailService>();

//Data Seeder
builder.Services.AddScoped<IClientSeeder, ClientSeeder>();

//Event
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();

//EventType
builder.Services.AddScoped<IEventTypeRepository, EventTypeRepository>();
builder.Services.AddScoped<IEventTypeService, EventTypeService>();

//ImageEvent
builder.Services.AddScoped<IImageEventRepository, ImageEventRepository>();

//City-Province
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICityService, CityService>();

// Cloudinary
builder.Services.Configure<CloudinarySetting>(builder.Configuration.GetSection("CloudinarySettings"));
builder.Services.AddScoped<CloudinaryService>();

var app = builder.Build();






using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var dataSeeder = services.GetRequiredService<IClientSeeder>();
        await dataSeeder.CreateRoles();
        await dataSeeder.CreateUserAdmin();
        await dataSeeder.CreateClientUsers();
        await dataSeeder.CreateContractorUsers();
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
