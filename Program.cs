using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ccs.Data;
using ccs.Models;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CCSContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CCsContext") ?? throw new InvalidOperationException("Connection string 'CCsContext' not found.")));
builder.Services
    .AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<CCSContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
