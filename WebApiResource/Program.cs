using System.Resources;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using WebApiResource.Filters;
using WebApiResource.Resources;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// builder.Services.AddSingleton<IBuilderMessageResourceError>(provider => new BuilderMessageResourceError(ResourceManager)));
// builder.Services.AddSingleton<IBuilderMessageResourceValidation>(provider => new BuilderMessageResourceValidation(ResourceManager)));

// builder.Services.AddSingleton<ResourceManager>(provider => { return new ResourceManager(typeof(ErrorMessages)); });
// builder.Services.AddSingleton<ResourceManager>(provider => { return new ResourceManager(typeof(ValidationMessages)); });
// builder.Services.AddSingleton<IBuilderMessageResourceError, BuilderMessageResourceError>();
// builder.Services.AddSingleton<IBuilderMessageResourceValidation, BuilderMessageResourceValidation>();
// builder.Services.AddSingleton<IMessageResource>(provider => new MessageResource(ValidationMessages));
// builder.Services.AddSingleton<IValidationAttributeAdapterProvider, ResourceValidationAttributeAdapterProvider>();
// builder.Services.AddScoped<ResourceExceptionFilter>();

// builder.Services.AddSingleton<MessageResourceFactory>();

builder.Services.AddSingleton(provider => { return new MessageResourceContext(typeof(ErrorMessages)); });

builder.Services.AddControllers(options => { options.Filters.Add<ResourceErrorFilter>(); });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
