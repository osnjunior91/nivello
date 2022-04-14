using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Nivello.Domain.Commands.Product.Commands;
using Nivello.Infrastructure.Data.Context;
using Nivello.Infrastructure.Data.Repository.Auctions;
using Nivello.Infrastructure.Data.Repository.Customers;
using Nivello.Infrastructure.Data.Repository.Products;
using System.Reflection;

namespace Nivello.Api
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
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetValue<string>("ConnectionString")));
            services.AddControllers();
            services.AddMediatR(typeof(CreateProductCommand).GetTypeInfo().Assembly);
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerRepository, ICustomerRepository>();
            services.AddScoped<IAuctionsBidRepository, AuctionsBidRepository>();
            services.AddCors(co => co.AddPolicy("Policy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nivello.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nivello.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors("Policy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
