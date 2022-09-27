using DotSheepFight.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// connection sql server
//builder.Services.AddDbContext<DotSheepFightContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")
//    ?? throw new InvalidOperationException("Connection string 'DotSheepFightContext' not found.")));

// connection postgres sql
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<DotSheepFightContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgressql")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.Run();
