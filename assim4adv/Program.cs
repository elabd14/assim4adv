namespace assim4adv
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            Department department = new Department { DeptID = 1, DeptName = "Sales Department" };
            Club club = new Club { ClubID = 1, ClubName = "Company Club" };

       
            SalesPerson salesPerson = new SalesPerson
            {
                EmployeeID = 1,
                BirthDate = new DateTime(1985, 5, 10),
                VacationStock = 5,
                AchievedTarget = 90,
                SalesQuota = 80
            };

            BoardMember boardMember = new BoardMember
            {
                EmployeeID = 2,
                BirthDate = new DateTime(1950, 3, 15),
                VacationStock = 0
            };

            department.AddStaff(salesPerson);
            department.AddStaff(boardMember);
            club.AddMember(salesPerson);
            club.AddMember(boardMember);

            
            Console.WriteLine("Before layoff events:");
            Console.WriteLine($"Department staff count: {department.Staff.Count}");
            Console.WriteLine($"Club member count: {club.Members.Count}");

         
            salesPerson.VacationStock = -1;

            boardMember.EndOfYearOperation();

            Console.WriteLine("\nAfter layoff events:");
            Console.WriteLine($"Department staff count: {department.Staff.Count}");
            Console.WriteLine($"Club member count: {club.Members.Count}");
        }
    }
}

