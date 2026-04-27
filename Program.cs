var taskService = new TaskService(new ConsoleNotifier(), new ConsoleTaskPrinter());

taskService.AddTask("Оформити public репозиторій");
taskService.AddTask("Створити PROGRAMMING_PRINCIPLES.md");
taskService.CompleteTask(1);
taskService.ShowTasks();

public sealed class TaskService
{
    private readonly INotifier _notifier;
    private readonly ITaskPrinter _taskPrinter;
    private readonly List<ProjectTask> _tasks = [];

    public TaskService(INotifier notifier, ITaskPrinter taskPrinter)
    {
        _notifier = notifier;
        _taskPrinter = taskPrinter;
    }

    public void AddTask(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            _notifier.Notify("Неможливо додати задачу без назви.");
            return;
        }

        var newTask = new ProjectTask(_tasks.Count + 1, title);
        _tasks.Add(newTask);
        _notifier.Notify($"Додано задачу: {title}");
    }

    public void CompleteTask(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task is null)
        {
            _notifier.Notify($"Задачу з id={id} не знайдено.");
            return;
        }

        task.Complete();
        _notifier.Notify($"Задачу \"{task.Title}\" завершено.");
    }

    public void ShowTasks()
    {
        _taskPrinter.PrintTasks(_tasks);
    }
}

public sealed class ProjectTask
{
    public int Id { get; }
    public string Title { get; }
    public TaskStatus Status { get; private set; }

    public ProjectTask(int id, string title)
    {
        Id = id;
        Title = title;
        Status = TaskStatus.Open;
    }

    public void Complete()
    {
        Status = TaskStatus.Done;
    }
}

public interface INotifier
{
    void Notify(string message);
}

public interface ITaskPrinter
{
    void PrintTasks(IEnumerable<ProjectTask> tasks);
}

public sealed class ConsoleNotifier : INotifier
{
    public void Notify(string message)
    {
        Console.WriteLine($"[info] {message}");
    }
}

public sealed class ConsoleTaskPrinter : ITaskPrinter
{
    public void PrintTasks(IEnumerable<ProjectTask> tasks)
    {
        Console.WriteLine();
        Console.WriteLine("Поточні задачі:");
        foreach (var task in tasks)
        {
            Console.WriteLine($"{task.Id}. {task.Title} | Стан: {task.Status}");
        }
    }
}

public enum TaskStatus
{
    Open,
    Done
}
