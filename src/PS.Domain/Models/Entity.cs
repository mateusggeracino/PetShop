using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation.Results;

namespace PS.Domain.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
        [NotMapped]
        public ValidationResult ValidationResult { get; set; }
    }
}