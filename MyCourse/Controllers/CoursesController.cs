using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCourse.Models.InputModels;
using MyCourse.Models.Services.Application;
using MyCourse.Models.ViewModels;

namespace MyCourse.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService courseService;
        private readonly IUsersService usersService;
        public CoursesController(ICachedCourseService courseService, IUsersService usersService)
        {
            this.courseService = courseService;
            this.usersService = usersService;
        }
        public async Task<IActionResult> Index(CourseListInputModel input)
        {
            ViewData["Title"] = "Catalogo dei corsi";
            ListViewModel<CourseViewModel> courses = await courseService.GetCoursesAsync(input);
            
            CourseListViewModel viewModel = new CourseListViewModel
            {
                Courses = courses,
                Input = input
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Detail(int id)
        {
            ListViewModel<UsersViewModel> users = await usersService.GetUsersByCourseId(id);
            CourseDetailViewModel viewModel = (await courseService.GetCourseAsync(id));
            viewModel.users = users.Results;
            ViewData["Title"] = viewModel.Title;
            return View(viewModel);
        }
    }
}