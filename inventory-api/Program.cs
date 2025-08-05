
// var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddControllers();
// builder.Services.AddSingleton<InventoryApi.Services.IProductService, InventoryApi.Services.ProductService>();
// var app = builder.Build();
// app.MapControllers();
// app.Run();


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona seu serviço
builder.Services.AddSingleton<InventoryApi.Services.IProductService, InventoryApi.Services.ProductService>();

// Configura o CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4200") // frontend URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors(); // Aplica o CORS

// Habilita Swagger em dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
