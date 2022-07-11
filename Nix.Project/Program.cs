using Business.Layer.Interfaces;
using Business.Layer.Mapping;
using Business.Layer.Services;
using Data.Access.Layer.EF;
using Data.Access.Layer.Entities;
using Data.Access.Layer.Interfaces;
using Data.Access.Layer.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nix.Site.Mapping;

var builder = WebApplication.CreateBuilder(args);
;


// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options => options.EnableSensitiveDataLogging().UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Data.Access.Layer")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders()
    .AddDefaultUI(); 

builder.Services.AddControllersWithViews();


builder.Services.AddRazorPages();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IGenericRepository<ApplicationUser>, GenericRepository<ApplicationUser>>();
builder.Services.AddTransient<IGenericRepository<Painting>, GenericRepository<Painting>>();

builder.Services.AddAutoMapper(typeof(PLAutoMapperProfile).Assembly, typeof(BLAutoMapperProfile).Assembly);
builder.Services.AddTransient<IPaintingService, PaintingService>();

//builder.Services.AddTransient<IGenericRepository<Order>, GenericRepository<Order>>();
//builder.Services.AddTransient<IGenericRepository<OrderItem>, GenericRepository<OrderItem>>();
//builder.Services.AddTransient<IGenericRepository<ShoppingCartItem>, GenericRepository<ShoppingCartItem>>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
