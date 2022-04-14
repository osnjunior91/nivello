using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Nivello.Domain.Commands.Product.Commands;
using Nivello.Infrastructure.Data.Context;
using Nivello.Infrastructure.Data.Repository.Admins;
using Nivello.Infrastructure.Data.Repository.Auctions;
using Nivello.Infrastructure.Data.Repository.Customers;
using Nivello.Infrastructure.Data.Repository.Products;
using System.Reflection;
using System.Text;

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
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddCors(co => co.AddPolicy("Policy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "Nivello.Api", Version = "v1" });

                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {

                    Description = "Coloque seu token aqui Ex: 'Bearer 12345abcdef'",
                    Name = "authorization",
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,

                });

                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });

            var key = Encoding.ASCII.GetBytes(Configuration["SecretKey"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
