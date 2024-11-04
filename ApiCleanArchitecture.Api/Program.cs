using ApiCleanArchitecture.Api.Module.Swagger;
using ApiCleanArchitecture.Api.Module.Versioning;
using ApiCleanArchitecture.Application.UseCases;
using ApiCleanArchitecture.Domain.IRepository;
using ApiCleanArchitecture.Infrastructure.Persistence.EntiryFramework;
using ApiCleanArchitecture.Infrastructure.Persistence.EntiryFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwagger();
builder.Services.AddVersioning();

#region Config Context - EntityFramework
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionSqlServer"));
});
#endregion

#region config IOC
//ApiCleanArchitecture.Application
builder.Services.AddTransient<PessoaFisicaUseCase>();

//ApiCleanArchitecture.Domain.IRepositories e ApiCleanArchitecture.Domain.Infrastructure.Repositories
builder.Services.AddTransient<IPessoaFisicaRepository, PessoaFisicaRepository>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        //Workaround to use the Swagger UI "Try Out" functionality when deployed behind a reverse proxy (APIM) with API prefix /sub context configured
        options.PreSerializeFilters.Add((swagger, httpReq) =>
        {
            if (httpReq.Headers.ContainsKey("X-Forwarded-Host"))
            {
                //The httpReq.PathBase and httpReq.Headers["X-Forwarded-Prefix"] is what we need to get the base path.
                //For some reason, they returning as null/blank. Perhaps this has something to do with how the proxy is configured which we don't have control.
                //For the time being, the base path is manually set here that corresponds to the APIM API Url Prefix.
                //In this case we set it to 'sample-app'.

                var basePath = "apitasytest";
                var serverUrl = $"https://{httpReq.Headers["X-Forwarded-Host"]}/{basePath}";
                swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = serverUrl } };
            }
        });
    });
    app.UseSwaggerUI(
    options =>
    {
        var descriptions = app.DescribeApiVersions();
        foreach (var description in descriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
