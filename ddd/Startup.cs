using ddd.Data;
using ddd.Infrastructure;
using ddd.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ddd.Domain.Repository;
using ddd.Data.Repository;

namespace ddd
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
            //docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Pa$$w0rd2022' -e 'MSSQL_PID=Express' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest-ubuntu
            //docker build -t dockerapi .
            var server = Configuration["DbServer"] ?? "localhost";
            var port = Configuration["DBPort"] ?? "1443";
            var user = Configuration["DBUser"] ?? "SA";
            var password = Configuration["DBPassword"] ?? "Pa$$w0rd2022"; // only for test
            var database = Configuration["Database"] ?? "Dron";


            services.AddControllers();
            services.AddMediatR(typeof(Startup));

            services.AddScoped<DomainEventDispatcher>();
            services.AddDbContext<DronContext>((serviceProvider, options) =>
            {
                options
                    .AddInterceptors(serviceProvider.GetService<DomainEventDispatcher>())
                    .UseSqlServer($"Server={server},{port};Initial Catalog={database}; User ID={user};Password={password}");
            });
            services.AddScoped<IExternalSystemServices, ExternalSystemServices>();
            services.AddScoped<IDronRepository, DronRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DronContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            db.Database.Migrate();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
