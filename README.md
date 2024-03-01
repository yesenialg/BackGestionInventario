# BackGestionInventario

## Cómo iniciar el proyecto

1. Subir el backup de la carpeta scripts a tu sqlServer para crear la base de datos con los registros de prueba.

2. Abrir el proyecto en Visual Studio y editar el `ConnectionString` (Nombre del servidor, usuario y contraseña) que se encuentra en el `appSettings` del Api para que coincida con su base de datos. El servidor de BD debe tener habilitadas las conexiones de autenticación por usuario sqlServer para tener una conexión exitosa desde el código.

3. Configure el Api como el `Startup project` e inicie el proyecto, esto abrirá el navegador con un swagger con el que podrá enviar peticiones.
