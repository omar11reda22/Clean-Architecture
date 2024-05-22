# Clean-arch

# Overview
This is a small practice project demonstrating the use of Clean Architecture principles in a .NET 7 application. The project focuses on managing Students and Departments with a one-to-many relationship.
+ and add a new commit to authantication and autharization section using (JWT) and create 2 Endpoint (registeration - Login) and test it using postman but
+ I Add a (dot net client) using (httpclient) (Microsoft.AspNet.WebApi.Client) (windows Form as a (consumer))   
# Technologies Used
.NET 7 
Entity Framework Core 7
AutoMapper
CQRS (Command Query Responsibility Segregation)
MediatR
JWT 
WindowsForm 
# Project Structure
The project follows the Clean Architecture pattern, which is divided into several layers:

Core: contains 2 main file [Command , Query]
Data: Implements domain entities.
Infrastructure: Implements data access, external services, and any other infrastructure concerns.
WebAPI: The entry point for the application, contains controllers and presentation logic.

# Domain Models
Student , Department [one to many] 
# postman collection 
https://solar-spaceship-351710.postman.co/workspace/New-Team-Workspace~78551f72-f490-4d09-b76d-bb548cfcaff6/collection/32062280-3a415bae-beaf-4ba9-bb6b-e047f70a8dbc?action=share&creator=32062280
