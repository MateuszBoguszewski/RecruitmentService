using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Recruitment.Announcement.Service.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Recruitment.Announcement.Service.Domain;
using Recruitment.Announcement.Service.Infrastructure.Domain;
using MediatR;
using RecruitmentService.Common;
using Recruitment.Announcement.Service.Application.Commands.AddAnnouncement;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.Swagger;
using Microsoft.OpenApi.Models;

namespace Recruitment.Announcement.Service
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
            services.AddControllers();

            services.AddDbContext<AnnouncementDbContext>(
                options => options.UseSqlServer(this.Configuration.GetConnectionString("DbConnection")));

            services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();

            services.AddMediatR(typeof(AddAnnouncementCommandHandler));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Recruitment Api", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            scope.ServiceProvider.GetService<AnnouncementDbContext>().Database.EnsureCreated();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Recruitment API V1");
            });


        }
    }
}
