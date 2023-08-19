using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WepApp.Data;

namespace WepApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var constr = builder.Configuration.GetConnectionString("Con1");

            builder.Services.AddDbContext<OkulContext>(
               options => options.UseSqlServer(constr));

            builder.Services
                .AddIdentity<AppUser, AppRole>(
                options =>
                {
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = true;
                    options.Password.RequiredLength = 3;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                }).AddEntityFrameworkStores<OkulContext>();

            builder.Services.AddControllersWithViews();

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
        }
    }
}