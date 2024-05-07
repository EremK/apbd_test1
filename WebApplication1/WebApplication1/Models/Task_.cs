namespace WebApplication1.Models;

public class Task_
{
    public int IdTask { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public int IdProject { get; set; }
    public int IdTaskType { get; set; }
    public int IdAssignedTo { get; set; }
    public int IdCreator { get; set; }
    
    public Task_(int idTask, string name, string description, DateTime deadline, int idProject, int idTaskType, int idAssignedTo, int idCreator)
    {
        IdTask = idTask;
        Name = name;
        Description = description;
        Deadline = deadline;
        IdProject = idProject;
        IdTaskType = idTaskType;
        IdAssignedTo = idAssignedTo;
        IdCreator = idCreator;
    }
}