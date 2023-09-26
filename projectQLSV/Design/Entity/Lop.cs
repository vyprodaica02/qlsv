using Design.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Design.Entity
{
    public class Lop : BaseEntity
    {
        public string? TenLop { get; set; }
        public int SiSo { get; set; }
        public int MaKhoa { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Khoa? khoa { get; set; }
    }
}
