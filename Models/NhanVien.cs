namespace QLNV_NHOM5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Bạn không được để trống thông tin này")]
        public long MaNV { get; set; }

        [StringLength(50)]
        public string TenNV { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgaySinh { get; set; }

        public int? LoaiNV { get; set; }

        [StringLength(50)]
        public string MaPhong { get; set; }

        public decimal? Luong { get; set; }

        public int? SoNgayLam { get; set; }

        public decimal? BacLuong { get; set; }

        public decimal? PhuCap { get; set; }

        public decimal? TongLuong { get; set; }

    }
}
