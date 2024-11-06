using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using usuario.Repositories;
using usuario.Service;

namespace usuario
{
    public class Program
    {

        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Orders Manager API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header
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
        private static void InjectRepositoryDependency(IHostApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<UsuarioDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );
        }

        private static void Authentication(IHostApplicationBuilder builder)
        {
            // Configuração de autenticação e autorização
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SECRET_KEY"]!))
                    };
                });
            builder.Services.AddAuthorization();
        }

        private static void InitializeSwagger(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        private static void AddControllersAndDependencies(IHostApplicationBuilder builder)
        {
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<AuthRepository>();
            builder.Services.AddScoped<TokenService>();
            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<UsuarioRepository>();
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureSwagger(builder.Services);
            InjectRepositoryDependency(builder);
            AddControllersAndDependencies(builder);
            Authentication(builder);


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                // Inicialização do Swagger
                InitializeSwagger(app);
            }

            app.MapControllers();

            app.Run();
        }
    }
}
