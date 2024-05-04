using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReactWithASP.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// メモリ内データベースを使用
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseInMemoryDatabase("AppDb"));

// Identity サービスの追加
builder.Services.AddAuthorization();

// Identity API をアクティブにする
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllers();

var app = builder.Build();

// Identity ルートをマップする
app.MapIdentityApi<IdentityUser>();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
