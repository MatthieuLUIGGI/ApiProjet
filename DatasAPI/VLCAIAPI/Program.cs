var builder = WebApplication.CreateBuilder(args);

// Ajouter les services nécessaires
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin() // Autorise toutes les origines
               .AllowAnyMethod() // Autorise toutes les méthodes (GET, POST, etc.)
               .AllowAnyHeader(); // Autorise tous les en-têtes
    });
});

var app = builder.Build();

app.UseHttpsRedirection();

// Appliquer le middleware CORS avant les contrôleurs
app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
