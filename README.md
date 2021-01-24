# GamesHorizon
A Web Site that someone can sell or buy old games for the price of 10$. Developed with ASP.NET Framework, using MVC, MS SQL server, and Google Authentication. 

In order for the application to start you will need to have Visual Studio 2019. 
There you can open the project using the GamesHorizon.sln file in GamesHorizon folder.

Then you will have to initialize the two Databases that are mandatory for the application. 
You can do that by executing the sql scripts in Databases folder under GamesHorizon folder.
First, you should execute the GamesHorizonDefaultUserAuthDB.sql and then the GamesHorizonDB.sql

When done with databases you should open the project on visual studio and edit the Web.Config file, altering under the <connectionStrings> tag 
the two connectionString attributes with your database's connection strings.

If you want google authentication to work you should create credentials for the application and paste them on StartUp.Auth.cs file under the App_start folder on lines 63,64. 

If everything is set up, you can run the application!
