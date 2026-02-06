using ProjectCore.Domain.Entities;
using ProjectCore.Domain.IRepositories;

namespace ProjectCore.Application.Courses;

public class CreateCourseService
{
    private readonly ICourseRepository _courseRepository;

    public CreateCourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<Guid> ExecuteAsync(string title)
    {
        var course = new Course(title);
        await _courseRepository.AddAsync(course);
        return course.Id;
    }
}