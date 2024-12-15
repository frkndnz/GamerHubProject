using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyWebApplication.Mapping.AutoMapperProfile;
using BusinessLayer.Mapping.AutoMapperProfiles;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLogging(configure =>
{
    configure.AddConsole(); // Console logger
    configure.AddDebug();  // Debug logger
    
});


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

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

builder.Services.AddScoped(typeof(IGameService),typeof(GameService));
builder.Services.AddScoped(typeof(IGameRepo),typeof(GameRepository));

builder.Services.AddScoped(typeof(IGenreService), typeof(GenreService));
builder.Services.AddScoped(typeof(IGenreRepo), typeof(GenreRepository));

builder.Services.AddScoped(typeof(IFileService), typeof(FileService));


builder.Services.AddAutoMapper(typeof(MapProfile).Assembly, typeof(BusinessMapProfile).Assembly);

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
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
