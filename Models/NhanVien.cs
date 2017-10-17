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
        [Display(Name = "Họ tên")]
        public string TenNV { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày sinh")]
        public DateTime? NgaySinh { get; set; }

        [Display(Name = "Loại")]
        public int? LoaiNV { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã phòng")]
        public string MaPhong { get; set; }

        public decimal? Luong { get; set; }

        [Display(Name = "Số ngày làm")]
        public int? SoNgayLam { get; set; }

        [Display(Name = "Bậc lương")]
        public decimal? BacLuong { get; set; }

        [Display(Name = "Phụ cấp")]
        public decimal? PhuCap { get; set; }

        [Display(Name = "Tổng lương")]
        public decimal? TongLuong { get; set; }

    }
}
