using System;
using System.ComponentModel.DataAnnotations;

namespace apiadoptadino.Models
{
    public class Dinosaur
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adopted { get; set; }
        public string Photo { get; set; }
        public string Weight { get; set; }

        public int TypeDinoId { get; set; }
        //public TypeDino TypeDino { get; set; }
    }
}