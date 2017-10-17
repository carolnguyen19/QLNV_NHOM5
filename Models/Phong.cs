namespace QLNV_NHOM5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phong")]
    public partial class Phong
    {
        [Key]
        [StringLength(10)]
        [Display(Name = "Mã phòng")]
        public string MaPhong { get; set; }

        [Display(Name = "Tên phòng")]
        [StringLength(50)]
        public string TenPhong { get; set; }
    }
}
