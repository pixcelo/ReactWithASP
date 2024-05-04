using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReactWithASP.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// CORSオリジン設定（開発用）
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
        });
});
//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(
//        policy =>
//        {
//            policy.WithOrigins("https://localhost:5173")
//                                .AllowAnyMethod()
//                                .AllowAnyHeader();
//        });
//});

// メモリ内データベースを使用
//builder.Services.AddDbContext<ApplicationDbContext>(
//    options => options.UseInMemoryDatabase("AppDb"));

// Identity サービスの追加
//builder.Services.AddAuthorization();

// Identity API をアクティブにする
//builder.Services.AddIdentityApiEndpoints<IdentityUser>()
//    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllers();

var app = builder.Build();

// Identity ルートをマップする
//app.MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();

// Configure the HTTP request pipeline.


// CORS ミドルウェアを有効にする
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
