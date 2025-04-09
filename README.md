# UIHCEmployeeAPI

Author: James Scott

This project includes an ASP Core Web Api version 9, and should be run in Visual Studio 2022 or later.

To call this api, there is an ASP Razor (.cshtml) file under /Pages/index.cshtml.  You will want to browse to that page within Visual Studio's localhost web server.

That will include a receipt upload form.  Clicking "Add Receipt" button will submit a fetch request to the api endpoint (/api/employeereceipts) and trigger the PostEmployeeReceipt controller method.  This method accepts an EmployeeReceipt model and uses Entity Framework to commit it to a Microsoft SQL local db, as defined in the appsettings.json file.

To create the database, within Visual Studio, go to Tools -> Package Manager Console.  In the console window, run command "Update-Database".  This should call an initial create migration that will run sql scripts to create the UIHCEmployees database and EmployeeReceipt table.  The "EmployeeReceipt" table contains the data columns associated with a submitted receipt (id (primary key), EmployeeID, Date, Amount, Description, ReceiptFileName, and Receipt.  The Receipt column stores the actual receipt file data.

Note, in this table there is an EmployeeID that is defaulted to 1 in the web api post, but in a real application, this will be the primary key from an employee table that stores all employees.  The population of the employee table is outside the scope of this functionality.
