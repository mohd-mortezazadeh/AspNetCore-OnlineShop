using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class UserChangePasswordVm
    {
        public string UserId { get; set; }
        [Display(Name = "رمز عبور فعلی")]
        [Required(ErrorMessage = "*")]
        [StringLength(255, ErrorMessage = "رمز عبور می بایست بین 5 تا 255 کاراکتر باشد", MinimumLength = 1)]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Display(Name = "رمز عبور جدید")]
        [Required(ErrorMessage = "*")]
        [StringLength(255, ErrorMessage = "رمز عبور می بایست بین 5 تا 255 کاراکتر باشد", MinimumLength = 1)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تایید رمز عبور جدید")]
        [Required(ErrorMessage = "*")]
        [StringLength(255, ErrorMessage = "رمز عبور می بایست بین 5 تا 255 کاراکتر باشد", MinimumLength = 1)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "مقادیر فیلدها برابر نمی باشند")]
        public string ConfirmPassword { get; set; }
    }
}
