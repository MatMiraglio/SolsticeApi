# SolsticeApi

API Built with:
1. C#
2. ASP.NET Core 2.0 MVC
3. Entity Framework Core
4. SQL Server 2016
5. IIS 10
6. Command Design Pattern
7. Dependency Injection

This is a simple api with loosly coupled components, easy to expand and modify.


The use of Dependency Injection and the Command Design Pattern makes it easy to write unit test for the application.

To Do List:
1. Add authentication
2. Add integration with Swagger(Open API) for documentation
3. Add functionality to upload pictures
4. Add JSON-PATCH option


This application can be tested using Visual Studio Community 2017 and Postman, a popular application to develop and test APIs.

Visual Studio Community 2017: www.visualstudio.com/vs/community/

Postman: https://www.getpostman.com

How to Test:
1. Download or clone project.
2. Open it on Visual Studio.
3. Launch the application with Ctrl + F5.
4. Test the http requests.

How to consume this API (see as raw):

Type of Request:            URL:                                     Effect:
GET      rootdomain/api/contact                   Returns all Contacts
GET      rootdomain/api/contact/5                 Returns Contact with id 5


must provide a string in the url with the complete or partial address/city/state.
GET      rootdomain/api/contact/location/denver   Returns all contacts that contain "denver" in their address 


must provide a phone number or segment of phone number without spaces or characters.
GET      rootdomain/api/contact/phone/12345       Return all contacts with the secuence 12345 on one of their phones      


must send the contact information in the body of the request as Json object. missing fields will be set to null.
POST     rootdomain/api/contact                   Creates a new contact and returns it with a newly asigned id


must provide contact information in the body of the request as Json object and an id in the url.
all of the contact's data must be provided otherwise fields will be set to null.
PATCH     rootdomain/api/contact/3                Updates the contact contact record of id 3


must provide id number in the url
DEL       rootdomain/api/contact/7                Deletes contact with id 7 and returns all the contact data that was deleted



















