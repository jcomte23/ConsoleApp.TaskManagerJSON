namespace ConsoleApp.TaskManagerJSON.Models;
internal class PersonalTask(string name, string description)
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    public bool Completed { get; set; } = false;
}