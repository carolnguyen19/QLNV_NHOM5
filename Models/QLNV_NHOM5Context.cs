namespace QLNV_NHOM5
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLNV_NHOM5Context : DbContext
    {
        public QLNV_NHOM5Context()
            : base("name=QLNV_NHOM5Context")
        {
        }

        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.TenNV)
                .IsFixedLength();

            //modelBuilder.Entity<NhanVien>()
            //    .Property(e => e.NgaySinh)
            //    .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaPhong)
                .IsFixedLength();

            modelBuilder.Entity<Phong>()
                .Property(e => e.MaPhong)
                .IsFixedLength();

            modelBuilder.Entity<Phong>()
                .Property(e => e.TenPhong)
                .IsFixedLength();
        }
    }
}
