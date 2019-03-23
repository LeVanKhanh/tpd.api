============= Appying =============

0. .Net Core 2.2
1. Swagger
2. DependencyInjection
3. Elmah
4. SignalR
5. CQRS
6. EFCore
7. Fluent API
8. Repository/ Unit of Work
9. SignalR
10. Bulk Extension
11. Timer

===================================================

============= How To Run =============

1. Set Tpd.Api.Example.Interface as start up project.
2. Change the connection string in file connectionstrings.json under project Tpd.Api.Example.Interface.
3. Run EF command in file EFCommands.txt in folder Appendices.
4. Ctr + F5.

==================================================

============= Meaning of each project =============

1. *.Database :		The project for defining an database.
		- Entity classes, DBContext
		- DB relations, Constraints.
2. *.DataAccess:	The project for accessing the database.
		- Repository
		- Unit of Work
3. *.Service		The project for doing business logic.
		- CQRS
4. *.Interface		The project for communicating with clients
5. *.Share			The project for sharing data/ component across projects
6. *.DataTransferObject:		The project for defining objects for transferring data across projects.
7. Utility:		The libs for resusing, sharing to all projects.
8. Core:		Core Libs for reusing to create a new project.
9. Example:		Example for real implementation.

==================================================

============= References =============

Create a web API with ASP.NET Core MVC
https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.2&tabs=visual-studio

Getting Started with Entity Framework Core
https://docs.microsoft.com/en-us/ef/core/get-started/

Clean Architecture with ASP.NET Core
https://www.youtube.com/watch?v=_lwCVE_XgqI

Command and Query Responsibility Segregation (CQRS) pattern
https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs

Best Practices:
https://code-maze.com/aspnetcore-webapi-best-practices/
https://code-maze.com/top-rest-api-best-practices/

Global Error Handling in ASP.NET Core Web API
https://code-maze.com/global-error-handling-aspnetcore/

Implementing Action Filters in ASP.NET Core
https://code-maze.com/action-filters-aspnetcore/

Dependency injection in ASP.NET Core
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.2

Get started with Swashbuckle and ASP.NET Core
https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.2&tabs=visual-studio

ElmahCore - Log exception
https://www.nuget.org/packages/ElmahCore/#

.NET Design Patterns
https://www.dofactory.com/net/design-patterns

SOLID principles
https://www.c-sharpcorner.com/UploadFile/damubetha/solid-principles-in-C-Sharp/

POCO
https://www.c-sharpcorner.com/UploadFile/5d065a/poco-classes-in-entity-framework/

Fluent API
https://docs.microsoft.com/en-us/ef/core/modeling/relationships
http://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx

==================================================
