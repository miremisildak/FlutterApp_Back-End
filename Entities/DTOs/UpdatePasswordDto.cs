using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UpdatePasswordDto:IDto
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        //public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
