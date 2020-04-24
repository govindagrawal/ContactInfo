# ContactInfo
Contact Information Center

The application is called as "The Contact Information Center". The application performs following Task:

01. User can Resgister and Login.
02. Login is Mandatory else only Home page is shown.
03. User is redirected to the Login page if not Logged in and tries to access Contacts page.
04. There are 2 types of views, Readonly and Editable.
05. Guest user can see only Readonly views.
06. Admin user can see Editable Views and can also perform various CRUD operations.
07. Admin user can Create, Update, Delete and Activate/Deactivate a contact.
08. Contacts Page shows the List of Contacts and has features which include pagination, sorting and searching.
09. It also has "New Contact", "Edit" and "Delete" Buttons to perform the respective operations.
10. "Name" column is a Link and when clicked, takes the user to the Details page.
11. Details page displays Contact Details and has an Activate/Deactivate button (Admin user only) to change the contact status.
12. Contact form is used to create a new contact as well edit an existing contact.


Credentials:

01. Admin
      a. Email: admin@contactinfo.com
      b. Password: Admin@123

02. Guest
      a. Email: guest@contactinfo.com
      b. Password: Guest@123


Following are the technology / features used w.r.t. this application:

01. Built using ASP.Net MVC5 and ASP.Net WebApi.
02. Used Entity Framework Code First approach as the persistence framework.
03. Used Unit of Work and Repository design patterns to communicate with the persistence framework.
04. Used Fluent Api for database validations and Data Annotations for client side validations.
05. Used Unity Container to achieve the Dependency Injection (DI) priciple.
06. Used AutoMapper to map the Domain Model with the Dtos and the ViewModels.
07. Tested the APIs using Postman.
08. Used WebApi 2 feature "IHttpActionResult" as the Api methods return type.
09. Used jQuery AJAX for calling few WebApi methods on the view.
10. Used jQuery Datatables to display the contacts list.
11. Drawn the tables using jQuery as well as Razor View HTML.
12. Used toastr to display a toast notification.
13. Used bootstrap-Bootbox for a confirmation dialog box.
14. Used both Attribute as well as Conventional Routing.
15. Implemented Authentication and Authorization.
16. Implemented Custom Error Handling and 404 error.
17. Created Unit Tests using MSTest.
18. For Deployment, used the Web Deploy feature and hosted the application using Azure.
