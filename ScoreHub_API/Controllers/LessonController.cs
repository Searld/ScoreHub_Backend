using Microsoft.AspNetCore.Mvc;
using ScoreHub_Application.UseCases;
using ScoreHub_Contracts;
using ScoreHub_Domain.Entities;

namespace ScoreHub_Backend.Controllers;

[ApiController]
public class LessonController : Controller
{
    private readonly CreateLessonUseCase _createLessonUseCase;

    public LessonController(CreateLessonUseCase  createLessonUseCase)
    {
        _createLessonUseCase = createLessonUseCase;
    }
    [HttpPost("/lesson/create")]
    public async Task<IActionResult> CreateLesson(CreateLessonRequest request)
    {
        await _createLessonUseCase.Execute(request);
        return Ok();
    }
}