using Abc.Soft.Movies.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Abc.Soft.Movies.Data;
using Abc.Infra;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<AbcSoftMoviesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AbcSoftMoviesContext") ?? throw new InvalidOperationException("Connection string 'AbcSoftMoviesContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<IMoviesRepo, MoviesRepo>();
builder.Services.AddScoped<ICountriesRepo, CountriesRepo>();
builder.Services.AddScoped<ICurrenciesRepo, CurrenciesRepo>();
builder.Services.AddScoped<IMoniesRepo, MoniesRepo>();
builder.Services.AddScoped<ICountryCurrenciesRepo, CountryCurrenciesRepo>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();