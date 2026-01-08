using ProjectCore.Domain.IRepositories;

namespace ProjectCore.Application.Lessons;

public class DeleteLessonService
{
    private readonly ICourseRepository _courseRepository;

    public DeleteLessonService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task ExecuteAsync(Guid courseId, Guid lessonId)
    {
        var course = await _courseRepository.GetByIdAsync(courseId)
                     ?? throw new InvalidOperationException("Course not found");

        course.DeleteLesson(lessonId);

        await _courseRepository.UpdateAsync(course);
    }
}