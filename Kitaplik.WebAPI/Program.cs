using Autofac;
using Autofac.Extensions.DependencyInjection;
using Kitaplik.Business.DependencyResolvers.AutoFac;
using Kitaplik.Business.DependencyResolvers.Extension;
using Kitaplik.DataAccess.Concrete.EntityFrameworkCore.Context;
using Kitaplik.Entities.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
