using Maps.Services.Interfaces;

namespace Maps.Services.Implimentations;

public class RepairService : IRepairService
{
    private IBaseRepositry<Category> Categories { get; set; }
    private IBaseRepositry<Establishment> Establishmets { get; set; }
    private IBaseRepositry<Tag> Tags { get; set; }

    public void Work()
    {
        var rand = new Random();
        var categoryId = Guid.NewGuid();
        var tagId = Guid.NewGuid();

        Categories.Create(new Category { Id = categoryId, Name = String.Format($"Category{rand.Next()}")});
        Tags.Create(new Tag { Id = tagId, Name = String.Format($"Tag{rand.Next()}")});

        var category = Categories.Get(categoryId);
        var tag = Tags.Get(tagId);

        Establishmets.Create(new Establishment {CategoryId = categoryId, TagId = tagId, Category = category, Tag = tag});
    }
}