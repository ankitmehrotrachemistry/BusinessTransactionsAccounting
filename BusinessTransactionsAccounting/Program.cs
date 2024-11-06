/* BUSINESS tranasctions and accounting Dot Net Core Project MVC - ChatGPT */

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BusinessTransactionsAccounting.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();  // Adds MVC services to the app
builder.Services.AddSingleton<AccountingService>();  // Register the AccountingService for dependency injection

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  // Show detailed error pages in development
}
else
{
    app.UseExceptionHandler("/Home/Error");  // Use the Error page in production
    app.UseHsts();  // Enforce strict transport security for production
}

app.UseHttpsRedirection();  // Redirect HTTP requests to HTTPS
app.UseStaticFiles();  // Enable serving static files (e.g., CSS, JavaScript)

// Enable routing
app.UseRouting();

// Define the default route for MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}");  // Sets Account/Index as the default route

app.Run();


/*
Page : https://localhost:7102/
Account Page: https://localhost:7102/Account/Index
Transaction Page: https://localhost:7102/Transaction/Index
Details : https://localhost:7102/Account/Details/1
*/