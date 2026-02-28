namespace SantosGit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Name of the Employee: ");
            string empName = Console.ReadLine();

            Console.WriteLine("Choose number reason of leave:");
            Console.WriteLine("(1) Sick Leave - 10 days");
            Console.WriteLine("(2) Vacation Leave - 10 days");
            Console.WriteLine("(3) Paternity Leave - 7 days");
            Console.WriteLine("(4) Maternity Leave - 107 days");

            int reason = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter number of Days to leave: ");
            int days = Convert.ToInt32(Console.ReadLine());

            int maxDays = 0;
            string leaveType = "";

            if (reason == 1)
            {
                maxDays = 10;
                leaveType = "Sick Leave";
            }
            else if (reason == 2)
            {
                maxDays = 10;
                leaveType = "Vacation Leave";
            }
            else if (reason == 3)
            {
                maxDays = 7;
                leaveType = "Paternity Leave";
            }
            else if (reason == 4)
            {
                maxDays = 107;
                leaveType = "Maternity Leave";
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }

            if (days > maxDays)
            {
                Console.WriteLine("Leave request denied. Exceeded allowed days.");
            }
            else
            {
                int remaining = maxDays - days;

                Console.WriteLine("\n--- Leave Summary ---");
                Console.WriteLine("Employee Name: " + empName);
                Console.WriteLine("Leave Type: " + leaveType);
                Console.WriteLine("Days Filed: " + days);
                Console.WriteLine("Remaining Leave Balance: " + remaining);
                Console.WriteLine("Leave request approved.");
            }
        }
    }
}