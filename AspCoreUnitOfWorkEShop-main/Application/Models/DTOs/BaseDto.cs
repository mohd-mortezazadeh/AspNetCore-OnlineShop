using System;

namespace Application.Models
{
    public class BaseDto
    {
        public Guid Id { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
    }
}
