using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCore.Api.Controllers.Requests;
using ProjectCore.Application.Courses;
using ProjectCore.Domain.Enums;

namespace ProjectCore.Api.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("api/courses")]
public class CoursesController : ControllerBase

{
    private readonly PublishCourseService _publishCourse;
    private readonly UnpublishCourseService _unpublishCourse;
    private readonly SearchCoursesService _searchCourses;
    private readonly CreateCourseService _createCourse;

    public CoursesController(
        PublishCourseService publishCourse,
        UnpublishCourseService unpublishCourse,
        SearchCoursesService searchCourses,
        CreateCourseService createCourse)
    {
        _publishCourse = publishCourse;
        _unpublishCourse = unpublishCourse;
        _searchCourses = searchCourses;
        _createCourse = createCourse;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCourseRequest request)
    {
        var id = await _createCourse.ExecuteAsync(request.Title);
        return CreatedAtAction(nameof(Create), new { id }, null);
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(
        [FromQuery] string? q,
        [FromQuery] CourseStatus? status,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var result = await _searchCourses.ExecuteAsync(q, status, page, pageSize);
        return Ok(result);
    }

    [HttpPatch("{id:guid}/publish")]
    public async Task<IActionResult> Publish(Guid id)
    {
        await _publishCourse.ExecuteAsync(id);
        return NoContent();
    }

    [HttpPatch("{id:guid}/unpublish")]
    public async Task<IActionResult> Unpublish(Guid id)
    {
        await _unpublishCourse.ExecuteAsync(id);
        return NoContent();
    }
}