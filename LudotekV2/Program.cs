using Ludotek.Services.Interfaces;
using LudotekV2.DataStore;

var builder = WebApplication.CreateBuilder(args);

// Data Store
var dataStore = new CsvDataStore();
try
{
    dataStore.Load();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

builder.Services.AddSingleton<IDataStore>(dataStore);

// Add services to the container.
builder.Services.AddControllersWithViews();

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Register application services and repositories
builder.Services.RegisterServices();
builder.Services.RegisterRepositories();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

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

app.Run();
