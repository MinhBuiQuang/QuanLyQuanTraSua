using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.fNhanVien
{
    public class NhanVien
    {
        public string TenDangNhap { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public int GioiTinh { get; set; }
        public int SDT { get; set; }
        public string Email { get; set; }
        public DateTime NgayVaoLam { get; set; }

    }
}
