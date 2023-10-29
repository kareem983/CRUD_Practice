using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Employee_CRUD.Models;

namespace Employee_CRUD.Employees_Report_Render
{
    public partial class EmployeesForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                employeeContext DBContext = new employeeContext();
                ReportViewer.ProcessingMode = ProcessingMode.Local;
                ReportViewer.SizeToReportContent = true;
                ReportViewer.Width = Unit.Percentage(900);
                ReportViewer.Height = Unit.Percentage(900);
                ReportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\EmployeesReport.rdlc";
                ReportViewer.LocalReport.DataSources.Clear();
                ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("EmployeeSet", DBContext.Employees.ToList()));
                ReportViewer.LocalReport.Refresh();
            }
            
        }
    }
}