using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace apiadoptadino.Models
{
    public class TypeDino
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string Feeding { get; set; }

        public List<Dinosaur> Dinosaur { get; set; }
    }
}