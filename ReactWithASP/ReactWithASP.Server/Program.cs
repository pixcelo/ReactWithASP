using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReactWithASP.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// CORS�I���W���ݒ�i�J���p�j
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

// ���������f�[�^�x�[�X���g�p
//builder.Services.AddDbContext<ApplicationDbContext>(
//    options => options.UseInMemoryDatabase("AppDb"));

// Identity �T�[�r�X�̒ǉ�
//builder.Services.AddAuthorization();

// Identity API ���A�N�e�B�u�ɂ���
//builder.Services.AddIdentityApiEndpoints<IdentityUser>()
//    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllers();

var app = builder.Build();

// Identity ���[�g���}�b�v����
//app.MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();

// Configure the HTTP request pipeline.


// CORS �~�h���E�F�A��L���ɂ���
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
