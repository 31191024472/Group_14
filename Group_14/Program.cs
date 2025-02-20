using Group_14.BusinessLayer.Interfaces;
using Group_14.ServiceLayer.Interfaces;
using Group_14.BusinessLayer.Services;
using Group_14.ServiceLayer.Services;
using Group_14.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Thêm Authentication & Authorization (FIX LỖI)
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Đăng ký DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Đăng ký BusinessLayer
builder.Services.AddScoped<IMovieService, MovieService>();

// Đăng ký ServiceLayer
builder.Services.AddScoped<IMovieServiceFacade, MovieServiceFacade>();

var app = builder.Build();

// Cấu hình Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// FIX LỖI: Cần gọi Authentication trước Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
