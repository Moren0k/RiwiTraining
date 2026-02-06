using ProjectCore.Domain.IRepositories;

namespace ProjectCore.Application.Lessons;

public class CreateLessonService
{
    private readonly ICourseRepository _courseRepository;

    public CreateLessonService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task ExecuteAsync(Guid courseId, string title)
    {
        var course = await _courseRepository.GetByIdAsync(courseId)
                     ?? throw new InvalidOperationException("Course not found");

        course.AddLesson(title);
        await _courseRepository.UpdateAsync(course);
    }
}