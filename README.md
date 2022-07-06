# Deloitte_Si_7
Summer Internship FY23

An ASP.Core web app where the user logs in and uploads a pbix file and can view details of file uploaded and can retrieve it as well, the app also has an option wherein the user can upload excel files and view their data ; data visualizations and reports generated for Nike market data using Microsoft Power BI can be found in the Deloitte Group 7 Report.pbix file inside the Power_bi folder.

The screenshots of the app's screens can be found inside the screenshots folder.

How to navigate through the app is available in the Home screen of the app.

In order to get the database and the tables created follow these steps:

1.Update CS_project_authContextConnection string in appsettings.json to the host's sqlserver connection string
2.Right click on project and go to tools
3.Select NuGet package Manager and Package Manager Console
4.Once inside the console type in the commands
5.Add-Migration "first create"
6.Update-Database
