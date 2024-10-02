using View.IServices;
using View.Servicecs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using View.Data;
using API.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ViewContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'ViewContext' not found.")));

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IProductServices, ProductServices>();
builder.Services.AddHttpClient<ISoleServices, SoleServices>();
builder.Services.AddHttpClient<IBrandServices, BrandServices>();
builder.Services.AddHttpClient<ICategoryServices, CategoryServices>();
builder.Services.AddHttpClient<IMaterialServices, MaterialServices>();
builder.Services.AddHttpClient<IPromotionServices, PromotionServices>();
builder.Services.AddHttpClient<IVoucherServices, VoucherServices>();
builder.Services.AddHttpClient<ISizeServices, SizeServices>();
builder.Services.AddHttpClient<IColorServices, ColorServices>();
builder.Services.AddHttpClient<IImageServices, ImageServices>();
builder.Services.AddHttpClient<ISelectedImageServices, SelectedImageServices>();
builder.Services.AddHttpClient<IAccountService, AccountService>();
builder.Services.AddHttpClient<IShippingUnitServices, ShippingUnitServices>();
//
builder.Services.AddHttpClient<IProductDetailService, ProductDetailService>();


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
app.UseSession();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}");

app.Run();
