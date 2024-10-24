using Domain.Entities;
using Domain.Enum;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class LocationVm:BaseVM
    {
        public LocationVm()
        {
            
        }
        public Guid? ParentId { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "*")]
        [StringLength(100, ErrorMessage = "حداکثر طول فیلد {0}  میتواند تا {1} کاراکتر باشد")]
        public string Name { get; set; }        
        public string Code { get; set; }
        public string NO { get; set; }

        [Display(Name = "توضیحات")]
        [StringLength(2000, ErrorMessage = "حداکثر طول فیلد {0}  میتواند تا {1} کاراکتر باشد")]
        public string Description { get; set; }        
        public string CreatorUserId { get; set; }
        public bool IsEnable { get; set; }
        
        [Display(Name = "وضعیت")]
        public LocationStatusEnum Status { get; set; }

        [Display(Name = "نوع")]
        public LocationTypeEnum Type { get; set; }

        public DateTime DateRegister { get; set; }

        //Added
        public string StatusEn { get; set; }
        public string StatusStr { get; set; }
        public Location Location { get; set; }
    }
}
