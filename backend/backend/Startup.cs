using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models.EarlyCompletion;
using backend.Models.Tariff;
using backend.Models.UsersData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace backend
{
    public class Startup
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options => {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });
            services.AddDbContext<UsersDataContext>(options =>
                options.UseLoggerFactory(MyLoggerFactory).UseSqlServer(Configuration.GetConnectionString("UsersData")));
            services.AddDbContext<TariffContext>(options =>
                options.UseLoggerFactory(MyLoggerFactory).UseSqlServer(Configuration.GetConnectionString("Tariff")));
            services.AddDbContext<EarlyCompletionContext>(options =>
                options.UseLoggerFactory(MyLoggerFactory).UseSqlServer(Configuration.GetConnectionString("EarlyCompletion")));
            services.Configure<FormOptions>(opt =>
            {
                opt.ValueLengthLimit = int.MaxValue;
                opt.MultipartBoundaryLengthLimit = int.MaxValue;
                opt.MemoryBufferThreshold = int.MaxValue;
            });

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(options =>
            options.WithOrigins("http://localhost:4000")
            .AllowAnyMethod()
            .AllowAnyHeader());


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
