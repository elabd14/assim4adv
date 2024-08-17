using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assim4adv
{
    internal class SalesPerson : Employee
    {
        public int AchievedTarget { get; set; }
        public int SalesQuota { get; set; }

        public bool CheckTarget(int quota)
        {
            return AchievedTarget >= quota;
        }

        protected override void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            if (e.Cause == LayOffCause.VacationStockNegative && !CheckTarget(SalesQuota))
            {
                e.Cause = LayOffCause.FailedSalesTarget;
            }
            base.OnEmployeeLayOff(e);
        }
    }
}
