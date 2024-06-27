using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BlessedBarbershop.API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Joselito Machado",
            Email = "opaguelosantos@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/joselitomachado/")
        }
    });

    var xmlFile = "BlessedBarbershop.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    x.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
