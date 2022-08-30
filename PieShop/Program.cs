using Microsoft.EntityFrameworkCore;
using PieShop.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();

builder.Services.AddDbContext<PieShopDbContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:PieShopDbContextConnection"]);
});
var app = builder.Build();

if(app.Environment.IsDevelopment())//se l app e in uso effettivamente allora:
{

app.UseDeveloperExceptionPage(); //mi fa vedere gli errori che riscontro nelle pagine
}

app.UseStaticFiles();

app.MapDefaultControllerRoute();//  questo metodo controlla tutte le nostre rotte delle view, cioe per assicurare ch epossiamo vedere le pagine
/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");*/
DbInitializer.Seed(app);
app.Run();
