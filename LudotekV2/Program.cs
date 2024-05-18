using Ludotek.Repositories.Context;
using Ludotek.Repositories.Interfaces;
using Ludotek.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Register application services and repositories
builder.Services.RegisterServices();
builder.Services.RegisterRepositories();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddDbContext<LudotekContext>(options =>
  options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultDatabase")));

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using var scope = app.Services.CreateScope();
using var dbContext = scope.ServiceProvider.GetRequiredService<LudotekContext>();
dbContext.Database.Migrate();

var ludotekRepository = scope.ServiceProvider.GetRequiredService<ILudothequeRepository>();
var importService = scope.ServiceProvider.GetRequiredService<IImportService>();

if (ludotekRepository.HasItems())
{
    importService.ImportDatabase("delta.csv");
}
else
{
    importService.ImportDatabase("full.csv");
}

app.Run();
