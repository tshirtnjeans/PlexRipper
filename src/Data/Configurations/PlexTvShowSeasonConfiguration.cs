﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlexRipper.Domain;

namespace PlexRipper.Data.Configurations
{
    public class PlexTvShowSeasonConfiguration : IEntityTypeConfiguration<PlexTvShowSeason>
    {
        public void Configure(EntityTypeBuilder<PlexTvShowSeason> builder)
        {
            // NOTE: This has been added to PlexRipperDbContext.OnModelCreating
            // Based on: https://stackoverflow.com/a/63992731/8205497
            // builder
            //     .Property(x => x.MediaData)
            //     .HasJsonValueConversion();
        }
    }
}