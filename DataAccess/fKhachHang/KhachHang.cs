using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.fKhachHang
{
    public class KhachHang
    {
        public int ID { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public int GioiTinh { get; set; }
        public int SDT { get; set; }
        public int Email { get; set; }

    }
}
