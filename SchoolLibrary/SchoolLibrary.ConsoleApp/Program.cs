using SchoolLibrary.Data.Repositories;
using SchoolLibrary.Services;
using SchoolLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IBookRepository, InMemoryBookRepository>();
builder.Services.AddSingleton(sp => new BookService(sp.GetRequiredService<IBookRepository>()));

var app = builder.Build();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Books}/{action=Index}/{id?}");


app.Run();
