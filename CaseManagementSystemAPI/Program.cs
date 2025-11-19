using Application;
using Application.Commons.PermissionModule;
using Application.Configurations;
using Application.Interfaces;
using Application.Interfaces.AccountService;
using Application.Interfaces.Audtiting;
using Application.Interfaces.FileServices;
using Application.Interfaces.ManagementService;
using Application.Repositories;
using Application.Repositories;
using Application.Repositories.AccountRepos;
using Application.Repositories.Auth;
using Application.Repositories.Commons;
using Application.Repositories.ManagementRepos;
using Application.Repositories.Users;
using Application.UseCases;
using Application.UseCases.Auth;
using Application.UseCases.LawyerService;
using AutoMapper;
using CaseManagementSystemAPI.Middlewares;
using Domain.Entites.Permissions;
using Infrastrcuture.Auth;
using Infrastrcuture.Database;
using Infrastrcuture.Mappers;
using Infrastrcuture.Repositories;
using Infrastrcuture.Repositories.AccountRepos;
using Infrastrcuture.Repositories.Auth;
using Infrastrcuture.Repositories.CaseRepositories;
using Infrastrcuture.Repositories.Commons;
using Infrastrcuture.Repositories.ManagementRepos;
using Infrastrcuture.Repositories.Users;
using Infrastrcuture.Services;
using Infrastrcuture.Services.Audting;
using Infrastrcuture.Services.FileServices;
using Infrastrcuture.Services.ManagementService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new() { Title = "Mezan System For Judical Affairs | منصة ميزان للشؤون القضائية", Version = "v1" });
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
        builder.Services.AddScoped<IFileEncryptionService, FileEncryptionService>();
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddScoped<IAccountRepository, AccountRepository>();
        builder.Services.AddScoped<IAccountService, AccountService>();
        builder.Services.AddScoped<IManagementService, ManagementService>();
        builder.Services.AddScoped<IAuditTrailService, AuditService>();
        builder.Services.AddScoped<IRefernceDataRepostiory, RefernceDataRepository>();
        builder.Services.AddScoped<IAuthorizationHandler, PermissionHandler>();


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

        builder.Services.Configure<FileStorageSettings>(builder.Configuration.GetSection("FileStorage"));
        builder.Services.AddTransient<IFTPCilentService, FTPCilentService>();


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

        builder.Services.AddMediatR(cfg =>
           cfg.RegisterServicesFromAssembly(typeof(AssemblyMarker).Assembly));

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

        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var permissionRepo = new PermissionRepostiory(context , context.Set<Permission>());

            var pagedPermissions = await permissionRepo.GetAllAsync(1  , int.MaxValue);
            var permissions = pagedPermissions.Data;

            var authorizationOptions = scope.ServiceProvider
                                            .GetRequiredService<IOptions<AuthorizationOptions>>()
                                            .Value;

            foreach (var permission in permissions)
            {
                authorizationOptions.AddPolicy(permission.Name, policy =>
                {
                    policy.Requirements.Add(new PermissionRequirement(permission.Name));
                });
            }
        }
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

    //    app.UseMiddleware<GlobalExceptionHandler>();

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
