# VehiculoDB

Aplicacion de escritorio desarrollada en **C# WinForms con .NET 8** para gestionar propietarios, vehiculos y mantenimientos asociados.

## Tecnologias utilizadas

- C#
- .NET 8 Windows
- Windows Forms
- SQL Server
- Microsoft.Data.SqlClient
- System.Configuration.ConfigurationManager

## Estructura principal

```text
VehiculoDB/
├── Core/
│   ├── Clases/       # Entidades del dominio
│   ├── Dao/          # Acceso a datos
│   └── Lib/          # Conexion a base de datos
├── Formularios/      # Interfaces WinForms
├── App.config        # Cadena de conexion
├── Program.cs        # Punto de entrada
└── VehiculoDB.csproj # Configuracion del proyecto
```

## Requisitos

- Visual Studio 2022 o superior
- .NET 8 SDK
- SQL Server o SQL Server Express
- Base de datos llamada `VehiculosDB`

## Configuracion de la conexion

El proyecto utiliza la cadena de conexion `SqlConn` definida en `VehiculoDB/App.config`.

Configuracion local recomendada:

```xml
<add name="SqlConn"
     connectionString="Server=.;Database=VehiculosDB;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=5;MultipleActiveResultSets=True"
     providerName="Microsoft.Data.SqlClient" />
```

Si usas SQL Server Express, puedes cambiar el servidor por:

```text
Server=.\SQLEXPRESS
```

## Modulos implementados

- Gestion de propietarios
- Busqueda de vehiculos
- Registro y consulta de mantenimientos
- Acceso a datos mediante DAO
- Conexion centralizada a SQL Server

## Mejoras incluidas en la rama `optimizacion-proyecto`

- Ampliacion de `.gitignore` para evitar subir archivos de compilacion.
- Cadena de conexion mas portable.
- Capa de conexion sin `MessageBox`, separando datos de interfaz grafica.
- Correccion de busqueda por DUI en propietarios.
- Correccion de busqueda de mantenimientos por placa y tipo.
- Eliminacion de mensajes de depuracion en DAO.
- Validacion de costo, vehiculo asociado y tipo de mantenimiento antes de registrar.
- Implementacion completa de `VehiculoDao` con insertar, actualizar, eliminar, obtener por ID y listar.
- Ajustes de interfaces para permitir resultados nulos al buscar por ID.

## Recomendaciones pendientes

- Agregar el script SQL completo de la base de datos en una carpeta `database/`.
- Eliminar del historial/seguimiento los archivos ya versionados dentro de `bin/` y `obj/`.
- Completar CRUD de catalogos como tipos de mantenimiento si se requiere administrarlos desde la interfaz.
- Renombrar carpetas y formularios con errores ortograficos, por ejemplo `FromsPropietario` a `FormsPropietario`.
- Agregar pruebas manuales documentadas para cada modulo.

## Ejecucion

1. Clonar el repositorio.
2. Abrir `VehiculoDB/VehiculoDB.sln` en Visual Studio.
3. Crear/restaurar la base de datos `VehiculosDB` en SQL Server.
4. Ajustar `App.config` si el servidor SQL tiene otro nombre.
5. Ejecutar el proyecto desde Visual Studio.
