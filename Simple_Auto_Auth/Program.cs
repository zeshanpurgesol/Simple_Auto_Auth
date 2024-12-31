using ApplicationLayer.IRepo;
using ApplicationLayer.Services;
using DomainLayer.Entities;
using InfrastructureLayer.Data;
using InfrastructureLayer.Repo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDataContext>(options=>options
.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStr")));
//builder.Services.AddTransient<Student>(new Student());
builder.Services.AddScoped(typeof(IRepo<>), typeof(Repo<>));
builder.Services.AddScoped<IStudentServices, StudentServices>();
//builder.Services.AddSingleton<IRepo<Student>,Repo<Student>>();

builder.Services.AddAuthentication()
    .AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddIdentityCore<IdentityUser>()
    .AddEntityFrameworkStores<AppDataContext>()
    .AddApiEndpoints();
//builder.Services
//    .AddIdentityApiEndpoints<IdentityUser>()
//    .AddEntityFrameworkStores<AppDataContext>();
builder.Services.AddAuthorization();



var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapIdentityApi<IdentityUser>();
app.Run();
