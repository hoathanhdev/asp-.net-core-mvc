using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities
{
    [Table("Course")]
    public class Course
    {
        [Key]
        public int cID { get; set; }
        public string cName { get; set; }
        public string cYearC { get; set; }
        public int MaHS { get; set; }
        public int MaGV { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isActived { get; set; }

        public Student Student { get; set; }

        public Teacher Teacher { get; set; }
    }
}
