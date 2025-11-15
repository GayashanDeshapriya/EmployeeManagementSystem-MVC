using System;

namespace EmployeeManagementApp.Services
{
    public interface IWorkingDaysService
    {
        int CalculateWorkingDays(DateTime start, DateTime end);
    }
}
