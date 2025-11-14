using EmployeeManagementApp.Data;
using EmployeeManagementApp.Data.Context;
using System.Collections.Generic;

namespace EmployeeManagementApp.Services
{
    public interface IHolidayService
    {
        IEnumerable<PublicHoliday> GetAllHolidays();
        PublicHoliday GetHolidayById(int id);
        void AddHoliday(PublicHoliday holiday);
        void UpdateHoliday(PublicHoliday holiday);
        void DeleteHoliday(int id);
    }
}
