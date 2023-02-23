using MeetingApp.Business.Abstracts;
using MeetingApp.Business.Utils;
using MeetingApp.DataAccess.Abstracts;
using MeetingApp.Entities.Models;
using MeetingApp.Utils;

namespace MeetingApp.Business.Concretes
{
    public class UserService : IUserService
    {
        private readonly IRepository _repo;
        private readonly IEmailService _emailService;
        public UserService(IRepository repo, IEmailService emailService)
        {
            _repo = repo;
            _emailService = emailService;
        }

        public OperationResponse<User> AddUser(User user)
        {
            try
            {
                var newUser = new User();
                var users = _repo.GetAll<User>().ToList();
                var isExist = users.Any(x => x.Mail.ToUpper().Trim() == user.Mail.ToUpper().Trim());
                var result = new OperationResponse<User>();

                if (!isExist)
                {
                    user.Mail = user.Mail.Trim();
                    user.Password = Encription.Encrypt(user.Password);

                    newUser = user;

                    _repo.Add(newUser);
                    _repo.SaveChanges();

                    Email email = new Email();

                    email.Subject = "Welcome!";
                    email.Body = $"We just want to say welcome aboard.We glad to see you here {user.FirstName} {user.LastName} :)";
                    email.EmailRecipients.Add(new EmailRecipient { EmailId = 1 , UserId = user.Id });
                    email.SenderUserId = 1;
                    email.SendDate = DateTime.Now;

                    _emailService.AddEmail(email);

                    result = OperationResponse<User>.CreateSuccesResponse(user);
                    result.Message = "Successfully added.";
                }
                else
                {
                    result = OperationResponse<User>.CreateFailure("This user already exists.");
                }

                return result;

            }
            catch (Exception ex)
            {
                return OperationResponse<User>.CreateFailure(ex.Message);
            }

        }

        public OperationResponse<List<User>> GetAllUsers()
        {
            try
            {
                var users = _repo.GetAll<User>().ToList();

                var result = OperationResponse<List<User>>.CreateSuccesResponse(users);

                result.Message = "Successfully brought.";

                return result;
            }
            catch (Exception ex)
            {
                return OperationResponse<List<User>>.CreateFailure(ex.Message);
            }
        }

        public OperationResponse<User> GetUser(int id)
        {
            try
            {
                var user = _repo.Get<User>(id);

                var result = OperationResponse<User>.CreateSuccesResponse(user);

                result.Message = "Successfully brought.";

                return result;
            }
            catch (Exception ex)
            {
                return OperationResponse<User>.CreateFailure(ex.Message);
            }
        }

        public OperationResponse<int> RemoveUser(int id)
        {
            try
            {
                var user = _repo.Get<User>(id);
                _repo.Remove(user);
                var response = _repo.SaveChanges();
                var result = OperationResponse<int>.CreateSuccesResponse(response);
                result.Message = "Successfully deleted.";
                return result;
            }
            catch (Exception ex)
            {
                return OperationResponse<int>.CreateFailure(ex.Message);
            }
        }

        public OperationResponse<User> UpdateUser(User user)
        {
            try
            {
                var newUser = new User();
                var users = _repo.GetAll<User>().ToList();
                var oldUser = users.Where(x => x.Mail.ToUpper().Trim() == user.Mail.ToUpper().Trim()).FirstOrDefault();
                var result = new OperationResponse<User>();

                if (oldUser == null || oldUser.Id == user.Id)
                {
                    user.Mail = user.Mail.Trim();
                    newUser = user;
                    _repo.Update(newUser);
                    var response = _repo.SaveChanges();
                    result = OperationResponse<User>.CreateSuccesResponse(user);
                    result.Message = "Successfully updated.";
                }
                else
                {
                    result = OperationResponse<User>.CreateFailure("This user already exists.");
                }

                return result;
            }
            catch (Exception ex)
            {
                return OperationResponse<User>.CreateFailure(ex.Message);
            }
        }
    }
}
