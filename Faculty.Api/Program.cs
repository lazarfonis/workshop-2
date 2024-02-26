using Faculty.Data;
using Faculty.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Faculty.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddIdentity<User, IdentityRole<Guid>>()
            .AddTokenProvider<DataProtectorTokenProvider<User>>(builder.Configuration["jwtIssuer"])
            .AddEntityFrameworkStores<FacultyDbContext>()
            .AddDefaultTokenProviders();

        builder.Services.AddDbContext<FacultyDbContext>(o =>
            o.UseSqlServer(builder.Configuration.GetConnectionString("FacultyDb")));

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
