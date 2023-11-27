using MaraphonApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MaraphonApp.Controllers
{

        public class UserController
        {
        Corebd context = new Corebd();
        /// <summary>
        /// Добавление пользователя
        /// </summary>
        /// <param name="email">почта</param>
        /// <param name="firstName">имя</param>
        /// <param name="lastName">фамилия</param>
        /// <param name="role">роль</param>
        /// <param name="gender">роль</param>
        /// <param name="password">пароль</param>
        /// <returns>bool</returns>
        public bool SaveRunnerData(string email, string firstName, string lastName, int role,string gender, string password)
        {
            users newUser = new users()
            {
                user_email = email,
                user_firstname = firstName,
                user_lastname = lastName,
                role_id = role,
                gender_code = gender,
                user_password = password
            };
            context.entities.users.Add(newUser);
            if (context.entities.SaveChanges()>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// проверяет есть ли в существующей пользователь  в таблице 
        /// </summary>
        /// <param name="email"></param>
        /// <returns>
        /// если Null возращает false в противном случае true
        /// </returns>
        public async Task<bool> FindUsers(string email)
        {
            users  result = await context.entities.users.FirstOrDefaultAsync(x => x.user_email == email);
            if (result == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Login(string Email, string Password)
        {
          var result = context.entities.users.Where(x => x.user_email == Email && x.user_password == Password).FirstOrDefault();
            if (result == null)
            {
                return false;
            }
           else 
            { 
                return true; 
            }

        }

    }

}
