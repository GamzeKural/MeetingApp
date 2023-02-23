using MeetingApp.Business.Utils;
using MeetingApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Business.Abstracts
{
    public interface IEmailService
    {
        OperationResponse<List<Email>> GetAllEmails();
        OperationResponse<Email> GetEmail(int id);
        OperationResponse<Email> AddEmail(Email email);
        OperationResponse<Email> UpdateEmail(Email email);
        OperationResponse<int> RemoveEmail(int id);
    }
}
