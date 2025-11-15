using EmployeeManagementApp.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementApp.Services
{
    public class WorkingDaysService : IWorkingDaysService
    {
        private readonly IHolidayService _holidayService;
        public WorkingDaysService(IHolidayService holidayService)
        {
            _holidayService = holidayService;
        }
        public int CalculateWorkingDays(DateTime start, DateTime end)
        {
            // Normalize date part
            var sdate = start.Date;
            var edate = end.Date;

            if (sdate > edate) throw new ArgumentException("Start date must be on or before end date.");
            if (sdate.DayOfWeek == DayOfWeek.Saturday || sdate.DayOfWeek == DayOfWeek.Sunday)
                throw new ArgumentException("Start date must be a weekday (Mon-Fri).");

            // get holidays cached (all) and then normalize for range
            var holidays = _holidayService.GetAllHolidays().ToList();
            var holidaySet = BuildHolidayHashSet(holidays, sdate.Year, edate.Year);

            int workingDays = 0;
            for (var currrent = sdate; currrent <= edate; currrent = currrent.AddDays(1))
            {
                if (currrent.DayOfWeek == DayOfWeek.Saturday || currrent.DayOfWeek == DayOfWeek.Sunday)
                    continue;

                if (holidaySet.Contains(currrent)) continue;

                workingDays++;
            }

            return workingDays;
        }
        private HashSet<DateTime> BuildHolidayHashSet(IEnumerable<PublicHoliday> holidays, int startYear, int endYear)
        {
            var set = new HashSet<DateTime>();
            foreach (var h in holidays)
            {
                if (h == null) continue;
                if (h.IsRecurring)
                {
                    for (int y = startYear; y <= endYear; y++)
                    {
                        // create a date in that year with the same month/day                   
                            var d = new DateTime(y, h.HolidayDate.Month, h.HolidayDate.Day);
                            set.Add(d.Date);                        
                    }
                }
                else
                {
                    set.Add(h.HolidayDate.Date);
                }
            }
            return set;
        }
    }
}
