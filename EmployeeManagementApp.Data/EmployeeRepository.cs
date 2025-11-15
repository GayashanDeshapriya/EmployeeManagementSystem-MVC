using EmployeeManagementApp.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementApp.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeManagementDBEntities _context;

        public EmployeeRepository(EmployeeManagementDBEntities context)
        {
            _context = context;
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
        }
        public void Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                throw new Exception($"Employee with ID {id} not found.");
            }
            _context.Employees.Remove(employee);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Employee employee)
        {
            throw new NotImplementedException();
        }
        IEnumerable<Employee> IEmployeeRepository.GetAll()
        {
            return _context.Employees.ToList();
        }

        Employee IEmployeeRepository.GetById(int id)
        {
            return _context.Employees.Find(id);
        }
    }
}
