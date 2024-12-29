using DAL.DataContext;
using DAL.ExceptionMiddlewares;
using DAL.Mappings;
using DAL.Repo;
using DAL.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<DatabaseContext>(
//    options => options.UseSqlServer(
//        builder.Configuration.GetConnectionString("ConnectionStr")
//));
builder.Services.AddDbContext<DatabaseContext>(
    context => context.UseSqlite(
        builder.Configuration.GetConnectionString("ConnectionStr")));

builder.Services.AddTransient(typeof(IRepo<>), typeof(Repo<>));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPageService, PageService>();
builder.Services.AddScoped<IProfileService, ProfileService>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseMiddleware<SessionCheckMiddleware>();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Index}/{id?}");

app.Run();
