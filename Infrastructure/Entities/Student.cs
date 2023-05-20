using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
  
        [Table("Student")]
        public class Student
        {
            [Key]
            public int MaHS { get; set; }
            public string TenHS { get; set; }
            public string Lop { get; set; }
            public string Khoa { get; set; }
            public string DiaChi { get; set; }
            public int Tuoi { get; set; }
            public DateTime CreatedDate { get; set; }
            public ICollection<Course> Courses { get; set; }
    }
    }

