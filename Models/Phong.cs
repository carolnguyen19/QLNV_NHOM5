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
        public string MaPhong { get; set; }

        [StringLength(50)]
        public string TenPhong { get; set; }
    }
}
