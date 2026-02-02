using Microsoft.AspNetCore.Mvc;
using ScoreHub_Application.Lessons.Features;
using ScoreHub_Contracts.Lessons;
using ScoreHub_Infrastructure.Repositories;

namespace ScoreHub_Backend.Controllers;

[ApiController]
public class SubjectsController : Controller
{

    [HttpPost("subject/{subjectId:guid}/lesson")]
    public async Task<ActionResult> CreateLesson(
        CreateLessonDto lesson,
        [FromServices] CreateLessonCommandHandler createLessonCommandHandler)
    {
        var command =  new CreateLessonCommand(lesson);
        await createLessonCommandHandler.Handle(command);
        return Ok();
    }
}