using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MyCourse.Models.Services.Infrastructure;
using MyCourse.Models.ViewModels;

namespace MyCourse.Models.Services.Application
{
    public class AdoNetUsersService : IUsersService
    {
        private readonly ILogger<AdoNetUsersService> logger;
        private readonly IDatabaseAccessor db;
        public AdoNetUsersService(ILogger<AdoNetUsersService> logger, IDatabaseAccessor db)
        {
            this.logger = logger;
            this.db = db;
        }

        public async Task<ListViewModel<UsersViewModel>> GetUserAsync(int id)
        {
            FormattableString query = $@"SELECT * FROM users WHERE id={id}";

            DataSet dataSet = await db.QueryAsync(query);
            var dataTable = dataSet.Tables[0];
            if (dataTable.Rows.Count != 1)
            {
                logger.LogWarning("User {id} not found", id);
            }
            var user = new List<UsersViewModel>();
            user.Add(UsersViewModel.FromDataRow(dataTable.Rows[0]));
            ListViewModel<UsersViewModel> result = new ListViewModel<UsersViewModel>{
                Results = user,
                TotalCount = 1
            };
            return result;
        }

        public async Task<ListViewModel<UsersViewModel>> GetUsersAsync()
        {
            FormattableString query = 
            $@"SELECT * FROM users";

            DataSet dataSet = await db.QueryAsync(query);
            var dataTable = dataSet.Tables[0];
            var courseList = new List<UsersViewModel>();

            foreach (DataRow userRow in dataTable.Rows)
            {
                UsersViewModel userViewModel = UsersViewModel.FromDataRow(userRow);
                courseList.Add(userViewModel);
            }
            ListViewModel<UsersViewModel> result = new ListViewModel<UsersViewModel>
            {
                Results = courseList,
                TotalCount = courseList.Count
            };

            return result;
        }

        public async Task<ListViewModel<UsersViewModel>> GetUsersByCourseId(int courseId){
            FormattableString query= $@"SELECT u.id, u.name, u.gender, u.surname, u.email, u.telefono, u.img
                                        FROM users u
                                        INNER JOIN user_courses uc ON u.id = uc.user_id
                                        WHERE uc.course_id = {courseId}";

            DataSet dataSet = await db.QueryAsync(query);
            var dataTable = dataSet.Tables[0];
            var courseList = new List<UsersViewModel>();

            foreach (DataRow courseRow in dataTable.Rows)
            {
                UsersViewModel courseViewModel = UsersViewModel.FromDataRow(courseRow);
                courseList.Add(courseViewModel);
            }
            ListViewModel<UsersViewModel> result = new ListViewModel<UsersViewModel>
            {
                Results = courseList,
                TotalCount = courseList.Count
            };

            return result;
        }
    }
}