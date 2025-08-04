using Microsoft.AspNetCore.Mvc;
using ScoreHub_Application.UseCases;
using ScoreHub_Contracts;

namespace ScoreHub_Backend.Controllers;

[ApiController]
public class SubjectController : Controller
{
    private readonly GetSubjectByNameUseCase _getSubjectByNameUseCase;
    private readonly CreateSubjectUseCase _createSubjectUseCase;

    public SubjectController(
        GetSubjectByNameUseCase getSubjectByNameUseCase,
        CreateSubjectUseCase createSubjectUseCase)
    {
        _getSubjectByNameUseCase = getSubjectByNameUseCase;
        _createSubjectUseCase = createSubjectUseCase;
    }
    [HttpGet("subject/{name}")]
    public async Task<IActionResult> GetSubject(string name)
    {
        return Ok(await _getSubjectByNameUseCase.Execute(name));
    }

    [HttpPost("subject/create")]
    public async Task<IActionResult> CreateSubject(CreateSubjectRequest request)
    {
        await _createSubjectUseCase.Execute(request);
        return Ok();
    }
}