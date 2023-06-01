using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCourse.Models.ViewModels;

namespace MyCourse.Models.Services.Application
{
    public interface IUsersService
    {
        Task<ListViewModel<UsersViewModel>> GetUserAsync(int id);
        public Task<ListViewModel<UsersViewModel>> GetUsersAsync();
        public Task<ListViewModel<UsersViewModel>> GetUsersByCourseId(int courseId);
    }
}