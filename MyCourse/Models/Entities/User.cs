using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCourse.Models.Entities
{
    public class User
    {
        public int id {get; set;} = 0;
        public string name {get; set;}
        public char gender {get; set;}
        public string surname {get; set;}
        public string email {get; set;} 
        public string telefono {get; set;} 
        public string img {get; set;}

        public User(int id, string name, char gender, string surname, string email, string telefono, string img){
            this.id = id;
            this.name = name;
            this.gender = gender;
            this.surname = surname;
            this.email = email;
            this.telefono = telefono;
            this.img = img;
        }
        public string genderDisplay(){
            if(this.gender == 'M')  return "Maschio";
            else return "Femmina";
        }
    }
}