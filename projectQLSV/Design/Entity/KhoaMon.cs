using Design.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Design.Entity
{
    public class KhoaMon : BaseEntity
    {
        public int MaKhoa { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Khoa? Khoa { get; set; }
        public int MaMH { get; set; }
        public string TinChi { get; set; }
        public string TongSoTiet { get; set; }
    }
}
