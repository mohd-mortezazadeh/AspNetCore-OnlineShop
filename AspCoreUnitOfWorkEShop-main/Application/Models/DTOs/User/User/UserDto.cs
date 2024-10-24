using Application.Models;
using System;

namespace Application.ViewModels
{
    public class UserDto : BaseDto
    {
        public UserDto()
        {
            
        }

        public Guid VehicleId { get; set; }
        public Guid UserId { get; set; }
    }
}
