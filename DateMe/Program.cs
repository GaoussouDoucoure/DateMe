using DateMe.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Setting up service to connect with the database, doing this after setting up the Context File
builder.Services.AddDbContext<DatingApplicationContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:DatingConnection"]); //here the [] means go and look for this in the configuration file
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
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")  //the "id?" here is used in Waitlist asp-route-varName
    .WithStaticAssets();


app.Run();
