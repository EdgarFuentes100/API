# API Productos

API REST para gestionar productos y sus tipos asociados usando ASP.NET Core y Entity Framework Core.

---

## Descripción

Esta API permite crear, consultar, actualizar y eliminar productos.  
Cada producto está relacionado con un tipo de producto.
Tambien permite crear un Tipo de producto, necesario para crear un producto nuevo

---

## Tecnologías

- ASP.NET Core Web API  
- Entity Framework Core  
- Base de datos SQL Server

---

## Cómo usar

1. Clona el repositorio:

   git clone https://github.com/EdgarFuentes100/API.git


2. Configurar la cadena de conexión
Edita el archivo `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;database=TuBaseDeDatos;user=root;password=TuPassword;"
  }
}

3. Ejecutar migraciones y correr la API

   add-migration

   update-database

   Nota: Si ya hay migraciones, borrarlas y ejecutarlas una nueva

4. Acceder a la documentación Swagger

   https://localhost:7017/swagger

5. Endpoints disponibles

                        PRODUCTS
| Método | Ruta                                      | Descripción                     |
| ------ | ----------------------------------------- | ------------------------------- |
| GET    | `/api/Products/ListaDeProductos`          | Lista todos los productos       |
| GET    | `/api/Products/ObtenerProductoPorId/{id}` | Obtiene producto por ID         |
| POST   | `/api/Products/CrearProducto`             | Crea un nuevo producto          |
| PUT    | `/api/Products/ActualizarProducto/{id}`   | Actualiza un producto existente |
| DELETE | `/api/Products/EliminarProducto/{id}`     | Elimina un producto por ID      |

                       TIPO PRODUCTO
| Método | Ruta                                      | Descripción                     |
| ------ | ----------------------------------------- | ------------------------------- |
| GET    | `/api/Products/ListaDeTipoProducto`       | Lista todos los tipo productos  |
| GET    | `/api/Products/ObtenerTipoPorId/{id}`     | Obtiene tipo producto por ID    |
| POST   | `/api/Products/CrearTipoProducto`         | Crea un nuevo tipo producto     |

Ejemplo de uso
POST /api/Products/CrearProducto

-------PRODUCTS------
   {
     "name": "Laptop",
     "description": "HP",
     "precio": 100,
     "stock": 10,
     "tipoProductoId": 1
   }

-------TIPO--PRODUCTO---
   {
     "name": "Tecnologia",
   }
