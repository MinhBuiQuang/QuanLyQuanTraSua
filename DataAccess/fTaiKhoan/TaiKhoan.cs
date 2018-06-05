using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.fTaiKhoan
{
    public class TaiKhoan
    {
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string TenHienThi { get; set; }
        public int ID_LoaiTaiKhoan { get; set; }
        public string LoaiTaiKhoan { get; set; }
    }
}