using EmployeeManagementApp.Data;
using EmployeeManagementApp.Data.Context;
using EmployeeManagementApp.Services;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;

namespace EmployeeManagementApp
{
    public static class UnityConfig
    {
        public static IUnityContainer RegisterComponents()
        {
			var container = new UnityContainer();

            // Register DbContext with per-request lifetime
            container.RegisterType<EmployeeManagementDBEntities>(new HierarchicalLifetimeManager());

            // Register Repositories
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<IHolidayRepository, HolidayRepository>();

            // Register Services
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<IHolidayService, HolidayService>();
            container.RegisterType<IWorkingDaysService, WorkingDaysService>();

            return container;

        }
    }
}