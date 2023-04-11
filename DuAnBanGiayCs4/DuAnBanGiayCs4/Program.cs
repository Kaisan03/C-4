
using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;
using DuAnBanGiayCs4.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.ConstrainedExecution;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddTransient<IAnhServices, AnhServices>();
builder.Services.AddTransient<IChiTietSanPhamServices, ChiTietSanPhamServices>();
builder.Services.AddTransient<IChucVuServices, ChucVuServices>();
builder.Services.AddTransient<IGioHangChiTietServices, GioHangChiTietServices>();
builder.Services.AddTransient<IGioHangServices, GioHangServices>();
builder.Services.AddTransient<IHoaDonChiTietServices, HoaDonChiTietServices>();
builder.Services.AddTransient<IHoaDonServices, HoaDonServices>();
builder.Services.AddTransient<ILoaiServices, LoaiServices>();
builder.Services.AddTransient<IMauSacServices, MauSacServices>();
builder.Services.AddTransient<INsxServices, NsxServices>();
builder.Services.AddTransient<ISanPhamServices, SanPhamServices>();
builder.Services.AddTransient<ISizeServices, SizeServices>();
builder.Services.AddTransient<IThanhToanServices, ThanhToanServices>();
builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddMvc();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(50);
});
builder.Services.AddHttpContextAccessor();
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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
