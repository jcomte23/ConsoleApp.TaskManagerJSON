using ConsoleApp.TaskManagerJSON.Models;

namespace ConsoleApp.TaskManagerJSON.Services
{
    internal class TaskChecker
    {
        public static bool TaskExists(List<PersonalTask> tasks, Guid taskId)
        {
            return tasks.Any(t => t.Id == taskId);
        }
    }
}
