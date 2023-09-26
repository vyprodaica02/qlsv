using Design.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Design.Entity
{
    public  class KetQua : BaseEntity
    {
        public int MaSinhVien { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SinhVien? SinhVien { get; set; }
        public int MaMonHoc { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public MonHoc? MonHoc { get; set; }
        public int LanThi { get; set; }
        public double DiemThi { get; set; }

    }
}
