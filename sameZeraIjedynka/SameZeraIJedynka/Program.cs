using SameZeraIjedynka.Database.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace SameZeraIJedynka
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();//.AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddDbContext<DatabaseContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseContextConnectionString")));

          //  builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

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
        }
    }
}