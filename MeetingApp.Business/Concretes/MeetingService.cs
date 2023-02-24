using MeetingApp.Business.Abstracts;
using MeetingApp.Business.Utils;
using MeetingApp.DataAccess.Abstracts;
using MeetingApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Business.Concretes
{
    public class MeetingService : IMeetingService
    {
        private readonly IRepository _repo;
        private readonly IEmailService _emailService;
        private readonly IMeetingParticipantService meetingParticipantService;
        public MeetingService(IRepository repo, IEmailService emailService, IMeetingParticipantService meetingParticipantService)
        {
            _repo = repo;
            _emailService = emailService;
            this.meetingParticipantService = meetingParticipantService;
        }

        public OperationResponse<Meeting> AddMeeting(Meeting meeting)
        {
            try
            {
                var newMeeting = new Meeting();

                var result = new OperationResponse<Meeting>();
                newMeeting = meeting;

                var meetingParticipants = newMeeting.MeetingParticipants.ToList();

                newMeeting.MeetingParticipants = new List<MeetingParticipant>();

                _repo.Add(newMeeting);
                _repo.SaveChanges();

                Email email = new Email();
                email.SendDate = DateTime.Now;
                email.Subject = "You have a New Meeting!";
                email.Body = $"Between {newMeeting.StartDate} and {newMeeting.EndDate} you have a meeting.You will be expected.";
                email.SenderUserId = newMeeting.UserTheCreatedId;

                foreach (var participant in meetingParticipants)
                {
                    email.EmailRecipients.Add(new EmailRecipient() { EmailId = 1, UserId = participant.UserId });

                    participant.MeetingId = newMeeting.Id;

                    meetingParticipantService.AddMeetingParticipant(participant);
                }

                _emailService.AddEmail(email);

                result = OperationResponse<Meeting>.CreateSuccesResponse(meeting);
                result.Message = "Successfully added.";

                return result;
            }
            catch (Exception ex)
            {
                return OperationResponse<Meeting>.CreateFailure(ex.Message);
            }
        }
        
        public OperationResponse<List<Meeting>> GetAllMeetings()
        {
            try
            {
                var meetings = _repo.GetAll<Meeting>().ToList();

                var result = OperationResponse<List<Meeting>>.CreateSuccesResponse(meetings);

                result.Message = "Successfully brought.";

                return result;
            }
            catch (Exception ex)
            {
                return OperationResponse<List<Meeting>>.CreateFailure(ex.Message);
            }
        }

        public OperationResponse<Meeting> GetMeeting(int id)
        {
            try
            {
                var meeting = _repo.Get<Meeting>(id);

                var result = OperationResponse<Meeting>.CreateSuccesResponse(meeting);

                result.Message = "Successfully brought.";

                return result;
            }
            catch (Exception ex)
            {
                return OperationResponse<Meeting>.CreateFailure(ex.Message);
            }
        }

        public OperationResponse<int> RemoveMeeting(int id)
        {
            try
            {
                var meeting = _repo.Get<Meeting>(id);
                _repo.Remove(meeting);
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

        public OperationResponse<Meeting> UpdateMeeting(Meeting meeting)
        {
            try
            {
                var newMeeting = new Meeting();
                var result = new OperationResponse<Meeting>();
                newMeeting = meeting;
                _repo.Update(newMeeting);
                var response = _repo.SaveChanges();
                result = OperationResponse<Meeting>.CreateSuccesResponse(meeting);
                result.Message = "Successfully updated.";

                return result;
            }
            catch (Exception ex)
            {
                return OperationResponse<Meeting>.CreateFailure(ex.Message);
            }
        }
    }
}
