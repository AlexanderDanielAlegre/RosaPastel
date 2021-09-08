using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using PracticeV2.Bussines.Interfaces;
using PracticeV2.Infraestructure.Data;
using PracticeV2.Infraestructure.Repositories;
using Server.Handlers;
using Server.Interfaces;
using Server.Requirements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAuthentication("OAuth")
                .AddJwtBearer("OAuth", config => {
                    var secretBytes = Encoding.UTF8.GetBytes(Constants.Secret);
                    var key = new SymmetricSecurityKey(secretBytes);

                    config.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = Constants.Issuer,
                        ValidAudience = Constants.Audience,
                        IssuerSigningKey = key
                    };
                });

            services.AddAuthorization(options => {
                options.AddPolicy("RoleAdmin", policy =>
                 policy.Requirements.Add(new RoleRequirment("Administrator")));
            });

            // Cors
            services.AddCors(options =>
                      options.AddPolicy("AllowWebapp", builder =>
                      {
                          // Allow multiple methods  
                          builder.WithMethods("GET", "POST", "PATCH", "DELETE", "OPTIONS").AllowAnyHeader()
                            //.WithHeaders(
                            //  HeaderNames.Accept,
                            //  HeaderNames.ContentType,
                            //  HeaderNames.Authorization)
                            //.AllowCredentials()
                            .SetIsOriginAllowed(origin =>
                            {
                                if (string.IsNullOrWhiteSpace(origin)) return false;
                                if (origin.ToLower().StartsWith(this.Configuration["CorsUrl"])) return true;
                                return false;
                            });
                      })
                    );

            services.AddDbContext<PracticeContext>(prop => prop.UseSqlServer(Configuration.GetConnectionString("Practice")));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDecodecs, Decodecs>();
            services.AddScoped<IAuthorizationHandler, RoleHandler>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowWebapp");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

          

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    app.UseSwagger();
            //    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PracticeV2 v1"));
            //}

            app.UseHttpsRedirection();

         

            app.UseRouting();

           // app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
    
}
