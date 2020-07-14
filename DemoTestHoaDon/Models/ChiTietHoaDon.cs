using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoTestHoaDon.Models
{
    public class ChiTietHoaDon
    {
        [Key]
        public string IdChiTiet { get; set; }

        [Required(ErrorMessage = "Khong de trong!")]
        public string SoHD { get; set; }

        [Required(ErrorMessage = "Khong de trong!")]
        public string TenSP { get; set; }

        [Required(ErrorMessage = "Khong de trong!")]
        public string DonVi { get; set; }

        [Required(ErrorMessage = "Khong de trong!")]
        public int SoLuong { get; set; }

        [Required(ErrorMessage = "Khong de trong!")]
        public decimal DonGia { get; set; }

        [Required(ErrorMessage = "Khong de trong!")]
        public decimal ThanhTien { get; set; }
    }
}
