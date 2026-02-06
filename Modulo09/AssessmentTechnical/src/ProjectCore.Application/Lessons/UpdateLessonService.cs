using ProjectCore.Domain.IRepositories;

namespace ProjectCore.Application.Lessons;

public class UpdateLessonService
{
    private readonly ICourseRepository _courseRepository;

    public UpdateLessonService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task ExecuteAsync(Guid courseId, Guid lessonId, string title, int order)
    {
        var course = await _courseRepository.GetByIdAsync(courseId)
                     ?? throw new InvalidOperationException("Course not found");

        course.UpdateLesson(lessonId, title, order);

        await _courseRepository.UpdateAsync(course);
    }
}