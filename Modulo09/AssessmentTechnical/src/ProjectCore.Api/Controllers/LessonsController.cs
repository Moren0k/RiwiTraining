using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCore.Api.Controllers.Requests;
using ProjectCore.Application.Lessons;
using ProjectCore.Domain.IRepositories;
using ProjectCore.Infrastructure.Persistence.Repositories;

namespace ProjectCore.Api.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("api/courses/{courseId:guid}/lessons")]
public class LessonsController : ControllerBase
{
    private readonly ICourseRepository _courseRepository;
    private readonly CreateLessonService _createLesson;
    private readonly UpdateLessonService _updateLesson;
    private readonly DeleteLessonService _deleteLesson;
    
    public LessonsController(
        ICourseRepository courseRepository,
        CreateLessonService createLesson,
        UpdateLessonService updateLesson,
        DeleteLessonService deleteLesson)
    {
        _courseRepository = courseRepository;
        _createLesson = createLesson;
        _updateLesson = updateLesson;
        _deleteLesson = deleteLesson;
    }
    [HttpPost]
    public async Task<IActionResult> Create(
        Guid courseId,
        [FromBody] CreateLessonRequest request)
    {
        await _createLesson.ExecuteAsync(courseId, request.Title);
        return NoContent();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll(Guid courseId)
    {
        var course = await _courseRepository.GetByIdAsync(courseId)
                     ?? throw new InvalidOperationException("Course not found");

        var lessons = course.Lessons
            .Where(l => !l.IsDeleted)
            .OrderBy(l => l.Order)
            .Select(l => new
            {
                l.Id,
                l.Title,
                l.Order
            });

        return Ok(lessons);
    }

    [HttpPut("{lessonId:guid}")]
    public async Task<IActionResult> Update(
        Guid courseId,
        Guid lessonId,
        [FromBody] UpdateLessonRequest request)
    {
        await _updateLesson.ExecuteAsync(courseId, lessonId, request.Title, request.Order);
        return NoContent();
    }

    [HttpDelete("{lessonId:guid}")]
    public async Task<IActionResult> Delete(Guid courseId, Guid lessonId)
    {
        await _deleteLesson.ExecuteAsync(courseId, lessonId);
        return NoContent();
    }
}