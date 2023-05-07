using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMADapper.Model.entities
{
    public class BaseEntity
    {
        public  int Id{get; set;}
        public bool IsDeleted{get; set;} = false;
        public string DateCreated {get; set;} = DateTime.Now.ToString("yyyyy'-'MM'-'dd'T'HH':'mm':'ss");
        public string DateModified {get; set;} = DateTime.Now.ToString("yyyyy'-'MM'-'dd'T'HH':'mm':'ss");
        
    }
}