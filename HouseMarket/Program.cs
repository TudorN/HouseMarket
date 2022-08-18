using HouseMarket.OfferService.DataModel.InputData.GeneratedClasses;
using HouseMarket.OfferService.Services;
using HouseMarket.OfferService.Services.Generic;
using HouseMarket.OfferService.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IHouseMarketOfferService, HouseMarketOfferService>();
builder.Services.AddScoped<ITopBrokerService, TopBrokerService>();
builder.Services.AddScoped<IGenericApiCall<HouseMarketOffer>, GenericApiCall<HouseMarketOffer>>();
builder.Services.AddScoped<IHouseMarketDataSampleService, HouseMarketDataSampleService>();
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HouseMarketOffer}/{action=Index}/{id?}");

app.Run();
