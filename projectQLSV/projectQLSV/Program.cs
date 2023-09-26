using Design.Entity;
using Infrastructure.DataEx;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using projectQLSV;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    // Thay "UseYourDatabaseProvider()" bằng phương thức sử dụng database provider của bạn (ví dụ: UseSqlServer, UseMySQL, ...)
    options.UseSqlServer("Server=localhost;Integrated Security=true;Initial Catalog=QLSINHVIENSS;MultipleActiveResultSets=True;encrypt=true;trustservercertificate=true");
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(SinhVienServices<>));
builder.Services.AddScoped(typeof(MonHocServices<>));
builder.Services.AddScoped(typeof(LopServices<>));
builder.Services.AddScoped(typeof(KhoaMonServices<>));
builder.Services.AddScoped(typeof(KhoaServices<>));
builder.Services.AddScoped(typeof(KetQuaServices<>));




var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

