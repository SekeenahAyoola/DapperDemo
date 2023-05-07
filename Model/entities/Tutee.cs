using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMADapper.Model.enums;

namespace TMADapper.Model.entities
{
    public class Tutee 
    {
        public int UserId{get; set;}
        public  Level TuteeLevel {get; set;}
        
    }
}