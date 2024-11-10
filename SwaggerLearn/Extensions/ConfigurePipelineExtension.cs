namespace SwaggerLearn.Extensions;

public static class ConfigurePipelineExtension
{
    public static void ConfigurePipeline(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Medicine provision v1");
        });
        
        app.MapControllers();
    }
}