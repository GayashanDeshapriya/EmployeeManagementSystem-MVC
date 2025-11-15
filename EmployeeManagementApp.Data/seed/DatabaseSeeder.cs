using EmployeeManagementApp.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementApp.Data.seed
{
    public class DatabaseSeeder
    {
        private readonly EmployeeManagementDBEntities _context;

        public DatabaseSeeder(EmployeeManagementDBEntities context)
        {
            _context = context;
        }

        public void SeedPublicHolidays()
        {
            if(_context.PublicHolidays.Any())
            {
                return; // Database has been seeded
            }

            var holidays = new[]
            {
                new PublicHoliday
                {
                    HolidayDate = new DateTime(DateTime.Now.Year, 1, 1),
                    Description = "New Year's Day",
                    IsRecurring = true
                },
                new PublicHoliday
                {
                    HolidayDate = new DateTime(2025, 1, 20),
                    Description ="Poaya Day",
                    IsRecurring = false

                },
                new PublicHoliday
                {
                    HolidayDate = new DateTime(2025, 2, 17),
                    Description = "Presidents' Day",
                    IsRecurring = false

                },
                new PublicHoliday
                {
                    HolidayDate = new DateTime(2025, 5, 26),
                    Description = "Memorial Day",
                    IsRecurring = false
                },
                new PublicHoliday
                {
                    HolidayDate = new DateTime(DateTime.Now.Year, 7, 4),
                    Description = "Independence Day",
                    IsRecurring = true
                },
                new PublicHoliday
                {
                    HolidayDate = new DateTime(2025, 9, 1),
                    Description = "Labor Day",
                    IsRecurring = false
                },
                new PublicHoliday
                {
                    HolidayDate = new DateTime(2025, 12, 25),
                    Description = "Christmas Day",
                    IsRecurring = true
                }

            };
            _context.PublicHolidays.AddRange(holidays);
            _context.SaveChanges();
        }

    }
}
