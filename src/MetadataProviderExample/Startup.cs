using Microsoft.AspNet.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MetadataProviderExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddMvcOptions(m => m.ModelMetadataDetailsProviders.Add(new DateTimeMetadataProvider()));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/",
                    defaults: new { controller = "Home", action = "Index" });

            });
        }
    }
}
