//var builder = WebApplication.CreateBuilder(args);

//// Ajouter les services nécessaires
//builder.Services.AddControllers();
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAllOrigins", builder =>
//    {
//        builder.AllowAnyOrigin() // Autorise toutes les origines
//               .AllowAnyMethod() // Autorise toutes les méthodes (GET, POST, etc.)
//               .AllowAnyHeader(); // Autorise tous les en-têtes
//    });
//});

//var app = builder.Build();

//app.UseHttpsRedirection();

//// Appliquer le middleware CORS avant les contrôleurs
//app.UseCors("AllowAllOrigins");

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

//var builder = WebApplication.CreateBuilder(args);

////Add services to the container.

//builder.Services.AddControllers();
////Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

////Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

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

// Ajouter les services Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurer Swagger
if (app.Environment.IsDevelopment()) // Active Swagger uniquement en développement
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Appliquer le middleware CORS avant les contrôleurs
app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();

