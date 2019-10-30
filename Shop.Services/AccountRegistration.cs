using Microsoft.Extensions.Configuration;
using Shop.DataAccess;
using Shop.Domain;
using Shop.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services
{
    public class AccountRegistration : IRegistrationAccount
    {
        public SmsVerification Verification { get; set; }
        public Connection Connect { get; set; }

        public AccountRegistration()
        {
            Verification = new SmsVerification();
            Connect = new Connection();        
        }
        /// <summary>
        /// Метод регистрирующий новый аккаунт в базе данных, принимает обьект типа User
        /// </summary>
        /// <param name="user"></param>
        public void Registration(User user)
        {
            Console.WriteLine("Введите логин");
            user.Login = Console.ReadLine();
            Console.WriteLine("Введите Ваш номер телефона в формате +7**********");
            user.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Введите пароль");
            user.Password = Console.ReadLine();
            Console.WriteLine("Введите email");
            user.Email = Console.ReadLine();
            Console.WriteLine("Введите адресс");
            user.Address = Console.ReadLine();

            Verification.VerificationCodeSender(user.PhoneNumber);
            Console.WriteLine("Введите верификационный код который был отправлен на ваш номер телефона");
            string verificationCode = Console.ReadLine();
            Verification.VerificationChecker(verificationCode);

            if (Verification.isVerificated)
            {
                user.VerificationCode = Verification.VerificationCode;
                using (var context = new Context(Connect.connectionString))
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }                   
            }
        }
    }
}
