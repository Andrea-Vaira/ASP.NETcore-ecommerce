using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MyCourse.Models.Entities;

namespace MyCourse.Models.ViewModels
{
    public class UsersViewModel
    {
        public ListViewModel<UsersViewModel> users;

        public UsersViewModel()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public char Gender { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Img { get; set; }


        public UsersViewModel(ListViewModel<UsersViewModel> _users){
            this.users = _users;
        }

        public UsersViewModel(UsersViewModel model, ListViewModel<UsersViewModel> _users){
            this.users = _users;
        }

        internal static UsersViewModel FromDataRow(DataRow userRow)
        {
            var usersViewModel = new UsersViewModel {
                Id = Convert.ToInt32(userRow["id"]),
                Name = Convert.ToString(userRow["name"]),
                Gender = Convert.ToChar(userRow["gender"]),
                Surname = Convert.ToString(userRow["surname"]),
                Email = Convert.ToString(userRow["email"]),
                Telefono = Convert.ToString(userRow["telefono"]),
                Img = Convert.ToString(userRow["img"])
            };
            return usersViewModel;
        }

        public string genderDisplay(){
            return this.Gender == 'M' ? "Maschio" : "Femmina";
        }
        
        public string colorDisplay(){
            return this.Gender == 'M' ? "var(--primary)" : "var(--pink)";
        }
    }
}