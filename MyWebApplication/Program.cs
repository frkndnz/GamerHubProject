using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// builder.Services.AddHttpClient<IApiService, GameApiService>();

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser,AppRole>(options=>{
    options.Password.RequireDigit = true; // En az bir rakam olmalı
    options.Password.RequireLowercase = true; // En az bir küçük harf olmalı
    options.Password.RequireUppercase = false; // Büyük harf gereksiz
    options.Password.RequireNonAlphanumeric = false; // Özel karakter gereksiz
    options.Password.RequiredLength = 8; // Minimum 8 karakter uzunluğu
    options.Password.RequiredUniqueChars = 1; // En az 1 benzersiz karakter
}).AddEntityFrameworkStores<Context>();

builder.Services.AddMvc(config=>{
    var policy= new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));

});

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
