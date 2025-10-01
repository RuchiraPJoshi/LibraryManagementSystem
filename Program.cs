using LibraryManagementSystem.Services.Implementations;
using LibraryManagementSystem.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//Add services
builder.Services.AddSingleton<ILibraryService, LibraryService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if(app.Environment.IsDevelopment() || true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
