using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Entities.Models
{
    public class Meeting
    {
        public Meeting()
        {
            MeetingParticipants = new List<MeetingParticipant>();
        }
        public int Id { get; set; }
        public string MeetingName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string Document { get; set; }
        public int UserTheCreatedId { get; set; }

        public virtual User? UserTheCreated { get; set; }
        public virtual ICollection<MeetingParticipant> MeetingParticipants { get; set; }

    }
}
