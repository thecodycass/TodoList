namespace TodoList.Models;

public class TodoRepository
{
    private static List<Todo> Todos = new List<Todo>()
    {
        new Todo { Id = 1, Name = "Meal Prep", IsCompleted = true },
        new Todo { Id = 2, Name = "Build App", IsCompleted = false },
        new Todo { Id = 3, Name = "Wash Truck", IsCompleted = false },
        new Todo { Id = 4, Name = "Get Pressure Washer", IsCompleted = false },
        new Todo { Id = 5, Name = "Wash Blankets", IsCompleted = false },
        new Todo { Id = 6, Name = "Dishes", IsCompleted = false }
    };
    
    public static List<Todo> GetNotCompletedTodos() => Todos.Where(t => !t.IsCompleted).ToList();
    public static List<Todo> GetTodos() => Todos;
    public static Todo? GetTodoById(int id)
    { 
        Todo todo = Todos.FirstOrDefault(t => t.Id == id);
        if (todo != null)
        {
            return new Todo
            {
                Id = todo.Id,
                IsCompleted = todo.IsCompleted,
                Name = todo.Name
            };
        }
        return null;
    }
    
    public static void DeleteTodo(int id)
    {
        var serverToDelete = Todos.FirstOrDefault(t => t.Id == id);
        if (serverToDelete != null)
        {
            Todos.Remove(serverToDelete);
        }
    }
    public static void UpdateTodo(Todo todo, int id)
    {
        if (todo.Id != id) return;
        var todoToUpdate = Todos.FirstOrDefault(t => t.Id == todo.Id);
        if (todoToUpdate != null)
        {
            todoToUpdate.Name = todoToUpdate.Name;
            todoToUpdate.IsCompleted = todoToUpdate.IsCompleted;
        }
    }

    public static void AddTodo(Todo todo)
    {
        var maxId = Todos.Max(t => t.Id);
        if (todo != null)
        {
            todo.Id =  maxId + 1;
            Todos.Add(todo);
        }
    }

    public static void ToggleComplete(int id)
    {
        var todoToMark = Todos.FirstOrDefault(t => t.Id == id);
        if (todoToMark != null)
        {
            todoToMark.IsCompleted = !todoToMark.IsCompleted;
        }
    }
}