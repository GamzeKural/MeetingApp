using MeetingApp.Business.Utils;
using MeetingApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Business.Abstracts
{
    public interface IUserService
    {
        OperationResponse<List<User>> GetAllUsers();
        OperationResponse<User> GetUser(int id);
        OperationResponse<User> AddUser(User user);
        OperationResponse<User> UpdateUser(User user);
        OperationResponse<int> RemoveUser(int id);
    }
}
