using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assim4adv
{
    internal class Employee
    {
        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;

        protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);
        }

        public int EmployeeID { get; set; }

        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        private int _vacationStock;
        public int VacationStock
        {
            get { return _vacationStock; }
            set
            {
                _vacationStock = value;
                if (VacationStock < 0)
                {
                    OnEmployeeLayOff(e: new EmployeeLayOffEventArgs { Cause = LayOffCause.VacationStockNegative });
                }
            }
        }

        public bool RequestVacation(DateTime From, DateTime To)
        {
            // Implement vacation request logic
            return true;
        }

        public void EndOfYearOperation()
        {
            if (DateTime.Now.Year - BirthDate.Year > 60)
            {
                OnEmployeeLayOff(e: new EmployeeLayOffEventArgs { Cause = LayOffCause.AgeOver60 });
            }
        }
    } }
