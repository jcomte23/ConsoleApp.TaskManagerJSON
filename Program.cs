using ConsoleApp.TaskManagerJSON.Models;
using ConsoleApp.TaskManagerJSON.Services;

var tasks = new List<PersonalTask>
{
    new PersonalTask("Estudiar C#", "Estudiar las colecciones en C#"),
    new PersonalTask("Hacer ejercicio", "Ir al gimnasio por 1 hora"),
    new PersonalTask("Leer libro", "Leer 20 páginas de un libro técnico")
};

var flag = true;

do
{
    Console.Clear();
    Console.WriteLine("####################");
    Console.WriteLine("1. List all tasks");
    Console.WriteLine("2. Add new task");
    Console.WriteLine("3. Mark task as completed");
    Console.WriteLine("4. Delete task");
    Console.WriteLine("5. Exit");
    Console.WriteLine("####################");

    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            TaskDisplayService.DisplayTasksInTable(tasks);
            break;
        default:
            break;
    }
}
while (flag == true);



