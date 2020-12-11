using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MusKos.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Autofac;
using MusKos.Data.UnitOfWork;
using MusKos.Domain.DomainServices;
using MusKos.Data.Repository;
using MusKos.Domain.Repositories;
using MusKos.Domain.DomainServices.Interfaces;
using MusKos.Domain.UnitOfWork;
using Autofac.Extensions.DependencyInjection;
using MusKos.Domain.Models.Identity;
using MusKosCore.PresentationServices;
using MusKosCore.PresentationServices.Interfaces;
using Microsoft.Extensions.Logging;
using System.IO;
using MusKos.Presentation.Util.Logger;
using Microsoft.Extensions.Logging.Debug;
using MusKos.Presentation.Util.Hubs;
using MusKos.Presentation.PresentationServices;
using MusKos.Presentation.PresentationServices.Interfaces;

namespace MusKosCore
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
           
            services.AddDbContext<MusDbContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
           services.AddControllersWithViews();
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddDefaultTokenProviders()
                 .AddEntityFrameworkStores<MusDbContext>();
            services.AddHttpContextAccessor();
            services.AddMvc();
            
            services.AddOptions();
            services.AddSignalR();


        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<MusDbContext>().As<IMusDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<TrackDomainService>().As<ITrackDomainService>().InstancePerDependency();
            builder.RegisterType<TrackPresentationService>().As<ITrackPresentationService>().InstancePerDependency();
            builder.RegisterType<ArtistPresentationService>().As<IArtistPresentationService>().InstancePerDependency();
            builder.RegisterType<ArtistRepository>().As<IArtistRepository>().InstancePerDependency();
            builder.RegisterType<AlbumRepository>().As<IAlbumRepository>().InstancePerDependency();
            builder.RegisterType<GenreRepository>().As<IGenreRepository>().InstancePerDependency();
            builder.RegisterType<TrackRepository>().As<ITrackRepository>().InstancePerDependency();
            builder.RegisterType<ArtistDomainService>().As<IArtistDomainService>().InstancePerDependency();
            builder.RegisterType<AlbumDomainService>().As<IAlbumDomainService>().InstancePerDependency();
            builder.RegisterType<GenreDomainService>().As<IGenreDomainService>().InstancePerDependency();
            builder.RegisterType<AppUserRepository>().As<IAppUserRepository>().InstancePerDependency();
            builder.RegisterType<AppUserDomainService>().As<IAppUserDomainService>().InstancePerDependency();
            builder.RegisterType<PlaylistRepository>().As<IPlaylistRepository>().InstancePerDependency();
            builder.RegisterType<PlaylistDomainService>().As<IPlaylistDomainService>().InstancePerDependency();
            builder.RegisterType<PlaylistPresentationService>().As<IPlaylistPresentationService>().InstancePerDependency();
            builder.RegisterType<EmailPresentationService>().As<IEmailPresentationService>().InstancePerDependency();
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddDebug();
                builder.AddConsole();
               
                builder.AddFilter("System", LogLevel.Debug)
                        .AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Trace);
            });
            ILogger logger = loggerFactory.CreateLogger<Startup>();


        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {

            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            var logger = loggerFactory.CreateLogger("FileLogger");

            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapAreaControllerRoute(
            name: "AdminArea",
            areaName: "Admin",
            pattern: "Admin/{controller=Admin}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Main}/{action=Index}/{id?}");
                endpoints.MapHub<ChatHub>("/chat");


            });

           
        }
    }
}
