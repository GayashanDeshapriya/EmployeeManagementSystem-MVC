using EmployeeManagementApp.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementApp.Data
{
    public class HolidayRepository : IHolidayRepository
    {
        private readonly EmployeeManagementDBEntities _context;
        public HolidayRepository(EmployeeManagementDBEntities context)
        {
            _context = context;
        }

        public void Add(PublicHoliday holiday)
        {
            _context.PublicHolidays.Add(holiday);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PublicHoliday> GetAll()
        {
            return _context.PublicHolidays.ToList();
        }

        public PublicHoliday GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(PublicHoliday holiday)
        {
            var existingHoliday = _context.PublicHolidays.Find(holiday.HolidayId);
            if (existingHoliday != null)
            {
                _context.Entry(existingHoliday).CurrentValues.SetValues(holiday);
            }
        }
    }
}
