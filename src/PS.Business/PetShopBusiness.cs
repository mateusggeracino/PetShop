using System.Collections.Generic;
using System.Linq;
using PS.Business.Interfaces;
using PS.Domain.Models;
using PS.Domain.Validations;
using PS.Repository.Interfaces;

namespace PS.Business
{
    public class PetShopBusiness : IPetShopBusiness
    {
        private readonly IPetShopRepository _petShopRepository;

        public PetShopBusiness(IPetShopRepository petShopRepository)
        {
            _petShopRepository = petShopRepository;
        }

        public Pet Insert(Pet pet)
        {
            var petValidator = new PetValidator();
            pet.ValidationResult = petValidator.Validate(pet);
            if (pet.ValidationResult.Errors.Any()) return pet;

            return _petShopRepository.Insert(pet);
        }

        public bool Remove(int id)
        {
            return _petShopRepository.Remove(id);
        }

        public Pet Update(Pet pet)
        {
            return _petShopRepository.Update(pet);
        }

        public Pet Read(int id)
        {
            return _petShopRepository.Read(id);
        }

        public IEnumerable<Pet> GetAll()
        {
            return _petShopRepository.GetAll();
        }
    }
}