using System.Reflection;
using InternalApi.Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using MediatR;
using InternalApi.Extensions.StartUp;
using InternalApi.Infrastructure.Repository.Interface;
using InternalApi.Infrastructure.Repository;
using ExerciseTwoApi.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// (1) Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// (2) SQL and Contexts
builder.Services.AddDbContext<InternalContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("InternalStore"), b => b.MigrationsAssembly("InternalApi.Infrastructure")));
builder.Services.AddTransient<IStartupFilter, MigrationFilter<InternalContext>>();

// (3) Swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();

// (4) MediatR
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// (5) IdentityServer
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:5443";
        options.Audience = "weatherapi";

        options.TokenValidationParameters.ValidTypes =  new[] { "at+jwt" };
    });

// (6) Services and Repositories
builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<IRepositoryFactory, RepositoryFactory>();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
