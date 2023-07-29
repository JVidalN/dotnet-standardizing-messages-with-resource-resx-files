using WebApiResource.AttributeAdapterProvider;
using WebApiResource.Filters;
using WebApiResource.Resources;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllers(options => { options.Filters.Add(new ResourceErrorFilter(new MessageResourceContext(typeof(ErrorMessages)))); });

builder.Services.AddMvc(options =>
{
    options.ModelMetadataDetailsProviders.Add(new ResourceValidationAttributeAdapterProvider(new MessageResourceContext(typeof(ValidationMessages))));
});

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
