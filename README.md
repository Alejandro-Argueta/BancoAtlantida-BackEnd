# Sistema Backend - Prueba Técnica
### Descripcion del Proyecto
Es una aplicación desarrollada en ASP.NET C# que proporciona una API 
para manejar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) en una base de datos.
Esta API utiliza conexiones a la base de datos para realizar operaciones de almacenamiento y recuperación de datos.
<br><br>

## Características Principales
- Desarrollado en ASP.NET C#.
- Proporciona una API HTTP para interactuar con la base de datos.
- Implementa operaciones CRUD para administrar datos.
- Utiliza el patrón Repository para la capa de acceso a datos.
- Utiliza AutoMapper para mapear entre modelos y DTOs (Objetos de Transferencia de Datos).
- Ofrece respuestas HTTP adecuadas para diferentes escenarios (éxito, error, no encontrado, etc.).
- Utiliza Entity Framework Core como ORM (Mapeo Objeto-Relacional) para interactuar con la base de datos.
<br><br>

## Tecnologías Utilizadas
- ASP.NET Core
- C#
- Entity Framework Core
- AutoMapper
- SQL Server (o el motor de base de datos de su elección)
<br><br>

## Peticiones HTTP
### Tabla Users

>### Index
- Método: GET
- Endpoint: `https://localhost:44310/api/Users`
- Descripción: Obtiene todos los usuarios registrados en el sistema.

>### Create
- Método: POST
- Endpoint: `https://localhost:44310/api/Users`
- Body:
```
{
  "name": "string",
  "lastName": "string"
}
```
- Descripción: Crea un nuevo usuario con el nombre y apellido especificados.
<br><br>

>### Show
- Método: GET
- Endpoint: `https://localhost:44310/api/Users/{id}`
- Descripción: Obtiene los detalles de un usuario específico por su ID.
<br><br>

>### Update
- Método: PUT
- Endpoint: `https://localhost:44310/api/Users/{id}`
- Body:
```
{
  "name": "string",
  "lastName": "string"
}
```
- Descripción: Actualiza los detalles de un usuario existente identificado por su ID.
<br><br>

>### Delete
- Método: DELETE
- Endpoint: `https://localhost:44310/api/Users/{id}`
- Descripción: Elimina un usuario específico por su ID.
<br><br>

### Tabla TransactionType
>### Index
- Método: GET
- Endpoint: `https://localhost:44310/api/TransactionType`
- Descripción: Obtiene todos los tipos de transacción registrados en el sistema.
<br><br>

>### Create
- Método: POST
- Endpoint: `https://localhost:44310/api/TransactionType`
- Body:
```
{
  "name": "string"
}
```
Descripción: Crea un nuevo tipo de transacción con el nombre especificado.
<br><br>

>### Show
- Método: GET
- Endpoint: `https://localhost:44310/api/TransactionType/{id}`
- Descripción: Obtiene los detalles de un tipo de transacción específico por su ID.
<br><br>

>### Update
- Método: PUT
- Endpoint: `https://localhost:44310/api/TransactionType/{id}`
- Body:
```
{
  "name": "string"
}
```
- Descripción: Actualiza los detalles de un tipo de transacción existente identificado por su ID.
<br><br>

>### Delete
- Método: DELETE
- Endpoint: `https://localhost:44310/api/TransactionType/{id}`
- Descripción: Elimina un tipo de transacción específico por su ID.
<br><br>

### Tabla Transactions
>### Index
- Método: GET
- Endpoint: `https://localhost:44310/api/Transaction`
- Descripción: Obtiene todas las transacciones registradas en el sistema.
<br><br>

>### Create
- Método: POST
- Endpoint: `https://localhost:44310/api/Transaction?transactionId={id}&creditCardId={id}`
- Body:
```
{
  "date": "date",
  "description": "string",
  "amount": "decimal"
}
```
- Descripción: Crea una nueva transacción con la fecha, descripción y monto especificados, asociada a una tarjeta de crédito y a un tipo de transacción mediante sus IDs.
<br><br>

>### Show
- Método: GET
- Endpoint: `https://localhost:44310/api/Transaction/{id}`
- Descripción: Obtiene los detalles de una transacción específica por su ID.
<br><br>

>### Update
- Método: PUT
- Endpoint: `https://localhost:44310/api/Transaction/{id}`
- Body:
```
{
  "date": "date",
  "description": "string",
  "amount": "decimal"
}
```
- Descripción: Actualiza los detalles de una transacción existente identificada por su ID.
<br><br>

>### Delete
- Método: DELETE
- Endpoint: `https://localhost:44310/api/Transaction/{id}`
- Descripción: Elimina una transacción específica por su ID.
<br><br>

### Tabla CreditCard
>### Index
- Método: GET
- Endpoint: `https://localhost:44310/api/CreditCard`
- Descripción: Obtiene todas las tarjetas de crédito registradas en el sistema.
<br><br>

>### Show
- Método: GET
- Endpoint: `https://localhost:44310/api/CreditCard/{id}`
- Descripción: Obtiene los detalles de una tarjeta de crédito específica por su ID.
<br><br>

>### Delete
- Método: DELETE
- Endpoint: `https://localhost:44310/api/CreditCard/{id}`
- Descripción: Elimina una tarjeta de crédito específica por su ID.
