using System;
using FluentValidation.Results;

namespace PS.Services.ViewModels
{
    public class PetViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Registration { get; set; }
        public bool Alive { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}