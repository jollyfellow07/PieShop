using PieShop.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
builder.Services.AddScoped<IPieRepository, MockPieRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

if(app.Environment.IsDevelopment())//se l app e in uso effettivamente allora:
{

app.UseDeveloperExceptionPage(); //mi fa vedere gli errori che riscontro nelle pagine
}

app.MapDefaultControllerRoute();//  questo metodo controlla tutte le nostre rotte delle view, cioe per assicurare ch epossiamo vedere le pagine

app.Run();
