using Microsoft.EntityFrameworkCore;
using PieShop.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<PieShopDbContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:PieShopDbContextConnection"]);
});

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseSession();

//app.MapDefaultControllerRoute();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

DbInitializer.Seed(app);

app.Run();
