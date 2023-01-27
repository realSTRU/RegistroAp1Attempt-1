using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RegistroAP.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var ConStr = builder.Configuration.GetConnectionString("ConStr");

// Add services to the container.
builder.Services.AddScoped<OcupacionesBLL>();
builder.Services.AddRazorPages();
IServerSideBlazorBuilder serverSideBlazorBuilder = builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<Contexto>(options => options.UseSqlite(ConStr));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
