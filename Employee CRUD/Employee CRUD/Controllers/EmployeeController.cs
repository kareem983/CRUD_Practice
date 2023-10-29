using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employee_CRUD.Models;
using System.Data.Entity;
using System.Transactions;
using MvcReportViewer;
using Microsoft.Reporting.WebForms;
using System.Web.UI.WebControls;

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
            refreshLocationData();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            using (var scope = DBContext.Database.BeginTransaction())
            {
                try
                {
                    if (dataIsValid(employee))
                    {
                        Employee serarchedEmp = DBContext.Employees.Where(n => n.national_id == employee.national_id).FirstOrDefault();
                        if (serarchedEmp == null)
                        {
                            DBContext.Employees.Add(employee);
                            DBContext.SaveChanges();
                            scope.Commit();
                            return RedirectToAction("Home");
                        }
                        ViewBag.ExistErrorMsg = "The Employee with this National ID already exist!";
                    }
                }
                catch(Exception)
                {
                    scope.Rollback();
                }
            }

            refreshLocationData();
            return View();
        }


        public ActionResult Edit()
        {
            refreshLocationData();
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            using (var scope = DBContext.Database.BeginTransaction())
            {
                try
                {
                    if (dataIsValid(emp))
                    {
                        Employee employee = DBContext.Employees.Where(n => n.national_id == emp.national_id).FirstOrDefault();
                        if (employee != null)
                        {
                            copyEmployee(employee, emp);
                            DBContext.SaveChanges();
                            scope.Commit();
                            return RedirectToAction("Home");
                        }
                        ViewBag.notExistErrorMsg = "The Employee with this National ID isn't exist!";
                    }
                }
                catch(Exception)
                {
                    scope.Rollback();
                }
            }

            refreshLocationData();
            return View();
        }

        public ActionResult Admin(String nationalId="0")
        {
            using (var scope = DBContext.Database.BeginTransaction())
            {
                try
                {
                    if (nationalId != "0")
                    {
                        Employee employee = DBContext.Employees.Where(n => n.national_id == nationalId).FirstOrDefault();
                        DBContext.Employees.Remove(employee);
                        DBContext.SaveChanges();
                        scope.Commit();
                        return RedirectToAction("Home");
                    }
                }
                catch(Exception)
                {
                    scope.Rollback();
                }
            }
            return View(DBContext.Employees.ToList());
        }

       public ActionResult RDLCReport()
       {
            return View();
       }



        // Helper Methods
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

        public void refreshLocationData()
        {
            ViewBag.govs = new SelectList(DBContext.Governments.ToList(), "id", "name");
            ViewBag.depts = new SelectList(DBContext.Departments.ToList(), "id", "name");
            ViewBag.villages = new SelectList(DBContext.villages.ToList(), "id", "name");
        }
        public void copyEmployee(Employee employee, Employee emp)
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
        }


    }
}