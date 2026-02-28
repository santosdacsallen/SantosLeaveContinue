namespace SantosGit
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter Name of the Employee: ");
            var EmpName = Console.ReadLine();
            Console.WriteLine("Choose number reason of leave: (1) sick 10 days, (2) vacation 10 days, (3) Paternity 7 days , (4) Maternity 107 days");
            int reason = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter number of Days to leave: ");
            int days = Convert.ToInt16(Console.ReadLine());


            int sick = 10 - days;
            int vacation = 10 - days;
            int paternity = 7 - days;
            int maternity = 107 - days;

            if (reason == 1)
            {
                Console.WriteLine("You have " + sick + " remaining of sick days");
            }
            else if (reason == 2)
            {
                Console.WriteLine("You have " + vacation + " remaining of sick days");
            }
            else if (reason == 3)
            {
                Console.WriteLine("You have " + paternity + " remaining of sick days");
            }
            else if (reason == 4)
            {
                Console.WriteLine("You have " + maternity + " remaining of sick days");
            }


        }
    }
}