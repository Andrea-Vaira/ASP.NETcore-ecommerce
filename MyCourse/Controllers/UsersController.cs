using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCourse.Models.Entities;
using MyCourse.Models.InputModels;
using MyCourse.Models.Options;
using MyCourse.Models.Services.Application;
using MyCourse.Models.ViewModels;

namespace MyCourse.Controllers
{
    // [Route("[controller]")]
    public class Users : Controller
    {
        private readonly ILogger<Users> _logger;
        private ListViewModel<UsersViewModel> _usersViewModel;
        private readonly ICachedCourseService courseService;
        private readonly IUsersService usersService;

        public Users(ILogger<Users> logger,ICachedCourseService courseService, IUsersService usersService)
        {
            _logger = logger;
            this.courseService = courseService;
            this.usersService = usersService;
        }

        public async Task<IActionResult> Index()
        {
            _usersViewModel = await getUsers();
            ViewData["Title"] = "Utenti";
            var model = new UsersViewModel(_usersViewModel);
            return View(model);
        }

        public async Task<IActionResult> Detail(CourseListInputModel input,int id)
        {
            var user = await getUser(id);
            ViewData["Title"] = "User Details";
            UsersDetailViewModel viewModel = new UsersDetailViewModel(user, await this.getCourses(id));
            return View(viewModel);
        }

        private async Task<ListViewModel<CourseViewModel>> getCourses(int id)
        {
            CoursesOrderOptions orderOptions = new CoursesOrderOptions();
            orderOptions.By = "id";
            orderOptions.Ascending = false;
            orderOptions.Allow = new string[] { "id", "name", "gender" };


            CourseListInputModel inputModel = new CourseListInputModel(
                search: "",
                page: 1,
                orderby: "id",
                ascending: false,
                limit: 10,
                orderOptions: orderOptions);

            ListViewModel<CourseViewModel> courses = await courseService.GetCoursesAsync(inputModel, id);
            return courses;
        }

        async Task<ListViewModel<UsersViewModel>> getUsers(){
            ListViewModel<UsersViewModel> users = await usersService.GetUsersAsync();
            return users;
        }

        async Task<UsersViewModel> getUser(int id){
            ListViewModel<UsersViewModel> user = await usersService.GetUserAsync(id);
            return user.Results[0];
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}