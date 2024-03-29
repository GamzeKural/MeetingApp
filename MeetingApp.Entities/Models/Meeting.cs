﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        [AllowNull]
        public byte[] Document { get; set; }
        public int UserTheCreatedId { get; set; }

        [AllowNull]
        public virtual User? UserTheCreated { get; set; }
        [AllowNull]
        public virtual ICollection<MeetingParticipant> MeetingParticipants { get; set; }

    }
}
