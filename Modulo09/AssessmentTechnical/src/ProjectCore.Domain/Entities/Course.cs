using System.ComponentModel.DataAnnotations.Schema;
using ProjectCore.Domain.Common;
using ProjectCore.Domain.Enums;

namespace ProjectCore.Domain.Entities;

public class Course : BaseEntity
{
    private readonly List<Lesson> _lessons = new();

    public string Title { get; private set; }
    public CourseStatus Status { get; private set; }
    public bool IsDeleted { get; private set; }

    [NotMapped]
    public IReadOnlyCollection<Lesson> Lessons => _lessons.AsReadOnly();

    private Course() { }

    public Course(string title)
    {
        Id = Guid.NewGuid();
        Title = title;
        Status = CourseStatus.Draft;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddLesson(string title)
    {
        var nextOrder = _lessons.Count == 0
            ? 1
            : _lessons.Max(l => l.Order) + 1;

        _lessons.Add(new Lesson(Id, title, nextOrder));
        Touch();
    }

    public void UpdateLesson(Guid lessonId, string title, int order)
    {
        var lesson = GetLesson(lessonId);

        if (_lessons.Any(l => l.Order == order && l.Id != lessonId && !l.IsDeleted))
            throw new InvalidOperationException("Lesson order must be unique.");

        lesson.Update(title, order);
        Touch();
    }

    public void DeleteLesson(Guid lessonId)
    {
        var lesson = GetLesson(lessonId);
        lesson.SoftDelete();
        Touch();
    }

    public void Publish()
    {
        if (!_lessons.Any(l => !l.IsDeleted))
            throw new InvalidOperationException("Cannot publish course without lessons.");

        Status = CourseStatus.Published;
        Touch();
    }

    public void Unpublish()
    {
        Status = CourseStatus.Draft;
        Touch();
    }

    public void SoftDelete()
    {
        IsDeleted = true;
        Touch();
    }

    private Lesson GetLesson(Guid lessonId)
    {
        return _lessons.FirstOrDefault(l => l.Id == lessonId && !l.IsDeleted)
               ?? throw new InvalidOperationException("Lesson not found.");
    }

    private void Touch()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}
