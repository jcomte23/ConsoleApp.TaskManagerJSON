# Task Manager JSON

Task Manager JSON es una aplicación de consola desarrollada en .NET que permite gestionar tareas personales utilizando un archivo JSON como base de datos. El proyecto sigue los principios SOLID y emplea servicios para garantizar un código modular y mantenible.

## Características

- **Listar todas las tareas**: Visualiza todas las tareas registradas en el archivo JSON.
- **Agregar una nueva tarea**: Crea y guarda una nueva tarea en la base de datos JSON.
- **Marcar tarea como completada**: Actualiza el estado de una tarea a completada.
- **Eliminar una tarea**: Borra una tarea de la base de datos JSON.
- **Salir**: Finaliza la ejecución del programa.

## Requisitos

- **.NET 8 o superior**
- Biblioteca **Newtonsoft.Json** para la serialización y deserialización de datos JSON.

## Estructura del proyecto

El proyecto está organizado de la siguiente manera:

```
TaskManagerJSON
├── Models
│   └── PersonalTask.cs
├── Services
│   ├── TaskChecker.cs
│   ├── TaskFetcherService.cs
│   ├── TaskDisplayService.cs
│   ├── TaskManagerService.cs
├── Data
│   └── tasks.json
└── Program.cs
```

### Descripción de carpetas

- **Models**: Contiene la clase `PersonalTask`, que representa una tarea con propiedades como `Id`, `Name`, `Description`, y `Completed`.
- **Services**: Incluye clases para gestionar las tareas, realizar validaciones, y mostrar datos en la consola.
- **Data**: Carpeta donde se encuentra el archivo `tasks.json`, que funciona como la base de datos del proyecto.
- **Program.cs**: Archivo principal que contiene la lógica de la aplicación y el flujo del menú.

## Instalación

1. Clona este repositorio en tu máquina local:

   ```bash
   git clone https://github.com/jcomte23/TaskManagerJSON.git
   ```

2. Navega al directorio del proyecto:

   ```bash
   cd TaskManagerJSON
   ```

3. Restaura las dependencias del proyecto:

   ```bash
   dotnet restore
   ```

4. Asegúrate de que el archivo `tasks.json` exista en la carpeta `Data`.

   Si no existe, el programa lo creará automáticamente al ejecutarse.

## Uso

Ejecuta el programa con el siguiente comando:

```bash
dotnet run
```

Sigue las instrucciones en pantalla para navegar por el menú y realizar las operaciones deseadas.

## Ejemplo de archivo `tasks.json`

```json
[
  {
    "Id": "d2f4d7b7-78a4-4f53-89ab-c8b1f6b5f2ad",
    "Name": "Estudiar C#",
    "Description": "Estudiar las colecciones en C#",
    "Completed": false
  },
  {
    "Id": "b32fc114-9832-4d69-857c-d1ed66be1b0d",
    "Name": "Hacer ejercicio",
    "Description": "Ir al gimnasio por 1 hora",
    "Completed": false
  }
]
```

## Contribución

Si deseas contribuir a este proyecto:

1. Haz un fork del repositorio.
2. Crea una rama para tu funcionalidad o corrección de errores:

   ```bash
   git checkout -b feature/nueva-funcionalidad
   ```

3. Realiza tus cambios y envía un pull request.

## Licencia

Este proyecto está bajo la licencia MIT. Consulta el archivo [LICENSE](LICENSE) para más detalles.
