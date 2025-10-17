using Application.Interfaces;
using Application.Repositories;
using Application.Repositories.Auth;
using Application.Repositories.Users;
using Application.UseCases;
using Application.UseCases.Auth;
using Application.UseCases.LawyerService;
using AutoMapper;
using CaseManagementSystemAPI.Middlewares;
using Infrastrcuture.Auth;
using Infrastrcuture.Database;
using Infrastrcuture.Mappers;
using Infrastrcuture.Repositories;
using Infrastrcuture.Repositories.Auth;
using Infrastrcuture.Repositories.CaseRepositories;
using Infrastrcuture.Repositories.Users;
using Infrastrcuture.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new() { Title = "Case Management System", Version = "v1" });
            options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Description = "Bearer <token>"
            });
            options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
            {
                {
                    new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        Reference = new Microsoft.OpenApi.Models.OpenApiReference
                        {
                            Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        builder.Services.AddScoped<IEmailService, EmailService>();
        builder.Services.AddScoped<SendOTPUseCase>();
        builder.Services.AddMemoryCache();
        builder.Services.AddScoped<ICacheService, CacheService>();
        builder.Services.AddScoped<VerifyOTPUseCase>();
        builder.Services.AddScoped<CheckEmail>();
        builder.Services.AddScoped<IAuthRepository, AuthRepository>();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<ILoginService, LoginService>();
        builder.Services.AddScoped<LoginUseCase>();
        builder.Services.AddScoped<IResetPasswordService, ResetPasswordUseCase>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<ICaseService, CaseService>();
        builder.Services.AddScoped<ICaseService, CaseService>();
        builder.Services.AddScoped<ILawyerRepository, LawyerRepository>();
        builder.Services.AddScoped<ILawyerService, LawyerService>();
        var csvFilePath = Path.Combine(
            Directory.GetParent(Directory.GetCurrentDirectory())!.FullName,
            "Service",
            "AppData",
            "Oman_Locations_Governates_Wallyats_Villages.csv"
        );

        var countriesCsvFilePath = Path.Combine(
                 Directory.GetParent(Directory.GetCurrentDirectory())!.FullName,
                "Service",
                "AppData",
                "countries.csv"
        );

        builder.Services.AddSingleton<IGetOmaniGovernatesService>(sp =>
            new GetOmanGovernatesService(csvFilePath));

        builder.Services.AddSingleton<IGetCountriesService>(sp =>
            new GetCountriesService(countriesCsvFilePath));


        builder.Services.AddAutoMapper(typeof(MappingProfile));

        builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
            opt.TokenLifespan = TimeSpan.FromMinutes(15));

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

        builder.Services.AddIdentity<ApplicationUser, ApplicationUserRole>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 5;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

        var publicKeyPath = Path.Combine(Directory.GetCurrentDirectory(), "Security", "public_key.pem");

        var publicKeyText = File.ReadAllText(publicKeyPath);
        var rsa = RSA.Create();
        rsa.ImportFromPem(publicKeyText);

        var securityKey = new RsaSecurityKey(rsa);

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = securityKey,
                ValidateIssuer = false,
                ValidateAudience = false,
                RoleClaimType = "Role"
            };
        });

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", policy =>
                     policy.RequireClaim("Role", "Admin"));
        });



        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader());
        });


        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseMiddleware<GlobalExceptionHandler>();

        app.Use(async (context, next) =>
        {
            Console.WriteLine($"Path: {context.Request.Path}");
            Console.WriteLine($"Authorization Header: {context.Request.Headers["Authorization"]}");
            Console.WriteLine($"Authenticated: {context.User?.Identity?.IsAuthenticated}");
            await next();
        });
        app.UseCors("AllowAll");


        app.MapControllers();
        app.Run();
    }
}
