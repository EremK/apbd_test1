namespace WebApplication1.Controllers;

using Microsoft.AspNetCore.Mvc; 
using Repositories;

[Route("api/[controller]")]
[ApiController]
public class TeamMembersController : ControllerBase
{  
    private readonly TeamMembersRepository _doctorRepository;
    private readonly TasksRepository _tasksRepository;

    public TeamMembersController()
    {
        _doctorRepository = new TeamMembersRepository("Server=db-mssql;Initial Catalog=2019SBD;User ID=s28391;Password=Qwerty123!;Integrated Security=False;Trust Server Certificate=True; Trusted_Connection=true;encrypt=false;");
        _tasksRepository = new TasksRepository("Server=db-mssql;Initial Catalog=2019SBD;User ID=s28391;Password=Qwerty123!;Integrated Security=False;Trust Server Certificate=True; Trusted_Connection=true;encrypt=false;");
    }
    
    [HttpGet("{id}")]
    public IActionResult GetTeamMember(int id)
    {
        var teamMember = _doctorRepository.GetTeamMeberById(id);
        var taskCreated = _tasksRepository.GetCreatedTaskById(id);
        var taskAssignedTo = _tasksRepository.GetAssignedTaskById(id);
        
        // var result = new 
        
        return Ok(teamMember);
    }
}