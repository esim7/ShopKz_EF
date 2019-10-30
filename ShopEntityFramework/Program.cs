using Shop.Domain;
using Shop.Services;
using Shop.Services.Abstract;
using System;

namespace ShopEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            User temporaryUser = new User();
            bool isActive = true;
            string key;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Зарегистрировать пользователя \n2. Войти в личный кабинет \n3. Поиск \n4. Просмотреть весь каталог товаров \n5. Выход");
                key = Console.ReadLine();
                switch (key)
                {
                    case "1":
                        {
                            Console.Clear();
                            User user = new User();
                            AccountRegistration registration = new AccountRegistration();
                            registration.Registration(user);
                        }
                        break;
                    case "2":
                        {
                            Console.Clear();
                            LogIn login = new LogIn();
                            login.LogInChecker(temporaryUser);
                            if (temporaryUser.IsLogged == true)
                            {
                                Console.Clear();
                                Console.WriteLine("1. Корзина \n2. История покупок \n3. Выйти из аккаунта \n4. Назад в главное меню");
                                string action;
                                bool basketIsExit = false;
                                action = Console.ReadLine();
                                switch (action)
                                {
                                    case "1":
                                        {
                                            Console.WriteLine("Реализовано только в подкюченном режиме");
                                        }
                                        break;
                                    case "2":
                                        {
                                            Console.WriteLine("Реализовано только в подкюченном режиме");
                                        }
                                        break;
                                    case "3":
                                        {
                                            login.LogOut(temporaryUser);
                                        }
                                        break;
                                    case "4":
                                        {
                                            break;
                                        }
                                        break;
                                }
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Для доступа в личный кабинет нужно авторизоваться в системе");
                                Console.ReadKey();
                            }
                        }
                        break;
                    case "3":
                        {
                            int pageSize = 3;
                            int pageNumber = 0;
                            bool exit = false;
                            FindItem find = new FindItem();
                            Console.WriteLine("Введите название товара");
                            string itemName = Console.ReadLine();
                            while(!exit)
                            {
                                Console.Clear();
                                try
                                {
                                    var result = find.FindItems(itemName, pageSize, pageNumber);
                                    foreach (var item in result)
                                    {
                                        Console.WriteLine(item.Name);
                                        Console.WriteLine(item.Price);
                                        Console.WriteLine(item.Description);
                                        Console.WriteLine("--------------------------------------------------");
                                    }
                                }
                                catch(ArgumentOutOfRangeException exception)
                                {
                                    Console.WriteLine("Ошибка! Чтобы продолжить просмотр листайте вперед");
                                }
                                Console.WriteLine("1. Следующая страница \n2. Предыдущая страница \n3. Выход");
                                string action = Console.ReadLine();
                                if (action == "1")
                                {
                                    pageNumber++;
                                }
                                else if (action == "2")
                                {
                                    pageNumber--;
                                }
                                else if (action == "3")
                                {
                                    exit = true;
                                }
                            }
                        }
                        break;
                    case "4":
                        {
                            int pageSize = 3;
                            int pageNumber = 0;
                            bool exit = false;
                            int i = 1;
                            ShowItem show = new ShowItem();
                            while (!exit)
                            {
                                Console.Clear();    
                                try
                                {
                                    var result = show.ShowItems(pageSize, pageNumber);
                                    foreach (var item in result)
                                    {
                                        Console.WriteLine("Наименование товара: " + item.Name);
                                        Console.WriteLine("Цена: " + item.Price);
                                        Console.WriteLine("Описание товара: " + item.Description);
                                        Console.WriteLine("--------------------------------------------------");
                                        i++;
                                    }
                                }
                                catch (ArgumentOutOfRangeException exception)
                                {
                                    Console.WriteLine("Ошибка! Чтобы продолжить просмотр листайте вперед");
                                }
                                Console.WriteLine("1. Следующая страница \n2. Предыдущая страница \n3. Выход");
                                string action = Console.ReadLine();
                                if (action == "1")
                                {
                                    pageNumber++;
                                }
                                else if (action == "2")
                                {
                                    pageNumber--;
                                }
                                else if (action == "3")
                                {
                                    exit = true;
                                }
                            }
                        }
                        break;
                    case "5":
                        {
                            isActive = false;
                        }
                        break;
                }
            } while (isActive != false);
        }
    }
}
