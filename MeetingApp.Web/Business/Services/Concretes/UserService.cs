using MeetingApp.Business.Utils;
using MeetingApp.Entities.Models;
using MeetingApp.Web.Business.Services.Abstracts;
using Newtonsoft.Json.Linq;
using System.Data;

namespace MeetingApp.Web.Business.Services.Concretes
{
    public class UserService : IUserService
    {
        private readonly IHttpService httpService;

        public UserService(IHttpService httpService)
        {
            this.httpService = httpService;
        }
        public async Task<OperationResponse<User>> AddUser(User user)
        {
            try
            {
                var result = await httpService.Post<OperationResponse<User>>("User/AddUser", user,false);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Token> Authenticate(AuthModel model)
        {
            try
            {
                var result = await httpService.Post<Token>("User/Authenticate", model, false);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationResponse<List<User>>> GetAllUsers()
        {
            try
            {
                var result = await httpService.Get<OperationResponse<List<User>>>("User/GetAllUsers",false);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationResponse<User>> GetUser(int id)
        {
            try
            {
                var result = await httpService.Get<OperationResponse<User>>($"User/GetUser?id={id}");
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationResponse<int>> RemoveUser(int id)
        {
            try
            {
                var result = await httpService.Delete<OperationResponse<int>>($"User/RemoveUser?id={id}");
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationResponse<User>> UpdateUser(User user)
        {
            try
            {
                var result = await httpService.Put<OperationResponse<User>>("User/UpdateUser", user);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
