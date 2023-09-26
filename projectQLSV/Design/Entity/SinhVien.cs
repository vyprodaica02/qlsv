using Design.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Design.Entity
{
    public class SinhVien : BaseEntity
    {
        public string HoSinhVien { get; set; }
        public string TenSinhVien { get;set; }
        public DateTime NgaySinh { get; set; }
        public string NoiSinh { get;set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string HocBong { get; set; }
        public string GioiTinh { get; set; }
        public int MaLop { get;set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Lop? Lop { get;set; }

    }
}
