using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assim4adv
{
    internal class BoardMember : Employee
    {

        public void Resign()
        {
            OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.Resig    nation });
        }

        protected override void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            if (e.Cause == LayOffCause.Resignation || e.Cause == LayOffCause.AgeOver60)
            {
                // BoardMembers do not get laid off due to age
                e.Cause = LayOffCause.Resignation;
            }
            base.OnEmployeeLayOff(e);
        }

    }
}
