namespace ProjectCore.Api.Controllers.Requests;

public class UpdateLessonRequest
{
    public string Title { get; set; } = string.Empty;
    public int Order { get; set; }
}