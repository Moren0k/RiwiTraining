using ProjectCore.Domain.Common;

namespace ProjectCore.Domain.Entities;

public class Lesson : BaseEntity
{
    public Guid CourseId { get; private set; }
    public string Title { get; private set; }
    public int Order { get; private set; }
    public bool IsDeleted { get; private set; }

    private Lesson() { }

    internal Lesson(Guid courseId, string title, int order)
    {
        Id = Guid.NewGuid();
        CourseId = courseId;
        Title = title;
        Order = order;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        IsDeleted = false;
    }

    internal void Update(string title, int order)
    {
        Title = title;
        Order = order;
        UpdatedAt = DateTime.UtcNow;
    }

    internal void SoftDelete()
    {
        IsDeleted = true;
        UpdatedAt = DateTime.UtcNow;
    }
}
