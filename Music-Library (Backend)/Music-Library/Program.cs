using Microsoft.EntityFrameworkCore;
using Music_Library.Data;

var builder = WebApplication.CreateBuilder(args);

string corsPolicyName = "myCorsPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName, options =>
    {
        options.WithOrigins("http://localhost:4200/").AllowAnyHeader().AllowAnyMethod();
    });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(_ => _.UseSqlServer("server=.\\SQLEXPRESS;database=MusicDb;trusted_connection=yes;"));

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

app.UseCors(corsPolicyName);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
