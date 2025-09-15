# ProductsAPI

Este proyecto es un servicio de gestión de productos desarrollado en .NET 8.0. Proporciona endpoints para consulta paginada de productos utilizando Entity Framework Core y una arquitectura limpia basada en capas.

## Estructura del proyecto
- **ProductsApi.Api**: API principal con los controladores y configuración (incluye Dockerfile).
- **ProductsApi.Application**: Lógica de negocio y casos de uso.
- **ProductsApi.Domain**: Entidades y abstracciones del dominio.
- **ProductsApi.Infrastructure**: Implementaciones concretas (repositorios, migraciones, configuración).

## Características
- Consulta paginada de productos
- Arquitectura limpia y desacoplada
- Configuración por entorno (`appsettings.json` y `appsettings.Development.json`)
- Listo para despliegue en Docker

## Requisitos
- .NET 8.0 SDK
- Git
- SQL Server (local o remoto)

## Instalación
1. Clona el repositorio:
   ```powershell
   git clone https://github.com/Victor-Manuel-David/ProductsAPI.git
   ```
2. Restaura los paquetes:
   ```powershell
   dotnet restore
   ```
3. Aplica las migraciones (opcional, si usas base de datos local):
   ```powershell
   dotnet ef database update --project ProductsApi.Infrastructure
   ```
4. Ejecuta la API:
   ```powershell
   dotnet run --project ProductsApi.Api
   ```

## Uso
- Endpoint principal: `GET /api/products`
  - Permite obtener la lista paginada de productos mediante parámetros `page` y `pageSize`.

## Uso con Docker
1. Construye la imagen:
   ```powershell
   docker build -t productsapi .
   ```
2. Ejecuta el contenedor:
   ```powershell
   docker run -p 5000:80 productsapi
   ```

## Configuración
- Variables de conexión y otros parámetros en `appsettings.json` y `appsettings.Development.json`.
- Configuración de puertos y perfiles en `Properties/launchSettings.json`.

## Migraciones y base de datos
Las migraciones de Entity Framework se encuentran en `ProductsApi.Infrastructure/Migrations`.
```

