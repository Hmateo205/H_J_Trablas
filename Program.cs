using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using H_J_Trablas.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<H_J_TrablasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("H_J_TrablasContext") ?? throw new InvalidOperationException("Connection string 'H_J_TrablasContext' not found.")));

// Add services to the container.
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
