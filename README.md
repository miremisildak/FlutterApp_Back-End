#### FlutterApp_Back-End
## This project is the back-end part of the mobile application we make as a finishing project.

> - Proje marketler arası bir sosyal ağ gibi düşünülmüştür. 
> - The project is thought of as an inter-grocery social network.
> - For login, the user can log in to the system by creating a username and password.
> - It will install the products they come across in the markets through the profile they create and will allow them to be aware of the prices and discounts of their other users.
> - Users can see how much of the products they want in which market through the homepage.

## Below are the application pictures.



 >   ![a](https://user-images.githubusercontent.com/58594933/162574098-f8d4004a-9694-4472-b9bc-f3e835206d94.png)   ![Ekran Görüntüsü (220)](https://user-images.githubusercontent.com/58594933/162574239-a5d2142b-e17a-4d92-8388-7d6b5069e60c.png)
    
 >   ![Ekran Görüntüsü (221)](https://user-images.githubusercontent.com/58594933/162574319-348a9987-7f6f-4c86-afd3-dd1a9939e7f4.png)   ![Ekran Görüntüsü (223)](https://user-images.githubusercontent.com/58594933/162574468-71c05022-b499-4c53-8641-92f40bc73635.png)
 


## Layers
> - Core : The core layer of the project is used for universal operations.
> - DataAccess : It is the layer that connects the project with the Database.
> - Entities: Our tables in the database have been created as objects in our project. It also contains DTO objects.
> - Business : It is the business layer of our project. Various business rules; Data controls, validations and authorization controls
> - WebAPI : It is the Restful API Layer of the project. Known methods: Get, Post, Put, Delete

## Structure
> - The project was developed in C#, in accordance with the multi-layered architecture and SOLID principles. 
 CRUD operations were performed using the Entity Framework.
MSSQL Localdb was used for database in the project. 
This system includes authentication and authorization. 
Users can only perform transactions for which they are authorized. 
Implementations of JWT; Transaction, Cache, Validation and Performance aspects have been implemented. 
Fluent Validation support for Validation, Autofac support for IoC added. 
> - The project includes CRUD operations for user,  product, product images,operations claim, user operation claims.Product add is carried out according to certain business rules.

## Used Technologies
> - Restful API
> - Result Types
> - Interceptor
> - Autofac
> - AOP, Aspect Oriented Programming
> - Caching
> - Performance
> - Transaction
> - Validation
> - Fluent Validation
> - Cache Management
> - JWT Authentication
> - Repository Design Pattern
> - Cross Cutting Concerns
> - Caching
> - Validation
> - Extensions
> - Claim
> - Exception Middleware
> - Service Collection
> - Error Handling
> - Validation Error Details






