# SolsticeApi

API Built with:
C#
ASP.NET Core 2.0 MVC
Entity Framework Core
SQL Server 2016
IIS 10
Command Design Pattern
Dependency Injection

This is a simple api with loosly coupled components, easy to expand and modify.
The use of Dependency Injection and the Command Design Pattern makes it easy to write unit test for the application.

To Do List:
Add authentication
Add integration with Swagger(Open API) for documentation
Add functionality to upload pictures
Add JSON-PATCH option


This application can be tested using Visual Studio Community 2017 and Postman, a popular application to develop and test APIs.

Visual Studio Community 2017: www.visualstudio.com/vs/community/
Postman: https://www.getpostman.com

How to Test:
1. Download or clone project.
2. Open it on Visual Studio.
3. Launch the application with Ctrl + F5.
4. Test the http requests.

How to consume this API (see as raw):

Type of Request:    URL:                                                Effect:
GET                 http://localhost:#####/api/contact                  Returns all Contacts
GET                 http://localhost:#####/api/contact/5                Returns Contact with id 5


must provide a string in the url.
GET                 http://localhost:#####/api/contact/location/denver  Returns all contacts with the word "denver" in their address 


must provide a phone number or segment of phone number without spaces or characters.
GET                 http://localhost:#####/api/contact/phone/12345      Return all contacts with the secuence 12345 on one of their phones      


must send the contact information in the body of the request as Json object. missing fields will be set to null.
POST                http://localhost:#####/api/contact     Creates a new contact and returns it with a newly asigned id


must provide contact information in the body of the request as Json object and an id in the url.
all of the contact's data must be provided otherwise fields will be set to null.
PATCH               http://localhost:#####/api/contact/3                 Updates the contact contact record of id 3

must provide id number in the url
DEL                 http://localhost:#####/api/contact/7                 Deletes contact with id 7



















