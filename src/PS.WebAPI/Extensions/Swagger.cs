using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace PS.WebAPI.Extensions
{
    public static class Swagger
    {
        public static void SwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Pet.LovePets",
                        Version = "v1",
                        Description = "Pet.LovePets API Simulator",
                        Contact = new Contact
                        {
                            Name = "Pet GitHub",
                            Url = "https://github.com/mateusggeracino/Pet"
                        }
                    });

                var caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                var caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, "PS.WebAPI.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });
        }

        public static void SwaggerApplication(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Pet LovePets");

                c.RoutePrefix = "docs";
            });
        }
    }
}