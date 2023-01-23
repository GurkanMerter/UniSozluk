using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniSozluk
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>(x =>
            {
                x.Password.RequireUppercase = false;
                x.Password.RequireNonAlphanumeric = false;

            }).AddEntityFrameworkStores<Context>();
            services.AddSession();
            services.AddControllersWithViews();
            services.AddMvc(Config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                Config.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddMvc();
           
            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme
                ).AddCookie(x => {
                    x.LoginPath = "/Login/Index";
                });
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/Index/";
                options.Cookie = new CookieBuilder
                {
                    Name = "UniSozlukUserCookie",
                    HttpOnly = false,
                    SecurePolicy = CookieSecurePolicy.Always
                };
                //cookie setting
                
                options.ExpireTimeSpan = TimeSpan.FromMinutes(100);
               
                options.SlidingExpiration = true;
                options.AccessDeniedPath = new PathString("/Login/AccessDenied/");
            });
            services.AddAuthorization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();
            app.UseStatusCodePagesWithReExecute("/Error/Index","?code={0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Entry}/{action=MainPage}/{id?}");
                
            });

            

        }
    }
}
