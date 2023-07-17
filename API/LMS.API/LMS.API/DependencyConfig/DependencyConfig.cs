using AutoMapper;
using GamaLearn.LMS.DataAccess;
using GamaLearn.LMS.DataAccess.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Text;
using GamaLearn.LMS.Services;
using GamaLearn.LMS.Services.Interfaces;
using GamaLearn.LMS.Domain.Repository;
using GamaLearn.LMS.Infrastructure.Repository;
using GamaLearn.LMS.DataAccess.Repository;

namespace GamaLearn.LMS.API.DependencyConfig
{
    public class DependencyConfig
    {
        private IServiceCollection _services;
        private IConfiguration _configuration;
        private IWebHostEnvironment _env;
        public DependencyConfig(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            _services = services;
            _configuration = configuration;
            _env = env;
        }

        public void ConfigureServices()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BookMappingProfile>();
            });
            AddDbContext(_services, _configuration, _env);
            // AddOptionsBinders(_services, _configuration);
            AddRepositories(_services);
            AddMapper(_services);
            AddDataServices(_services);
            AddSwagger(_services);
            AddAuth(_services, _configuration);
            AddCoresAllowAll(_services);
        }
        public void AddDbContext(IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
        {
            var connectionString = configuration.GetConnectionString("TaskConnection");
            services.AddDbContext<LMSDbContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlServerOptions =>
                {
                    sqlServerOptions.CommandTimeout(90);
                    sqlServerOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            });
        }
        public void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();
        }
        public void AddDataServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IUrlHelper>(x =>
            {
                var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = x.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(actionContext);
            });

            //services.AddScoped<IUserSession, UserSession>();
        }
        public void AddOptionsBinders(IServiceCollection services, IConfiguration configuration)
        {
            // in case of have some configuration from app setting , so we create a bided class for each section
           // services.AddOptions<BooksOption>().Bind(configuration.GetSection(BooksOption.SectionName)).ValidateDataAnnotations();
        }

        public void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                             new OpenApiInfo
                             {
                                 Version = "1.0",
                                 Title = "Library Managment System API",
                                 Description = "Library Managment System API",
                             });

                c.AddSecurityDefinition("Bearer",
                                        new OpenApiSecurityScheme
                                        {
                                            In = ParameterLocation.Header,
                                            Description = "Please enter into field the word 'Bearer' following by space and JWT",
                                            Name = "Authorization",
                                            Type = SecuritySchemeType.ApiKey,
                                            Scheme = "Bearer"
                                        });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                    Array.Empty<string>()
                }
            });
            });
        }

        public void AddAuth(IServiceCollection services, IConfiguration configuration)
        {
            // services.AddSingleton(new HasPermissionFilterOptions("test", "")); if i have permitions & roles
            var audienceConfig = configuration.GetSection("Audience");
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audienceConfig["Secret"]));
            var tokenValidationParameters = new TokenValidationParameters
            {
                NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = audienceConfig["Iss"],
                ValidateAudience = true,
                ValidAudience = audienceConfig["Aud"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = tokenValidationParameters;
            });
            services.AddAuthorization();
        }

        public void AddMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BookMappingProfile));
        }

        public void AddCoresAllowAll(IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("AllowAllOrigin",
                            options => options.AllowAnyOrigin()
                                              .AllowAnyMethod()
                                              .AllowAnyHeader());
            });
        }
    }
}
