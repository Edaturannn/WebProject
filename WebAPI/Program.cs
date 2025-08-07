using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using WebAPI.Business.Abstract;
using WebAPI.Business.Concrete;
using WebAPI.DataAccess.Abstract;
using WebAPI.DataAccess.Concrete;
using WebAPI.DataAccess.Data;
using WebAPI.Entity.Concrete;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

// ➕ DbContext ekleniyor (bağlantı dizesine göre yapılandır)
builder.Services.AddDbContext<ApplicationDbContext>();

// ➕ Dependency Injection (DI) tanımları
builder.Services.AddScoped<IGenericDal<Post>, GenericDal<Post>>();
builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
       {
           options.Title = "ToDoList API";
           options.ShowSidebar = true;
           options.Theme = ScalarTheme.BluePlanet;
       });
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

