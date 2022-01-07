using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Mappings
{
    public class AnnouncementMapping : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.ToTable("tb_AnuncioWebmotors");
            builder.HasKey(y => y.Id);

            builder.Property(x => x.Make)
                .HasColumnName("marca")
                .HasColumnType("varchar(45)")
                .IsRequired();

            builder.Property(x => x.Model)
               .HasColumnName("modelo")
               .HasColumnType("varchar(45)")
               .IsRequired();

            builder.Property(x => x.Version)
              .HasColumnName("versao")
              .HasColumnType("varchar(45)")
              .IsRequired();

            builder.Property(x => x.Year)
              .HasColumnName("ano")
              .HasColumnType("INT")
              .IsRequired();

            builder.Property(x => x.Mileage)
              .HasColumnName("quilometragem")
              .HasColumnType("INT")
              .IsRequired();

            builder.Property(x => x.Note)
             .HasColumnName("observacao")
             .HasColumnType("text")
             .IsRequired();
        }
    }
}
