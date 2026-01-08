using ProjectCore.Domain.IRepositories;

namespace ProjectCore.Application.Courses;

public class PublishCourseService
{
    private readonly ICourseRepository _courseRepository;

    public PublishCourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task ExecuteAsync(Guid courseId)
    {
        var course = await _courseRepository.GetByIdAsync(courseId)
                     ?? throw new InvalidOperationException("Course not found");

        course.Publish();

        await _courseRepository.UpdateAsync(course);
    }
}