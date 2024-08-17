using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assim4adv
{
    internal class Club
    {
        public int ClubID { get; set; }
        public string ClubName { get; set; }
        private List<Employee> Members = new List<Employee>();

        public void AddMember(Employee e)
        {
            Members.Add(e);
            e.EmployeeLayOff += RemoveMember;
        }

        public void RemoveMember(object sender, EmployeeLayOffEventArgs e)
        {
            var employee = sender as Employee;
            if (employee != null)
            {
                if (e.Cause == LayOffCause.VacationStockNegative)
                {
                    Members.Remove(employee);
                }
            }
        }
    }
}
