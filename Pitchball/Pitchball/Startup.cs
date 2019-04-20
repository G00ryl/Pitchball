using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couchbase.Extensions.Caching;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.Extensions.Session;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pitchball.Infrastructure.Commands.Account;
using Pitchball.Infrastructure.Commands.Captain;
using Pitchball.Infrastructure.Commands.Team;
using Pitchball.Infrastructure.Data;
using Pitchball.Infrastructure.Extensions;
using Pitchball.Infrastructure.Extensions.Interfaces;
using Pitchball.Infrastructure.Services;
using Pitchball.Infrastructure.Services.Interfaces;
using Pitchball.Validators.Account;
using Pitchball.Validators.Captain;
using Pitchball.Validators.Team;

namespace Pitchball
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
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddFluentValidation(fv =>
                {
                    fv.ImplicitlyValidateChildProperties = true;
                });

            #region Couchbase
            services.AddCouchbase(opt =>
            {
                opt.Servers = new List<Uri> { new Uri("http://localhost:8091") };
                opt.UseSsl = false;
                opt.Username = "PitchballSession";
                opt.Password = "Pitchball1234!";
                opt.Buckets = new List<Couchbase.Configuration.Client.BucketDefinition> { new Couchbase.Configuration.Client.BucketDefinition() { Name = "PitchballSession" } };
            });

            services.AddDistributedCouchbaseCache("PitchballSession", opt => { });

            services.AddCouchbaseSession(opt =>
            {
                opt.Cookie.Name = ".Pitchball";
                opt.Cookie.MaxAge = new TimeSpan(5, 0, 0, 0);
                opt.IdleTimeout = new TimeSpan(6, 0, 0);
            });
            #endregion

            #region DatabaseSettings
            services.AddDbContext<PitchContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString("PitchballDatabase"),
                    c => c.MigrationsAssembly("Pitchball")).EnableSensitiveDataLogging(false));
            #endregion

            #region Services
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<ICaptainService, CaptainService>();
            services.AddScoped<AccountImageService>();

            services.AddScoped<Func<string, IImageService>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case "account":
                        return serviceProvider.GetService<AccountImageService>();

                    default:
                        return null;
                }
            });
            #endregion

            #region Extensions
            services.AddScoped<IPasswordManager, PasswordManager>();
            #endregion

            #region Validators
            services.AddTransient<IValidator<CreateAccount>, CreateAccountValidator>();
            services.AddTransient<IValidator<CreateCaptainWithTeam>, CreateCaptainWithTeamValidator>();
            services.AddTransient<IValidator<CreateTeam>, CreateTeamValidator>();
            services.AddTransient<IValidator<LoginAccount>, LoginAccountValidator>();
            services.AddTransient<IValidator<UpdateAccount>, UpdateAccountValidator>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
