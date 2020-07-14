using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoTestHoaDon.Models
{
    public class HoaDons
    {
        [Key]
        public string SoHD { get; set; }

        [Required(ErrorMessage ="Khong de trong!")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Khong de trong!")]
        public int DienThoai { get; set; }

        public DateTime NgayXuat { get; set; }
        public decimal TongTien { get; set; }
    }
}
