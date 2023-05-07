using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMADapper.Model.entities
{
    public class Comment : BaseEntity
    {
        public int TutorId{get; set;}
        public int TuteeId{get; set;}
        public string Comments{get; set;}
    }
}