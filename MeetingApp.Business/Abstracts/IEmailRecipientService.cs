using MeetingApp.Business.Utils;
using MeetingApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Business.Abstracts
{
    public interface IEmailRecipientService
    {
        OperationResponse<List<EmailRecipient>> GetAllEmailRecipients();
        OperationResponse<EmailRecipient> GetEmailRecipient(int id);
        OperationResponse<EmailRecipient> AddEmailRecipient(EmailRecipient emailRecipient);
        OperationResponse<EmailRecipient> UpdateEmailRecipient(EmailRecipient emailRecipient);
        OperationResponse<int> RemoveEmailRecipient(int id);
    }
}
