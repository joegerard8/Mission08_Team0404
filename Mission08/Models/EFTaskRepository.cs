namespace Mission08.Models;


public class EFTaskRepository : ITaskRepository
{
    private AppDbContext _context;

    public EFTaskRepository(AppDbContext temp)
    {
        _context = temp;
    }
    public List<Task> Tasks => _context.Tasks.ToList();
    public List<Category> Categories => _context.Categories.ToList();

    public void AddTask(Task task)
    {
        _context.Add(task);
        _context.SaveChanges();
    }

    public void DeleteTask(int id)
    {
        var task = _context.Tasks.Find(id); // Find the task by ID
        if (task != null)
        {
            _context.Tasks.Remove(task); // Remove it from the database
            _context.SaveChanges(); // Save the changes
        }
    }
    public void UpdateTask(Task task)
    {
        _context.Tasks.Update(task);
        _context.SaveChanges();
    }

}