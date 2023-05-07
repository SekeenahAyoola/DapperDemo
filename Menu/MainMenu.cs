using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMADapper.Model.entities;
using TMADapper.Model.enums;
using TMADapper.Service.Interface;

namespace TMADapper.Menu
{
    public class MainMenu
    {
        private readonly IUserService _userService;
        private readonly ITutorService _tutorService;
        private readonly ITuteeService _tuteeService;
        private readonly TuteeMenu _tuteeMenu;
        private readonly TutorMenu _tutorMenu;
        private readonly SuperAdminMenu _superAdminMenu;
        private readonly AdminMenu _adminMenu;
        public MainMenu(IUserService userService, ITutorService tutorService, ITuteeService tuteeService, TutorMenu tutorMenu, TuteeMenu tuteeMenu,
        SuperAdminMenu superAdminMenu, AdminMenu adminMenu)
        {
            _userService = userService;
            _tutorService = tutorService;
            _tuteeService = tuteeService;
            _tuteeMenu = tuteeMenu;
            _tutorMenu = tutorMenu;
            _superAdminMenu = superAdminMenu;
            _adminMenu = adminMenu;
        }
        public void Welcome()
        {
            Console.WriteLine("Enter 1 to register or 2 to login");
            int a = Convert.ToInt32(Console.ReadLine());
            if (a ==1)
            {
                Register();
            }
            else if (a == 2)
            {
                Login();
            }
        }
        public void Register()
        {
            Console.Write("Enter your Firstname: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter your Lastname(Surname): ");
            string lastName = Console.ReadLine();
            Console.Write("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter 1 for Male \nEnter 2 for Female: ");
            Gender gender = (Gender) Enum.Parse(typeof(Gender), Console.ReadLine());
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your Phone Number: ");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Enter 1 to register as a tutor or 2 toregister as a tutee");
            string register = Console.ReadLine();
            if (register =="1")
            {
                User user = _userService.RegisterUser(firstName,lastName,email,password,age,gender,phoneNumber,"Tutor");
                var newUser = _userService.GetUser(email);
                if (newUser != null)
                {
                    Console.WriteLine(newUser.Id);
                    Tutor tutor = _tutorService.RegisterTutor(newUser.Id,"");
                    Console.WriteLine("Registration succcessful");
                }
            }
            else if (register == "2")
            {
                User user = _userService.RegisterUser(firstName,lastName,email,password,age,gender,phoneNumber,"Tutee");
                var newUser = _userService.GetUser(email);
                if (newUser != null)
                {
                    Console.WriteLine(newUser.Id);
                    Tutee tutee = _tuteeService.RegisterTutee(newUser.Id,Level.Jss3);
                    Console.WriteLine("Registration succcessful");
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }

        }

        public void Login()
        {
            Console.WriteLine ("input your email");
            string email = Console.ReadLine();
            Console.WriteLine("enter your password");
            string password = Console.ReadLine();
           User user = _userService.GetUser(email);
           if (user.Password == password)
           {
                switch (user.Role)
                {
                    case "Tutee":
                    _tuteeMenu.WelcomeTutee(user);
                    break;
                    case "Tutor":
                    _tutorMenu.WelcomeTutor(user);
                    break;
                    case "Admin":
                    break;
                    case "SuperAdmin":
                    break;
                    default:
                    
                    break;
                }
           }

        }
    }
}