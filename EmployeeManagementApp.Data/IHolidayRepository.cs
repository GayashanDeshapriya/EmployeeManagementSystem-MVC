using EmployeeManagementApp.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementApp.Data
{
    public interface IHolidayRepository
    {
        IEnumerable<PublicHoliday> GetAll();
        PublicHoliday GetById(int id);
        void Add(PublicHoliday holiday);
        void Update(PublicHoliday holiday);
        void Delete(int id);
        void Save();
    }
}
