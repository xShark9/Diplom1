using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AuthAPP.Models;
using AuthAPP.Views.Pages.Class;

namespace AuthAPP.Controller
{
    public class UserController
    {
        Connection connection = new Connection(); 

        public List<Users> GetUsers()
        {
            try
            {
                var users = connection.auth.Users.ToList();
                return users;
            }
            catch(Exception ex) 
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public Users CreateNewUser(string firstname,string lastname, string patronymic, DateTime datebirth, string username, string password, int genderId, int classId)
        {
            try
            {
                Users users = new Users
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Patronymic = patronymic,
                    DateBirth = datebirth,
                    Username = username,
                    Password = password,
                    GenderId = genderId,
                    IdClass = classId,
                    RoleId = 1,
                };
                connection.auth.Users.Add(users);
               // connection.auth.Users.Remove(users);
                connection.auth.SaveChanges();
                return users;
            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public Users DeleteUser(object selectedItems)
        {
           var selectedUsers = selectedItems as Users;
            connection.auth.Users.Remove(selectedUsers);
            return selectedUsers;
        }
        public Users SignIn(string username, string password)
        {
            try
            {
                var user = connection.auth.Users.Where(x=>x.Username == username && x.Password == password).First();
                return user;
            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        

        
    }
}
