using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobiZ.Models
{
    public class RegisterModel
    {
        public long ID { get; set; }
        [Display(Name ="Tên đăng nhập")]
        [Required(ErrorMessage ="Bạn chưa điền tên đăng nhập")]
        [MinLength(5,ErrorMessage ="Tên đăng nhập ít nhất 5 ký tự"),MaxLength(32,ErrorMessage ="Tên đăng nhập tối đa 32 ký tự")]
        public string Username { get; set; }
        [Display(Name ="Mật khẩu")]
        [Required(ErrorMessage = "Bạn chưa điền mật khẩu")]
        [MinLength(5, ErrorMessage = "Mật khẩu ít nhất 5 ký tự"), MaxLength(32, ErrorMessage = "Mật khẩu tối đa 32 ký tự")]
        public string Password { get; set; }
        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("Password",ErrorMessage ="Mật khẩu không khớp")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Tên đầy đủ")]
        public string FullName { get; set; }
        [Display(Name = "Tuổi")]
        public int Age { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Số điện thoại")]
        public int PhoneNumber { get; set; }
    }
}