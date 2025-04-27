public class Post
{
    public int Id {get; set;}
    public string Title {get; set;} 
    public string Description {get; set;} 
    public DateTime CreateDate {get; } = DateTime.Now;
}
