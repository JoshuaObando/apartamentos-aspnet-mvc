# apartmentos-aspnet-mvc

Web application for managing apartment rentals, built with ASP.NET Core MVC and SQL Server.

## 🏘️ Apartment Rental Management System

This project is a web-based system for handling apartment rentals. It was created using ASP.NET Core MVC and SQL Server. It includes role-based logic for managing rental transactions, tenants, and apartment availability.

## 🚀 Features

- Add, edit, and remove apartment listings
- Register new tenants
- Track apartment rental status (Available / Rented)
- Perform rental and return transactions
- View filtered apartment lists based on status
- Data validation and UI feedback

## 🛠️ Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- C#
- Bootstrap (for styling)

## 📁 Folder Structure

```
Apartmentos/
├── Apartmentos.BL/         # Business logic (rental operations)
├── Apartmentos.DA/         # Data access logic (DbContext)
├── Apartmentos.Model/      # Entity models
└── Apartmentos.UI/         # User interface (controllers, views, wwwroot)
```

## 🧑‍💻 How to Run

1. Clone the repository:
   ```
   git clone https://github.com/JoshuaObando/apartamentos-aspnet-mvc.git
   ```

2. Open the solution in Visual Studio.

3. Update the SQL Server connection string in `appsettings.json` to match your local setup.

4. Apply migrations or create the database manually if needed.

5. Run the application.

## 👨‍🎓 Authors

- Joshua Obando González

## 📌 Notes

This project was developed as a learning experience in academic settings and demonstrates use of MVC architecture, Entity Framework, and relational data modeling.


# 🏢 apartamentos-aspnet-mvc

Aplicación web para la gestión de alquileres de apartamentos, construida con ASP.NET Core MVC y SQL Server.

## 📋 Descripción

Este proyecto es una aplicación ASP.NET Core MVC creada para administrar el alquiler de apartamentos. Incluye funcionalidades para listar, registrar, editar y eliminar información sobre los apartamentos, además de gestionar sus estados (Disponible o Alquilado) y controlar las operaciones básicas del sistema.

## 🧩 Funcionalidades

- CRUD de apartamentos (Crear, Leer, Actualizar, Eliminar)
- Gestión de estado de apartamentos (Disponible / Alquilado)
- Filtrado de apartamentos disponibles y alquilados
- Control de lógica de negocio mediante capas (UI, DA, BL, Model)
- Arquitectura MVC y separación por capas

## 🛠️ Tecnologías utilizadas

- ASP.NET Core MVC
- C#
- SQL Server
- Entity Framework Core
- Visual Studio 2022
- Razor Pages
- HTML y CSS
- LINQ

## 🗂️ Estructura del proyecto

```
AlquilerApartamentos/
│
├── AlquilerApartamentos.BL        # Lógica de negocio
├── AlquilerApartamentos.DA        # Acceso a datos (Data Access)
├── AlquilerApartamentos.Model     # Modelos (entidades)
├── AlquilerApartamentos.UI        # Interfaz de usuario (MVC)
└── AlquilerApartamentos.sln       # Archivo de solución
```

## 🚀 Cómo ejecutar el proyecto

1. Clona el repositorio:

   ```
   git clone https://github.com/JoshuaObando/apartamentos-aspnet-mvc.git
   ```

2. Abre el archivo `AlquilerApartamentos.sln` con Visual Studio.

3. Asegúrate de que el proyecto UI sea el predeterminado para iniciar.

4. Configura la conexión a la base de datos en `appsettings.json`.

5. Ejecuta el proyecto.

## 👥 Autor

- Joshua David Obando González  
  Estudiante de Ciencias de la Computación en la UCR

---

> Este proyecto fue desarrollado con fines académicos y representa una práctica completa de ASP.NET Core MVC.
