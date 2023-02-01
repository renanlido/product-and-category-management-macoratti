namespace Domain.src.Entities
{
  public abstract class Entity
  {
    private string? _id;
    private string? _createdAt;
    private string? _updatedAt;
    public virtual string Id
    {
      get { return _id ?? Guid.NewGuid().ToString(); }
      protected set { _id = value; }
    }

    public virtual string? CreatedAt
    {
      get { return _createdAt ?? DateTime.UtcNow.ToString("o"); }
      protected set { _createdAt = value; }
    }

    public virtual string UpdatedAt
    {
      get { return _updatedAt ?? DateTime.UtcNow.ToString("o"); }
      protected set { _updatedAt = value; }
    }
  }
}
