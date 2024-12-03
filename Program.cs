using Demo19305.AppDataContext;
using Demo19305.Models;
using Demo19305.Services;

// synchronize: đồng bộ/tuần tự
// asynchronous: bất đồng bộ



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(); // thêm dịch vụ để sử dụng controller


// kết nối database
builder.Services.Configure<DbSettings>
    (builder.Configuration.GetSection("DbSettings"));
builder.Services.AddSingleton<AppDataContext>(); // tạo một instance duy nhất của AppDataContext

// tạo một instance mới mỗi khi được yêu cầu
builder.Services
    .AddScoped<IAccountServices, AccountServices>(); 
builder.Services
    .AddScoped<ICharacterServices, CharacterServices>();

var app = builder.Build();

// thêm dòng này
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider;
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//add cors: cross-origin resource sharing
app.UseCors(builder => builder
    .AllowAnyOrigin() // accept all origin
    .AllowAnyMethod() // accept all method
    .AllowAnyHeader()); // accept all header





app.UseHttpsRedirection();
app.MapControllers(); // map các controller vào ứng dụng

app.Run();


// tạo project: dotnet new webapi -n Demo19302
// run: dotnet run
// stop: Ctrl + C

// url: http://localhost:5164/swagger/index.html
// http: giao thức truy cập web
// localhost: domain name (tên miền) chỉ trỏ đến máy tính của mình
// 5164: port (cổng) để truy cập vào ứng dụng web
// 80: port mặc định của http


// MVC: Model - View - Controller
// Model: dùng để chứa dữ liệu/database
// Controller: xử lý logic, điều hướng dữ liệu (json, html)
// View: hiển thị dữ liệu (trang quản trị)
// Service: thao tác database (thêm, sửa, xóa, lấy dữ liệu)



// Database first: tạo database trước, sau đó tạo model class
// Code first: tạo model class trước, sau đó tạo database


// web http status code
// 2xx: thành công
// 4xx: lỗi do client/người dùng
// 400: Bad Request
// 401: Unauthorized (chưa xác thực)
// 403: Forbidden (bị cấm)
// 404: Not Found (không tìm thấy)
// 5xx: lỗi do server




// các package cần thiết cho project
// dotnet add package Microsoft.EntityFrameworkCore --version 8.0.0 
// dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.0
// dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.0
// dotnet add package AutoMapper --version 13.0.1



