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
    
}