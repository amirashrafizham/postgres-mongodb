using Microsoft.EntityFrameworkCore;
using temp_api.Data;
using temp_api.Interfaces;
using temp_api.Services;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<CharacterContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("CharacterConnection")));
builder.Services.Configure<BookStoreDatabaseSettings>(builder.Configuration.GetSection("BookStoreDatabase"));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
