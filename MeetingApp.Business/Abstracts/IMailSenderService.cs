using MeetingApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Business.Abstracts
{
    public interface IMailSenderService
    {
        public string SendEMail(MailModel model);
    }
}
