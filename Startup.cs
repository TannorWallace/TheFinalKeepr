using System;
using Keepr.Data;
using System.Data;
using System.Linq;
using keepr.Repositories;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Keepr
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
      //ADD USER AUTH through JWT
      services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
          options.LoginPath = "/Account/Login";
          options.Events.OnRedirectToLogin = (context) =>
                  {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                  };
        });
      services.AddCors(options =>
          {
            options.AddPolicy("CorsDevPolicy", builder =>
                  {
                    builder
                              .WithOrigins(new string[]{
                                "http://localhost:8080"
                          })
                              .AllowAnyMethod()
                              .AllowAnyHeader()
                              .AllowCredentials();
                  });
          });

      services.AddMvc();
      // TODO register all Transient informations
      services.AddTransient<IDbConnection>(x => CreateDBContext());
      services.AddTransient<UserRepository>();
      services.AddTransient<KeepRepository>();
      services.AddTransient<VaultsRepository>();
      services.AddTransient<VaultKeepsRepository>();


    }

    private IDbConnection CreateDBContext()
    {
      var _connectionString = Configuration.GetSection("DB").GetValue<string>("gearhost");
      var connection = new MySqlConnection(_connectionString);
      connection.Open();
      return connection;
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseCors("CorsDevPolicy");
      }
      else
      {
        app.UseHsts();
      }
      //NOTE I dont remember what UseHttpsRedirection is but it was in the reference so better safe than sorry (shrug)
      // app.UseHttpsRedirection();
      app.UseAuthentication();
      app.UseDefaultFiles();
      app.UseStaticFiles();
      app.UseMvc();
    }
  }
}
