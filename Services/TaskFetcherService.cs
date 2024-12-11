using ConsoleApp.TaskManagerJSON.Models;

namespace ConsoleApp.TaskManagerJSON.Services;
internal class TaskFetcherService
{
    public static PersonalTask GetTaskById(List<PersonalTask> tasks, Guid taskId)
    {
        var task = tasks.First(t => t.Id == taskId);
        return task;
    }
}

