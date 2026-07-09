using LeaveManagementModels;
namespace LeaveManagementDataService
{
    public class LeaveDataService
    {
        ILeaveDataService _dataService;
        public LeaveDataService(ILeaveDataService dataService)
        {
            _dataService = dataService;
        }
        public void Add(Leave leave)
        {
            _dataService.Add(leave);
        }
        public List<Leave> GetLeaves()
        {
            return _dataService.GetLeaves();
        }
        public Leave? GetById(Guid id)
        {
            return _dataService.GetById(id);
        }
        public void Update(Leave leave)
        {
            _dataService.Update(leave);
        }
        public void Delete(Guid id)
        {
            _dataService.Delete(id);
        }
    }
}
