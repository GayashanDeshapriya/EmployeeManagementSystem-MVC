using EmployeeManagementApp.Data.Context;
using EmployeeManagementApp.Services;
using System;
using System.Web.Mvc;

namespace EmployeeManagementApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }
        public ActionResult Employee()
        {
            var employees = _service.GetAllEmployees();
            return View(employees);
        }

        [HttpPost]
        public ActionResult Create(Employee model)
        {
            if (!ModelState.IsValid)
            {
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = false, message = "Validation failed. Please check your inputs." });
                }
                return View(model);
            }

            try
            {

                model.CreatedAt = DateTime.Now;
                model.CreatedBy = "System";
                _service.AddEmployee(model);

                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true, message = "Employee created successfully!" });
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = false, message = "Error: " + ex.Message });
                }
                ModelState.AddModelError("", "An error occurred while creating the employee.");
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult GetEmployee(int id)
        {
            try
            {
                var employee = _service.GetEmployeeById(id);
                if (employee == null)
                {
                    return Json(new { success = false, message = "Employee not found." }, JsonRequestBehavior.AllowGet);
                }

                return Json(new
                {
                    success = true,
                    data = new
                    {
                        employeeId = employee.EmployeeId,
                        name = employee.Name,
                        email = employee.Email,
                        jobPosition = employee.JobPosition
                    }
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Update(Employee model)
        {
            if (!ModelState.IsValid)
            {
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = false, message = "Validation failed. Please check your inputs." });
                }
                return View(model);
            }

            try
            {
                var existingEmployee = _service.GetEmployeeById(model.EmployeeId);
                if (existingEmployee == null)
                {
                    if (Request.IsAjaxRequest())
                    {
                        return Json(new { success = false, message = "Employee not found." });
                    }
                    return RedirectToAction("Employee");
                }

                // Update only the editable fields
                existingEmployee.Name = model.Name;
                existingEmployee.Email = model.Email;
                existingEmployee.JobPosition = model.JobPosition;
                existingEmployee.UpdatedAt = DateTime.Now;
                existingEmployee.UpdatedBy = "System";

                _service.UpdateEmployee(existingEmployee);

                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true, message = "Employee updated successfully!" });
                }
                return RedirectToAction("Employee");
            }
            catch (Exception ex)
            {
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = false, message = "Error: " + ex.Message });
                }
                ModelState.AddModelError("", "An error occurred while updating the employee.");
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _service.DeleteEmployee(id);
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true, message = "Employee deleted successfully!" }, JsonRequestBehavior.AllowGet);
                }
                return RedirectToAction("Employee");
            }
            catch (Exception ex)
            {
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = false, message = "Error: " + ex.Message }, JsonRequestBehavior.AllowGet);
                }
                ModelState.AddModelError("", "An error occurred while deleting the employee.");
                return RedirectToAction("Employee");
            }
        }
    }
}