# 🐦 DispenX Core API  

API backend para el sistema **DispenX**, encargado de recibir telemetría de dispensadores de alpiste/mijo, calcular el stock restante, gestionar alertas de bajo nivel, administrar usuarios y autenticación JWT.  

## 🧱 Arquitectura  

El proyecto sigue los principios de **Domain‑Driven Design (DDD)**, dividiendo el sistema en contextos acotados independientes:  

| Contexto | Responsabilidad | 
|----------|----------------| 
| **IAM** | Registro, login, generación de tokens JWT y hash de contraseñas. | 
| **Inventario** | Recepción de datos de sensores (peso, nivel, flujo), cálculo del porcentaje de stock y exposición del estado actual. | 
| **Notificaciones** | Evaluación de umbrales críticos y envío de alertas push cuando el stock está bajo. | 
| **Usuarios** | Perfil del dueño/cuidador y vinculación con el dispensador físico. |  

Cada contexto está organizado en capas: **Domain**, **Application**, **Infrastructure** y **Controllers**.  

## 🛠️ Stack Tecnológico  

- **.NET 9** (ASP.NET Core Web API) 
- **C# 13** 
- **Entity Framework Core** con **MySQL 8** (proveedor Pomelo) 
- **Autenticación JWT** (Bearer) 
- **Swagger** con versionado de API (v1) 
- **Rider** como IDE principal  

## ⚙️ Requisitos Previos  

1. [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) 
2. Servidor **MySQL 8** (local o remoto) con una base de datos vacía llamada `DispenX`. 
3. (Opcional) Rider, VS Code o Visual Studio 2022+. 
4. Tools de EF Core (opcional para generar migraciones manualmente):    
   ```bash    
   dotnet tool install --global dotnet-ef 
   ```

## 🚀 Instalación y Ejecución 

### 1. Clonar el repositorio 
```bash 
git clone <url-del-repo> 
cd Backend-DispenXCore.Api 
```

### 2. Configurar la conexión a la base de datos 
Edita el archivo `appsettings.json` y ajusta la cadena de conexión:  
```json 
"ConnectionStrings": {   
  "DispenXDb": "Server=localhost;Database=DispenX;User=root;Password=TU_PASSWORD;" 
} 
```
Asegúrate de que la base de datos `DispenX` exista (puede estar vacía).  

### 3. Aplicar las migraciones (automático o manual) 
El proyecto está configurado para aplicar las migraciones automáticamente al iniciar (en `Program.cs`).  

Si prefieres hacerlo manualmente:  
```bash 
dotnet ef database update 
```
(Este comando crea todas las tablas necesarias).  

### 4. Ejecutar la aplicación 
```bash 
dotnet run 
```
La API estará disponible en `https://localhost:5001` (o el puerto configurado en `launchSettings.json`).  

## 📚 Documentación de la API (Swagger) 
Una vez en ejecución, abre tu navegador en:  
```text 
https://localhost:5001/swagger 
```
Verás la UI de Swagger con todos los endpoints versión v1. Puedes autenticarte usando el botón **Authorize** e ingresar `Bearer <token>`.  

## 🔐 Autenticación y Endpoints IAM 

### Registro de usuario 
`POST /api/v1/auth/register` 
Body: 
```json
{ 
  "email": "usuario@ejemplo.com", 
  "password": "123456" 
}  
```

### Inicio de sesión 
`POST /api/v1/auth/login` 
Body: 
```json
{ 
  "email": "usuario@ejemplo.com", 
  "password": "123456" 
} 
```
Respuesta: 
```json
{ 
  "token": "eyJhbGciOi..." 
}  
```

Usa ese token en las peticiones a los demás endpoints agregando el encabezado: 
`Authorization: Bearer eyJhbGciOi...`  

### Crear perfil y vincular dispensador 
Endpoints protegidos en `/api/v1/perfil`.  

## 📦 Endpoints Principales 

| Método | Ruta | Descripción |
|--------|------|-------------|
| POST | `/api/v1/inventario/medicion` | Registra una medición (peso, nivel, flujo) |
| GET | `/api/v1/inventario/estado` | Obtiene el % de stock de todos los granos |
| POST | `/api/v1/notificaciones/evaluar` | Evalúa umbrales y envía push |
| GET | `/api/v1/notificaciones/{contenedorId}` | Lista alertas de un contenedor |
| POST | `/api/v1/perfil` | Crea el perfil de usuario |
| POST | `/api/v1/perfil/vincular-dispensador` | Asocia un dispensador al perfil |

*Nota: los endpoints de inventario y notificaciones requieren autenticación.*

## 📁 Estructura del Proyecto 

```text 
Backend-DispenXCore.Api/ 
├── Shared/                  # Kernel DDD, extensiones, middleware 
├── Infrastructure/          # DbContext único 
├── src/ 
│   ├── IAM/                 # Autenticación y JWT 
│   ├── Inventario/          # Dominio de stock y sensores 
│   ├── Notificaciones/      # Umbrales y push 
│   └── Usuarios/            # Perfiles y dispensadores 
├── Program.cs               # Configuración de la app, JWT, Swagger, migraciones 
└── appsettings.json         # Cadena de conexión y clave JWT 
```

## 🔧 Migraciones de Base de Datos 

Si necesitas crear una nueva migración después de modificar entidades:  
```bash 
dotnet ef migrations add NombreDeLaMigracion 
dotnet ef database update 
```

## 🤝 Contribuir 

Si deseas extender el sistema, respeta las capas DDD:  
- No pongas lógica de negocio en los controladores.  
- Cada contexto acotado debe ser independiente (no referenciar directamente las entidades de otro contexto, usa servicios de aplicación si es necesario).  
- Usa los Value Objects y entidades del dominio tal como están definidos.
