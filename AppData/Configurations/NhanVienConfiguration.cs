using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Configurations
{
    public class NhanVienConfiguration : IEntityTypeConfiguration<NhanVien>
    {
        public void Configure(EntityTypeBuilder<NhanVien> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Ten).IsRequired().HasMaxLength(200);
            builder.Property(x=>x.Tuoi).IsRequired().HasMaxLength(200);
            builder.Property(x=>x.Role).IsRequired().HasMaxLength(200);
            builder.Property(x=>x.Email).IsRequired().HasMaxLength(200);
            builder.Property(x=>x.Luong).IsRequired().HasMaxLength(200);
            builder.Property(x=>x.TrangThai).IsRequired();

        }
    }
}
