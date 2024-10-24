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
    public class UserProfilePasswordVm
    {
        public UserProfilePasswordVm()
        {        
        }
        public string Id { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        [StringLength(100, ErrorMessage = "حداکثر طول فیلد {0}  میتواند تا {1} کاراکتر باشد")]
        public string MobileNumber { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        [StringLength(100, ErrorMessage = "حداکثر طول فیلد {0}  میتواند تا {1} کاراکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "رمز عبور")]
        [StringLength(100, ErrorMessage = "حداکثر طول فیلد {0}  میتواند تا {1} کاراکتر باشد")]
        public string Password2 { get; set; }

    }
}
