# Post API

API RESTful para la gestión de publicaciones (posts) desarrollada en .NET 8, utilizando Entity Framework Core y SQLite. Incluye endpoints CRUD para crear, leer, actualizar y eliminar posts.

## Tecnologías utilizadas

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core 9** (Design, InMemory, Sqlite)
- **SQLite** (como base de datos)
- **Swashbuckle.AspNetCore** (para documentación Swagger/OpenAPI)

## Arquitectura

El proyecto sigue una arquitectura MVC simplificada:

- **Controllers**: Gestiona las rutas HTTP y lógica de endpoints (`Controllers/PostController.cs`).
- **Models**: Define las entidades de dominio (`Models/Post.cs`).
- **DTOs**: Objetos de transferencia de datos para entrada/salida (`Controllers/dto/CreatePost.cs`, `Controllers/dto/UpdatePost.cs`).
- **DbContext**: Contexto de EF Core para acceso a datos (`db/DbContext.cs`).

## Configuración y ejecución

1. **Clonar el repositorio**
2. **Restaurar dependencias**:
   ```bash
   dotnet restore
   ```
3. **Ejecutar migraciones (opcional)**:
   ```bash
   dotnet ef database update
   ```
4. **Ejecutar el proyecto**:
   ```bash
   dotnet run
   ```
5. Acceder a la documentación interactiva en: `https://localhost:5001/swagger`

### Configuración de la base de datos

La conexión se define en `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "DataSource=Posts.db"
}
```

## Endpoints disponibles

### Obtener todos los posts
- **GET** `/Post`
- **Descripción**: Devuelve una lista de todos los posts.
- **Respuesta**: `200 OK`, lista de objetos `Post`.

### Crear un post
- **POST** `/Post`
- **Body** (JSON):
  ```json
  {
    "title": "Título del post",
    "description": "Descripción del post"
  }
  ```
- **Respuesta**: `201 Created`, objeto `Post` creado.

### Actualizar un post
- **PUT** `/Post/{id}`
- **Body** (JSON):
  ```json
  {
    "title": "Nuevo título",
    "description": "Nueva descripción"
  }
  ```
- **Respuesta**: `200 OK`, mensaje de éxito o `404 Not Found` si no existe el post.

### Eliminar un post
- **DELETE** `/Post/{id}`
- **Respuesta**: `200 OK`, mensaje de éxito o `404 Not Found` si no existe el post.

## Modelo de datos

```csharp
public class Post {
  public int Id { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public DateTime CreateDate { get; } = DateTime.Now;
}
```

## Ejemplo de uso con curl

- **Crear un post:**
  ```bash
  curl -X POST "https://localhost:5001/Post" -H "Content-Type: application/json" -d '{"title": "Mi primer post", "description": "Contenido"}'
  ```
- **Obtener posts:**
  ```bash
  curl "https://localhost:5001/Post"
  ```
- **Actualizar un post:**
  ```bash
  curl -X PUT "https://localhost:5001/Post/1" -H "Content-Type: application/json" -d '{"title": "Actualizado", "description": "Nuevo contenido"}'
  ```
- **Eliminar un post:**
  ```bash
  curl -X DELETE "https://localhost:5001/Post/1"
  ```

## Swagger/OpenAPI

La documentación y pruebas interactivas están disponibles automáticamente en `/swagger`.

## Notas adicionales
- El proyecto utiliza migraciones de Entity Framework para la gestión de la base de datos.
- Se recomienda usar HTTPS para todas las peticiones.
- El entorno de desarrollo puede configurarse en `appsettings.Development.json`.

---
