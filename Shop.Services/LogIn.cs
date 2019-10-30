using Microsoft.Extensions.Configuration;
using Shop.DataAccess;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Services
{
    public class LogIn
    {
        public Connection Connect { get; set; }

        public LogIn()
        {
            Connect = new Connection();         
        }
        /// <summary>
        /// Проверяет на существование в БД зарегистрированного пользователя 
        /// </summary>
        /// <param name="user">если пользователь существует присваивает его данные в переданный обьект</param>
        public void LogInChecker(User user)
        {
            if (user.IsLogged == false)
            {
                using (var context = new Context(Connect.connectionString))
                {
                    Console.WriteLine("Введите логин");
                    string login = Console.ReadLine();
                    Console.WriteLine("Введите пароль");
                    string password = Console.ReadLine();
                    var result = context.Users;
                    if (result.Any(user => user.Login.Contains(login) && (result.Any(user => user.Password.Contains(password)))))
                    {
                        user.IsLogged = true;
                        Console.WriteLine(user.Login + " Вы успешно авторизовались в системе!");
                    }
                    else 
                    {
                        Console.WriteLine("Данный пользователь не найден!!! Пройдите регистрацию");
                    }                  
                }
            }
            else
            {
                Console.WriteLine(user.Login + " Вы уже вошли в систему");
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Метод который делает имитатуцию logOut из системы путем очистки обьекта от присвоенных из БД данных
        /// </summary>
        /// <param name="user"></param>
        public void LogOut(User user)
        {
            user.Id = Guid.Empty;
            user.Login = string.Empty;
            user.Address = string.Empty;
            user.Password = string.Empty;
            user.IsLogged = false;
            Console.WriteLine("Вы вышли из системы!");
        }
    }
}
