using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employee_CRUD.Models;

namespace Employee_CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private employeeContext DBContext = new employeeContext();

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.govs = new SelectList(DBContext.Governments.ToList(), "id", "name");
            ViewBag.depts = new SelectList(DBContext.Departments.ToList(), "id", "name");
            ViewBag.villages = new SelectList(DBContext.villages.ToList(), "id", "name");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Department department = DBContext.Departments.Where(n => n.id == employee.dept_id).FirstOrDefault();
                village village = DBContext.villages.Where(n => n.id == employee.village_id).FirstOrDefault();

                if (department.gov_id == employee.gov_id)
                {
                    if (village.dept_id == employee.dept_id)
                    {
                       /* DBContext.Employees.Add(employee);
                        DBContext.SaveChanges();
                        */return RedirectToAction("Home");
                    }
                    else
                        ViewBag.villageErrorMsg = "The Department doesn't have the selected Village";
                    
                }
                else
                    ViewBag.deptErrorMsg = "The Goverment doesn't have the selected department";
            }

            ViewBag.govs = new SelectList(DBContext.Governments.ToList(), "id", "name");
            ViewBag.depts = new SelectList(DBContext.Departments.ToList(), "id", "name");
            ViewBag.villages = new SelectList(DBContext.villages.ToList(), "id", "name");
            return View();
        }



    }
}