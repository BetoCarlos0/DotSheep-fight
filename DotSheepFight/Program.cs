using DotSheepFight.Hubs;
using DotSheepFight.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// connection postgres sql
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<DotSheepFightContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgressql")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

DatabaseManagementService.MigrationInitialisation(app);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<GameHub>("/gameHub");
app.Run();
