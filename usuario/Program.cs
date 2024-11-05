using Microsoft.EntityFrameworkCore;
using usuario.Repositories;
using usuario.Service;

namespace usuario
{
    public class Program
    {
        private static void InjectRepositoryDependency(IHostApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<UsuarioDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );
        }

        private static void AddControllersAndDependencies(IHostApplicationBuilder builder)
        {
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<AuthRepository>();
            builder.Services.AddScoped<TokenService>();
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            InjectRepositoryDependency(builder);
            AddControllersAndDependencies(builder);
            var app = builder.Build();

            app.MapControllers();

            app.Run();
        }
    }
}
