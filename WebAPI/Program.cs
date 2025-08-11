using Microsoft.EntityFrameworkCore;
using WebAPI.Business.Abstract;
using WebAPI.Business.Concrete;
using WebAPI.DataAccess.Abstract;
using WebAPI.DataAccess.Concrete;
using WebAPI.DataAccess.Data;
using WebAPI.Entity.Concrete;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

// Sadece Production/Development için Npgsql provider tanımlanıyor
if (!builder.Environment.IsEnvironment("Testing"))
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
}

// ➕ Dependency Injection (DI) tanımları
builder.Services.AddScoped<IGenericDal<Post>, GenericDal<Post>>();
builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

// Entegrasyon testleri için zorunlu
public partial class Program { }
