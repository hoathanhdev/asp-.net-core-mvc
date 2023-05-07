using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebDemo.Models
{
    public class AccountViewModel
    {
        public AccountViewModel()
        {
        }

        [DisplayName("ID")]
        public int aID { get; set; }

        [DisplayName("Tên người dùng")]
        [MaxLength(10, ErrorMessage = "Tên người dùng không được quá 10 kí tự")]
        public string aUsername { get; set; }

        [DisplayName("Mật khẩu")]
        [MaxLength(10, ErrorMessage = "Password không được quá 10 kí tự")]
        public string aPassword { get; set; }

        [DisplayName("QUẢN TRỊ VIÊN")]
        public bool aIsAdmin { get; set; }

        [DisplayName("Thông tin tài khoản")]
        [MaxLength(1000, ErrorMessage = "Thông tin tài khoản không quá 1000 kí tự")]
        public string aInformation { get; set; }

        [DisplayName("Email")]
        [MaxLength(125, ErrorMessage = "Email không được quá 125 kí tự")]
        public string aEmail { get; set; }

        public DateTime CreatedDate { get; set; }

        [DisplayName("Trang thai đang hoạt động")]
        public bool isActived { get; set; }


    }
}
