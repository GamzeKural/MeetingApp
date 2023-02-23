using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Entities.Models
{
    public class MeetingParticipant
    {
        public int Id { get; set; }
        public int MeetingId { get; set; }
        public int UserId { get; set; }

        public virtual Meeting? Meeting { get; set; }
        public virtual User? User { get; set; }

    }
}
