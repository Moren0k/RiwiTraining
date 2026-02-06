using ProjectCore.Domain.Entities;
using ProjectCore.Domain.Enums;

namespace ProjectCore.Domain.IRepositories;

public interface ICourseRepository
{
    Task AddAsync(Course course);
    Task UpdateAsync(Course course);

    Task<Course?> GetByIdAsync(Guid id);

    Task<IReadOnlyCollection<Course>> SearchAsync(
        string? query,
        CourseStatus? status,
        int page,
        int pageSize
    );
}