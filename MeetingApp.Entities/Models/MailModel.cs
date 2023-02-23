using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Entities.Models
{
    public class MailModel
    {
        [Required(ErrorMessage = "Alıcı e-posta adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçersiz e-posta adresi.")]
        public string To { get; set; }

        [Required(ErrorMessage = "E-posta konusu gereklidir.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "E-posta içeriği gereklidir.")]
        public string Body { get; set; }
    }
}
