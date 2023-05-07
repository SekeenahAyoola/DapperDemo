// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using TMADapper.Context;
using TMADapper.Menu;
using TMADapper.Repositories.Implementation;
using TMADapper.Repositories.Interfaces;
using TMADapper.Service.Implementation;
using TMADapper.Service.Interface;

DbContext dbContext = new DbContext();
dbContext.CreateSchema();
IUserRepository userRepository = new UserRepository(dbContext);
IUserService user = new UserService(userRepository);
ITuteeRepository tuteeRepository = new TuteeRepository(dbContext);
ITuteeService tutee = new TuteeService(tuteeRepository,userRepository);
ITutorRepository tutorRepository = new TutorRepository(dbContext);
ITutorService tutor = new TutorService(tutorRepository,userRepository);
TutorMenu tutorMenu = new TutorMenu();
TuteeMenu tuteeMenu = new TuteeMenu(tutee,tutor);
SuperAdminMenu superAdminMenu = new SuperAdminMenu();
AdminMenu adminMenu = new AdminMenu();
MainMenu menu = new MainMenu(user,tutor,tutee,tutorMenu,tuteeMenu,superAdminMenu,adminMenu);
menu.Welcome();
