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
