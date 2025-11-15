using EmployeeManagementApp.Data.Context;
using EmployeeManagementApp.Data.seed;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity.Mvc5;

namespace EmployeeManagementApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            // Configure Unity Dependency Injection
            var container = UnityConfig.RegisterComponents();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // Seed the database with public holidays
            SeedDatabase();
        }
        private void SeedDatabase()
        {
            using (var context = new EmployeeManagementDBEntities())
            {
                var seeder = new DatabaseSeeder(context);
                seeder.SeedPublicHolidays();
            }
        }
    }
}
