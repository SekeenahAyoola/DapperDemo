using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMADapper.Model.entities;
using TMADapper.Service.Interface;
namespace TMADapper.Menu
{
    public class TuteeMenu
    {
        private readonly ITuteeService _tuteeService;
        private readonly ITutorService _tutorService;
        public TuteeMenu(ITuteeService tuteeService, ITutorService tutorSevice)
        {
            _tuteeService = tuteeService;
            _tutorService = tutorSevice;
        }

        public ITuteeService TuteeService => _tuteeService;

        public void WelcomeTutee(User user)
        {
            Console.Write($"Welcome {user.FirstName} {user.LastName}");
        }
    }
}