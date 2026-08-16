using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuestPDF;
using QuestPDF.Infrastructure;
using Traversal.BusinessLayer.ValidationRules.AboutValidators;
using Traversal.DataAccessLayer.Concrete;
using Traversal.EntityLayer.Entities;
using Traversal.WebUI.Extensions;
using Traversal.WebUI.Models.CustomIdentityValidator;
using Traversal.WebUI.SignalRHub;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TraversalContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddIdentity<AppUser, AppRole>()
     .AddEntityFrameworkStores<TraversalContext>()
    .AddDefaultTokenProviders()
    .AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddHttpClient("CurrencyApi", client =>
{
    client.DefaultRequestHeaders.Add("x-rapidapi-key", builder.Configuration["RapidApi:CurrencyKey"]);
    client.DefaultRequestHeaders.Add("x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com");
});

builder.Services.AddHttpClient("GoldApi", client =>
{
    client.DefaultRequestHeaders.Add("x-rapidapi-key", builder.Configuration["RapidApi:GoldKey"]);
    client.DefaultRequestHeaders.Add("x-rapidapi-host", "harem-altin-anlik-altin-fiyatlari-live-rates-gold.p.rapidapi.com");
});

builder.Services.AddHttpClient("WeatherApi", client =>
{
    client.DefaultRequestHeaders.Add("x-rapidapi-key", builder.Configuration["RapidApi:WeatherKey"]);
    client.DefaultRequestHeaders.Add("x-rapidapi-host", "open-weather13.p.rapidapi.com");
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));


builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddServiceRegistration();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Error/403";

    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        context.Response.Redirect("/Error/401");
        return Task.CompletedTask;
    };
});
Settings.License = LicenseType.Community;
builder.Services.AddSignalR();
builder.Services.AddControllersWithViews();

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
app.UseAuthentication();
app.UseAuthorization();

app.UseStatusCodePagesWithRedirects("/Error/{0}");
app.MapHub<TraversalHub>("/traversalhub");

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//      name: "areas",
//      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//    );
//});


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
