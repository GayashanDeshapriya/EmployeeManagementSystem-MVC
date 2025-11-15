using EmployeeManagementApp.Data;
using EmployeeManagementApp.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;
        public EmployeeService(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        public void AddEmployee(Employee employee)
        {
            _employeeRepo.Add(employee);
            _employeeRepo.Save();
        }

        public void DeleteEmployee(int id)
        {
            _employeeRepo.Delete(id);
            _employeeRepo.Save();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeRepo.GetAll();
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeRepo.GetById(id);
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeRepo.Update(employee);
        }
    }
}
