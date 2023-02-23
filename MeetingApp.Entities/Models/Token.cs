using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Entities.Models
{
    public class Token
    {
        public string VerifiedToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
