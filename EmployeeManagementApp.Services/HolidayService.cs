using EmployeeManagementApp.Data;
using EmployeeManagementApp.Data.Context;
using System.Collections;
using System.Collections.Generic;

namespace EmployeeManagementApp.Services
{
    public class HolidayService : IHolidayService
    {
        private readonly IHolidayRepository _holidayRepo;
        public HolidayService(IHolidayRepository holidayRepo)
        {
            _holidayRepo = holidayRepo;
        }

        public void AddHoliday(PublicHoliday holiday)
        {
            _holidayRepo.Add(holiday);
            _holidayRepo.Save();
        }

        public void DeleteHoliday(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PublicHoliday> GetAllHolidays()
        {
              return _holidayRepo.GetAll();
        }

        public PublicHoliday GetHolidayById(int id)
        {
            return _holidayRepo.GetById(id);
        }

        public void UpdateHoliday(PublicHoliday holiday)
        {
            _holidayRepo.Update(holiday);
            _holidayRepo.Save();
        }
    }
}
