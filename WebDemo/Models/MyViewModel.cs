using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities;

namespace WebDemo.Models
{
    public class MyViewModel
    {
        public CourseViewModel Data { get; set; }
        public IQueryable<Student> Data1 { get; set; }
        public IQueryable<Teacher> Data2 { get; set; }

    }
}
