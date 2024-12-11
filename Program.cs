using ConsoleApp.TaskManagerJSON.Models;
using ConsoleApp.TaskManagerJSON.Services;
using Newtonsoft.Json;

bool doesDirectoryExist = Directory.Exists("Data");

if (!doesDirectoryExist)
{
    Directory.CreateDirectory($"Data");
    string workDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Data");
    File.WriteAllText(Path.Combine(workDirectory, "tasks.json"), String.Empty);
}

var dataFromJson = File.ReadAllText($"Data{Path.DirectorySeparatorChar}tasks.json");
var tasks = JsonConvert.DeserializeObject<List<PersonalTask>>(dataFromJson);

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
        case "2":
            Console.Clear();
            Console.WriteLine("Enter the task name:");
            Console.Write("=> ");
            string taskName = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(taskName))
            {
                Console.WriteLine("Task name cannot be empty.");
                Console.WriteLine("Click to continue ...");
                Console.ReadLine();
                continue;
            }

            Console.WriteLine("Enter the task description:");
            Console.Write("=> ");
            string taskDescription = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(taskDescription))
            {
                Console.WriteLine("Task description cannot be empty.");
                Console.WriteLine("Click to continue ...");
                Console.ReadLine();
                continue;
            }


            var newTask = new PersonalTask(taskName, taskDescription);

            tasks.Add(newTask);

            string addTaskIntoJson = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            File.WriteAllText($"Data{Path.DirectorySeparatorChar}tasks.json", addTaskIntoJson);

            Console.WriteLine("Task added successfully.");
            Console.WriteLine("Click to continue ...");
            Console.ReadLine();
            break;
        case "3":
            Console.Clear();
            TaskDisplayService.DisplayTasksInTable(tasks);
            Console.WriteLine();
            Console.WriteLine("Copy and paste the Id of the task you want to mark as completed");
            Console.Write("=> ");
            string taskIdToComplete = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(taskIdToComplete))
            {
                Console.WriteLine("Invalid ID.");
                Console.WriteLine("Click to continue ...");
                Console.ReadLine();
                continue;
            }

            try
            {
                var id = Guid.Parse(taskIdToComplete);
                bool existsTask = TaskChecker.TaskExists(tasks, id);

                if (!existsTask)
                {
                    Console.WriteLine("The task was not found.");
                    Console.WriteLine("Click to continue ...");
                    Console.ReadLine();
                    continue;
                }

                // Buscar la tarea
                var taskToComplete = TaskFetcherService.GetTaskById(tasks, id);

                if (taskToComplete.Completed)
                {
                    Console.WriteLine("This task is already marked as completed.");
                    Console.WriteLine("Click to continue ...");
                    Console.ReadLine();
                    continue;
                }

                // Marcar como completada
                taskToComplete.Completed = true;

                // Actualizar el archivo JSON
                string updatedJson = JsonConvert.SerializeObject(tasks, Formatting.Indented);
                File.WriteAllText($"Data{Path.DirectorySeparatorChar}tasks.json", updatedJson);

                Console.WriteLine("Task marked as completed successfully.");
                Console.WriteLine("Click to continue ...");
                Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid ID format.");
                Console.WriteLine("Click to continue ...");
                Console.ReadLine();
            }
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
                    tasks.Remove(task);
                    string updatedJson = JsonConvert.SerializeObject(tasks, Formatting.Indented);
                    File.WriteAllText($"Data{Path.DirectorySeparatorChar}tasks.json", updatedJson);

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
        case "5":
            Console.Clear();
            Console.WriteLine("Are you sure you want to exit?");
            Console.WriteLine("[1] Yes or [0] No");
            Console.Write("=> ");
            var exitConfirm = Console.ReadLine();

            switch (exitConfirm)
            {
                case "1":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    flag = false; // Termina el bucle principal
                    break;
                case "0":
                    Console.WriteLine("Operation cancelled.");
                    Console.WriteLine("Click to continue ...");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Invalid option. Returning to menu.");
                    Console.WriteLine("Click to continue ...");
                    Console.ReadLine();
                    break;
            }
            break;
        default:
            break;
    }
}
while (flag == true);