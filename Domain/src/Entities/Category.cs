using Domain.src.Validations;

namespace Domain.src.Entities
{
  public sealed class Category : Entity
  {
    public string? Name { get; private set; }
    public ICollection<Product>? Products { get; set; }

    public Category(string name, string? createdAt)
    {
      ValidateDomain(name);
      CreatedAt = createdAt;
    }

    public Category(string id, string name, string? createdAt)
    {
      ValidateDomain(name);

      Id = id;
      CreatedAt = createdAt;
    }


    public void Update(string name, string createdAt)
    {
      ValidateDomain(name);

      CreatedAt = createdAt;
    }

    private void ValidateDomain(string name)
    {
      DomainExceptionValidation.When(string.IsNullOrEmpty(name), "[Invalid name]. Name is required.");

      DomainExceptionValidation.When(name.Length < 3, "[Invalid name]. To short, minimum 3 characters.");

      Name = name;
    }
  }
}
