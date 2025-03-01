﻿using Autofac;
using AutoMapper;
using PlexRipper.Application.Config;
using PlexRipper.Data.Config;
using PlexRipper.Domain.AutoMapper;
using PlexRipper.DownloadManager.Common.Autofac;
using PlexRipper.FileSystem.Config;
using PlexRipper.HttpClient.Config;
using PlexRipper.PlexApi.Config;
using PlexRipper.PlexApi.Config.Mappings;
using PlexRipper.Settings.Config;

namespace PlexRipper.WebAPI.Config
{
    public static class ContainerConfig
    {
        /// <summary>
        /// Autofac container builder, Serilog registration is left out due to being context dependent. Integration tests have a different configuration than the application.
        /// </summary>
        /// <param name="builder">The builder through which components can be registered.</param>
        public static void ConfigureContainer(ContainerBuilder builder)
        {
            // Application
            builder.RegisterModule<ApplicationModule>();

            // Infrastructure
            builder.RegisterModule<DataModule>();
            builder.RegisterModule<DownloadManagerModule>();
            builder.RegisterModule<FileSystemModule>();
            builder.RegisterModule<PlexApiModule>();
            builder.RegisterModule<SettingsModule>();
            builder.RegisterModule<HttpClientModule>();

            // Presentation
            builder.RegisterModule<WebApiModule>();

            // Auto Mapper
            builder.Register(ctx =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new DomainMappingProfile());
                    cfg.AddProfile(new ApplicationMappingProfile());
                    cfg.AddProfile(new PlexApiMappingProfile());
                    cfg.AddProfile(new WebApiMappingProfile());
                });
                config.AssertConfigurationIsValid();
                return config;
            });

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}