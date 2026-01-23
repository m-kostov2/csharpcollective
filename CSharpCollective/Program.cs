

using DataBase.DataContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.ConfigMap;
using AutoMapper;


namespace CSharpCollective
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //TODO: НАПРАВИ ПЪРВА ВРЪЗКА ЗА ЛОГИН И РЕГИСТРАЦИЯ със контролер и вюта и го накарай да работи

           
            builder.Services.AddDbContext<CollectiveContext>();
           


            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddTransient<LoginService>();
            builder.Services.AddScoped<RegisterService>();
            builder.Services.AddScoped<CommentService>();
            builder.Services.AddScoped<PostService>();



            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();
            

            var app = builder.Build();

            var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<CollectiveContext>();
            db.Database.EnsureCreated();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.MapControllerRoute(
               name: "Login",
               pattern: "{controller=Login}/{action=Login}/{id?}");

            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }
    }
}
