using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebDemo.Models
{
    public class CourseViewModel
    {
        public CourseViewModel()
        {
        }

        [DisplayName("Mã Khóa học")]
        public int cID { get; set; }

        [DisplayName("Tên khóa học")]
        [MaxLength(100, ErrorMessage = "Tên khóa học không được quá 100 kí tự")]
        public string cName { get; set; }

        [DisplayName("Năm học")]
        [MaxLength(10, ErrorMessage = "Năm học không được quá 10 kí tự")]
        public string cYearC { get; set; }

        [DisplayName("Tên học sinh")]
        public int MaHS { get; set; }

        [DisplayName("Tên giáo viên")]   
        public int MaGV { get; set; }

        public DateTime CreatedDate { get; set; }

        [DisplayName("Trang thai đang hoạt động")]
        public bool isActived { get; set; }


    }
}
