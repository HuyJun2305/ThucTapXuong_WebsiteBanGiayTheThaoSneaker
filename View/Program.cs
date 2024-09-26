using View.IServices;
using View.Servicecs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using View.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ViewContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ViewContext") ?? throw new InvalidOperationException("Connection string 'ViewContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<ISoleServices, SoleServices>();
builder.Services.AddHttpClient<IBrandServices, BrandServices>();
builder.Services.AddHttpClient<ICategoryServices, CategoryServices>();
builder.Services.AddHttpClient<IMaterialServices, MaterialServices>();

builder.Services.AddHttpClient<ISizeServices, SizeServices>();
builder.Services.AddHttpClient<IColorServices, ColorServices>();
builder.Services.AddHttpClient<IImageServices, ImageServices>();
builder.Services.AddHttpClient<ISelectedImageServices, SelectedImageServices>();

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
