using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Simple_Auto_Auth.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication()
    .AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorization();
builder.Services.AddIdentityCore<IdentityUser>()
    .AddEntityFrameworkStores<AppDataContext>()
    .AddApiEndpoints();
builder.Services.AddDbContext<AppDataContext>(options=>options
.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStr")));

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
