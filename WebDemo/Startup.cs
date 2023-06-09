using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.EF;
using Infrastructure.Generic;
using Infrastructure.Repository;
using Infrastructure.Service;
using WebDemo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebDemo
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
            services.AddControllersWithViews();

            services.AddDbContext<EXDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("EXDbContextConnection"), b => b.MigrationsAssembly("WebDemo")));

            services.AddSingleton(new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Mapping());
            }).CreateMapper());


            

            #region Services
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUserService, UserService>();


            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IStudentRepository, StudentRepository>();

            services.AddScoped<IStudentService, StudentService>();

            services.AddScoped<ITeacherRepository, TeacherRepository>();

            services.AddScoped<ITeacherService, TeacherService>();

            services.AddScoped<ICourseRepository, CourseRepository>();

            services.AddScoped<ICourseService, CourseService>();
            #endregion
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

          

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
