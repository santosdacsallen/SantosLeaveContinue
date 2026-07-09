namespace LeaveManagementModels
{
    public class Leave
    {
        public Guid LeaveId { get; set; }
        public string EmployeeName { get; set; }
        public string LeaveType { get; set; }
        public int DaysFiled { get; set; }
        public int MaxDays { get; set; }
        public int RemainingDays { get; set; }
        public bool IsApproved { get; set; }
    }
}
