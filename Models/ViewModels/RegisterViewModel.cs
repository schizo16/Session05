using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Session05.Models.ViewModels
{
    public class RegisterViewModel
    {
        [DisplayName("Tài khoản")]
        [Required(ErrorMessage = "Tài khoản không để trống")]
        [StringLength(20, MinimumLength = 3, ErrorMessage ="Độ dài từ 3-20 ký tự")]

        public string Username { get; set; }
        [DisplayName("Mật khẩu")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Chưa nhập mật khẩu")]
        public string Password { get; set; }

        [DisplayName("Nhập lại mật khẩu")]
        [Required(ErrorMessage ="Nhập không khớp")]
        [DataType(DataType.Password)]
        [Compare("Passowrd")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Họ và tên")]
        [Required(ErrorMessage ="Họ và tên không được trống")]
        public string Fullname { get; set; }

        [DisplayName("Hòm thư")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email không bỏ trống")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")]
        public string Email { get; set; }

        [DisplayName("Điện thoại")]
        [RegularExpression(@"^[0-9]*$")]
        public string Phone { get; set; }

        [DisplayName("Ngày sinh")]

        public DateTime Birthday { get; set; }
    }
}
