using System.Reflection;
using Microsoft.OpenApi.Models;
using SwaggerLearn.Services;

namespace SwaggerLearn.Extensions;

public static class ConfigureServicesExtension
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddSingleton<StoreService>();
        services.AddControllers();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "Medicine provision",
                Version = "v1",
                Description =
                    "The API provides access to creating, deleting, retrieving and changing a list of medicines",
                Contact = new OpenApiContact()
                {
                    Name = "Shmygol Maksim",
                    Email = "sh.maksim343@gmail.com"
                }
            });

            string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });
    }
}