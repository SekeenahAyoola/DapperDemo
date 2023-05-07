using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMADapper.Model.enums;

namespace TMADapper.Model.entities
{
    public class Rating : BaseEntity
    {
        public int TuteeId {get; set;}
        public int TutorId {get; set;}
        public Rate Rate {get; set;}
    }
}