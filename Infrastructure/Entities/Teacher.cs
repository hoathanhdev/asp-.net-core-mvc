using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
  
        [Table("Teacher")]
        public class Teacher
        {
            [Key]
            public int MaGV { get; set; }
            public string TenGV { get; set; }
            public string BoMon{ get; set; }
            public string DiaChi { get; set; }
            public int LuongCoBan { get; set; }
            public int Tuoi { get; set; }
            public bool IsTruongBM { get; set; }
            public DateTime CreatedDate { get; set; }

            public ICollection<Course> Courses { get; set; }
    }
    }

