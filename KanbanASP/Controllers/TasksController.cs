using AutoMapper;
using KanbanASP.BLL.DTO;
using KanbanASP.BLL.Services;
using KanbanASP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KanbanASP.WEB.Controllers
{
    public class TasksController : Controller
    {
        private UserService _userService;
        private ProjectService _projectService;
        private MyTaskService _taskService;

        public TasksController()
        {
            _userService = new UserService();
            _projectService = new ProjectService();
            _taskService = new MyTaskService();
        }
        // GET: TasksController
        public ActionResult Index()
        {
            var usersDTO = _userService.GetAll();
            var mapperUser = new MapperConfiguration(conf => conf.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var users = mapperUser.Map<IEnumerable<UserDTO>, List<UserViewModel>>(usersDTO);
            var projDTO = _projectService.GetAll();
            var mapperProj = new MapperConfiguration(conf => conf.CreateMap<ProjectDTO, ProjectViewModel>()).CreateMapper();
            var projects = mapperProj.Map<IEnumerable<ProjectDTO>, List<ProjectViewModel>>(projDTO);
            var tasksDTO = _taskService.GetAll();
            var mapperTask = new MapperConfiguration(conf => conf.CreateMap<MyTaskDTO, MyTaskViewModel>()).CreateMapper();
            var tasks = mapperTask.Map<IEnumerable<MyTaskDTO>, List<MyTaskViewModel>>(tasksDTO);

            var all = from t in tasks
                      join p in projects on t.ProjectId equals p.Id
                      join u in users on t.UserId equals u.Id
                      select new
                      {
                          Project = p.Name,
                          ProjectStatus = p.Status,
                          TaskName = t.Name,
                          TaskStatus = t.Status,
                          TaskPriority = t.Priority,
                          TaskDeadline = t.Deadline,
                          UserFNmae = u.FirstName,
                          UserSName = u.SecondName,
                          UserLName = u.LastName,
                          UserPosition = u.Position,
                          UserPassword = u.Password,
                          UserAdminRights = u.AdminRights,
                          UserBossRights = u.BossRights
                      };

            return View(all);
        }



        // GET: TasksController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TasksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TasksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TasksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TasksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TasksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TasksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
