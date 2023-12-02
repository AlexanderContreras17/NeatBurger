using Microsoft.EntityFrameworkCore;
using NeatBurger.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NeatContext>(x=>
x.UseMySql("server=localhost;user=root;database=neat;password=root",
Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql")));

builder.Services.AddMvc();
var app = builder.Build();


app.UseFileServer();

app.MapControllerRoute(
    name:"areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapDefaultControllerRoute();
app.Run();
