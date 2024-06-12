using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using KanbanASP.DAL.EF;

namespace KanbanASP.WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class APIController : ControllerBase
    {

        public APIController(Context context, IMapper mapper)
        {

        }

        //public IActionResult Index()
        //
        //    return View();
        //}
    }
}
