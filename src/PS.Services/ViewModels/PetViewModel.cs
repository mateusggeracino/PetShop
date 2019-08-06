using System;
using System.ComponentModel;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace PS.Services.ViewModels
{
    public sealed class PetViewModel
    {
        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [JsonIgnore]
        public DateTime Registration { get; set; }
        public bool Alive { get; set; }

        [JsonIgnore]
        public ValidationResult ValidationResult { get; set; }
    }
}