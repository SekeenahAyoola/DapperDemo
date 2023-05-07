using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMADapper.Model.enums;

namespace TMADapper.Model.entities
{
    public class User : BaseEntity
    {
        public string FirstName{get; set;}
        public string LastName{get;set;}
        public int Age{get; set;}
        public string Email{get; set;}
        public string PhoneNumber{get; set;}
        public Gender Gender{set; get;}
        public string Role{set; get;}
        public string Password{set; get;}

    }
}