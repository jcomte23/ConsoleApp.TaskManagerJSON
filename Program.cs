using ConsoleApp.TaskManagerJSON.Models;

var tarea = new PersonalTask("example", "example");

Console.WriteLine(tarea.Id);
Console.WriteLine(tarea.Name);
Console.WriteLine(tarea.Description);
Console.WriteLine(tarea.Completed);
Console.WriteLine();
