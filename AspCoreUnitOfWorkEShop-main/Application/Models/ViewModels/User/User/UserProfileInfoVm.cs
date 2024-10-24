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
    public class UserProfileInfoVm
    {
        public UserProfileInfoVm()
        {
        }
        public string Id { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        [StringLength(100, ErrorMessage = "حداکثر طول فیلد {0}  میتواند تا {1} کاراکتر باشد")]
        public string FullName { get; set; }


        [Display(Name = "تصویر کاربر")]
        public IFormFile FileAvatar { get; set; }
        public string FileAvatarStr { get; set; }


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        [StringLength(100, ErrorMessage = "حداکثر طول فیلد {0}  میتواند تا {1} کاراکتر باشد")]
        public string Email { get; set; }

        [Display(Name = "شماره تلفن")]
        public string PhoneNumber { get; set; }

        [StringLength(100, ErrorMessage = "حداکثر طول فیلد {0}  میتواند تا {1} کاراکتر باشد")]
        [Display(Name = "شماره موبایل")]
        public string MobileNumber { get; set; }

        [StringLength(100, ErrorMessage = "حداکثر طول فیلد {0}  میتواند تا {1} کاراکتر باشد")]
        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        public string NationalCode { get; set; }

        [Display(Name = "علامت اختصاری")]
        public string Symbol { get; set; }
        [Display(Name = "کد کاربری")]
        public string Code { get; set; }
        [Display(Name = "فعال")]
        public bool IsEnable { get; set; }
        [Display(Name = "وضعیت")]
        public UserStatusEnum Status { get; set; }

        [Display(Name = "تاریخ تولد")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        public string DateBirth { get; set; }

        [Display(Name = "جنسیت")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
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


        public int TechnicalAssistantId { get; set; }/// <summary>نام و امضا مسئول فنی</summary>
        public int UniversityBossId { get; set; }/// <summary>نام و امضا رییس دانشگاه</summary>

        [Display(Name = "شماره شناسنامه")]
        [StringLength(100, ErrorMessage = "حداکثر طول فیلد {0}  میتواند تا {1} کاراکتر باشد")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        public string IDCardNumber { get; set; }/// <summary>شماره شناسنامه</summary>

        [Display(Name = "تاریخ شروع به کار")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        public string DateStartToWork { get; set; }/// <summary>تاریخ شروع به کار</summary>

        [Display(Name = "شماره حساب بانکی")]
        [StringLength(100, ErrorMessage = "حداکثر طول فیلد {0}  میتواند تا {1} کاراکتر باشد")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        public string BankAccountNumber { get; set; }

        [Display(Name = "شماره بیمه")]
        [StringLength(100, ErrorMessage = "حداکثر طول فیلد {0}  میتواند تا {1} کاراکتر باشد")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        public string InsuranceNumber { get; set; }

        [Display(Name = "آدرس")]
        [StringLength(300, ErrorMessage = "حداکثر طول فیلد {0}  میتواند تا {1} کاراکتر باشد")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        public string Address { get; set; }

        [Display(Name = "شماره تلفن ضروری")]
        [StringLength(100, ErrorMessage = "حداکثر طول فیلد {0}  میتواند تا {1} کاراکتر باشد")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        public string UrgentNumber { get; set; }


        [Display(Name = "سابقه واکسن دارم")]
        public bool HasVaccinated { get; set; }
        [Display(Name = "توضیحات")]
        public string HasVaccinatedDescription { get; set; }
        [Display(Name = "سابقه بیماری دارم")]
        public bool HasPatient { get; set; }
        [Display(Name = "توضیحات")]
        public string HasPatientDescription { get; set; }
        [Display(Name = "گروه خونی")]
        public string PatientDescription { get; set; }
        [Display(Name = "شیوه استخدام")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]

        public string Evaluation { get; set; }
        public string EvaluationDate { get; set; }




        //Added
        public int avatar_remove { get; set; }
        public int signature_remove { get; set; }

        public UserPartialEnum Partial { get; set; }
    }
}
