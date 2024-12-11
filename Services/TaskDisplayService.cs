using ConsoleApp.TaskManagerJSON.Models;

namespace ConsoleApp.TaskManagerJSON.Services;
internal class TaskDisplayService
{
    public static void DisplayTasksInTable(List<PersonalTask> tasks)
    {
        Console.WriteLine("{0,-40} {1,-30} {2,-50} {3,-10}", "ID", "Nombre", "Descripción", "Completada");
        foreach (var item in tasks)
        {
            Console.WriteLine("{0,-40} {1,-30} {2,-50} {3,-10}", item.Id, item.Name, item.Description, item.Completed);
        }
    }

    public static void DisplayTask(PersonalTask task)
    {
        Console.WriteLine("");
        Console.WriteLine($"Id => {task.Id}");
        Console.WriteLine($"Name => {task.Name}");
        Console.WriteLine($"Description => {task.Description}");
        Console.WriteLine($"Completed => {task.Completed}");
        Console.WriteLine("");
    }
}

