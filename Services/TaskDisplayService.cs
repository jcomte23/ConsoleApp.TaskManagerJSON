using ConsoleApp.TaskManagerJSON.Models;

namespace ConsoleApp.TaskManagerJSON.Services;
internal class TaskDisplayService
{
    public static void DisplayTasksInTable(List<PersonalTask> tasks)
    {
        Console.Clear();
        Console.WriteLine("{0,-40} {1,-30} {2,-50} {3,-10}", "ID", "Nombre", "Descripción", "Completada");
        foreach (var item in tasks)
        {
            Console.WriteLine("{0,-40} {1,-30} {2,-50} {3,-10}", item.Id, item.Name, item.Description, item.Completed);
        }
        Console.WriteLine("Click to continue ...");
        Console.ReadKey();
    }
}

