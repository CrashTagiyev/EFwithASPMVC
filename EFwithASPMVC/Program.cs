using Application.Data;
using Application.Models.Entities.Concretes;
using Application.Repositories.Abstracts;
using Application.Repositories.Concretes;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
//Models
builder.Services.AddScoped<Student>();
builder.Services.AddScoped<Group>();
//Database
builder.Services.AddDbContext<AcademyDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
//Repositories
builder.Services.AddScoped<IRepository<Group>, GroupRepository>();
builder.Services.AddScoped<IRepository<Student>, StudentRepository>();


// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Group}/{action=AllGroups}/{id?}");

app.Run();
