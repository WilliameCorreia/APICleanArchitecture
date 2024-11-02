using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiCleanArchitecture.Api.Module.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }
        private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Version = description.ApiVersion.ToString(),
                Title = $"Api Clean Architecture - {description.GroupName}",
                Description = "Projeto destinado a aplicação dos conceitos da arquitetura limpa e DDD",
                Contact = new OpenApiContact
                {
                    Name = "Williame",
                    Email = "williame_lima@hotmail.com",
                    Url = new Uri("https://github.com/WilliameCorreia")
                }
            };
            return info;
        }
    }
}
