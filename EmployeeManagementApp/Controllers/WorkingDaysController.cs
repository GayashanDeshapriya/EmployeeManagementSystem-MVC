using EmployeeManagementApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementApp.Controllers
{
    
    public class WorkingDaysController : Controller
    {
        private readonly IWorkingDaysService _workingDaysService;

        public WorkingDaysController(IWorkingDaysService workingDaysService)
        {
            _workingDaysService = workingDaysService;
        }
        // GET: WorkingDays
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(DateTime startDate, DateTime endDate)
        {
            try
            {
                int workingDays = _workingDaysService.CalculateWorkingDays(startDate, endDate);
                return Json(new { success = true, workingDays = workingDays });
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }
    }
}