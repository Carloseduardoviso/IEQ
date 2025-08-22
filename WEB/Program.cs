using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WEB.Data;
using WEB.Helpers.Extensions;
using WEB.Mapper;

var builder = WebApplication.CreateBuilder(args);

var supportedCultures = new[] { new CultureInfo("pt-BR") };
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("pt-BR");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

var connectionString = builder.Configuration.GetConnectionString("DataContext") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScopeds();

builder.Services.AddAutoMapper(config =>
{
    config.AddExpressionMapping();
}, typeof(ConfigurationMapping));

builder.Services.AddHttpContextAccessor();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddMemoryCache();
builder.Services.AddControllersWithViews();

var app = builder.Build();

var cultureInfo = new CultureInfo("pt-BR");
var requestLocalizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(cultureInfo),
    SupportedCultures = new[] { cultureInfo },
    SupportedUICultures = new[] { cultureInfo }
};

app.UseRequestLocalization(requestLocalizationOptions);
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
