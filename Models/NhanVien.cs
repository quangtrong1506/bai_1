using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_1.Models
{
    class NhanVien : DiaChi
    {
        public string id { get; set; }
        public string hoTen { get; set; }
        public string tuoi { get; set; }
        public float luong { get; set; }
        public string soDienThoai { get; set; }
    }
}
