using Autofac.Extensions.DependencyInjection;
using Kitaplik.Business.DependencyResolvers.Extension;
using Autofac;
using Kitaplik.Business.DependencyResolvers.AutoFac;
using Kitaplik.DataAccess.Concrete.EntityFrameworkCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Kitaplik.Entities.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//AutoFac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(b => b.RegisterModule(new BusinessModule()));

//AddDbContext
builder.Services.Register();
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<KitaplikContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = "localhost",
        ValidIssuer = "localhost",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("DMADHJWAGHDBANWDHWGA"))
    };
});

builder.Services.AddIdentity<AppUser, AppRole>()
            .AddEntityFrameworkStores<KitaplikContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Register}/{id?}");

app.Run();
