using Application.Interfaces;
using Application.UseCases.Auth;
using Infrastrcuture.Auth;
using Infrastrcuture.Database;
using Infrastrcuture.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Infrastrcuture.Database;
using Infrastrcuture.Repositories.Auth;
using CaseManagementSystemAPI.Middlewares;
using Application.Repositories.Auth;
using Infrastrcuture.Mappers;
using AutoMapper;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IEmailService, EmailService>();
        builder.Services.AddScoped<SendOTPUseCase>();
        builder.Services.AddMemoryCache();
        builder.Services.AddScoped<IOTPCache, OTPCacheService>();
        builder.Services.AddScoped<VerifyOTPUseCase>();
        builder.Services.AddScoped<CheckEmail>();
        builder.Services.AddScoped<IAuthRepository , AuthRepository>();
        builder.Services.AddScoped<ILoginService , LoginService>();
        builder.Services.AddAutoMapper(typeof(MappingProfile));

        builder.Services.AddDbContext<ApplicationDbContext>(option =>

            option.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

        builder.Services.AddIdentity<ApplicationUser, ApplicationUserRole>
        (options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 5;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
        })
             .AddEntityFrameworkStores<ApplicationDbContext>()
             .AddDefaultTokenProviders();


        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new() { Title = "نظام ادارة القضايا | Case Management System", Version = "v1" });

            // 🔐 Add JWT Bearer token support
            options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Description = "بعدها مسافة ثم ادخل التوكن الذي ينتج عن عملية تسجيل الدخول Bearer قم بأدخال كلمة "
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
            new string[] {}
        }
    });
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
        app.UseMiddleware<GlobalExceptionHandler>();

        app.MapControllers();


        app.Run();
    }
}