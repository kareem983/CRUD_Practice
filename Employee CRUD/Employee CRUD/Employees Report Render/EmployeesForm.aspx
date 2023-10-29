<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesForm.aspx.cs" Inherits="Employee_CRUD.Employees_Report_Render.EmployeesForm" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div>
        <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer" ClientIDMode="Predictable" runat="server"></rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
