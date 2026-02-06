using ProjectCore.Domain.IRepositories;

namespace ProjectCore.Application.Courses;

public class UnpublishCourseService
{
    private readonly ICourseRepository _courseRepository;

    public UnpublishCourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task ExecuteAsync(Guid courseId)
    {
        var course = await _courseRepository.GetByIdAsync(courseId)
                     ?? throw new InvalidOperationException("Course not found");

        course.Unpublish();

        await _courseRepository.UpdateAsync(course);
    }
}