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
            if (dataIsValid(employee))
            {
                DBContext.Employees.Add(employee);
                DBContext.SaveChanges();
                return RedirectToAction("Home");
            }

            ViewBag.govs = new SelectList(DBContext.Governments.ToList(), "id", "name");
            ViewBag.depts = new SelectList(DBContext.Departments.ToList(), "id", "name");
            ViewBag.villages = new SelectList(DBContext.villages.ToList(), "id", "name");
            return View();
        }


        public ActionResult Edit()
        {
            ViewBag.govs = new SelectList(DBContext.Governments.ToList(), "id", "name");
            ViewBag.depts = new SelectList(DBContext.Departments.ToList(), "id", "name");
            ViewBag.villages = new SelectList(DBContext.villages.ToList(), "id", "name");

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            if (dataIsValid(emp))
            {
                Employee employee = DBContext.Employees.Where(n => n.national_id == emp.national_id).FirstOrDefault();
                if (employee != null)
                {
                    employee.name = emp.name;
                    employee.national_id = emp.national_id;
                    employee.phone_number = emp.phone_number;
                    employee.age = emp.age;
                    employee.salary = emp.salary;
                    employee.married = emp.married;
                    employee.salary = emp.salary;
                    employee.gov_id = emp.gov_id;
                    employee.dept_id = emp.dept_id;
                    employee.village_id = emp.village_id;
                    DBContext.SaveChanges();
                    return RedirectToAction("Home");
                }

                ViewBag.notExistErrorMsg = "The Employee with this National ID isn't exist!";
            }


            ViewBag.govs = new SelectList(DBContext.Governments.ToList(), "id", "name");
            ViewBag.depts = new SelectList(DBContext.Departments.ToList(), "id", "name");
            ViewBag.villages = new SelectList(DBContext.villages.ToList(), "id", "name");

            return View();
        }



        // Helper Method
        private bool dataIsValid(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Department department = DBContext.Departments.Where(n => n.id == employee.dept_id).FirstOrDefault();
                village village = DBContext.villages.Where(n => n.id == employee.village_id).FirstOrDefault();

                if (department.gov_id == employee.gov_id)
                {
                    if (village.dept_id == employee.dept_id)
                    {
                        return true;
                    }
                    else
                        ViewBag.villageErrorMsg = "The Department doesn't have the selected Village";

                }
                else
                    ViewBag.deptErrorMsg = "The Goverment doesn't have the selected department";
            }
            return false;
        }


    }
}