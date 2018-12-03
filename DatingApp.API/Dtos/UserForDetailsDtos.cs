using System;
using System.Collections.Generic;
using DatingApp.API.Models;

namespace DatingApp.API.Dtos
{
    public class UserForDetailsDtos
    {
         public int Id { get; set; }
        public string UserName { get; set; }


        public string Gender { get; set; }
        public int Age { get; set; }
        public string knownAs { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }

        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string city { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<PhotoForDetailDtos> Photos { get; set; }

    }
}