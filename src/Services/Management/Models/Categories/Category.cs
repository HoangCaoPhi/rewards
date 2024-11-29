using Shared.Domain;

namespace Management.Models.Categories;

public class Category : Entity
{
    public string Name { get; private set; }

    public static Category Create(Guid id, string name)
    {
        return new Category()
        {
            Id = id,
            Name = name,
        };
    }
}
