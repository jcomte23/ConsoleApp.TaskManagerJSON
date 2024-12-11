using ConsoleApp.TaskManagerJSON.Models;
using ConsoleApp.TaskManagerJSON.Services;
using System.Threading.Tasks;

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
            Console.Clear();
            TaskDisplayService.DisplayTasksInTable(tasks);
            Console.WriteLine("Click to continue ...");
            Console.ReadKey();
            break;
        case "4":
            Console.Clear();
            TaskDisplayService.DisplayTasksInTable(tasks);
            Console.WriteLine();
            Console.WriteLine("Copy and paste the Id you want to delete");
            Console.Write("=>");
            string taskId = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrEmpty(taskId))
            {
                Console.WriteLine("Invalid id");
                Console.WriteLine("Click to continue ...");
                Console.ReadLine();
                continue;
            }

            try
            {
                var id = Guid.Parse(taskId);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid id");
                Console.WriteLine("Click to continue ...");
                Console.ReadLine();
                continue;
                throw;
            }

            bool exists = TaskChecker.TaskExists(tasks, Guid.Parse(taskId));

            if (!exists)
            {
                Console.WriteLine("The task was not found");
                Console.WriteLine("Click to continue ...");
                Console.ReadLine();
                continue;
            }


            var task = TaskFetcherService.GetTaskById(tasks, Guid.Parse(taskId));
            Console.Clear();
            Console.WriteLine("This task will be deleted");
            TaskDisplayService.DisplayTask(task);
            Console.WriteLine("Are you sure?");
            Console.WriteLine("[1]yes or [0]no");
            Console.WriteLine("=>");
            var confirm = Console.ReadLine();
            switch (confirm)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Task deleted");
                    Console.WriteLine("Click to continue ...");
                    Console.ReadLine();
                    break;
                case "0":
                    Console.Clear();
                    Console.WriteLine("Operation cancellated");
                    Console.WriteLine("Click to continue ...");
                    Console.ReadLine();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid id");
                    Console.WriteLine("Click to continue ...");
                    Console.ReadLine();
                    continue;
            }
            break;
        default:
            break;
    }
}
while (flag == true);



