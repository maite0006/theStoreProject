# e-Store Backend (.NET)

## 📌 Description
Backend application for an e-commerce system that manages products, orders, and users, including payment processing integration.

## 🎯 Objective
Provide a structured API to handle business logic related to product management, order processing, and payment workflows.

## 🛠️ Technologies
- .NET / ASP.NET
- C#
- SQL Server
- JWT Authentication

## 🏗️ Architecture
The system is structured using a layered architecture with clear separation of responsibilities:

- **API Layer**: Handles HTTP requests and responses  
- **Application Layer**: Coordinates use cases and application workflows  
- **Business Logic Layer**: Contains core domain rules and validations  
- **Data Access Layer**: Manages persistence and database interactions  

It follows separation of concerns, using DTOs to decouple internal models from external contracts.

## ⚙️ Features
- Product and order management  
- Business logic implementation for order workflows  
- Integration with payment gateway (Mercado Pago)  
- Webhook handling for asynchronous payment updates  
- Data validation and error handling  
- Authentication and authorization using JWT  

## 🔌 Integrations
- Mercado Pago payment gateway  
  - Payment processing  
  - Webhook implementation for status updates  

## ▶️ How to Run
- Clone repository  
- Configure database  
- Set environment variables (JWT, payment credentials)  
- Run project using Visual Studio  
