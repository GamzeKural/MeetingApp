using MeetingApp.Business.Utils;
using MeetingApp.Entities.Models;

namespace MeetingApp.Web.Business.Services.Abstracts
{
    public interface IUserService
    {
        Task<OperationResponse<List<User>>> GetAllUsers();
        Task<OperationResponse<User>> GetUser(int id);
        Task<OperationResponse<User>> AddUser(User user);
        Task<OperationResponse<User>> UpdateUser(User user);
        Task<OperationResponse<int>> RemoveUser(int id);
    }
}
