using Domain.src.Validations;

namespace Domain.src.Entities
{
  public sealed class Product : Entity
  {
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string? Image { get; private set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    // Constructor 1
    public Product(string name, string description, decimal price, int stock, string image, string? createdAt)
    {
      ValidateDomain(name, description, price, stock, image);
      CreatedAt = createdAt;
    }

    // Constructor 2
    public Product(string id, string name, string description, decimal price, int stock, string image, string? createdAt)
    {
      ValidateDomain(name, description, price, stock, image);

      Id = id;
      CreatedAt = createdAt;
    }

    public void Update(string name, string description, decimal price, int stock, string image, int categoryId, string createdAt)
    {
      ValidateDomain(name, description, price, stock, image);

      CategoryId = categoryId;
      CreatedAt = createdAt;

    }


    private void ValidateDomain(string name, string description, decimal price, int stock, string image)
    {
      DomainExceptionValidation.When(string.IsNullOrEmpty(name), "[Invalid name]. Name is required.");

      DomainExceptionValidation.When(name.Length < 3, "[Invalid name]. To short, minimum 3 characters.");

      DomainExceptionValidation.When(string.IsNullOrEmpty(description), "[Invalid Description]. Description is required.");

      DomainExceptionValidation.When(description.Length < 5, "[Invalid Description]. To short, minimum 5 characters.");

      DomainExceptionValidation.When(price < 0, "[Invalid Price]. Invalid price value.");

      DomainExceptionValidation.When(stock < 0, "[Invalid Stock]. Invalid price value.");

      DomainExceptionValidation.When(image.Length > 250, "[Invalid Image]. Invalid image name, maximum 250 characters.");

      Name = name;
      Description = description;
      Price = price;
      Stock = stock;
      Image = image;
    }
  }
}
