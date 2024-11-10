using SwaggerLearn.Extensions;

namespace SwaggerLearn;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        builder.Services.ConfigureServices();
        
        WebApplication app = builder.Build();
        app.ConfigurePipeline();
        
        app.Run();
    }
}