using System;
using System.ComponentModel.DataAnnotations;

namespace apiadoptadino.Models
{
    public class Adoption
    {
        public int Id { get; set; }

        public int DinosaurId { get; set; }
        public Dinosaur Dinosaur { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}