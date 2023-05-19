using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebDemo.Models
{
    public class TeacherViewModel
    {
        public TeacherViewModel()
        {
        }

        [DisplayName("ID")]
        public int MaGV { get; set; }

        [DisplayName("Tên giáo viên")]
        [MaxLength(50, ErrorMessage = "Tên giáo viên không được quá 50 kí tự")]
        public string TenGV { get; set; }

        [DisplayName("Tuổi")]
        public int Tuoi { get; set; }

        [DisplayName("Tên bộ môn")]
        [MaxLength(50, ErrorMessage = "Thông tin bộ môn không quá 50 kí tự")]
        public string BoMon { get; set; }

        [DisplayName("Là trưởng bộ môn")]
        public bool IsTruongBM { get; set; }

        [DisplayName("Địa chỉ")]
        [MaxLength(100, ErrorMessage = "Thông tin địa chỉ không được quá 100 kí tự")]
        public string DiaChi { get; set; }

        [DisplayName("Lương cơ bản")]
        public int LuongCoBan { get; set; }

        public DateTime CreatedDate { get; set; }


    }
}
