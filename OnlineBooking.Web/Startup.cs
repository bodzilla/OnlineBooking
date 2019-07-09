using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OnlineBooking.Web.Interfaces;
using OnlineBooking.Web.Models;
using OnlineBooking.Web.Repositories;
using OnlineBooking.Web.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace OnlineBooking.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(x => x.LowercaseUrls = true);
            services.Configure<DbContextSettings>(Configuration.GetSection(nameof(DbContextSettings)));
            services.AddTransient<IDbContextSettings>(x => x.GetRequiredService<IOptions<DbContextSettings>>().Value);
            services.AddTransient<DbContext>();
            services.AddTransient<IStylistRepository, StylistRepository>();
            services.AddTransient<IStylistService, StylistService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(x => { x.SwaggerDoc("v1", new Info { Title = "Online Booking", Version = "v1" }); });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(x => { x.SwaggerEndpoint("/swagger/v1/swagger.json", "Online Booking v1"); });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
