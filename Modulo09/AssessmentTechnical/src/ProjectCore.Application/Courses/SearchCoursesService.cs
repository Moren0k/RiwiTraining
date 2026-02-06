using ProjectCore.Domain.Entities;
using ProjectCore.Domain.Enums;
using ProjectCore.Domain.IRepositories;

namespace ProjectCore.Application.Courses;

public class SearchCoursesService
{
    private readonly ICourseRepository _courseRepository;

    public SearchCoursesService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<IReadOnlyCollection<Course>> ExecuteAsync(
        string? query,
        CourseStatus? status,
        int page,
        int pageSize)
    {
        return await _courseRepository.SearchAsync(query, status, page, pageSize);
    }
}