using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Entities.Models
{
    public class Email
    {
        public Email()
        {
            EmailRecipients = new List<EmailRecipient>();
        }
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SendDate { get; set; }
        public int SenderUserId { get; set; }
        public virtual User? SenderUser { get; set; }
        public virtual ICollection<EmailRecipient> EmailRecipients { get; set; }
    }
}
