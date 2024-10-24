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
    public class UserProfileSignVm
    {
        public UserProfileSignVm()
        {         
        }
        public string Id { get; set; }


        [Display(Name = "تصویر امضا")]
        public IFormFile FileSignature { get; set; }
        public string FileSignatureStr { get; set; }


        //Added
        public int avatar_remove { get; set; }
        public int signature_remove { get; set; }

    }
}
