using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCourse.Models.Entities;

namespace MyCourse.Models.ViewModels
{
    public class UsersDetailViewModel : UsersViewModel
    {
        public UsersViewModel user;
        public ListViewModel<CourseViewModel> courses;

        public UsersDetailViewModel()
        {
        }

        public UsersDetailViewModel(UsersViewModel user, ListViewModel<CourseViewModel> _courses){
            this.user = user;
            this.courses = _courses;
        }

        public UsersDetailViewModel(ListViewModel<UsersViewModel> _users, ListViewModel<CourseViewModel> _courses){
            this.users = _users;
            this.courses = _courses;
        }

        public static UsersDetailViewModel FromEntity(User user)
        {
            return new UsersDetailViewModel{
                Id = user.id,
                Name = user.name,
                Gender = user.gender
            };
        }

        
    }
}