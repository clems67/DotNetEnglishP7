using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dot.Net.WebApi.Controllers;
using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;
using Humanizer.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using WebApi;
using WebApi.Domain;
using WebApi.Domain.Interfaces;
using WebApi.Repositories;
using WebApi.Repositories.Interfaces;

namespace Dot.Net.WebApi
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

            services.AddDbContext<LocalDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddLogging(builder =>
            {
                var logger = new LoggerConfiguration()
                            .MinimumLevel.Debug()
                            .WriteTo.Debug()
                            .CreateLogger();

                builder.AddSerilog(logger);
            });

            services.AddControllers(options =>
            {
                options.Filters.Add<CustomExceptionFilter>();
            });

            services.AddControllers();
            services.AddSingleton<IBidRepository, BidRepository>();
            services.AddSingleton<ICurvePointRepository, CurvePointRepository>();
            services.AddSingleton<IRatingRepository, RatingRepository>();
            services.AddSingleton<IRuleRepository, RuleRepository>();
            services.AddSingleton<ITradeRepository, TradeRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();

            services.AddSingleton<IBidService, BidService>();
            services.AddSingleton<ICurvePointService, CurvePointService>();
            services.AddSingleton<IRatingService, RatingService>();
            services.AddSingleton<IRuleService, RuleService>();
            services.AddSingleton<ITradeService, TradeService>();
            services.AddSingleton<IUserService, UserService>();

            //services.AddSingleton<IConfiguration>(Configuration);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Debug()
                .CreateLogger();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Audience"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
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

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
