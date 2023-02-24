using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Entities.Models
{
    public class AuthModel
    {
        [Required]
        [EmailAddress]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
