using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using KanbanASP.DAL.EF;
using KanbanASP.BLL.DTO;

namespace KanbanASP.WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class APIController : ControllerBase
    {

        public APIController(Context context, IMapper mapper)
        {

        }

        // GET api/API/GetProjectsName
        [HttpGet("GetProjectsName")]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjectsName()
        {

            throw new NotImplementedException();

        }
    }
}