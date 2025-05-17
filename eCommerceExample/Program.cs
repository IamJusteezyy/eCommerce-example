using Microsoft.AspNetCore.Mvc.Razor;
using eCommerceExample;
using Microsoft.EntityFrameworkCore;
using eCommerceExample.EF.DBContext;
using eCommerceExample.Library.Repositories;
using eCommerceExample.Repository.Interfaces;
using eCommerceExample.Library;
using eCommerceExample.Repository.IUnitOfWork;
using eCommerceExample.Library.UnitOfWork;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

//Connection Strings
string nookBookConnectionString = builder.Configuration.GetConnectionString("NookBookConnectionString") ?? 
    throw new InvalidOperationException("Connection string 'NookBook'" +
    " not found.");
string azureBlobStorageConnectionString = builder.Configuration.GetConnectionString("AzureBlobStorage") ??
    throw new InvalidOperationException("Connection string 'NookBook'" +
    " not found.");

//DbContexts
builder.Services.AddDbContext<NookBookContext>(options =>
    options.UseSqlServer(nookBookConnectionString));

//Repositories
builder.Services.AddTransient<IBookPriceRepository, BookPriceRepository>();
builder.Services.AddTransient<ICoverTypeRepository, CoverTypeRepository>();
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.Configure<RazorViewEngineOptions>(options => options.ViewLocationExpanders.Add(new CustomViewLocationExpander()));

builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(azureBlobStorageConnectionString);
});

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
    pattern: "{controller=Home}/{action=Home}/{id?}");

app.Run();
