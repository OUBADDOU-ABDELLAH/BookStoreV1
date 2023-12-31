using BookStoreV1.Models;
using BookStoreV1.Models.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMvc();

builder.Services.AddSingleton<IBookStoreRepository<Author>,AuthorRepository>();

builder.Services.AddSingleton<IBookStoreRepository<Book>, BookRepository>();

builder.Services.AddDbContext<BookStoreDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DbCon")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Author}/{action=Index}/{id?}");

app.Run();
