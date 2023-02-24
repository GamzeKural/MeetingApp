using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Entities.Models
{
    public class MeetingModel
    {
        public MeetingModel()
        {
            IDictionary<int, string> data = new Dictionary<int, string>();
        }
        public int Id { get; set; }
        public string MeetingName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public byte[] Document { get; set; }
        public IDictionary<int, string> data { get; set; }

    }
}
