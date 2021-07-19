using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MongoRepositoryPattern.Context;
using MongoRepositoryPattern.Models;
using MongoRepositoryPattern.Repositories.Domain;
using MongoRepositoryPattern.Repositories.Domain.Interfaces;
using MongoRepositoryPattern.Services.Departements;
using MongoRepositoryPattern.Services.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoRepositoryPattern
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
            services.Configure<Settings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("Mongodb:ConnectionString").Value;
                options.Database = Configuration.GetSection("Mongodb:Database").Value;
            });


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MongoRepositoryPattern", Version = "v1" });
            });

            #region contexts_registration
            services.AddTransient<IMongoContext, MongoContext>();
            #endregion

            #region repositories_registration
            services.AddTransient<IEmployeeRepositoryAsync, EmployeeRepositoryAsync>();
            services.AddTransient<IDepartementRepositoryAsync, DepartementRepositoryAsync>();
            #endregion

            #region service_registration
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IDepartementService, DepartementServices>();
            #endregion`
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MongoRepositoryPattern v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
