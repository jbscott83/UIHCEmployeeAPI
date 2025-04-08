# UIHCEmployeeAPI

This project includes an ASP Core Web Api version 9.

To call this api, there is a .cshtml file under /Pages/index.cshtml.  You will want to run that in a browser.

Index.cshtml is a Razor page that will include a receipt upload form.  Clicking "Add Receipt" button will submit a fetch request to the api endpoint (/api/employeereceipts) and trigger the PostEmployeeReceipt controller method.  This method accepts an EmployeeReceipt model and uses Entity Framework to commit it to a Microsoft SQL local db, as defined in the appsettings.json file.

The database is named UIHCEmployees.  There is a table named "EmployeeReceipt" that will contain the data columns associated with a submitted receipt (id (primary key), EmployeeID, Date, Amount, Description, ReceiptFileName, and Receipt.  The Receipt column stores the actual receipt file data.

Note, in this table there is an EmployeeID that is defaulted to 1 in the web api post, but in a real application, this will be the primary key from an employee table that stores all employees.  The population of the employee table is outside the scope of this functionality.
