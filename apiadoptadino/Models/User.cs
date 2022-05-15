using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace apiadoptadino.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string HasDino { get; set; }

        //public List<Adoption> Adoptions { get; set; }
    }
}