

namespace PruebasWebNetCore.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PruebasWebNetCore.Web.Data;
    using PruebasWebNetCore.Web.Data.Entities;

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
            services.AddIdentity<User, IdentityRole>(cfg =>
             {
                 //para las opciones en la creacion de cuenta de usuario
                 cfg.User.RequireUniqueEmail = true;
                 cfg.Password.RequireDigit = false;
                 cfg.Password.RequiredUniqueChars = 0;
                 cfg.Password.RequireLowercase = false;
                 cfg.Password.RequireNonAlphanumeric = false;
                 cfg.Password.RequireUppercase = false;
                 cfg.Password.RequiredLength = 6;
             }).AddEntityFrameworkStores<DataContext>();



            services.AddDbContext<DataContext>(cfg =>
            {

                cfg.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"));

            });

            //para los datos cargados por defecto
            services.AddTransient<SeedDb>();



            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
