using LeaveManagementDataService;
using LeaveManagementModels;
namespace LeaveManagementAppService
{
    public class LeaveAppService
    {
        LeaveDataService leaveDataService =
        new LeaveDataService(new LeaveDBData());
        public bool FileLeave(Leave leave)
        {
            if (leave.DaysFiled > leave.MaxDays)
            {
                leave.IsApproved = false;
                leave.RemainingDays = leave.MaxDays;
            }
            else
            {
                leave.IsApproved = true;
                leave.RemainingDays = leave.MaxDays - leave.DaysFiled;
            }
            leaveDataService.Add(leave);
            return leave.IsApproved;
        }
        public List<Leave> GetLeaves()
        {
            return leaveDataService.GetLeaves();
        }
        public Leave? GetLeave(Guid id)
        {
            return leaveDataService.GetById(id);
        }
        public void UpdateLeave(Leave leave)
        {
            leaveDataService.Update(leave);
        }
        public void DeleteLeave(Guid id)
        {
            leaveDataService.Delete(id);
        }
    }
}
