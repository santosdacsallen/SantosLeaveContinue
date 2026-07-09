using LeaveManagementAppService;
using LeaveManagementModels;

namespace SantosGit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LeaveAppService app = new LeaveAppService();
            Console.Write("Employee Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("1. Sick Leave");
            Console.WriteLine("2. Vacation Leave");
            Console.WriteLine("3. Paternity Leave");
            Console.WriteLine("4. Maternity Leave");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.Write("Days to Leave: ");
            int days = Convert.ToInt32(Console.ReadLine());
            Leave leave = new Leave();
            leave.LeaveId = Guid.NewGuid();
            leave.EmployeeName = name;
            leave.DaysFiled = days;
            switch (choice)
            {
                case 1:
                    leave.LeaveType = "Sick Leave";
                    leave.MaxDays = 10;
                    break;
                case 2:
                    leave.LeaveType = "Vacation Leave";
                    leave.MaxDays = 10;
                    break;
                case 3:
                    leave.LeaveType = "Paternity Leave";
                    leave.MaxDays = 7;
                    break;
                case 4:
                    leave.LeaveType = "Maternity Leave";
                    leave.MaxDays = 107;
                    break;
            }
            bool approved = app.FileLeave(leave);
            Console.WriteLine();
            if (approved)
            {
                Console.WriteLine("Leave Approved!");
                Console.WriteLine($"Remaining Days: {leave.RemainingDays}");
            }
            else
            {
                Console.WriteLine("Leave Denied!");
            }
                }
        }
    }