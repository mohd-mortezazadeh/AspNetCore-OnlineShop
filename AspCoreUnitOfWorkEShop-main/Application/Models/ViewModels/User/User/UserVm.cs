using Domain.Entities;
using Domain.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class UserVm
    {
        public UserVm()
        {
            ListOrganizationId = new List<string>();
            selectedPermissionIds = new List<int>();         
        }
        public string Id { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "*")]
        [StringLength(100, ErrorMessage = "حداکثر طول فیلد {0}  میتواند تا {1} کاراکتر باشد")]
        public string FullName { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "*")]
        [StringLength(100, ErrorMessage = "حداکثر طول فیلد {0}  میتواند تا {1} کاراکتر باشد")]
        public string UserName { get; set; }

        [Display(Name = "کد ملی")]
        public string NationalCode { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "*")]
        [StringLength(100, ErrorMessage = "حداکثر طول فیلد {0}  میتواند تا {1} کاراکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "رمز عبور")]
        [StringLength(100, ErrorMessage = "حداکثر طول فیلد {0}  میتواند تا {1} کاراکتر باشد")]
        public string Password2 { get; set; }

        [Display(Name = "تصویر کاربر")]
        public IFormFile FileAvatar { get; set; }
        public string FileAvatarStr { get; set; }

        [Display(Name = "تصویر امضا")]
        public IFormFile FileSignature { get; set; }
        public string FileSignatureStr { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        [Display(Name = "شماره تلفن")]
        public string PhoneNumber { get; set; }
        [Display(Name = "شماره موبایل")]
        public string MobileNumber { get; set; }
        [Display(Name = "علامت اختصاری")]
        public string Symbol { get; set; }
        [Display(Name = "کد کاربری")]
        public string Code { get; set; }
        [Display(Name = "فعال")]
        public bool IsEnable { get; set; }
        [Display(Name = "وضعیت")]
        public UserStatusEnum Status { get; set; }

        [Display(Name = "تاریخ تولد")]
        public string DateBirth { get; set; }

        [Display(Name = "جنسیت")]
        public bool Gender { get; set; }

        [Display(Name = "روز")]
        public string Day { get; set; }

        [Display(Name = "ماه")]
        public string Month { get; set; }

        [Display(Name = "سال")]
        public string Year { get; set; }
        [Display(Name = "وضعیت")]
        public string StatusStr { get; set; }
        public EnumRoleMain UserType { get; set; }
        public DateTime DateRegister { get; set; }
        //Added
        public int avatar_remove { get; set; }
        public int signature_remove { get; set; }

        [Display(Name = "سمت کاربری")]
        public string ListOrganizationStr { get; set; }
        public List<string> ListOrganizationId { get; set; }
        public List<int> selectedPermissionIds { get; set; }
        public bool IsEdit { get; set; }
        public UserPartialEnum Partial { get; set; }
    }
}
