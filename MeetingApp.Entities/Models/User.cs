using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Entities.Models
{
    public class User
    {
        public User()
        {
            Meetings = new List<Meeting>();
            MeetingParticipants = new List<MeetingParticipant>();
            Emails = new List<Email>();
            EmailRecipients = new List<EmailRecipient>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "This Can Not Be Empty")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "This is not a valid Email Address")]
        public string Mail { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ProfilePhoto { get; set; }

        [AllowNull]
        public virtual ICollection<Meeting>? Meetings { get; set; }
        [AllowNull]
        public virtual ICollection<MeetingParticipant>? MeetingParticipants { get; set; }
        [AllowNull]
        public virtual ICollection<Email>? Emails { get; set; }
        [AllowNull]
        public virtual ICollection<EmailRecipient>? EmailRecipients { get; set; }
    }
}
