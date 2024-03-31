namespace API.Entities;

public class TopLevelTodo : Todo
{
    public TopLevelTodo(string title) : base(title)
    {
        Details = "Top level todo";
        DueDate = DateTime.Now.AddDays(7);
    }

    public override void Complete()
    {
        throw new NotImplementedException();
    }
}