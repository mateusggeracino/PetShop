using FluentValidation.Results;

namespace PS.Domain.Models
{
    public abstract class Entity
    {
       public int Id { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}