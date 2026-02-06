using Microsoft.EntityFrameworkCore;
using ProjectCore.Domain.Entities;
using ProjectCore.Domain.Enums;
using ProjectCore.Domain.IRepositories;

namespace ProjectCore.Infrastructure.Persistence.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _context;

    public CourseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Course course)
    {
        await _context.Courses.AddAsync(course);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Course course)
    {
        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
    }
    
    public async Task<Course?> GetByIdAsync(Guid id)
    {
        return await _context.Courses
            .Include(c => EF.Property<ICollection<Lesson>>(c, "_lessons"))
            .FirstOrDefaultAsync(c => c.Id == id);
    }
    
    public async Task<IReadOnlyCollection<Course>> SearchAsync(
        string? query,
        CourseStatus? status,
        int page,
        int pageSize)
    {
        var coursesQuery = _context.Courses.AsQueryable();

        if (!string.IsNullOrWhiteSpace(query))
        {
            coursesQuery = coursesQuery
                .Where(c => c.Title.Contains(query));
        }

        if (status.HasValue)
        {
            coursesQuery = coursesQuery
                .Where(c => c.Status == status.Value);
        }

        return await coursesQuery
            .OrderByDescending(c => c.UpdatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}