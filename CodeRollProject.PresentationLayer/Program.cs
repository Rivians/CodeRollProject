using CodeRollProject.BusinessLayer.Abstract;
using CodeRollProject.BusinessLayer.Concrete;
using CodeRollProject.DataAccessLayer.Abstract;
using CodeRollProject.DataAccessLayer.Concrete;
using CodeRollProject.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddMvc().AddSessionStateTempDataProvider().AddJsonOptions(option =>				BU SERVÝS TEMPDATA SERÝLÝZE ETME SORUNU ÝÇÝN DENENDÝ, OLMADI.
//{
//	option.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
//});

//builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

builder.Services.AddScoped<Context>();
builder.Services.AddScoped<IEventDal,EfEventRepository>();
builder.Services.AddScoped<IUserDal,EfUserRepository>();
builder.Services.AddScoped<IVoteDal,EfVoteRepository>();
builder.Services.AddScoped<IVoteOptionDal,EfVoteOptionRepository>();
builder.Services.AddScoped<IEventService, EventManager>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IVoteService, VoteManager>();
builder.Services.AddScoped<IVoteOptionService, VoteOptionManager>();
builder.Services.AddSession();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
	options.Cookie.Name = "NetCoreMvc.Auth";
	options.LoginPath = "/Login/Index";
	options.AccessDeniedPath = "/Login/Index";
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

app.UseSession();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
