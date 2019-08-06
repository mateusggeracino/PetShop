using System;

namespace PS.Domain.Models
{
    public class Pet : Entity
    {
        public string Name { get; set; } 
        public DateTime Registration { get; set; }
        public bool Alive { get; set; }
    }
}