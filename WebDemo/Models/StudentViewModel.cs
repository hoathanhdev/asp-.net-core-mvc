using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebDemo.Models
{
    public class StudentViewModel
    {
        public StudentViewModel()
        {
        }

        [DisplayName("ID")]
        public int MaHS { get; set; }

        [DisplayName("Tên học sinh")]
        [MaxLength(50, ErrorMessage = "Tên học sinh không được quá 50 kí tự")]
        public string TenHS { get; set; }

        [DisplayName("Tuổi")]
        public int Tuoi { get; set; }

        [DisplayName("Tên lớp")]
        [MaxLength(50, ErrorMessage = "Thông tin tên lớp không quá 50 kí tự")]
        public string Lop { get; set; }

        [DisplayName("Tên khoa")]
        [MaxLength(50, ErrorMessage = "Thông tin tên khoa không được quá 50 kí tự")]
        public string Khoa { get; set; }

        [DisplayName("Địa chỉ")]
        [MaxLength(100, ErrorMessage = "Thông tin địa chỉ không được quá 100 kí tự")]
        public string DiaChi { get; set; }

        public DateTime CreatedDate { get; set; }


    }
}
